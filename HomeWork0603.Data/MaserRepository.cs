using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork0603.Data
{
    public class MaserRepository
    {
        private readonly string _connectionString;

        public MaserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Income> GetIncome()
        {
            using var context = new MaserDataContext(_connectionString);
            return context.Incomes.Include(s => s.Source).ToList();
        }

        public List<GroupedIncomes> GetGroupIncome()
        {
            List<GroupedIncomes> gi = new();
            using var context = new MaserDataContext(_connectionString);
            var incomes = context.Incomes.Include(s => s.Source).ToList();
            var sources = context.Sources.ToList();
            foreach (Source s in sources)
            {
                gi.Add(new()
                {
                    Source = s,
                    Incomes = incomes.Where(i => i.SourceId == s.Id).ToList()

                });
            }
            return gi;
        }

        public List<Payment> GetPayments()
        {
            using var context = new MaserDataContext(_connectionString);
            return context.Payments.ToList();
        }

        public List<string> GetStringSources()
        {
            using var context = new MaserDataContext(_connectionString);
            return context.Sources.Select(s => s.Name).ToList();
        }

        public List<Source> GetSources()
        {
            using var context = new MaserDataContext(_connectionString);
            return context.Sources.ToList();
        }

        public void AddIncome(Income income)
        {
            using var context = new MaserDataContext(_connectionString);
            context.Incomes.Add(income);
            context.SaveChanges();
        }

        public void AddPayment(Payment payment)
        {
            using var context = new MaserDataContext(_connectionString);
            context.Payments.Add(payment);
            context.SaveChanges();
        }

        public void AddSource(string source)
        {
            Source s = new() { Name = source };
            using var context = new MaserDataContext(_connectionString);
            context.Sources.Add(s);
            context.SaveChanges();
        }

        public void UpdateSource(string source, string edited)
        {
            using var context = new MaserDataContext(_connectionString);
            context.Database.ExecuteSqlInterpolated(
               $"UPDATE Sources SET Name = {edited} WHERE Name = {source}");
        }

        public void DeleteSource(string source)
        {
            using var context = new MaserDataContext(_connectionString);
            Source selected = context.Sources.FirstOrDefault(s => s.Name == source);
            int count = context.Incomes.Where(i => i.SourceId == selected.Id).Count();
            if (count > 0)
            {
                context.Database.ExecuteSqlInterpolated($"DELETE FROM Incomes WHERE SourceId = {selected.Id} DELETE FROM Sources WHERE Id = {selected.Id}");
            }
            else
            {
                context.Database.ExecuteSqlInterpolated($"DELETE FROM Sources WHERE Id = {selected.Id}");
            }
        }

        public Overview GetOverview()
        {
            using var context = new MaserDataContext(_connectionString);
            return new()
            {
                TotalIncome = context.Incomes.Select(i => i.Amount).Sum(),
                TotalMasser = context.Payments.Select(p => p.Amount).Sum()
            };
        }
    }
}
