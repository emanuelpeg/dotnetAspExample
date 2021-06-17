using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            return this.apiDbContext.Artistas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Artista> GetById(long id)
        {
            var artistas = this.apiDbContext.Artistas.Where(a => a.id == id).ToList();
            if (artistas.Count == 0)
            {
                return NotFound();
            }
            var discos = artistas[0].discos;
            return artistas[0];
        }

        [HttpGet("{id}/discos")]
        public List<List<Disco>> GetDiscosById(long id)
        {
            var discos = this.apiDbContext.Artistas.Where(a => a.id == id).Select(a => a.discos).ToList();
            return discos;
        }

        [HttpPut]
        public ActionResult<Artista> Update(Artista artista) {
            var artistas = this.apiDbContext.Artistas.Where(a => a.id == artista.id).ToList();
            if (artistas.Count == 0)
            {
                return NotFound();
            }

            var artistaFromDB = artistas[0];
            artistaFromDB.nombre = artista.nombre;
            artistaFromDB.fechaNacimiento = artista.fechaNacimiento;

            this.apiDbContext.Add(artistaFromDB);
            this.apiDbContext.SaveChanges();

            return artistaFromDB;
        }

        [HttpPost]
        public ActionResult<Artista> Create(Artista artista)
        {
           
            this.apiDbContext.Artistas.Add(artista);
            this.apiDbContext.SaveChanges();

            return artista;
        }

    }
}