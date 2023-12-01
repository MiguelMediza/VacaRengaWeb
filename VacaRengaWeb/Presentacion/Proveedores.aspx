<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="VacaRengaWeb.Presentacion.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 style="text-align:center">ABM Proveedores</h1>

    
    <div class="jumbotron">
        <div class="row">
            <div class="col-sm-6">
                <p>
                 <asp:Label ID="id" runat="server" Text="ID:" Width="100px"></asp:Label>
                 <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="Label7" runat="server" Text="Cédula:" Width="100px"></asp:Label>
                <asp:TextBox ID="txtCedula" runat="server" Width="200px" ></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="nombre" runat="server" Text="Nombre:" Width="100px"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" Width="200px" ></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="Label1" runat="server" Text="Apellido:" Width="100px"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" Width="200px"></asp:TextBox>
                 </p>
                <p>
                <asp:Label ID="Label2" runat="server" Text="Dirección:" Width="100px"></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" Width="200px"></asp:TextBox>
                  </p>
                <p>
                <asp:Label ID="Label3" runat="server" Text="Teléfono:" Width="100px"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" Width="200px"></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="Label4" runat="server" Text="Tipo producto provee:" Width="224px"></asp:Label>
                <br />
                <asp:TextBox ID="txtTipoProducto" runat="server" Width="301px"></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="Label5" runat="server" Text="Procedencia:" Width="100px"></asp:Label>
                <br>
                </p>
                <p>
                <asp:RadioButton id="rbtNacional" Text="Nacional" Value="NAC" runat="server"  GroupName="Nacionalidad" Checked="True" AutoPostBack="true" OnCheckedChanged="rbtNacional_CheckedChanged"></asp:RadioButton>
                </p>
                <p>
                <asp:RadioButton id="rbtExtranjero" Text="Extranjero" Value="EXT" runat="server" GroupName="Nacionalidad" AutoPostBack="true" OnCheckedChanged="rbtExtranjero_CheckedChanged"></asp:RadioButton>
                </p>
                <p>
                <asp:Label ID="Label6" runat="server" Text="Impuestos aranceles:" Width="230px"></asp:Label>
                <br />
                <asp:TextBox ID="txtImpuestos" runat="server" Width="300px"></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="lblMensajes" runat="server" Width="400px" Height="25px"></asp:Label>
                </p>

            </div>

            <div class="col-sm-6">
                <h1 style="font-size: 20px; color: cornflowerblue;"> Listado de Proveedores</h1>
                <asp:ListBox ID="lstProveedores" runat="server" Width="600px" Rows="8" AutoPostBack="true" OnSelectedIndexChanged="lstProveedores_SelectedIndexChanged" ></asp:ListBox>
            </div>


        </div>

        <p style="text-align:center;">
            <asp:LinkButton ID="LinkButton1" runat="server" style="text-align:center" OnClick="LinkButton1_Click" >Limpiar</asp:LinkButton>
        </p>


        <p style="text-align:center;">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click"  />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click"  />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </p>

 </div>
</asp:Content>
