using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ApiPeliculas.Models
{
    public partial class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public double Puntuacion { get; set; }
        public string Rating { get; set; }
        public int Anio { get; set; }
    }
}
