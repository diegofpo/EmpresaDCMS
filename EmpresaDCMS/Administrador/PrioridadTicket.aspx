<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="PrioridadTicket.aspx.cs" Inherits="EmpresaDCMS.WebForm5" %>
<%@ MasterType  virtualPath="~/Maestra.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 290px;
            height: 31px;
        }
        .auto-style2 {
            width: 290px;
            height: 65px;
        }
        .auto-style3 {
            height: 65px;
        }
        .auto-style4 {
            width: 290px;
            height: 30px;
        }
        .auto-style5 {
            width: 290px;
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="border-style: double; width: 575px; text-align: center;" class="pantallaRol">
        <asp:RadioButtonList ID="HojaPrioridadTicket" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="HojaPrioridadTicket_SelectedIndexChanged" AutoPostBack="True" TextAlign="Right" ValidateRequestMode="Inherit" CssClass="Selector">
            <asp:ListItem Value="1">Insertar</asp:ListItem>
            <asp:ListItem Value="2">Modificar</asp:ListItem>
            <asp:ListItem Value="3">Eliminar</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Panel ID="Panel1" runat="server">
             <table style="border-color: #000000; width: 100%;">
                    <tr>
                        <td class="auto-style2" style="text-align: center">
                            <asp:Label ID="Label1" runat="server" Text="Id de la prioridad:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIdPrioridad" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style3" style="text-align: center">
                            <asp:TextBox ID="txtIdPrioridad" runat="server" Width="190px" Font-Names="Arial"></asp:TextBox>
                            <asp:Panel ID="panelBuscar" runat="server">
                                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click1" Text="Buscar" Width="100px" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5" style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text="Nombre de la prioridad:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombrePrioridad" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style5" style="text-align: center">
                            <asp:TextBox ID="txtNombrePrioridad" runat="server" Width="190px" Font-Names="Arial"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNombrePrioridad" ErrorMessage="Solo se permiten letras." ForeColor="Red" ValidationExpression="^[A-Za-z]+$">(*)</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style5">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        </td>
                        <td class="auto-style5">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="113px" OnClick="btnGuardar_Click" />
                        </td>
                    </tr>
                </table>
        </asp:Panel>
        </div>
    <br />
    <div style="border-style: double; width: 650px; text-align: center;" class="pantallaRol">
        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" CssClass="gridview" ForeColor="Black" Width="600px" DataSourceID="SqlDataSource1">
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DCMSConnectionString %>" SelectCommand="select idPrioridad as 'Id', nombrePrioridad as 'Prioridad para el Ticket'
from Prioridad"></asp:SqlDataSource>
    </div>
    <br />
</asp:Content>
