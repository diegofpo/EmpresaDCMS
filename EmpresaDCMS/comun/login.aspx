<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EmpresaDCMS.comun.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DCMS Help</title>
    <link href="../Css/Estilos.css" rel="stylesheet" />
    <script src="../Java/Scripts.js"></script>
    <script>
        window.location.hash = "no-back-button";
        window.location.hash = "Again-No-back-button";
        window.onhashchange = function () { window.location.hash = "no-back-button"; }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <div>
                <ul>
                    <li><asp:Image ID="Image1" runat="server" ImageUrl="~/images/logito.png" Height="45px" Width="245px"/></li>
                    <li><asp:Label ID="usuario" runat="server" Text="Login"></asp:Label></li>
                </ul>
            </div>               
        </div>
        <nav class="navBarra">
            <ul class="nav">
		        <center><marquee direction="left" id="ejemplo"><span class="Apple-style-span" style="color:white;">Bienvenido, por favor ingresa al sistema para continuar...</span></marquee> <a href="javascript:void(0);"></a> <a href="javascript:void(0);"></a></center>
		    </ul>
	    </nav>
        <br />
        <div style="width: 580px; text-align: center;" class="pantallaRol">
            <asp:Panel ID="Panel1" runat="server" CssClass="login">
                <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" Width="551px" LoginButtonText="Ingresar" PasswordRequiredErrorMessage="Ingrese la contraseña." RememberMeText="Recordar Usuario." UserNameLabelText="Id Empleado:" UserNameRequiredErrorMessage="Ingrese el Id del Empleado" BorderStyle="Double" CssClass="login" FailureText="Ingreso no completado. Intente de nuevo.">

                </asp:Login>
            </asp:Panel>
        </div>
        <aside>
        </aside>
        <div id="footer">
            <footer>
                <h5>Copyright © 2016 DCMS Help.<br />All rights reserved.</h5>
            </footer>
        </div>
    </form>
</body>
</html>
