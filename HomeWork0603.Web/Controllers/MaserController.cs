using HomeWork0603.Data;
using HomeWork0603.Web.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeWork0603.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaserController : ControllerBase
    {
        private readonly string _connectionString;

        public MaserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        [HttpGet("GetOverview")]
        public Overview GetOverview()
        {
            var repo = new MaserRepository(_connectionString);
            return repo.GetOverview();
        }

        [HttpGet("GetStringSources")]
        public List<string> GetStringSources()
        {
            var repo = new MaserRepository(_connectionString);
            return repo.GetStringSources();
        }

        [HttpGet("GetSources")]
        public List<Source> GetSources()
        {
            var repo = new MaserRepository(_connectionString);
            return repo.GetSources();
        }



        [HttpGet("GetIncomes")]
        public List<Income> GetIncomes()
        {
            var repo = new MaserRepository(_connectionString);
            return repo.GetIncome();
        }

        [HttpGet("GetIncomesBySource")]
        public List<GroupedIncomes> GetIncomesBySource()
        {
            var repo = new MaserRepository(_connectionString);
            return repo.GetGroupIncome();
        }

        [HttpGet("GetPayments")]
        public List<Payment> GetPayments()
        {
            var repo = new MaserRepository(_connectionString);
            return repo.GetPayments();
        }

        [HttpPost("AddIncome")]
        public void AddIncome(IncomeViewMModel vm)
        {
            Income income = new()
            {
                SourceId = vm.SourceId,
                Amount = vm.Amount,
                Date = DateTime.Parse(vm.Date)
            };
            var repo = new MaserRepository(_connectionString);
            repo.AddIncome(income);
        }

        [HttpPost("AddPayment")]
        public void AddPayment(PaymentViewModel vm)
        {
            Payment payment = new()
            {
                Recipient = vm.Recipient,
                Amount = vm.Amount,
                Date = DateTime.Parse(vm.Date)
            };
            var repo = new MaserRepository(_connectionString);
            repo.AddPayment(payment);
        }

        [HttpPost("AddSource")]
        public void AddSource(string source)
        {
            var repo = new MaserRepository(_connectionString);
            repo.AddSource(source);
        }

        [HttpPost("DeleteSource")]
        public void DeleteSource(string source)
        {
            var repo = new MaserRepository(_connectionString);
            repo.DeleteSource(source);
        }

        [HttpPost("UpdateSource")]
        public void UpdateSource(EditSourceViewModel vm)
        {
            var repo = new MaserRepository(_connectionString);
            repo.UpdateSource(vm.EditingSource, vm.SelectedSource);
        }

        //[HttpPost("SetNote")]
        //public void SetNote(UpdateNoteViewModel viewModel)
        //{
        //    var user = GetCurrentUser();
        //    var bookRepo = new FavoriteBooksRepository(_connectionString);
        //    if (!bookRepo.DoesBookBelongToUser(user.Id, viewModel.FavoriteBookId))
        //    {
        //        return;
        //    }

        //    bookRepo.SetNote(viewModel.FavoriteBookId, viewModel.Note);
        //}
    }
}
