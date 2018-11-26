<%@ Page Title="" Language="C#" EnableViewState="true" EnableEventValidation="false" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="rFacturas.aspx.cs" Inherits="ProyectoFinal.UI.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row main">
            <div class="main-login main-center">
                <br />
                <h5>Registro de Facturas</h5>
                <br />
                <div class="form-group">
                    <label for="name" class="cols-sm-2 control-label">ID</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="IdTextBox" TextMode="Number" min="0" Text="0" class="form-control" runat="server"></asp:TextBox>
                            <div class="input-group-append">
                                <asp:Button ID="BuscarButton" CssClass="btn btn-primary" runat="server" Text="Buscar" OnClick="BuscarButton_Click1" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Fecha de factura</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="FechaTextBox" TextMode="Date" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="FechaTextBox" ErrorMessage="Llene el campo Fecha"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Fecha Prestamo</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="FechaPrestamoTextBox" TextMode="Date" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="FechaPrestamoTextBox" ErrorMessage="Llene el campo Fecha Prestamo"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Fecha Devolucion</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="FechaDevolucionTextBox" TextMode="Date" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="FechaDevolucionTextBox" ErrorMessage="Llene el campo Fecha Devolucion"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-10">
                        <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                        <asp:DropDownList ID="ClientesDropDownList" class="form-control" runat="server">
                            <asp:ListItem Text="Clientes" Value="0" />
                        </asp:DropDownList>
                        <asp:DropDownList ID="PeliculasDropDownList" class="form-control" runat="server">
                            <asp:ListItem Text="Peliculas" Value="0" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-10">
                        <asp:Button ID="AddButton" CausesValidation="false" CssClass="btn btn-primary" runat="server" Text="Agregar" OnClick="AddButton_Click1" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-10">
                        <asp:GridView ID="DetalleGridView" AutoGenerateColumns="false" AllowPaging="true" DataKeyNames="FactDetalleId" class="table table-condensed table-bordered table-responsive"
                            CellPadding="4" ForeColor="Black" GridLines="Horizontal" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EnablePersistedSelection="True" OnRowEditing="DetalleGridView_RowEditing" OnRowDeleting="DetalleGridView_RowDeleting" OnRowUpdating="DetalleGridView_RowUpdating" OnRowCancelingEdit="DetalleGridView_RowCancelingEdit">
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                            <SortedDescendingHeaderStyle BackColor="#242121" />

                            <Columns>
                                <asp:BoundField DataField="NombrePelicula" HeaderText="Nombre" ReadOnly="true" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="true" />
                                <asp:CommandField ShowEditButton="true" />
                                <asp:CommandField ShowDeleteButton="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Monto</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="MontoTextBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="MontoTextBox" ErrorMessage="Llene el campo Monto"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Observaciones</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="ObservacionesTextBox" TextMode="MultiLine" Rows="4" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="ObservacionesTextBox" ErrorMessage="Llene el campo Observaciones"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-10">
                        <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                        <asp:Button ID="NuevoButton" CausesValidation="false" CssClass="btn btn-warning" runat="server" Text="Nuevo" OnClick="NuevoButton_Click1" />
                        <asp:Button ID="GuardarButton" ValidationGroup="Guardar" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click1" />
                        <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click1" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
