import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { Container, TextField, Button, Autocomplete, Typography } from '@mui/material';
import dayjs from 'dayjs';
import axios from 'axios';

const AddIncomePage = () => {
    const navigate = useNavigate();

    useEffect(() => {
        const loadSources = async () => {
            const { data } = await axios.get('/api/maser/GetSources');
            setSources(data);
        }
        loadSources();
    }, []);

    const [sources, setSources] = useState([]);
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [selectedSource, setSelectedSource] = useState(new Option());
    const [amount, setAmount] = useState('');

    const onAddClick = async() => {
        await axios.post(`/api/maser/AddIncome`, { sourceId: selectedSource.id, amount, date: selectedDate });
        navigate('/');
    }


    return (
        <Container maxWidth="sm" sx={{ display: 'flex', flexDirection: 'column', justifyContent: 'center', height: '80vh' }}>
            <Typography variant="h2" component="h1" gutterBottom>
                Add Income
            </Typography>
            <Autocomplete
                options={sources}
                getOptionLabel={(option) => option.name}
                fullWidth
                margin="normal"
                renderInput={(params) => <TextField {...params} label="Source" variant="outlined" />}
                onChange={(e, value) => setSelectedSource(value)}
            />
            <TextField
                label="Amount"
                variant="outlined"
                type="number"
                InputProps={{ inputProps: { min: 0, step: 0.01 } }}
                fullWidth
                margin="normal"
                onChange={e => setAmount(e.target.value)}
                value={amount}
            />
             <TextField
                label="Date"
                type="date"
                value={dayjs(selectedDate).format("YYYY-MM-DD")}
                onChange={e => setSelectedDate(e.target.value)}
                renderInput={(params) => <TextField {...params} fullWidth margin="normal" variant="outlined" />}
            />
            <Button onClick={onAddClick} variant="contained" color="primary">Add Income</Button>
        </Container>
    );
}

export default AddIncomePage;
