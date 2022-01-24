using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPeliculas.Models;
using ApiPeliculas.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;


namespace filmsController.Controllers{

        [Route("api/[controller]")]
        [ApiController]
        public class filmsController : ControllerBase{

        private readonly PeliculaBDContext _context;

        public filmsController (PeliculaBDContext context){
            this._context = context;
        }

        [HttpGet]
        public async Task<IQueryable<Pelicula>> GetAll(){
            var query = await _context.Peliculas.AsQueryable<Pelicula>().AsNoTracking().ToListAsync();
            return query.AsQueryable();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Pelicula> GetById(int id)
        {            
            var query = await _context.Peliculas.FirstOrDefaultAsync(x => x.IdPelicula == id);
            return query;
        }

        [HttpPost]
        public async Task<int> Create([FromBody]Pelicula pelicula){
            
            var entity = pelicula;
            await _context.AddAsync(entity);
            var rows = await _context.SaveChangesAsync();

            if(rows<= 0){
                throw new Exception("No se pudo realizar el registro");
            }
            return entity.IdPelicula;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<bool> Update(int id, [FromBody]Pelicula pelicula)
        {
            if(id <= 0 || pelicula == null)
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");

            var entity = await GetById(id);

            entity.Titulo = pelicula.Titulo;
            entity.Director = pelicula.Director;
            entity.Genero = pelicula.Genero;
            entity.Puntuacion = pelicula.Puntuacion;
            entity.Rating = pelicula.Rating;
            entity.Anio = pelicula.Anio;

            _context.Update(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        [HttpDelete]
        public async Task<bool> DeleteAll(){
            var query = await _context.Peliculas.AsQueryable<Pelicula>().AsNoTracking().ToListAsync();

            foreach(var Pelicula in query){
                _context.Remove(Pelicula);  
            }
            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<bool> DeleteById(int id)
        {
            if(id <= 0 )
                throw new ArgumentException("Falta información para continuar con el proceso de modificación...");

            var entity = await GetById(id);

            _context.Remove(entity);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        [HttpGet]
        [Route("Anio/{anio:int}/Puntuacion/{puntuacion:double}")]
        public async Task<IQueryable<Pelicula>> GetByAnioGetByPuntuacion(int anio, double puntuacion){

            var query = _context.Peliculas.Where(x => x.Anio == anio);
            query = query.Where(x=> x.Puntuacion == puntuacion);
            return query.AsQueryable();
        }

    }
}