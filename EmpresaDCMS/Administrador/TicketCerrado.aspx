<%@ Page Title="" Language="C#" MasterPageFile="~/Maestra.Master" AutoEventWireup="true" CodeBehind="TicketCerrado.aspx.cs" Inherits="EmpresaDCMS.WebForm8" EnableEventValidation="false"%>
<%@ MasterType  virtualPath="~/Maestra.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="border-style: double; width: 850px; text-align: center;" class="pantallaRol">
        <asp:Panel ID="panelTicket" runat="server">
            <asp:GridView ID="gvTicket" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" CssClass="gridview" ForeColor="Black" Width="801px" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Ticket No." DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:BoundField DataField="Ticket No." HeaderText="Ticket No." InsertVisible="False" ReadOnly="True" SortExpression="Ticket No." />
                    <asp:BoundField DataField="Solicitante" HeaderText="Solicitante" SortExpression="Solicitante" />
                    <asp:BoundField DataField="Tecnico" HeaderText="Tecnico" SortExpression="Tecnico" />
                    <asp:BoundField DataField="Fecha de Ingreso" HeaderText="Fecha de Ingreso" SortExpression="Fecha de Ingreso" ReadOnly="True" />
                    <asp:BoundField DataField="Fecha de Solucion" HeaderText="Fecha de Solucion" SortExpression="Fecha de Solucion" ReadOnly="True" />
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
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DCMSConnectionString %>" SelectCommand="SELECT idTicket AS 'Ticket No.', idEmpleado AS 'Solicitante', idTecnico AS 'Tecnico', CONVERT(VARCHAR(11), fechaIngreso,6) AS 'Fecha de Ingreso', CONVERT(VARCHAR(11), fechaSolucion,6) AS 'Fecha de Solucion' FROM Ticket WHERE (estadoTicket = 4)"></asp:SqlDataSource>
            <asp:Button ID="btnExportar" runat="server" OnClick="btnExportar_Click" Text="Exportar Reporte" />
        </asp:Panel>
    </div>
</asp:Content>
