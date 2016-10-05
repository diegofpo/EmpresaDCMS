<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarTicket.aspx.cs" Inherits="EmpresaDCMS.comun.IngresarTicket" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>DCMS Help</title>
    <link href="../Css/Estilos.css" rel="stylesheet" />
    <script src="../Java/Scripts.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 321px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
            <div>
                <ul>
                    <li><asp:Image ID="Image1" runat="server" ImageUrl="~/images/logito.png" Height="45px" Width="245px"/></li>
                    <li><asp:Label ID="usuario" runat="server" Text="Ingreso de Ticket"></asp:Label></li>
                </ul>
            </div>               
        </div>
        <nav class="navBarra">
            <ul class="nav">
                <li><a href="javascript: history.back()">Regresar</a></li>
		    </ul>
	    </nav>
        <br />
        <br />
    <div style="border-style: double; width: 800px; text-align: center;" class="pantallaRol">
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        <asp:Panel ID="Panel1" runat="server">
            <table style="width:100%;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Ingrese su ID:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtId" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtId" runat="server" Width="180px" MaxLength="6" TextMode="Number"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Categoria del problema:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCategoria" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlCategoria" runat="server" Width="180px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Prioridad del problema:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPrioridad" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style2">
                        <asp:DropDownList ID="ddlPrioridad" runat="server" Width="180px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlPrioridad_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:TextBox ID="coloPrioridad" runat="server" Width="20px" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Fecha de ingreso:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechaIngreso" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtFechaIngreso" runat="server" TextMode="Date" Width="180px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label6" runat="server" Text="Fecha maxima de solucion:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFechaSolucion" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtFechaSolucion" runat="server" TextMode="Date" Width="180px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="Label4" runat="server" Text="Descripcion del problema:"></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtDescripcion" runat="server" Height="59px" TextMode="MultiLine" Width="355px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnIngresarTicket" runat="server" Text="Ingresar Ticket" Width="150px" OnClick="btnIngresarTicket_Click" />
                    </td>
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="panelPregunta" runat="server">
                <table style="width:100%;">
                 <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label7" runat="server" Text="Desea ingresar otro ticket?"></asp:Label>
                        </td>
                    <td class="auto-style2">
                        
                        <asp:RadioButtonList ID="hojaPregunta" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="hojaPregunta_SelectedIndexChanged" CssClass="Selector" Width="291px">
                            <asp:ListItem Value="1">Si</asp:ListItem>
                            <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                        
                    </td>
                </tr>
             </table>
            </asp:Panel>
    </div>
    <br />
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