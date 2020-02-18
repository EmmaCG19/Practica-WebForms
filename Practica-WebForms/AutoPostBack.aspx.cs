using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practica_WebForms.DAL;

namespace Practica_WebForms
{
    public partial class AutoPostBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //Cargar autores en la CheckBoxList
                ChckBoxListAutores.DataSource = this.CargarListaAutores().Select(a => a.Nombre);
                ChckBoxListAutores.DataBind();
                ChckBoxListAutores.AutoPostBack = true;
            }
            else
            {
                //No se que poner aca

            }
        }

        protected List<Autor> CargarListaAutores()
        {
            List<Autor> autores = new List<Autor>()
            {
                new Autor(){Nombre="Sabato", Libros = new List<Libro>(){ new Libro() {Titulo="La historia sin fin", CantPaginas= 500 } }  },
                new Autor(){Nombre="Neruda", Libros = new List<Libro>(){ new Libro() {Titulo="Poemas a la medianoche", CantPaginas= 150 } }  },
                new Autor(){Nombre="El Rubius", Libros = new List<Libro>(){ new Libro() {Titulo="Mirenme, soy youtuber!", CantPaginas= 300 } }}
            };

            return autores;

        }

        protected void ChckBoxListAutores_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtBoxSeleccionados.Text = this.MostrarAutoresSeleccionados();

        }

        protected string MostrarAutoresSeleccionados()
        {
            string listaAutores = "";

            for (int i = 0; i < ChckBoxListAutores.Items.Count; i++)
            {
                if (ChckBoxListAutores.Items[i].Selected)
                {
                    listaAutores += ChckBoxListAutores.Items[i].Value + "\n";

                }
            }

            return listaAutores;
        }
    }
}