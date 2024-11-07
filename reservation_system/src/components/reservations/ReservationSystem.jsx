import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import OptionsForm from '../forms/OptionsForm';

export default function ReservationSystem() {
    const { id } = useParams();
    const [book, setBook] = useState(null);
    const [isAudioBook, setAudioBook] = useState(false);
    const [isQuickPickUp, setQuickPickUp] = useState(false)

    const navigate = useNavigate();

    const today = new Date().toISOString().split("T")[0];
    const [reservationPeriod, setReservationPeriod] = useState(today);

    const handleAudioCheckBox = () => {
        setAudioBook((prev) => !prev);
        setQuickPickUp(false);
    };

    const handleQuickPickUpCheckBox = () => {
        setQuickPickUp((prev) => !prev);
    };

    const handleReservationPeriodChange = (event) => {
        setReservationPeriod(event.target.value);
    };

    useEffect(() => {
        axios.get(`/api/books/${id}`)
            .then(response => {
                setBook(response.data);
                setAudioBook(response.data.isAudioBook);
            })
            .catch(error => {
                console.error("Error:", error);
            });
    }, [id]);

    const handleSubmit = async (event) => {
        event.preventDefault();

        const reservationData = {
            BookId: id,
            IsAudioBook: isAudioBook,
            IsQuickPickUp: isQuickPickUp,
            ReservationEnd: reservationPeriod
        };

        try {
            const response = await axios.post('/api/reservations/create', reservationData);
            console.log("Yay", response.data);
            navigate(-1);
        } catch (error) {
            console.error("Error", error);
        }
    };

    if (!book) {
        return <p>Loading...</p>;
    }

    return (
        <div>
            <h2 className='txt'>Reserve Book</h2>
            <p className='txt'><strong>Title:</strong> {book.title}</p>
            <p className='txt'><strong>Author:</strong> {book.author}</p>

            <OptionsForm 
                isAudioBook={isAudioBook}
                isQuickPickUp={isQuickPickUp}
                reservationPeriod={reservationPeriod}
                handleAudioCheckBox={handleAudioCheckBox}
                handleQuickPickUpCheckBox={handleQuickPickUpCheckBox}
                handleReservationPeriodChange={handleReservationPeriodChange}
                handleSubmit={handleSubmit}/>
        </div>

    );
    
}
