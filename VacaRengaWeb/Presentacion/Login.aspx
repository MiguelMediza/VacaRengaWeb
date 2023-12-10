<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="VacaRengaWeb.Presentacion.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-4"></div>
        <div class="col-sm-4">
            <div class="jumbotron text-center">
        
            <h2>Inicio de sesión</h2>
                <br />
            <p>
                <asp:Label ID="Label1" runat="server" Text="Usuario: " Width="150px"></asp:Label>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Contraseña: " Width="150px"></asp:Label>
                <asp:TextBox ID="txtContrasenia" type="password" runat="server"></asp:TextBox>
            </p>
            <asp:Button ID="btnInicio" class="btn btn-primary" runat="server" Text="Ingresar" OnClick="btnInicio_Click" />
            <p>
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </p>
           </div>
        </div>
        <div class="col-sm-4"></div>
    </div>
</asp:Content>
