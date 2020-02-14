using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practica_WebForms.DAL;

namespace Practica_WebForms
{
    public partial class WebFormContador : System.Web.UI.Page
    {
        //Property
        private const int CONTADOR_INICIAL = 100000;
        public static int ContadorInicial { get { return CONTADOR_INICIAL; } }

        //Entity Framework
        ContadorEntities Contadores = new ContadorEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {

                //Eliminar todos los registros y settear el contador en su valor CONTADOR_INICIAL
                this.EliminarTodo();
                LblContador.Text = ContadorInicial.ToString();

            }
            else
            {



            }
        }

        protected void EliminarTodo()
        {
            int longitud = Contadores.Numeros.ToList().Count;

            try
            {
                for (int i = 0; i < longitud; i++)
                {
                    Numero num = Contadores.Numeros.Find(Contadores.Numeros.ToList()[i].Id);
                    Contadores.Numeros.Remove(num);
                }

                Contadores.SaveChanges();
            }
            catch (Exception)
            {
                Console.WriteLine("No se pudieron eliminar los registros");

            }

        }
    }
}
