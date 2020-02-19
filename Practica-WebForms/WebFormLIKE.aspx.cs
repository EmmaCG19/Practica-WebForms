using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practica_WebForms.DAL;

namespace Practica_WebForms
{
    public partial class WebFormLIKE : System.Web.UI.Page
    {
        LiteraturaDBEntities context = new LiteraturaDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.CargarAutores();

            }
            else
            {
                //La GW va a cambiar dependiendo del texto que se ingrese al buscar
                LblError.Text = String.Empty;

            }
        }

        private void CargarAutores()
        {
            GWAutores.DataSource = context.Escritores.ToList();
            GWAutores.DataBind();

        }

        private void CargarAutores(List<Escritor> escritores)
        {
            GWAutores.DataSource = escritores;
            GWAutores.DataBind();

        }

        protected void LinkBtnBuscar_Click(object sender, EventArgs e)
        {
            List<Escritor> escritoresEncontrados = this.ObtenerLibrosPor(TxtBoxLibro.Text);

            this.CargarAutores(escritoresEncontrados);

            if (escritoresEncontrados.Count == 0)
            {
                LblError.ForeColor = System.Drawing.Color.Red;
                LblError.Text = "No se encontraron resultados coincidentes";
            }
            
        }

        protected List<Escritor> ObtenerLibrosPor(string patron)
        {
            patron = patron.Trim();
            List<Escritor> escritoresObtenidos = context.Escritores.Where(e => e.Libro.Contains(patron)).ToList();

            return escritoresObtenidos;
        }

        
    }
}