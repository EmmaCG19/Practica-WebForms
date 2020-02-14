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
        private const int VALOR_INICIAL = 100000;

        private static int _contador = 0;
        public static int Contador { get { return _contador; } set { _contador = value; } }

        //Entity Framework
        ContadorDBEntities Contadores = new ContadorDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                this.Inicializar();
               
            }
            else
            {
                //Por el momento, no se hace nada


            }
        }

        #region Eliminar

        #endregion
        protected void Inicializar()
        {
            //Eliminar todos los registros y settear el contador en su valor CONTADOR_INICIAL
            this.EliminarTodo();
            Contador = VALOR_INICIAL;
            LblContador.Text = Contador.ToString();

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

        protected void Insertar()
        {
            Numero numero = new Numero();
            numero.Valor = Contador;

            Contadores.Numeros.Add(numero);
            Contadores.SaveChanges();
                        
        }

        protected void BtnIncrementar_Click(object sender, EventArgs e)
        {
            this.Insertar();
            LblContador.Text = (++Contador).ToString();
            
        }
    }
}
