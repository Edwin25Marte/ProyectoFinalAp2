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
        decimal Mont = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            Entidad.FechaDevolucion = Convert.ToDateTime(FechaDevolucionTextBox.Text);
            Entidad.ClienteId = int.Parse(ClientesDropDownList.SelectedItem.Value);
            Entidad.Monto = Convert.ToDecimal(MontoTextBox.Text);
            Entidad.Observaciones = ObservacionesTextBox.Text;
            Entidad.DetalleFactura = Detalle.ToList();
            Mont = 0;

            return Entidad;
        }

        private void LlenarCampos(Facturas Entidad)
        {
            Facturas Buscar = BLL.Buscar(Entidad.ClienteId);

            IdTextBox.Text = Entidad.FacturaId.ToString();
            FechaTextBox.Text = Entidad.Fecha.ToString("yyyy-MM-dd");
            FechaDevolucionTextBox.Text = Entidad.FechaDevolucion.ToString("yyyy-MM-dd");
            MontoTextBox.Text = Entidad.Monto.ToString();
            ClientesDropDownList.ClearSelection();
            ClientesDropDownList.Items.FindByValue(cBLL.Buscar(Buscar.ClienteId).ClienteId.ToString()).Selected = true;
            ObservacionesTextBox.Text = Entidad.Observaciones.ToString();
            ViewState["detalle"] = Entidad.DetalleFactura;
            DetalleGridView.DataSource = Entidad.DetalleFactura.ToList();
            DetalleGridView.DataBind();
            Mont = 0;
        }

        void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            FechaTextBox.Text = string.Empty;
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
            Mont = 0;
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
                    factBLL.Guardar(LlenarClase());
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
            if(int.Parse(CantidadTextBox.Text) > 0 && int.Parse(ClientesDropDownList.SelectedItem.Value) > 0 && int.Parse(PeliculasDropDownList.SelectedItem.Value) > 0)
            {
                int result = DateTime.Compare(DateTime.Parse(FechaTextBox.Text), DateTime.Parse(FechaDevolucionTextBox.Text));
                if(result < 0)
                {
                    bool paso = false;
                    var dt = new DetalleFacturas();

                    dt.FactDetalleId = 0;

                    if (IdTextBox.Text == string.Empty)
                        dt.FacturaId = 0;
                    else
                        dt.FacturaId = Convert.ToInt32(IdTextBox.Text);

                    dt.PeliculaId = int.Parse(PeliculasDropDownList.SelectedItem.Value);
                    Peliculas buscar = pBLL.Buscar(int.Parse(PeliculasDropDownList.SelectedItem.Value));
                    dt.NombrePelicula = buscar.Nombre;
                    dt.Precio = buscar.Precio;
                    dt.Cantidad = int.Parse(CantidadTextBox.Text);
                    dt.Importe = decimal.Parse(ImporteTextBox.Text);

                    Mont += dt.Importe;
                    MontoTextBox.Text = Mont.ToString();

                    foreach (GridViewRow grid in DetalleGridView.Rows)
                    {
                        if (grid.Cells[1].Text == dt.NombrePelicula)
                        {
                            paso = true;
                            break;
                        }
                    }

                    if (paso == false)
                    {
                        if (buscar.Cantidad >= dt.Cantidad)
                            Detalle.Add(dt);
                        else
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('No hay suficientes peliculas en el inventario.');", addScriptTags: true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('La pelicula ya existe en el detalle.');", addScriptTags: true);

                    ViewState["detalle"] = Detalle;
                    DetalleGridView.DataSource = Detalle.ToList();
                    DetalleGridView.DataBind();
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('La fecha de devolucion tiene que ser mayor a la fecha de la factura.');", addScriptTags: true);
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('Llene todos los campos.');", addScriptTags: true);
        }

        protected void DetalleGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DetalleGridView.EditIndex = e.NewEditIndex;
            DetalleGridView.DataSource = (List<DetalleFacturas>)ViewState["detalle"];
            DetalleGridView.DataBind();
        }

        protected void DetalleGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            RepositorioBase<DetalleFacturas> dtaBLL = new RepositorioBase<DetalleFacturas>();
            int dtId = Convert.ToInt32(DetalleGridView.DataKeys[e.RowIndex].Value.ToString());

            GridViewRow row = DetalleGridView.Rows[e.RowIndex];
            Detalle = (List<DetalleFacturas>)ViewState["detalle"];
            TextBox Cant = row.Cells[2].Controls[0] as TextBox;
            var Buscar = dtaBLL.Buscar(dtId);

            if (int.Parse(Cant.Text) < Buscar.Cantidad)
                Detalle[e.RowIndex].Cantidad = int.Parse(Cant.Text);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['warning']('No hay suficientes copias en el inventario.');", addScriptTags: true);

            ViewState["detalle"] = Detalle;
            ViewState["Factura"] = LlenarClase();
            DetalleGridView.DataSource = Detalle.ToList();
            DetalleGridView.DataBind();
        }

        protected void DetalleGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = DetalleGridView.Rows[e.RowIndex];
            int ID = Convert.ToInt32(DetalleGridView.DataKeys[e.RowIndex].Value.ToString());

            //ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']" + "('" + ID + "');", addScriptTags: true);
            //var itemToRemove = Detalle.Single(r => r.FactDetalleId == ID);
            //Detalle.Remove(itemToRemove);
            if (factBLL.Delete(ID))
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Se ha eliminado del detalle.');", addScriptTags: true);
        }

        protected void DetalleGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DetalleGridView.EditIndex = -1;
            DetalleGridView.DataSource = Detalle;
            DetalleGridView.DataBind();
        }

        protected void PeliculasDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Entidad = pBLL.Buscar(int.Parse(PeliculasDropDownList.SelectedItem.Value));
            PrecioTextBox.Text = Entidad.Precio.ToString();
        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal Mult = decimal.Parse(CantidadTextBox.Text) * decimal.Parse(PrecioTextBox.Text);
            ImporteTextBox.Text = Mult.ToString();
        }

        private void RegisterPostBackControl()
        {
            foreach (GridViewRow row in DetalleGridView.Rows)
            {
                LinkButton btn_Edit = row.FindControl("btn_Edit") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btn_Edit);
            }
        }
    }
}