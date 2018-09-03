<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/pages/portal/portal.Master" CodeBehind="contacto.aspx.cs" Inherits="WebFormApp.pages.contacto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <% 
    if (Request.Form.AllKeys.Length > 0) {
        Response.Write(nombre + "|" + telefono+ "| varget:" + varget);
    } 
    %>
    <form id="form1" action="?varget=8" method="post">
        <div><b>nombre :</b><input type="text" id="nombre" name="nombre" /></div>
        <div><b>telefono :</b><input type="text" id="telefono" name="telefono" /></div>
        <div><input type="submit" value="Enviar" /></div>
    </form>

</asp:Content>
