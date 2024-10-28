using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Book_Reservation_app.Data;
using Book_Reservation_app.Models;

namespace Book_Reservation_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ReservationsController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet("full")]
        public async Task<IActionResult> GetReservationswithBooks() {
            var reservations = await (from reservation in _context.Reservations
                                      join book in _context.Books on reservation.BookId equals book.Id
                                      select new ReservationWithBook{
                                          Id = reservation.Id,
                                          BookId = reservation.BookId,
                                          Days = reservation.Days,
                                          IsQuickPickUp = reservation.IsQuickPickUp,
                                          TotalPrice = reservation.TotalPrice,
                                          ReservationEnd = reservation.ReservationEnd,
                                          IsAudioBook = reservation.IsAudioBook,

                                          Title = book.Title
                                      })
                                      .ToListAsync();

            return new JsonResult(reservations);
        }


        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("create")]
        public async Task<ActionResult<Reservation>> CreateReservation([FromBody] ReservationC reservationc) {
            if (reservationc == null) {
                return BadRequest("error");
            }

            int days = 0;
            decimal totalPrice = 0;
            FeesCalculations.FeesSum(reservationc, ref days, ref totalPrice);

            Reservation reservation = new Reservation(reservationc.BookId, days, reservationc.IsQuickPickUp, reservationc.IsAudioBook, totalPrice, reservationc.ReservationEnd);

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
