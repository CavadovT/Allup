using Allup.DAL;
using Allup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Allup.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _con;

        public SubscribeController(AppDbContext con)
        {
            _con = con;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Subscriber sub)
        {
            Subscriber subscriber = new Subscriber();
            if (!ModelState.IsValid)
            {
                return Ok("Email Don't Empty");
            }
            bool IsSubscribers = await _con.Subscribers.AnyAsync(s => s.Email.ToLower().Contains(sub.Email.ToLower()));

            if (IsSubscribers)
            {
                return Ok("this mail alredy exist");

            }
            subscriber.Email = sub.Email;
            await _con.Subscribers.AddAsync(subscriber);
            await _con.SaveChangesAsync();
            
            return RedirectToAction("index","Home");
        }
    }
}
