using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica_WebForms.DAL
{
    public class Autor
    {
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }

    }
}