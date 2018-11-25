using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // POST /api/newrentals
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
        {
            //if (newRentalDto.MoviesIds.Count == 0)
            //    return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers.Single(c => c.Id == newRentalDto.CustomerId);
            //if (customer == null)
            //    return BadRequest("CustomerId is not valid.");

            var movies = _context.Movies.Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            //if (movies.Count != newRentalDto.MovieIds.Count)
            //    return BadRequest("One or more MovieIds are invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.UtcNow
                };
                _context.Rentals.Add(rental);
            }
                
            _context.SaveChanges();

            return Ok();
        }
    }
}
