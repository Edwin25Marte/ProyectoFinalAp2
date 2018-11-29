<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="rPeliculas.aspx.cs" Inherits="ProyectoFinal.UI.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row main">
            <div class="main-login main-center">
                <br />
                <h5>Registro de Peliculas</h5>
                <br />
                <div class="form-group">
                    <label for="name" class="cols-sm-2 control-label">ID</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="IdTextBox" TextMode="Number" min="0" Text="0" CssClass="form-control" runat="server"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="BuscarButton" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Nombre de la pelicula</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="NombreTextBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="NombreTextBox" ErrorMessage="Llene el campo Nombre"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Fecha de salida</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="FechaTextBox" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="FechaTextBox" ErrorMessage="Llene el campo Fecha"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Cantidad</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="CantidadTextBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" TextMode="Number" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="CantidadTextBox" ErrorMessage="Llene el campo Cantidad"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Precio</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="PrecioTextBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="PrecioTextBox" ErrorMessage="Llene el campo Precio"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Genero</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                            <asp:DropDownList ID="GenerosDropDownList" class="form-control" runat="server">
                                <asp:ListItem Value="Generos">Generos</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Actor</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                            <asp:DropDownList ID="ActorDropDownList" class="form-control" runat="server">
                                <asp:ListItem Value="0">Actores</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Personaje que interpreta el actor</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="PersonajeTextBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="PersonajeTextBox" ErrorMessage="Llene el campo Personaje"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="cols-sm-10">
                                <asp:Button ID="AddButton" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="AddButton_Click" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <div class="cols-sm-10">
                                <asp:GridView ID="DetalleGridView" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="DetallePeliculaId" class="table table-condensed table-bordered table-responsive"
                                    CellPadding="4" ForeColor="Black" GridLines="Horizontal" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EnablePersistedSelection="True" OnRowCancelingEdit="DetalleGridView_RowCancelingEdit" OnRowDeleting="DetalleGridView_RowDeleting" OnRowEditing="DetalleGridView_RowEditing" OnRowUpdating="DetalleGridView_RowUpdating">
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_Edit" runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-warning" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Button ID="btn_Update" runat="server" Text="U" CommandName="Update" CssClass="btn btn-primary" />
                                                <br />
                                                <asp:Button ID="btn_Cancel" runat="server" Text="C" CommandName="Cancel" CssClass="btn btn-danger" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="NombreActor" HeaderText="Nombre Actor" ReadOnly="true" />
                                        <asp:BoundField DataField="Personaje" HeaderText="Personaje" />

                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btn_Delete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="form-group">
                    <label for="email" class="cols-sm-2 control-label">Sinopsis</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="SinopsisTextBox" TextMode="MultiLine" Rows="4" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="SinopsisTextBox" ErrorMessage="Llene el campo Sinopsis"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-10">
                        <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                        <asp:Button ID="NuevoButton" CausesValidation="false" CssClass="btn btn-warning" runat="server" Text="Nuevo" OnClick="NuevoButton_Click" />
                        <asp:Button ID="GuardarButton" ValidationGroup="Guardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                        <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>