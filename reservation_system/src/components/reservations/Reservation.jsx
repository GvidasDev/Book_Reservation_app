import React from 'react';

export function Reservation({reservation}){
    return(
        <div className='reservation-container'>
            <p className='txt res-text'> <strong> {reservation.id} Reservation :</strong></p>
            <div className='txt res-info'>
                <p><strong>Book title: </strong>{reservation.title}</p>
                <p><strong> Book type: </strong>{reservation.isAudioBook ? 'Audiobook' : 'Book'}</p>
                <p><strong> Is quick up: </strong>{reservation.isQuickPickUp ? 'Yes' : 'No'}</p>
                <p><strong> Book reservation time: </strong>{reservation.days} {reservation.days === 1 ? 'day' : 'days'}</p>
                <p><strong> Book return date: </strong>{new Date(reservation.reservationEnd).toLocaleDateString()}</p>
                <p><strong> Total reservation cost: </strong>{reservation.totalPrice} €</p>
            </div>
        </div>
    );
}