using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practica_WebForms.Helpers;

namespace Practica_WebForms
{
    public partial class WebFormSPA : System.Web.UI.Page
    {
        private const string PASSWORD = "admin";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ShowLogin();
            }
        }

        protected void ShowLogin()
        {
            PanelLogin.Visible = true;
            PanelBase64.Visible = !PanelLogin.Visible;
        }

        protected void ShowBase64()
        {
            PanelBase64.Visible = true;
            PanelLogin.Visible = !PanelBase64.Visible;
        }


        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtBoxClave.Text.Equals(PASSWORD))
            {
                LblLoginValido.Text = "Bienvenido!";
                this.ShowBase64();
            }
            else
            {
                LblLoginValido.ForeColor = System.Drawing.Color.Red;
                LblLoginValido.Text = "La clave no es válida. Vuelva a intentarlo.";
            }
        }

        protected void BtnCodificar_Click(object sender, EventArgs e)
        {
            TxtBoxCodif.Text = Base64.Encode(TxtBoxSinCodif.Text); 

        }

        protected void LinkBtnCerrar_Click(object sender, EventArgs e)
        {
            this.CleanAll();
            this.ShowLogin();
        }

        private void CleanAll()
        {
            LblLoginValido.Text = TxtBoxClave.Text = TxtBoxCodif.Text = TxtBoxSinCodif.Text = String.Empty;
        }
    }
}