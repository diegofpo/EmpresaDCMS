<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketRegistrado.aspx.cs" Inherits="EmpresaDCMS.comun.TicketRegistrado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>DCMS Help</title>
    <link href="../Css/Estilos.css" rel="stylesheet" />
    <script src="../Java/Scripts.js"></script>
     <style type="text/css">
         .auto-style3 {
             width: 415px;
             height: 41px;
         }
         .auto-style4 {
             width: 415px;
         }
         .auto-style5 {
             width: 415px;
             height: 87px;
         }
         .auto-style6 {
             height: 87px;
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
            <li><a href="javascript:history.back()">Regresar</a></li>
		</ul>
	</nav>
    <div style="border-style: double; width: 800px; text-align: center;" class="pantallaRol">
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <asp:GridView ID="gvRegistro" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" CssClass="gridview" ForeColor="Black" OnSelectedIndexChanged="gvRegistro_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Button" SelectText="Calificar" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>           
        </asp:Panel>
        <br />
        <asp:Panel ID="panelCalificar" runat="server" Visible="False">

            <table style="width: 100%;">
                <tr>
                    <th class="auto-style3">Por favor califique la solucion ofrecida...</th>
                </tr>
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="Label2" runat="server" Text="El tecnico que atendio su requerimiento, soluciono con exito su requerimiento?"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:RadioButtonList ID="rbCalificacion1" runat="server" RepeatDirection="Horizontal" Width="320px" OnSelectedIndexChanged="rbCalificacion1_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="1">Si</asp:ListItem>
                        <asp:ListItem Value="2">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="PanelCalificacion2" runat="server" Visible="False">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label1" runat="server" Text="Como calificaria la atencion por parte del tecnico que le ayudo?"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbCalificacion2" runat="server" RepeatDirection="Horizontal" Width="320px">
                            <asp:ListItem Value="5">Excelente</asp:ListItem>
                            <asp:ListItem Value="3">Regular</asp:ListItem>
                            <asp:ListItem Value="1">Mala</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label3" runat="server" Text="Como calificaria el tiempo que tardo el tecnico en completar la solucion ofrecida?"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbCalificacion3" runat="server" RepeatDirection="Horizontal" Width="320px">
                            <asp:ListItem Value="5">Excelente</asp:ListItem>
                            <asp:ListItem Value="3">Regular</asp:ListItem>
                            <asp:ListItem Value="1">Mala</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label4" runat="server" Text="Como calificaria el conocimiento del tecnico al momento de completar la solucion ofrecida?"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rbCalificacion4" runat="server" RepeatDirection="Horizontal" Width="320px" OnSelectedIndexChanged="rbCalificacion4_SelectedIndexChanged">
                            <asp:ListItem Value="5">Excelente</asp:ListItem>
                            <asp:ListItem Value="3">Regular</asp:ListItem>
                            <asp:ListItem Value="1">Mala</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="PanelBoton" runat="server">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td style="align-items:center">
                        <asp:Button ID="btnCalificar" runat="server" OnClick="btnCalificar_Click" Text="Enviar Calificacion" Width="200px" />
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

