using System;
using System.Web.UI;
using BLL;
using Entidades;

namespace ProyectoFinal.UI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private RepositorioBase<Actores> BLL = new RepositorioBase<Actores>();

        protected void Page_Load(object sender, EventArgs e)
        { }

        private Actores LlenarClase()
        {
            var Entidad = new Actores();

            if (IdTextBox.Text == string.Empty)
                Entidad.ActorId = 0;
            else
                Entidad.ActorId = Convert.ToInt32(IdTextBox.Text);

            Entidad.Nombre = NombreTextBox.Text;
            Entidad.FechaDebut = Convert.ToDateTime(FechaTextBox.Text);

            return Entidad;
        }

        private void LlenarCampos(Actores Entidad)
        {
            IdTextBox.Text = Entidad.ActorId.ToString();
            NombreTextBox.Text = Entidad.Nombre;
            FechaTextBox.Text = Entidad.FechaDebut.ToString("yyyy-MM-dd");
        }

        void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            FechaTextBox.Text = string.Empty;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            Actores Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                LlenarCampos(Buscar);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Actor no encontrado.');", addScriptTags: true);
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                {
                    BLL.Guardar(LlenarClase());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Actor Guardado.');", addScriptTags: true);
                }
                else
                {
                    if (int.Parse(IdTextBox.Text) > 0)
                    {
                        Actores Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));
                        if (Buscar == null)
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('El ID debe ser 0 para guardar.');", addScriptTags: true);
                        else
                        {
                            BLL.Modificar(LlenarClase());
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Actor Modificado.');", addScriptTags: true);
                        }
                    }
                }
                Limpiar();
            }
        }

        protected void EliminarButton_Click1(object sender, EventArgs e)
        {
            Actores Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                BLL.Eliminar(int.Parse(IdTextBox.Text));
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Actor no eliminado.');", addScriptTags: true);
            Limpiar();
        }

        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}