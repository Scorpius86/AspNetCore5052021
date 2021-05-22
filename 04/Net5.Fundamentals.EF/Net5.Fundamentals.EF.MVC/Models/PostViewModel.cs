using System;
using System.Collections.Generic;

namespace Net5.Fundamentals.EF.MVC.Models
{
    public class PostViewModel
    {
        public PostViewModel()
        {
        }

        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public string Contenido { get; set; }                
        public DateTime FechaCreacion { get; set; }        
        public DateTime FechaActualizacion { get; set; }

        public List<ComentarioViewModel> Comentarios { get; set; }
        public UsuarioViewModel UsuarioPropietario { get; set; }
        public UsuarioViewModel UsuarioCreacion { get; set; }
        public UsuarioViewModel UsuarioActualizacion { get; set; }
    }
}