<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarClave.aspx.cs" Inherits="EmpresaDCMS.comun.CambiarClave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DCMS Help</title>
    <link href="../Css/Estilos.css" rel="stylesheet" />
    <script src="../Java/Scripts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <div>
                <ul>
                    <li><asp:Image ID="Image1" runat="server" ImageUrl="~/images/logito.png" Height="45px" Width="245px"/></li>
                    <li><asp:Label ID="usuario" runat="server" Text="Cambio de Contraseña"></asp:Label></li>
                </ul>
            </div>               
        </div>
        <nav class="navBarra">
            <ul class="nav">
		        <li><a href="javascript:history.back()">Regresar</a></li>
            </ul>
	    </nav>
        <div style="border-style: double; width: 540px; text-align: center;" class="pantallaRol">
        <br />
        <table style="width: 100%;">
            <tr style="padding:5px 8px 5px 8px">
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Ingrese su ID:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtId" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtId" runat="server" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr style="padding:5px 8px 5px 8px">
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Nueva Contraseña:"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Contraseña vacia y/o erronea." ForeColor="Red">(*)</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="220px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Confirmar Contraseña:"></asp:Label>

                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmarPassword" ErrorMessage="Las contraseñas no son las mismas." ForeColor="Red">(*)</asp:CompareValidator>

                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtConfirmarPassword" runat="server" TextMode="Password" Width="220px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">

                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Italic="False" ForeColor="Red" />

                </td>
                <td class="auto-style4">
                    <asp:Button ID="btnCambiarClave" runat="server" Text="Aceptar" Height="34px" Width="140px" OnClick="btnCambiarClave_Click" />
                </td>
            </tr>
        </table>
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
