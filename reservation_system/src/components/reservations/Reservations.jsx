import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Reservation } from './Reservation';

export default function Reservations() {
    const [reservations, setReservation] = useState([]);

    useEffect(() => {
        axios.get("/api/reservations/full")
            .then(response => {
                setReservation(response.data);
            })
            .catch(error => {
                console.error("Error:", error);
            });
    }, []);

    if (!reservations) {
        return <p className='txt'>Loading...</p>;
    }

    return (
        <div className="items-container">
            <h1 className="txt title">Reservations</h1>
            <div>
                {reservations.map(reservation => {
                    return <Reservation reservation={reservation}/>
                })}
            </div>
        </div>
    );
}
