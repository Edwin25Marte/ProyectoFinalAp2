using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace ProyectoFinal.UI
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private RepositorioBase<Facturas> BLL = new RepositorioBase<Facturas>();
        private RepositorioBase<Clientes> cBLL = new RepositorioBase<Clientes>();
        private RepositorioBase<Peliculas> pBLL = new RepositorioBase<Peliculas>();
        private RepositorioFactura factBLL = new RepositorioFactura();

        private List<DetalleFacturas> Detalle = new List<DetalleFacturas>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FechaPrestamoTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                ViewState.Add("detalle", Detalle);
                ViewState.Add("Factura", new Facturas());
                Expression<Func<Clientes, bool>> fClientes = x => true;
                Expression<Func<Peliculas, bool>> fPeliculas = x => true;
                var itemCount = cBLL.GetList(fClientes).Count;

                if (itemCount > 0)
                {
                    foreach (var i in cBLL.GetList(fClientes))
                    {
                        ListItem l = new ListItem(i.Nombre, Convert.ToString(i.ClienteId), true);
                        ClientesDropDownList.Items.Add(l);
                    }
                    ClientesDropDownList.DataBind();
                }

                var itemCount2 = pBLL.GetList(fPeliculas).Count;

                if (itemCount2 > 0)
                {
                    foreach (var i in pBLL.GetList(fPeliculas))
                    {
                        ListItem l = new ListItem(i.Nombre, Convert.ToString(i.PeliculaId), true);
                        PeliculasDropDownList.Items.Add(l);
                    }
                    PeliculasDropDownList.DataBind();
                }
            }
            else
                Detalle = (List<DetalleFacturas>)ViewState["detalle"];
        }

        private Facturas LlenarClase()
        {
            var Entidad = new Facturas();

            if (IdTextBox.Text == string.Empty)
                Entidad.FacturaId = 0;
            else
                Entidad.FacturaId = Convert.ToInt32(IdTextBox.Text);

            Entidad.Fecha = DateTime.Now;
            Entidad.FechaPrestamo = DateTime.Now;
            Entidad.FechaDevolucion = Convert.ToDateTime(FechaDevolucionTextBox.Text);
            Entidad.ClienteId = int.Parse(ClientesDropDownList.SelectedItem.Value);
            Entidad.Monto = Convert.ToDecimal(MontoTextBox.Text);
            Entidad.Observaciones = ObservacionesTextBox.Text;
            Entidad.DetalleFactura = Detalle.ToList();

            return Entidad;
        }

        private void LlenarCampos(Facturas Entidad)
        {
            Facturas Buscar = BLL.Buscar(Entidad.ClienteId);

            IdTextBox.Text = Entidad.FacturaId.ToString();
            FechaTextBox.Text = string.Empty;
            FechaTextBox.Text = Entidad.Fecha.ToString("yyyy-MM-dd");
            FechaPrestamoTextBox.Text = string.Empty;
            FechaPrestamoTextBox.Text = Entidad.FechaPrestamo.ToString("yyyy-MM-dd");
            FechaDevolucionTextBox.Text = Entidad.FechaDevolucion.ToString("yyyy-MM-dd");
            MontoTextBox.Text = Entidad.Monto.ToString();
            //ClientesDropDownList.ClearSelection();
            //ClientesDropDownList.Items.FindByValue(cBLL.Buscar(Buscar.ClienteId).Nombre).Selected = true;
            ObservacionesTextBox.Text = Entidad.Observaciones.ToString();
            DetalleGridView.DataSource = Entidad.DetalleFactura.ToList();
            DetalleGridView.DataBind();
        }

        void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            FechaTextBox.Text = string.Empty;
            FechaPrestamoTextBox.Text = string.Empty;
            FechaDevolucionTextBox.Text = string.Empty;
            ClientesDropDownList.DataTextField = string.Empty;
            PeliculasDropDownList.DataTextField = string.Empty;
            MontoTextBox.Text = string.Empty;
            ObservacionesTextBox.Text = string.Empty;
            ClientesDropDownList.ClearSelection();
            ClientesDropDownList.Items.FindByValue("0").Selected = true;
            PeliculasDropDownList.ClearSelection();
            PeliculasDropDownList.Items.FindByValue("0").Selected = true;
            DetalleGridView.Visible = true;
            DetalleGridView.DataBind();
        }

        protected void RemoveButton_Click1(object sender, EventArgs e)
        {
            GridViewRow row = DetalleGridView.SelectedRow;
            int id = Convert.ToInt32(DetalleGridView.DataKeys[row.RowIndex].Value);
            RepositorioBase<DetalleFacturas> dfa = new RepositorioBase<DetalleFacturas>();
            dfa.Eliminar(id);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Fila Removida.');", addScriptTags: true);
        }

        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            Facturas Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                LlenarCampos(Buscar);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Factura no encontrada.');", addScriptTags: true);
        }

        protected void NuevoButton_Click1(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IdTextBox.Text) || IdTextBox.Text == "0")
            {
                if (int.Parse(PeliculasDropDownList.SelectedItem.Value) > 0)
                {
                    BLL.Guardar(LlenarClase());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Factura Guardada.');", addScriptTags: true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('Seleccione una pelicula valida.');", addScriptTags: true);
            }
            else
            {
                factBLL.Modificar(LlenarClase());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Factura Modificada.');", addScriptTags: true);
            }
            Limpiar();
        }

        protected void EliminarButton_Click1(object sender, EventArgs e)
        {
            Facturas Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                BLL.Eliminar(int.Parse(IdTextBox.Text));
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Factura no eliminada.');", addScriptTags: true);
            Limpiar();
        }

        protected void AddButton_Click1(object sender, EventArgs e)
        {
            var dt = new DetalleFacturas();

            dt.FactDetalleId = 0;

            if (IdTextBox.Text == string.Empty)
                dt.FacturaId = 0;
            else
                dt.FacturaId = Convert.ToInt32(IdTextBox.Text);

            dt.PeliculaId = int.Parse(PeliculasDropDownList.SelectedItem.Value);
            Peliculas buscar = pBLL.Buscar(int.Parse(PeliculasDropDownList.SelectedItem.Value));
            dt.Pelicula = pBLL.Buscar(int.Parse(PeliculasDropDownList.SelectedItem.Value));
            dt.NombrePelicula = buscar.Nombre;
            dt.Precio = buscar.Precio;
            dt.Cantidad = buscar.Cantidad;
          
            Detalle.Add(dt);
            ViewState["detalle"] = Detalle;
            DetalleGridView.DataSource = Detalle.ToList();
            DetalleGridView.DataBind();

        }

        protected void DetalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DetalleGridView.EditIndex = e.NewEditIndex;
            DetalleGridView.DataSource = (List<DetalleFacturas>)ViewState["detalle"];
            DetalleGridView.DataBind();
        }

        protected void DetalleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = DetalleGridView.Rows[e.RowIndex];
        }

        protected void DetalleGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int userid = Convert.ToInt32(DetalleGridView.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = DetalleGridView.Rows[e.RowIndex];
            Detalle = (List<DetalleFacturas>)ViewState["detalle"];
            TextBox Cant = row.Cells[1].Controls[0] as TextBox;
            Detalle[0].Cantidad = int.Parse(Cant.Text);

            ViewState["detalle"] = Detalle;
            ViewState["Factura"] = LlenarClase();
            DetalleGridView.DataSource = Detalle.ToList();
            DetalleGridView.DataBind();
        }

        protected void DetalleGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DetalleGridView.EditIndex = -1;
            DetalleGridView.DataSource = Detalle;
            DetalleGridView.DataBind();
        }
    }
}