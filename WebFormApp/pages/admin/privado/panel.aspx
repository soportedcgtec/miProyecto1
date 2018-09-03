<%@ Page Title="" Language="C#" MasterPageFile="~/pages/admin/privado/admin.Master" AutoEventWireup="true" CodeBehind="panel.aspx.cs" Inherits="WebFormApp.pages.admin.privado.panel" %>

<asp:Content ID="IdHeadTitle" ContentPlaceHolderID="HeadTitle" runat="server">Panel de Usuario</asp:Content>

<asp:Content ID="IdMainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Bienvenidooo!!!</h2>
        <form id="formBienvenido" runat="server">
            <asp:LoginName ID="LoginName1" runat="server" Font-Bold = "true" />
            <asp:LoginStatus ID="LoginStatus1" runat="server" />
        </form>
    </div>
</asp:Content>
