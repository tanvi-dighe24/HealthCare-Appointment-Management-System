using Microsoft.AspNetCore.Mvc;
using HealthCareApp.Models; // This links to your 1st file!
using System.Collections.Generic;
using System.Linq;

namespace HealthCareApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        // A temporary list to store our appointments while the app is running
        private static List<PatientModel> appointments = new List<PatientModel>();

        // 1. VIEW ALL: This shows every patient who has booked
        [HttpGet]
        public IActionResult GetAllAppointments()
        {
            return Ok(appointments);
        }

        // 2. BOOK NEW: This adds a new patient to our list
        [HttpPost]
        public IActionResult CreateNewBooking([FromBody] PatientModel newPatient)
        {
            if (newPatient == null)
            {
                return BadRequest("Data is empty.");
            }

            // Assign a simple ID and save
            newPatient.PatientId = appointments.Count + 1;
            appointments.Add(newPatient);

            return Ok("Appointment successfully booked for " + newPatient.Name);
        }

        // 3. CANCEL: This removes a patient using their ID number
        [HttpDelete("{id}")]
        public IActionResult CancelBooking(int id)
        {
            var patient = appointments.FirstOrDefault(p => p.PatientId == id);
            if (patient == null)
            {
                return NotFound("Patient ID not found.");
            }

            appointments.Remove(patient);
            return Ok("Appointment cancelled successfully.");
        }
    }
}