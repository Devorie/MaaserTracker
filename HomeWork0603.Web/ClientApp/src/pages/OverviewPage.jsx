import React, { useState, useEffect } from 'react';
import { Container, Typography, Box, Paper } from '@mui/material';
import axios from 'axios';

const OverviewPage = () => {
    useEffect(() => {
        const loadOverview = async () => {
            const { data } = await axios.get('/api/maser/GetOverview');
            setTotalIncome(data.totalIncome);
            setTotalMaaser(data.totalMasser);
        }
        loadOverview();
    }, []);

    const [totalIncome, setTotalIncome] = useState('');
    const [totalMaaser, setTotalMaaser] = useState('');

  return (
    <Container
      maxWidth="md"
      sx={{
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        height: '80vh',
        textAlign: 'center'
      }}
    >
      <Paper elevation={3} sx={{ padding: '120px', borderRadius: '15px' }}>
        <Typography variant="h2" gutterBottom>
          Overview
        </Typography>
        <Box sx={{ marginBottom: '20px' }}>
          <Typography variant="h5" gutterBottom>
                      Total Income: ${totalIncome}
          </Typography>
          <Typography variant="h5" gutterBottom>
                      Total Maaser: ${totalMaaser}
          </Typography>
        </Box>
        <Box>
          <Typography variant="h5" gutterBottom>
                      Maaser Obligated: ${(totalIncome/10).toFixed(0)}
          </Typography>
          <Typography variant="h5" gutterBottom>
                      Remaining Maaser obligation: ${((totalIncome / 10) - totalMaaser).toFixed(0)}
          </Typography>
        </Box>
      </Paper>
    </Container>
  );
}

export default OverviewPage;
