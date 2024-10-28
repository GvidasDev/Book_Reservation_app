import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Book } from './Book';
import Filters from './Filters';

export default function BooksList() {
    const [books, setBooks] = useState([]);
    const [filteredBooks, setFilteredBooks] = useState([]);
    const [titleFilter, setTitleFilter] = useState("");
    const [yearFilter, setYearFilter] = useState("");
    const [typeFilter, setTypeFilter] = useState("all");

    useEffect(() => {
        axios.get("/api/books")
            .then(response => {
                setBooks(response.data);
                setFilteredBooks(response.data);
            })
            .catch(error => {
                console.error("Error:", error);
            });
    }, []);

    const handleFilter = () => {
        let filtered = books;

        if (titleFilter) {
            filtered = filtered.filter(book =>
                book.title.toLowerCase().replace(/\s+/g, '').includes(titleFilter.toLowerCase().replace(/\s+/g, ''))
            );
        }

        if (yearFilter) {
            filtered = filtered.filter(book => book.year.startsWith(yearFilter));
        }

        if (typeFilter !== "all") {
            filtered = filtered.filter(book =>
                typeFilter === "audiobook" ? book.isAudioBook : !book.isAudioBook
            );
        }

        setFilteredBooks(filtered);
    };

    const handleClearFilters = () => {
        setTitleFilter("");
        setYearFilter("");
        setTypeFilter("all");
        setFilteredBooks(books);
    };

    if (!filteredBooks) {
        return <p className='txt'>Loading...</p>;
    }

    return (
        <div className="filters-container">
            <h1 className="txt title">Books List</h1>
            <Filters 
                titleFilter={titleFilter}
                setTitleFilter={setTitleFilter}
                yearFilter={yearFilter}
                setYearFilter={setYearFilter}
                typeFilter={typeFilter}
                setTypeFilter={setTypeFilter}
                handleFilter={handleFilter}
                handleClearFilters={handleClearFilters}
            />
            <div className='books-container'>
                {filteredBooks.map(book => (
                    <Book
                        {...book} 
                        key={book.id}
                        id={book.id}
                        title={book.title}
                        author={book.author}
                        year={book.year}
                        image={book.image}
                    />
                ))}
            </div>
        </div>
    );
}
