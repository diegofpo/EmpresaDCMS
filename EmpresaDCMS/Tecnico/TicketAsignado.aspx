<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnicos.Master" AutoEventWireup="true" CodeBehind="TicketAsignado.aspx.cs" Inherits="EmpresaDCMS.WebForm18" %>
<%@ MasterType  virtualPath="~/Tecnicos.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-style:double; width: 820px; text-align: center;" class="pantallaRol">
        <asp:Panel ID="panelTicket" runat="server">
            <asp:GridView ID="gvAsignado" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" CssClass="gridview" ForeColor="Black" Width="801px" OnSelectedIndexChanged="gvAsignado_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
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
        <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div style="border-style:double; width: 820px; text-align: center;" class="pantallaRol">
        <asp:Panel ID="panelDetalle" runat="server" Visible="False">
            <asp:GridView ID="gvDetalle" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" CssClass="gridview" ForeColor="Black" Width="801px">
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
            <br />
            <asp:Button ID="btnActualizar" runat="server" Text="Marcar como Completo" OnClick="btnActualizar_Click" />
        </asp:Panel>
    </div> 
</asp:Content>
