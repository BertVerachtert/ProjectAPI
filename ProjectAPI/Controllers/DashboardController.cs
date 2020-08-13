using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models;
using ProjectAPI.ViewModels;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly DataContext _context;

        public DashboardController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DashboardViewModel>> GetDashboard(long id)
        {
            DashboardViewModel d = new DashboardViewModel();
            List<Lijst> beheerderLijsten = new List<Lijst>();
            List<Stem> uStemmen = new List<Stem>();

            List<Lijst> lijsten = await _context.Lijsts
                .ToListAsync();

            foreach (var item in lijsten)
            {
                if (item.GebruikerID == id)
                {
                    beheerderLijsten.Add(item);
                }  
            }

            List<Stem> stemmen = await _context.Stems
                .Include(s => s.Gebruiker)
                .ToListAsync();

            foreach (var item in stemmen)
            {
                if (item.GebruikerID == id)
                {
                    uStemmen.Add(item);
                }
            }

            d.BeheerderLijsten = beheerderLijsten;
            d.UitStemmen = uStemmen;

            return d;
        }
    }
}