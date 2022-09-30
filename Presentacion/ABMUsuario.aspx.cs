using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMUsuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string nombre = txtNombre.Text;
        
        try
        {
            Usuario usuario = LogicaUsuario.Buscar(nombre);
           
            if (usuario != null)
            {
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                
                Session["SUsuario"] = usuario;

                btnBaja.Enabled = true;
                BtnModificar.Enabled = true;
                btnAlta.Enabled = false;
            }
            else
            {
                btnAlta.Enabled = true;

                Session["SUsuario"] = null;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            Label1.Text = "Test";
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        string logId, nombre, apellido, contrasena;

        try
        {
            logId = txtUsuario.Text;
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            contrasena = txtContrasena.ToString(); //Hay que consumir los datos que se ingresan en el input

            Usuario usuario = new Usuario(logId, contrasena, nombre, apellido);

            LogicaUsuario.Agregar(usuario);
            lblError.Text = "Alta con Exito";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            throw;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {

    }

    protected void btnBaja_Click(object sender, EventArgs e)
    {

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtUsuario.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        txtContrasena.Value = "";
    }
}