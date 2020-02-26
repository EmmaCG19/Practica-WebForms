using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        private static bool _flag = false;
        public static bool BusquedaPorApellidoOn { get { return _flag; } set { _flag = value; } }

        /*************************************************************/

        protected void ListarCientificos(List<Cientifico> cientificos)
        {
            GWCientificos.DataSource = cientificos;
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
            this.Agregar(new Cientifico() { Apellido = "Sadosky" });
            this.Agregar(new Cientifico() { Apellido = "Balseiro" });

            //Cargar la ficha de Sadosky, osea, el primer cientifico cargado
            this.CargarFichaPorId(context.Cientificos.First().Id);

        }

        protected void EliminarPorId(int id)
        {
            Cientifico c = context.Cientificos.Find(id);
            context.Cientificos.Remove(c);
            context.SaveChanges();
        }

        protected void CargarFichaPorId(int id)
        {
            Cientifico c = this.BuscarPorId(id);

            if (c != null)
            {
                TxtBoxApellido.Text = c.Apellido;
                TxtBoxId.Text = c.Id.ToString();
            }
            else
                throw new Exception();
        }

        protected List<Cientifico> BuscarPorApellido(string apellido)
        {
            //Encontrar todos los cientificos que posean el mismo apellido. No Contains, sino Equals

            List<Cientifico> mismoApellido = context.Cientificos.Where(c => c.Apellido.Equals(apellido)).ToList();
            BusquedaPorApellidoOn = true;

            return mismoApellido;
        }

        protected void RenumerarPorId(List<Cientifico> cientificos)
        {
            //Modificar el Id de los cientificos sin alterar sus apellidos

            //1) Obtener los apellidos:
            List<string> listaApellidos = cientificos.Select(c => c.Apellido).ToList();

            //2) Eliminar todos los científicos que se encuentran cargados
            foreach (Cientifico c in cientificos)
            {
                this.EliminarPorId(c.Id);
            }

            //3) Realizar la reinserción de los científicos a la base de datos
            foreach (string apellido in listaApellidos)
            {
                Cientifico c = new Cientifico();
                c.Apellido = apellido;
                this.Agregar(c);
            }

        }


        protected void Depurar()
        {
            //1) Ordenar cientificos por apellido y por ID en segundo lugar

            List<Cientifico> cientificosOrdenados = context.Cientificos.OrderBy(c => c.Apellido).OrderBy(c => c.Id).ToList();


        }


        /*************************************************************/

        private void Guardar(Cientifico cientifico)
        {
            cientifico.Apellido = TxtBoxApellido.Text;
            context.SaveChanges();

        }

        private void Agregar(Cientifico cientifico)
        {
            context.Cientificos.Add(cientifico);
            context.SaveChanges();
        }

        private Cientifico BuscarPorId(int id)
        {
            return context.Cientificos.Find(id);

        }

        private void LimpiarCampos()
        {
            TxtBoxApellido.Text = TxtBoxId.Text = String.Empty;
        }

        /*************************************************************/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.InicializarConSadoskyBalseiro();
            }
            else
            {
                LblError.Text = String.Empty;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //Si está activado el flag de busqueda por apellido, va a mostrar la lista de coincidentes, sino todos los cientificos
            if (BusquedaPorApellidoOn)
            {
                BusquedaPorApellidoOn = false;
            }
            else
            {
                this.ListarCientificos(context.Cientificos.ToList());
            }
        }

        protected void LinkBtnInicializar_Click(object sender, EventArgs e)
        {
            this.InicializarConSadoskyBalseiro();
        }

        protected void LinkBtnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(TxtBoxId.Text);
                this.CargarFichaPorId(id);
            }
            catch (FormatException)
            {
                Console.Write("El id no tiene un formato correcto.");
            }
            catch (Exception error)
            {
                Console.Write(error.Message);
                //TxtBoxApellido.Text = "No existe el alumno con esa Id";

            }
        }

        protected void LinkBtnGuardar_Click(object sender, EventArgs e)
        {

            Cientifico c = new Cientifico();

            //Creo un cientifico a partir de los textbox

            //Si el TxtBoxId no esta vacio
            if (TxtBoxId.Text.Trim() != "")
            {
                c = this.BuscarPorId(Convert.ToInt32(TxtBoxId.Text));

                //Si el cientifico existe, que guarde los cambios
                if (c != null)
                {
                    this.Guardar(c);
                }
            }
            else
            {
                c.Apellido = TxtBoxApellido.Text;
                this.Agregar(c);
            }

            this.LimpiarCampos();
        }

        protected void LinkBtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.EliminarPorId(Convert.ToInt32(TxtBoxId.Text));
                this.LimpiarCampos();
            }
            catch (Exception)
            {
                //Lo mejor seria tener un Label que avise todo tipo de errores, desde problemas de persistencia por inexistencia o formato del input

            }


        }

        protected void LinkBtnBuscar_Click(object sender, EventArgs e)
        {
            List<Cientifico> cientificosMismoApellido = this.BuscarPorApellido(TxtBoxApellido.Text);

            if (cientificosMismoApellido.Count == 0)
                LblError.Text = "No hay cientificos coincidentes";

            this.ListarCientificos(cientificosMismoApellido);
        }

        protected void LinkBtnRenumerar_Click(object sender, EventArgs e)
        {
            this.RenumerarPorId(context.Cientificos.ToList());

        }

        protected void LinkBtnDepurar_Click(object sender, EventArgs e)
        {
            //Eliminar apellidos repetidos y quedarnos con el primero que se presente

            this.Depurar();


        }
    }
}