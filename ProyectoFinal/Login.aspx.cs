using System;
using Entidades;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using BLL;
using System.Web.Security;

namespace ProyectoFinal
{
    public partial class Login : System.Web.UI.Page
    {
        private RepositorioBase<Usuario> BLL = new RepositorioBase<Usuario>();

        protected void Page_Load(object sender, EventArgs e)
        { }

        protected void InitButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Usuario, bool>> filtrar = x => true;
            Usuario user = new Usuario();

            filtrar = t => t.NombreUsuario.Equals(UsuarioTextBox.Text) && t.Password.Equals(PassTextBox.Text);
            if (BLL.GetList(filtrar).Count() != 0)
                FormsAuthentication.RedirectFromLoginPage(user.NombreUsuario, true);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Usuario o contraseña Incorrecto');", addScriptTags: true);
        }
    }
}