<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site.Master" AutoEventWireup="true" CodeBehind="cFacturas.aspx.cs" Inherits="ProyectoFinal.UI.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row main">
            <div class="main-login main-center">
                <br />
                <h5>Consulta de Facturas</h5>
                <br />

                <div class="form-group">
                    <div class="cols-sm-10">
                        <label for="username" class="cols-sm-2 control-label">Campo a filtrar</label>
                        <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                        <asp:DropDownList ID="CampoFiltrarDropDownList" class="form-control" runat="server">
                            <asp:ListItem Text="ID" Value="0" />
                            <asp:ListItem Text="ID Cliente" Value="1" />
                            <asp:ListItem Text="Monto" Value="2" />
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="form-group">
                    <label for="username" class="cols-sm-2 control-label">Criterio de búsqueda</label>
                    <div class="cols-sm-10">
                        <div class="input-group">
                            <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                            <asp:TextBox ID="CriterioTextBox" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="CriterioTextBox" ErrorMessage="Llene el campo Criterio de búsqueda"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-10">
                        Desde:
                        <asp:TextBox ID="Fecha1TextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="Fecha1TextBox" ErrorMessage="Llene el campo Fecha"></asp:RequiredFieldValidator>
                        <br />
                        Hasta:
                        <asp:TextBox ID="Fecha2TextBox" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ValidationGroup="Guardar" runat="server" CssClass="ErrorMessage" ControlToValidate="Fecha2TextBox" ErrorMessage="Llene el campo Fecha"></asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-10">
                        <asp:Button ID="FiltrarButton" ValidationGroup="Guardar" CssClass="btn btn-primary" runat="server" Text="Filtrar" OnClick="FiltrarButton_Click" />
                        <asp:Button ID="FiltrarTodoButton" CausesValidation="false" CssClass="btn btn-success" runat="server" Text="Filtrar Todo" OnClick="FiltrarTodoButton_Click" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-10">
                    </div>
                    <asp:GridView ID="cGridView" AutoGenerateColumns="false" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />

                        <Columns>
                            <asp:BoundField DataField="FacturaId" HeaderText="ID" ReadOnly="true" />
                            <asp:BoundField DataField="ClienteId" HeaderText="ID Cliente" />
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" ReadOnly="true" />
                            <asp:BoundField DataField="FechaDevolucion" HeaderText="Fecha de Devolución" ReadOnly="true" />
                            <asp:BoundField DataField="Monto" HeaderText="Monto" ReadOnly="true" />
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
