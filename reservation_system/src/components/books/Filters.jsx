import React from 'react';

export default function Filters({ titleFilter, setTitleFilter, yearFilter, setYearFilter, typeFilter, setTypeFilter, handleFilter, handleClearFilters }) {
    return (
        <form className='filters'>
            <input 
                className='filter filter-input'
                type="text" 
                placeholder="Filter by title" 
                value={titleFilter}
                onChange={(e) => setTitleFilter(e.target.value)} 
            />
            <input 
                className='filter filter-input'
                type="number" 
                placeholder="Filter by year" 
                value={yearFilter}
                onChange={(e) => setYearFilter(e.target.value)} 
            />
            <select className='filter filter-select' value={typeFilter} onChange={(e) => setTypeFilter(e.target.value)}>
                <option value="all">All</option>
                <option value="audiobook">Audio Book</option>
                <option value="book">Regular Book</option>
            </select>

            <button className='btn btn-filter' type="button" onClick={handleFilter}>Filter</button>
            <button className='btn btn-clear-filters' type="button" onClick={handleClearFilters}>Clear Filters</button>
        </form>
    );
}
