using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practica_WebForms.DAL;

namespace Practica_WebForms
{
    public partial class WebFormSort : System.Web.UI.Page
    {
        LiteraturaDBEntities context = new LiteraturaDBEntities();


        //Obtener los nombres de los campos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                DropDownCampos.DataSource = this.ObtenerFiltros().Keys;
                DropDownCampos.DataBind();
                this.CargarAutores();
            }
        }

        protected void CargarAutores()
        {
            GWAutores.DataSource = context.Escritores.ToList();
            GWAutores.DataBind();
        }

        protected void CargarAutores(List<Escritor> escritores)
        {
            GWAutores.DataSource = escritores.ToList();
            GWAutores.DataBind();
        }

        //protected void Pre_Render(object sender, EventArgs e)
        //{
        //    //El ordenamiento se va a dar por el AutoPostBack del DropDownList
        //}

        protected Dictionary<string, Func<Escritor, Object>> ObtenerFiltros()
        {
            Dictionary<string, Func<Escritor, Object>> filtros = new Dictionary<string, Func<Escritor, Object>>();
            filtros.Add("Id", e => e.Id);
            filtros.Add("Nombre", e => e.Nombre);
            filtros.Add("Libro", e => e.Libro);

            return filtros;
        }

        protected void DropDownCampos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<string, Func<Escritor, Object>> filtros = this.ObtenerFiltros();
            string campo = DropDownCampos.SelectedValue;
            Func<Escritor, Object> filtroSeleccionado = filtros[campo];

            this.CargarAutores(this.OrdenarListaPor(filtroSeleccionado));
            
        }

        protected List<Escritor> OrdenarListaPor(Func<Escritor, Object> filtro)
        {
            List<Escritor> escritoresOrdenados = context.Escritores.OrderBy(filtro).ToList();

            return escritoresOrdenados;
        }
    }
}