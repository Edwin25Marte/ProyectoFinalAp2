<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinal.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alquiler Peliculas</title>
    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Bootstrap/js/jquery-3.3.1.min.js"></script>
    <script src="Bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <link href="content/toastr.css" rel="stylesheet" />
    <script src="Scripts/toastr.js"></script>
    <link href="Scripts/StyleSheet.css" rel="stylesheet" />
    <link rel="icon" type="image/x-icon" href="Images/favicon.ico" sizes="16x16" />

</head>
<body>
    <form id="Login" runat="server">
        <div class="container">
            <div class="row main">
                <div class="main-login main-center">
                    <br />
                    <h5>Iniciar Sesión</h5>
                    <br />
                    <div class="form-group">
                        <label for="name" class="cols-sm-2 control-label">Nombre de Usuario</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                <asp:TextBox ID="UsuarioTextBox" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="email" class="cols-sm-2 control-label">Contraseña</label>
                        <div class="cols-sm-10">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                                <asp:TextBox ID="PassTextBox" type="password" class="form-control" runat="server"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button ID="InitButton" CssClass="btn btn-primary" runat="server" Text="Iniciar" OnClick="InitButton_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
