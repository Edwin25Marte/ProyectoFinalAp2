using System;
using System.Web.UI;
using BLL;
using Entidades;

namespace ProyectoFinal.UI
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private RepositorioBase<Clientes> BLL = new RepositorioBase<Clientes>();

        protected void Page_Load(object sender, EventArgs e)
        { }

        private Clientes LlenarClase()
        {
            var Entidad = new Clientes();

            if (IdTextBox.Text == string.Empty)
                Entidad.ClienteId = 0;
            else
                Entidad.ClienteId = Convert.ToInt32(IdTextBox.Text);

            Entidad.Nombre = NombreTextBox.Text;
            Entidad.Direccion = DireccionTextBox.Text;
            Entidad.FechaNacimiento = Convert.ToDateTime(FNacimientoTextBox.Text);
            Entidad.Telefono = TelefonoTextBox.Text;
            Entidad.Email = EmailTextBox.Text;

            return Entidad;
        }

        private void LlenarCampos(Clientes Entidad)
        {
            IdTextBox.Text = Entidad.ClienteId.ToString();
            NombreTextBox.Text = Entidad.Nombre;
            DireccionTextBox.Text = Entidad.Direccion;
            FNacimientoTextBox.Text = Entidad.FechaNacimiento.ToString();
            TelefonoTextBox.Text = Entidad.Telefono.ToString();
            EmailTextBox.Text = Entidad.Email.ToString();
        }

        void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FNacimientoTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
        }

        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Clientes Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                LlenarCampos(Buscar);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Cliente no encontrado.');", addScriptTags: true);
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                {
                    BLL.Guardar(LlenarClase());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Cliente Guardado.');", addScriptTags: true);
                }
                else
                {
                    if (int.Parse(IdTextBox.Text) > 0)
                    {
                        Clientes Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));
                        if (Buscar == null)
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('El ID debe ser 0 para guardar.');", addScriptTags: true);
                        else
                        {
                            BLL.Modificar(LlenarClase());
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Cliente Modificado.');", addScriptTags: true);
                        }
                    }
                }
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Clientes Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                BLL.Eliminar(int.Parse(IdTextBox.Text));
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Cliente no eliminado.');", addScriptTags: true);
            Limpiar();
        }
    }
}