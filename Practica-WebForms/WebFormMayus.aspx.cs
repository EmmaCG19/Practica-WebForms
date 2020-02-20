using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practica_WebForms.DAL;

namespace Practica_WebForms
{
    public partial class WebFormMayus : System.Web.UI.Page
    {
        EscuelaDBEntities context = new EscuelaDBEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.MostrarEstudiantes();

        }

        protected void MostrarEstudiantes()
        {
            GWEstudiantes.DataSource = context.Estudiantes.ToList();
            GWEstudiantes.DataBind();
        }

        protected void BtnConvertir_Click(object sender, EventArgs e)
        {
            this.ConvertirAMayus(); 

        }

        //Modificar a aquellos alumnos que tengan un DNI  == Cantidad Adeudada
        protected void ConvertirAMayus()
        {
            List<Estudiante> estudiantesMismoDNIDeuda = context.Estudiantes.Where(e => e.NroDocumento.Equals(e.CantidadAdeudada)).ToList();

            foreach (Estudiante est in estudiantesMismoDNIDeuda)
            {
                est.Sobrenombre = est.Sobrenombre.ToUpper();
                context.SaveChanges();
            }

        }
    }
}