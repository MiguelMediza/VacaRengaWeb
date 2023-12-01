<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="VacaRengaWeb.Presentacion.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align:center">ABM Clientes</h1>

    
    <div class="jumbotron">
        <div class="row">
            <div class="col-sm-6">
                <p>
                 <asp:Label ID="id" runat="server" Text="ID:" Width="100px"></asp:Label>
                 <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                </p>
       
                <p>
                <asp:Label ID="Label4" runat="server" Text="Tipo:" Width="100px"></asp:Label>
                <br>
                </p>
                <p>
                <asp:RadioButton id="rbtEmpresa" Text="Empresa" Value="EMP" runat="server"  GroupName="Cliente" Checked="True" AutoPostBack="true" OnCheckedChanged="rbtEmpresa_CheckedChanged"></asp:RadioButton>
                </p>
                <p>
                <asp:RadioButton id="rbtPersona" Text="Persona" Value="PER" runat="server" GroupName="Cliente" AutoPostBack="true" OnCheckedChanged="rbtPersona_CheckedChanged"></asp:RadioButton>
                </p>
                <p>
                <asp:Label ID="lblempresa" runat="server" Text="Empresa:" Width="100px"></asp:Label>
                <asp:DropDownList ID="ddlEmpresa" AutoPostBack="true" runat="server" Width="200px"></asp:DropDownList>
                </p>
                <p>
                <asp:Label ID="Label5" runat="server" Text="Cédula:" Width="100px"></asp:Label>
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
                <asp:Label ID="lblMensajes" runat="server" Width="400px" Height="25px"></asp:Label>
                </p>

            </div>

            <div class="col-sm-6">
                <h1 style="font-size: 20px; color: cornflowerblue;"> Listado de Clientes Corporativos</h1>
                <asp:ListBox ID="lstClienteEmpresario" runat="server" Width="600px" Rows="8" AutoPostBack="true" OnSelectedIndexChanged="lstClienteEmpresario_SelectedIndexChanged" ></asp:ListBox>
            </div>

            <div class="col-sm-6">
                <h1 style="font-size: 20px; color: cornflowerblue;"> Listado de Clientes Comunes</h1>
                <asp:ListBox ID="lstClienteComun" runat="server" Width="600px" AutoPostBack="true"  Rows="8" OnSelectedIndexChanged="lstClienteComun_SelectedIndexChanged"></asp:ListBox>
            </div>


        </div>

        <p style="text-align:center;">
            <asp:LinkButton ID="LinkButton1" runat="server" style="text-align:center" OnClick="LinkButton1_Click">Limpiar</asp:LinkButton>
        </p>


        <p style="text-align:center;">
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        </p>

 </div>
</asp:Content>
