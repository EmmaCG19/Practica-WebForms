using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practica_WebForms.DAL;

namespace Practica_WebForms
{
    public partial class WebFormParcial : System.Web.UI.Page
    {
        CientificosDBEntities context = new CientificosDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.InicializarConSadoskyBalseiro();
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.ListarCientificos();
        }

        protected void ListarCientificos()
        {
            GWCientificos.DataSource = context.Cientificos.ToList();
            GWCientificos.DataBind();

        }

        
        protected void InicializarConSadoskyBalseiro()
        {
            List<Cientifico> cientificos = context.Cientificos.ToList();

            //Eliminar a todos los cientificos
            foreach (Cientifico c in cientificos)
            {
                this.EliminarPorId(c.Id);
            }


            //Cargar a Sadosky y Balseiro - Reseed?
            
            this.Agregar("Sadosky");
            this.Agregar("Balseiro");
            

        }



        protected void EliminarPorId(int id)
        {
            Cientifico c = context.Cientificos.Find(id);
            context.Cientificos.Remove(c);
            context.SaveChanges();
        }


        private void Agregar(string apellido)
        {
            Cientifico c = new Cientifico();
            c.Apellido = apellido;
            context.Cientificos.Add(c);
            context.SaveChanges();
        }

        protected void LinkBtnInicializar_Click(object sender, EventArgs e)
        {
            this.InicializarConSadoskyBalseiro();
        }
    }
}