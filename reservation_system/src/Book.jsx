import React from 'react';
import { useNavigate } from 'react-router-dom';

export function Book({id, title, author, year, image}){
    const navigate = useNavigate();

    const handleReserveClick = () => {
        navigate(`/reservation/${id}`);
    };

    const newDate = new Date(year).getFullYear();

    return(
        <div className='book-container'>
            <img src={image}/>
            <div className='book-info-container'>
                <p className='txt book-title'>{title}</p>
                <p className='txt book-year'>{newDate}</p>
            </div>
            <button className="btn btn-reserve" onClick={handleReserveClick}>Reserve</button>
        </div>
    );
}