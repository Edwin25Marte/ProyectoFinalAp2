using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
                ViewState.Add("detalle", Detalle);
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

            Entidad.Fecha = Convert.ToDateTime(FechaTextBox.Text);
            Entidad.FechaPrestamo = Convert.ToDateTime(FechaPrestamoTextBox.Text);
            Entidad.FechaDevolucion = Convert.ToDateTime(FechaDevolucionTextBox.Text);
            Entidad.ClienteId = int.Parse(ClientesDropDownList.SelectedItem.Value);
            Entidad.Monto = Convert.ToDecimal(MontoTextBox.Text);
            Entidad.Observaciones = ObservacionesTextBox.Text;
            Entidad.DetalleFactura = Detalle;

            return Entidad;
        }

        private void LlenarCampos(Facturas Entidad)
        {
            Facturas Buscar = BLL.Buscar(Entidad.ClienteId);
                
            IdTextBox.Text = Entidad.FacturaId.ToString();
            FechaTextBox.Text = Entidad.Fecha.ToString("yyyy-MM-dd");
            FechaPrestamoTextBox.Text = Entidad.FechaPrestamo.ToString("yyyy-MM-dd");
            FechaDevolucionTextBox.Text = Entidad.FechaDevolucion.ToString("yyyy-MM-dd");
            MontoTextBox.Text = Entidad.Monto.ToString();
            ObservacionesTextBox.Text = Entidad.Observaciones.ToString();
            DetalleGridView.DataSource = Entidad.DetalleFactura;
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
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                BLL.Guardar(LlenarClase());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Factura Guardada.');", addScriptTags: true);
            }
            else
            {
                /*var Ent = new DetalleFacturas();
                List<DetalleFacturas> nDet = new List<DetalleFacturas>();
                
                for (int i = 0; i < DetalleGridView.Rows.Count; ++i)
                {
                    Ent.NombrePelicula = DetalleGridView.Rows[i].Cells[3].Text;
                    Ent.FechaPrestamo = Convert.ToDateTime(DetalleGridView.Rows[i].Cells[4].Text);
                    Ent.FechaDevolucion = Convert.ToDateTime(DetalleGridView.Rows[i].Cells[5].Text);
                    Ent.Precio = Convert.ToDecimal(DetalleGridView.Rows[i].Cells[6].Text);

                    nDet.Add(Ent);
                }

                var Entidad = new Facturas();

                if (IdTextBox.Text == string.Empty)
                    Entidad.FacturaId = 0;
                else
                    Entidad.FacturaId = Convert.ToInt32(IdTextBox.Text);

                Entidad.Fecha = Convert.ToDateTime(FechaTextBox.Text);
                Entidad.ClienteId = int.Parse(ClientesDropDownList.SelectedItem.Value);
                Entidad.Monto = Convert.ToDecimal(MontoTextBox.Text);
                Entidad.Observaciones = ObservacionesTextBox.Text;
                Entidad.DetalleFactura = nDet;

                factBLL.Modificar(Entidad);
                BLL.Modificar(LlenarClase());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Factura Modificada.');", addScriptTags: true);*/
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
            DetalleFacturas dt = new DetalleFacturas();

            if (IdTextBox.Text == string.Empty)
                dt.FactDetalleId = 0;
            else
                dt.FactDetalleId = Convert.ToInt32(IdTextBox.Text);

            if (IdTextBox.Text == string.Empty)
                dt.FacturaId = 0;
            else
                dt.FacturaId = Convert.ToInt32(IdTextBox.Text);

            dt.PeliculaId = int.Parse(PeliculasDropDownList.SelectedItem.Value);
            Peliculas buscar = pBLL.Buscar(int.Parse(PeliculasDropDownList.SelectedItem.Value));
            dt.NombrePelicula = buscar.Nombre;
            dt.Precio = buscar.Precio;

            Detalle.Add(dt);
            ViewState["detalle"] = Detalle;
            DetalleGridView.DataSource = Detalle;
            DetalleGridView.DataBind();
        }

        protected void DetalleGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;

            switch (e.Row.RowType)
            {
                case DataControlRowType.DataRow:
                    e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='White'; this.style.color='Gray'; this.style.cursor='pointer'");
                    if (e.Row.RowState == DataControlRowState.Alternate)
                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", DetalleGridView.AlternatingRowStyle.BackColor.ToKnownColor()));
                    else
                        e.Row.Attributes.Add("onmouseout", String.Format("this.style.color='Black';this.style.backgroundColor='{0}';", DetalleGridView.RowStyle.BackColor.ToKnownColor()));
                    
                    e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(DetalleGridView, "Select$" + e.Row.RowIndex.ToString()));
                    id = e.Row.RowIndex;
                    break;
            }

            if (e.Row.RowType == DataControlRowType.DataRow) {
                e.Row.ToolTip = "Click to select this row.";
            }*/
        }
    }
}