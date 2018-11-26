﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Entidades;

namespace ProyectoFinal.UI
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private RepositorioBase<Peliculas> BLL = new RepositorioBase<Peliculas>();
        private RepositorioBase<Actores> actBLL = new RepositorioBase<Actores>();
        private RepositorioBase<Generos> genBLL = new RepositorioBase<Generos>();
        private List<DetallePeliculas> Detalle = new List<DetallePeliculas>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Add("detalle", Detalle);
                Expression<Func<Actores, bool>> fActores = x => true;
                Expression<Func<Generos, bool>> fGeneros = x => true;
                var itemCount = actBLL.GetList(fActores).Count;

                if (itemCount > 0)
                {
                    foreach (var i in actBLL.GetList(fActores))
                    {
                        ListItem l = new ListItem(i.Nombre, Convert.ToString(i.ActorId), true);
                        ActorDropDownList.Items.Add(l);
                    }
                    ActorDropDownList.DataBind();
                }

                var itemCount2 = genBLL.GetList(fGeneros).Count;

                if (itemCount2 > 0)
                {
                    foreach (var i in genBLL.GetList(fGeneros))
                    {
                        ListItem l = new ListItem(i.Nombre, Convert.ToString(i.GeneroId), true);
                        GenerosDropDownList.Items.Add(l);
                    }
                    GenerosDropDownList.DataBind();
                }
            }
            else
                Detalle = (List<DetallePeliculas>)ViewState["detalle"];
        }

        private Peliculas LlenarClase()
        {
            var Entidad = new Peliculas();

            if (IdTextBox.Text == string.Empty)
                Entidad.PeliculaId = 0;
            else
                Entidad.PeliculaId = Convert.ToInt32(IdTextBox.Text);

            Entidad.Nombre = NombreTextBox.Text;
            Entidad.ActorId = int.Parse(ActorDropDownList.SelectedItem.Value);
            Entidad.FechaSalida = Convert.ToDateTime(FechaTextBox.Text);
            Entidad.Cantidad = int.Parse(CantidadTextBox.Text);
            Entidad.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            Entidad.Genero = GenerosDropDownList.SelectedItem.Value;
            Entidad.Personaje = PersonajeTextBox.Text;
            Entidad.Sipnosis = SinopsisTextBox.Text;
            Entidad.DetallePels = Detalle;

            return Entidad;
        }

        private void LlenarCampos(Peliculas Entidad)
        {
            IdTextBox.Text = Entidad.PeliculaId.ToString();
            NombreTextBox.Text = Entidad.Nombre;
            FechaTextBox.Text = Entidad.FechaSalida.ToString("yyyy-MM-dd");
            CantidadTextBox.Text = Entidad.Cantidad.ToString();
            PrecioTextBox.Text = Entidad.Precio.ToString();
            GenerosDropDownList.ClearSelection();
            GenerosDropDownList.Items.FindByValue(Entidad.Genero).Selected = true;
            PersonajeTextBox.Text = Entidad.Personaje;
            SinopsisTextBox.Text = Entidad.Sipnosis.ToString();
            DetalleGridView.DataSource = Entidad.DetallePels;
            DetalleGridView.DataBind();
        }

        void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            FechaTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            GenerosDropDownList.ClearSelection();
            GenerosDropDownList.Items.FindByValue("Generos").Selected = true;
            PersonajeTextBox.Text = string.Empty;
            SinopsisTextBox.Text = string.Empty;
            DetalleGridView.Visible = true;
            DetalleGridView.DataBind();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Peliculas Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                LlenarCampos(Buscar);
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Película no econtrada.');", addScriptTags: true);
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
                    if (GenerosDropDownList.SelectedItem.Value != "Generos")
                    {
                        BLL.Guardar(LlenarClase());
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Película Guardada.');", addScriptTags: true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Seleccione un género válido.');", addScriptTags: true);
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
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['success']('Película Modificada.');", addScriptTags: true);
                        }
                    }
                }
                Limpiar();
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Peliculas Buscar = null;

            if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                Buscar = BLL.Buscar(int.Parse(IdTextBox.Text));

            if (Buscar != null)
                BLL.Eliminar(int.Parse(IdTextBox.Text));
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error']('Película no eliminada.');", addScriptTags: true);
            Limpiar();
        }
    }
}