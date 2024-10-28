import React from 'react';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import BooksList from './BooksList';
import Navbar from './Navbar';
import Reservations from './Reservations';
import ReservationSystem from './ReservationSystem';

export default function App() {
    return (
        <div className="App">
            <h1 className=" txt title main-title">Welcome to the library!</h1>
            <Router>
                <hr />
                <Navbar />
                <hr />
                <Routes>
                    <Route exact path="/" element={<BooksList />} />
                    <Route path="/reservations" element={<Reservations />} />
                    <Route path="/reservation/:id" element={<ReservationSystem />} />
                </Routes>
            </Router>
        </div>
    );
}
