<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Insumos.aspx.cs" Inherits="VacaRengaWeb.Presentacion.Insumos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align:center">ABM Insumos</h1>
    <div class="jumbotron">

        <div class="row">
            <div class="col-sm-6">
                <p>
                    <asp:Label ID="id" runat="server" Text="ID:" Width="120px"></asp:Label>
                    <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="200px"></asp:TextBox>       
                </p>
                <p>
                    <asp:Label ID="nombre" runat="server" Text="Nombre:" Width="120px"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label1" runat="server" Text="Comentario:" Width="120px"></asp:Label>
                    <asp:TextBox ID="txtComentario" runat="server" Width="200px"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="lbproveedor" runat="server" Text="Proveedor:" Width="120px"></asp:Label>
                    <asp:DropDownList ID="ddlProveedor" AutoPostBack="true" runat="server" Width="200px" OnSelectedIndexChanged="ddlProveedor_SelectedIndexChanged"></asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="Label3" runat="server" Text="Info del Proveedor:" Width="323px" Enabled="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtInfoProveedor" runat="server" Width="319px" Enabled="False"></asp:TextBox>

                </p>

                <p>
                    <asp:Label ID="Label2" runat="server" Text="Stock:" Width="120px"></asp:Label>
                    <asp:TextBox ID="txtStock" runat="server" Width="200px"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label4" runat="server" Text="Precio x/unidad:" Width="120px"></asp:Label>
                    <asp:TextBox ID="txtprecio" runat="server" Width="200px"></asp:TextBox>
                </p>

                <p>
                <asp:Label ID="lblMensajes" runat="server" Width="400px" Height="25px"></asp:Label>
                </p>

            </div>


            <div class="col-sm-6">
                <h1 style="font-size: 20px; color: cornflowerblue;"> Listado de Insumos</h1>
                <asp:ListBox ID="lstInsumos" runat="server" Width="600px" Rows="8" AutoPostBack="true" OnSelectedIndexChanged="lstInsumos_SelectedIndexChanged"></asp:ListBox>
            </div>

        </div>
        <p style="text-align: center;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" >Limpiar</asp:LinkButton>
        </p>

        <p style="text-align:center;">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </p>

    </div>
</asp:Content>
