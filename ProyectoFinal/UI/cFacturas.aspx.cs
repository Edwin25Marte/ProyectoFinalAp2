using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal.UI
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        private RepositorioBase<Facturas> BLL = new RepositorioBase<Facturas>();
        Expression<Func<Facturas, bool>> filter = x => true;

        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void FiltrarButton_Click(object sender, EventArgs e)
        {
            DateTime F1 = DateTime.Parse(Fecha1TextBox.Text);
            DateTime F2 = DateTime.Parse(Fecha2TextBox.Text);

            switch (CampoFiltrarDropDownList.SelectedIndex)
            {
                case 0://ID
                    if (!string.IsNullOrWhiteSpace(CriterioTextBox.Text))
                    {
                        double Num;
                        bool isNum = double.TryParse(CriterioTextBox.Text, out Num);

                        if (isNum)
                        {
                            int id = int.Parse(CriterioTextBox.Text);
                            filter = (x => x.FacturaId == id && x.Fecha >= F1 && x.Fecha <= F2);
                        }
                        else
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('El ID solo puede ser un número.');", addScriptTags: true);
                    }
                    else
                        filter = null;
                    break;
                case 1://IDCliente
                    if (!string.IsNullOrWhiteSpace(CriterioTextBox.Text))
                    {
                        double Num;
                        bool isNum = double.TryParse(CriterioTextBox.Text, out Num);

                        if (isNum)
                        {
                            int id = int.Parse(CriterioTextBox.Text);
                            filter = (x => x.ClienteId == id && x.Fecha >= F1 && x.Fecha <= F2);
                        }
                        else
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('El ID solo puede ser un número.');", addScriptTags: true);
                    }
                    else
                        filter = null;
                    break;
                case 2:// Monto
                    if (!string.IsNullOrWhiteSpace(CriterioTextBox.Text))
                    {
                        double Num;
                        bool isNum = double.TryParse(CriterioTextBox.Text, out Num);

                        if (isNum)
                        {
                            decimal monto = decimal.Parse(CriterioTextBox.Text);
                            filter = (x => x.Monto == monto && x.Fecha >= F1 && x.Fecha <= F2);
                        }
                        else
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('El Monto solo puede ser un número.');", addScriptTags: true);
                    }
                    else
                        filter = null;
                    break;
            }
            if (filter != null)
                cGridView.DataSource = BLL.GetList(filter).ToList();
            cGridView.DataBind();
        }

        protected void FiltrarTodoButton_Click(object sender, EventArgs e)
        {
            filter = (x => true);
            cGridView.DataSource = BLL.GetList(filter);
            cGridView.DataBind();
        }
    }
}