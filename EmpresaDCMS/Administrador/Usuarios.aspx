<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="EmpresaDCMS.WebForm13" %>
<%@ MasterType  virtualPath="~/Maestra.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 45px;
        }
        .auto-style3 {
            height: 45px;
        }
        .auto-style4 {
            height: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div style="border-style: double; width: 575px; text-align: center;" class="pantallaRol">
        <asp:RadioButtonList ID="HojaUsuarios" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" TextAlign="Right" ValidateRequestMode="Inherit" CssClass="Selector" OnSelectedIndexChanged="HojaUsuarios_SelectedIndexChanged">
            <asp:ListItem Value="1">Insertar</asp:ListItem>
            <asp:ListItem Value="2">Modificar</asp:ListItem>
            <asp:ListItem Value="3">Eliminar</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Panel ID="Panel1" runat="server">
             <table style="border-color: #000000; width: 100%;">
                    <tr>
                        <td class="auto-style4" style="text-align: center">
                            <asp:Label ID="Label1" runat="server" Text="Id del Usuario:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIdUsuario" ErrorMessage="Campo Vacio." ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style4" style="text-align: center">
                            <asp:TextBox ID="txtIdUsuario" runat="server" Width="250px" Font-Names="Arial" TextMode="Number" MaxLength="6"></asp:TextBox>
                            <asp:Panel ID="panelBuscar" runat="server">
                                <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click1" Text="Buscar" Width="100px" />
                            </asp:Panel>
                        </td>
                    </tr>
                 <tr>
                        <td class="auto-style3" style="text-align: center">
                            <asp:Label ID="Label3" runat="server" Text="Cedula:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCedula" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style3" style="text-align: center">
                            <asp:TextBox ID="txtCedula" runat="server" Width="250px" Font-Names="Arial" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3" style="text-align: center">
                            <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style3" style="text-align: center">
                            <asp:TextBox ID="txtNombreUsuario" runat="server" Width="250px" Font-Names="Arial"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtNombreUsuario" ErrorMessage="Solo se permiten letras." ForeColor="Red" ValidationExpression="^[A-Za-z]+$">(*)</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="text-align: center">
                            <asp:Label ID="Label7" runat="server" Text="Apellido:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtApellidoUsuario" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style2" style="text-align: center">
                            <asp:TextBox ID="txtApellidoUsuario" runat="server" Width="250px" Font-Names="Arial"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtApellidoUsuario" ErrorMessage="Solo se permiten letras." ForeColor="Red" ValidationExpression="^[A-Za-z]+$">(*)</asp:RegularExpressionValidator>
                        </td>
                    </tr><tr>
                        <td class="auto-style2" style="text-align: center">
                            <asp:Label ID="Label10" runat="server" Text="Celular:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCelularUsuario" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style2" style="text-align: center">
                            <asp:TextBox ID="txtCelularUsuario" runat="server" Width="250px" Font-Names="Arial" TextMode="Phone" MaxLength="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3" style="text-align: center">
                            <asp:Label ID="Label11" runat="server" Text="E-Mail:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCorreoUsuario" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style3" style="text-align: center">
                            <asp:TextBox ID="txtCorreoUsuario" runat="server" Width="250px" Font-Names="Arial" TextMode="Email"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="text-align: center">
                            <asp:Label ID="Label12" runat="server" Text="Rol del Usuario:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlRol" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style2" style="text-align: center">

                            <asp:DropDownList ID="ddlRol" runat="server" Width="250px" AutoPostBack="True">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="text-align: center">
                            <asp:Label ID="Label13" runat="server" Text="Departamento:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlDepartamento" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style2" style="text-align: center">

                            <asp:DropDownList ID="ddlDepartamento" runat="server" Width="250px" AutoPostBack="True">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2" style="text-align: center">
                            <asp:Label ID="Label14" runat="server" Text="Password:"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPasswordUsuario" ErrorMessage="Campo Vacio" ForeColor="Red">(*)</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style2" style="text-align: center">
                            <asp:TextBox ID="txtPasswordUsuario" runat="server" Width="250px" Font-Names="Arial" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                        </td>
                        <td class="auto-style2">
                             <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="113px" OnClick="btnGuardar_Click" />
                        </td>
                    </tr>
                </table>
        </asp:Panel>
    </div>
    <br />
    <div style="border-style: double; width: 650px; text-align: center;" class="pantallaRol">
        <asp:GridView ID="gvUsuarios" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="7" CssClass="gridview" ForeColor="Black" Width="600px">
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
    </div>
</asp:Content>
