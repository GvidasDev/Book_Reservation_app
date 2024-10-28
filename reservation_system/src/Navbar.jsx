import React from 'react';
import { Link } from 'react-router-dom';

const Navbar = () => {
    return (
        <nav className='navbar'>
            <Link className='txt txt-link' to="/">Library</Link>
            <Link className='txt txt-link' to="/reservations">Reservations</Link>
        </nav>
    );
}

export default Navbar;
