<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VacaRengaWeb.Presentacion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="color:#cad7b2; font-size: 36px; text-align: center;">Vaca Renga</h1>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/image1.png" Width="500px" style="text-align:center;" />

    <div class="jumbotron">

        <div class="row">
            <div class="col-sm-6">
                
                    <div>
                        <h1>Inicio Sesion</h1>
                        <p>
                            <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
                            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
                            <input id="txtContrasena" type="password" />
                        </p>
                        <p>
                            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" />
                        </p>


                    </div>
        
            </div>
        </div>
    </div>
</asp:Content>
