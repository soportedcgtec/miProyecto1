<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebFormApp.pages.admin.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Admin inicio de Sesion</title>
    <link rel="stylesheet" href="<% =Utils.baseUrl()%>www/css/pages/admin/login.css" />
    <style type="text/css">
        .auto-style1 {
            width: 120px;
        }
        .auto-style2 {
            width: 120px;
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
        }

        /*Adicion manual*/
        .aspNetHidden{display:none;}
    </style>
</head>
<body>

    <div class="pc-tab">
        <input id="tab1" type="radio" name="pct" checked="checked" />
        <input id="tab2" type="radio" name="pct" />
        <nav>
            <ul>
                <li class="tab1">
                    <label for="tab1">Login WebForm</label>
                </li>
                <li class="tab2">
                    <label for="tab2">login Standard</label>
                </li>
            </ul>
        </nav>
        <section>

            <div class="tab1">
                <form id="frmLogin" visible="true" runat="server">
                    <asp:RadioButton ID="rdbtnLoginA" runat="server" Text="Login WebForm 1" AutoPostBack="True" TextAlign="Left" GroupName="Logins" OnCheckedChanged="rdbtnLoginA_CheckedChanged" Checked="true" />
                    <asp:RadioButton ID="rdbtnLoginB" runat="server" Text="Login WebForm 2" AutoPostBack="True" TextAlign="Left" GroupName="Logins" OnCheckedChanged="rdbtnLoginB_CheckedChanged" Checked="false" />

                    <% /*Formulario Forma A*/ %>
                    <asp:Panel id="panelLoginA" visible="true" runat="server">
                        <asp:Login ID="Login" runat="server" OnAuthenticate="ValidateUser" DisplayRememberMe="False"></asp:Login>
                    </asp:Panel>

                    <% /*Formulario Forma B*/ %>
                    <asp:Panel id="panelLoginB" visible="false" runat="server">
                        <table border="0" style="width: 258px">
                            <tr><td class="auto-style1">usuario:</td>
                                <td><asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr><td class="auto-style2">password:</td>
                                <td class="auto-style3"><asp:TextBox ID="txtPass" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr><td colspan="2">
                                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Iniciar Sesion" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </form>
            </div>

            <div class="tab2">
                login Standard
            </div>
        </section>
    </div>

    <footer> 2018 </footer>
  
</body>
</html>
