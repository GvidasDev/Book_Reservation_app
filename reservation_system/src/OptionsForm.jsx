import React from 'react';

export default function OptionsForm({isAudioBook, isQuickPickUp, reservationPeriod, handleAudioCheckBox, handleQuickPickUpCheckBox, handleReservationPeriodChange, handleSubmit}) {
    const today = new Date().toISOString().split("T")[0];

    return (
        <form className="form" onSubmit={handleSubmit}>
            <p className='txt input-options'>
                Audio Book
                <input 
                    className='checkbox-input' 
                    type="checkbox" 
                    checked={isAudioBook} 
                    onChange={handleAudioCheckBox} />
            </p>

            <p className='txt input-options'>
                Quick pick up
                <input className='checkbox-input' 
                    type="checkbox" 
                    checked={isQuickPickUp} 
                    onChange={handleQuickPickUpCheckBox} 
                    disabled={isAudioBook} />
            </p>

            <p className='txt input-options'>
                Reservation period 
                <input 
                    className='date-input' 
                    type="date" 
                    value={reservationPeriod} 
                    onChange={handleReservationPeriodChange} 
                    min={today} />
            </p>

            <button className="btn btn-submit" type="submit">Submit</button>
        </form>
    );
}
