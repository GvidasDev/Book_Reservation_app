import React from 'react';

export function Reservation({id, title, days, isPickUp, totalPrice, reservationEnd, bookType}){
    return(
        <div className='reservation-container'>
            <p className='txt res-text'> <strong> {id} Reservation :</strong></p>
            <div className='txt res-info'>
                <p><strong>Book title: </strong>{title}</p>
                <p><strong> Book type: </strong>{bookType}</p>
                <p><strong> Is quick up: </strong>{isPickUp}</p>
                <p><strong> Book reservation time: </strong>{days} {days === 1 ? 'day' : 'days'}</p>
                <p><strong> Book return date: </strong>{reservationEnd}</p>
                <p><strong> Total reservation cost: </strong>{totalPrice} €</p>
            </div>
        </div>
    );
}