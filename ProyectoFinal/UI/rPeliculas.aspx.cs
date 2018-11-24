using System;
using System.Web.UI;
using BLL;
using Entidades;

namespace ProyectoFinal.UI
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private RepositorioBase<Peliculas> BLL = new RepositorioBase<Peliculas>();

        protected void Page_Load(object sender, EventArgs e)
        { }

        private Peliculas LlenarClase()
        {
            var Entidad = new Peliculas();

            if (IdTextBox.Text == string.Empty)
                Entidad.PeliculaId = 0;
            else
                Entidad.PeliculaId = Convert.ToInt32(IdTextBox.Text);

            Entidad.Nombre = NombreTextBox.Text;
            Entidad.FechaSalida = Convert.ToDateTime(FechaTextBox.Text);
            Entidad.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            Entidad.Sipnosis = SinopsisTextBox.Text;

            return Entidad;
        }

        private void LlenarCampos(Peliculas Entidad)
        {
            IdTextBox.Text = Entidad.PeliculaId.ToString();
            NombreTextBox.Text = Entidad.Nombre;
            PrecioTextBox.Text = Entidad.Precio.ToString();
            SinopsisTextBox.Text = Entidad.Sipnosis.ToString();
        }

        void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            SinopsisTextBox.Text = string.Empty;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            Peliculas Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                LlenarCampos(Buscar);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Pelicula no econtrada.');", addScriptTags: true);
        }

        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
                {
                    BLL.Guardar(LlenarClase());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Pelicula Guardada.');", addScriptTags: true);
                }
                else
                {
                    if (int.Parse(IdTextBox.Text) > 0)
                    {
                        Peliculas Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));
                        if (Buscar == null)
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('El ID debe ser 0 para guardar.');", addScriptTags: true);
                        else
                        {
                            BLL.Modificar(LlenarClase());
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Pelicula Modificada.');", addScriptTags: true);
                        }
                    }
                }
                Limpiar();
            }
        }

        protected void EliminarButton_Click1(object sender, EventArgs e)
        {
            Peliculas Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                BLL.Eliminar(int.Parse(IdTextBox.Text));
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Pelicula no eliminada.');", addScriptTags: true);
            Limpiar();
        }
    }
}