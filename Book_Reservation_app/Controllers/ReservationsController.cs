using Microsoft.AspNetCore.Mvc;
using Book_Reservation_app.Models;
using Book_Reservation_app.Services;

namespace Book_Reservation_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase {
        private readonly ReservationService reservationService;

        public ReservationsController(ReservationService reservationService) {
            this.reservationService = reservationService;
        }

        [HttpGet("full")]
        public async Task<IActionResult> GetReservationsWithBooks() {
            var reservations = await reservationService.GetReservationsWithBooksAsync();
            return Ok(reservations);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations() {
            var reservations = await reservationService.GetReservationsAsync();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id) {
            var reservation = await reservationService.GetReservationByIdAsync(id);
            if (reservation == null) {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation) {
            var success = await reservationService.UpdateReservationAsync(id, reservation);
            if (!success) {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("create")]
        public async Task<ActionResult<Reservation>> CreateReservation([FromBody] ReservationCreateModel reservationc) {
            if (reservationc == null) {
                return BadRequest("Invalid reservation data.");
            }

            var reservation = await reservationService.CreateReservationAsync(reservationc);
            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(ReservationCreateModel reservation) {
            var createdReservation = await reservationService.CreateReservationAsync(reservation);
            return CreatedAtAction(nameof(GetReservation), new { id = createdReservation.Id }, createdReservation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id) {
            var success = await reservationService.DeleteReservationAsync(id);
            if (!success) {
                return NotFound();
            }
            return NoContent();
        }
    }
}
