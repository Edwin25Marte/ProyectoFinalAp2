using System;
using System.Web.UI;
using BLL;
using Entidades;

namespace ProyectoFinal.UI
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private RepositorioBase<Generos> BLL = new RepositorioBase<Generos>();

        protected void Page_Load(object sender, EventArgs e)
        { }

        private Generos LlenarClase()
        {
            var Entidad = new Generos();

            if (IdTextBox.Text == string.Empty)
                Entidad.GeneroId = 0;
            else
                Entidad.GeneroId = Convert.ToInt32(IdTextBox.Text);

            Entidad.Nombre = NombreTextBox.Text;
            Entidad.Descripcion = DescripcionTextBox.Text;

            return Entidad;
        }

        private void LlenarCampos(Generos Entidad)
        {
            IdTextBox.Text = Entidad.GeneroId.ToString();
            NombreTextBox.Text = Entidad.Nombre;
            DescripcionTextBox.Text = Entidad.Descripcion.ToString();
        }

        void Limpiar()
        {
            IdTextBox.Text = "0";
            NombreTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            Generos Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                LlenarCampos(Buscar);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Genero no econtrado.');", addScriptTags: true);
        }

        protected void EliminarButton_Click1(object sender, EventArgs e)
        {
            Generos Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                BLL.Eliminar(int.Parse(IdTextBox.Text));
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Genero no eliminado.');", addScriptTags: true);
            Limpiar();
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                {
                    BLL.Guardar(LlenarClase());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Genero Guardado.');", addScriptTags: true);
                }
                else
                {
                    if (int.Parse(IdTextBox.Text) > 0)
                    {
                        Generos Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));
                        if (Buscar == null)
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('El ID debe ser 0 para guardar.');", addScriptTags: true);
                        else
                        {
                            BLL.Modificar(LlenarClase());
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Genero Modificado.');", addScriptTags: true);
                        }
                    }
                }
                Limpiar();
            }
        }
    }
}