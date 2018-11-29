using BLL;
using Entidades;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;

namespace ProyectoFinal.UI
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private RepositorioBase<Generos> BLL = new RepositorioBase<Generos>();
        Expression<Func<Generos, bool>> filter = x => true;

        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void FiltrarButton_Click(object sender, EventArgs e)
        {
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
                            filter = (x => x.GeneroId == id);
                        }
                        else
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('El ID solo puede ser un número.');", addScriptTags: true);
                    }
                    else
                        filter = null;
                    break;
                case 1:// Nombre
                    if (!string.IsNullOrWhiteSpace(CriterioTextBox.Text))
                        filter = (x => x.Nombre.Contains(CriterioTextBox.Text));
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