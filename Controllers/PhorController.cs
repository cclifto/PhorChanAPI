using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhorChanAPI.Models;
using System.Linq;

namespace PhorChanAPI.Controllers
{
    [Route("api/[controller]")]
    public class PhorController : Controller
    {
        private readonly PhorContext _context;

        public PhorController(PhorContext context)
        {
            _context = context;

            if (_context.PhorItems.Count() == 0)
            {
                _context.PhorItems.Add(new PhorItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<PhorItem> GetAll()
        {
            return _context.PhorItems.ToList();
        }

        [HttpGet("{id}", Name = "GetPhor")]
        public IActionResult GetById(long id)
        {
            var item = _context.PhorItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        } 
    }
}