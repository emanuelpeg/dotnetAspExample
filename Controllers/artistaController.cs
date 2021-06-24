using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace dotnetAspExample.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ArtistaController : ControllerBase
    {
        private readonly ApiDbContext apiDbContext;
        
        public ArtistaController(ApiDbContext apiDbContext) {
            this.apiDbContext = apiDbContext; 
        }

        [HttpGet]
        public List<Artista> Get()
        {
            return this.apiDbContext.Artistas
            .Include(a => a.Discos)
            .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Artista> GetById(long id)
        {
            var artistas = this.apiDbContext.Artistas.Where(a => a.Id == id).ToList();
            if (artistas.Count == 0)
            {
                return NotFound();
            }
            var artista = artistas[0];
            this.apiDbContext.Entry(artista)
                .Collection(b => b.Discos)
                .Load();
            return Ok(artista);
        }

        [HttpGet("{id}/discos")]
        public List<Disco> GetDiscosById(long id)
        {
            var discos = this.apiDbContext.Artistas.Where(a => a.Id == id).SelectMany(a => a.Discos).ToList();
            return discos;
        }

        [HttpPut]
        public ActionResult<Artista> Update(Artista artista) {
            var artistas = this.apiDbContext.Artistas.Where(a => a.Id == artista.Id).ToList();
            if (artistas.Count == 0)
            {
                return NotFound();
            }

            var artistaFromDB = artistas[0];
            
            artistaFromDB.Nombre = artista.Nombre;
            artistaFromDB.FechaNacimiento = artista.FechaNacimiento;

            this.apiDbContext.SaveChanges();

            return Ok(artistaFromDB);
        }

        [HttpPost]
        public ActionResult<Artista> Create(Artista artista)
        {
           
            this.apiDbContext.Artistas.Add(artista);
            this.apiDbContext.SaveChanges();

            return Ok(artista);
        }

         [HttpPost("{id}/disco")]
        public ActionResult<Artista> AddDisco(long id, Disco disco)
        {
           var artistas = this.apiDbContext.Artistas.Where(a => a.Id == id).ToList();
            if (artistas.Count == 0)
            {
                return NotFound();
            }

            var artistaFromDB = artistas[0];
            this.apiDbContext.Entry(artistaFromDB)
                .Collection(b => b.Discos)
                .Load();

            artistaFromDB.Discos.Add(disco);
            this.apiDbContext.Discos.Add(disco);
            this.apiDbContext.SaveChanges();
            
            return Ok(artistaFromDB);
        }

    }
}