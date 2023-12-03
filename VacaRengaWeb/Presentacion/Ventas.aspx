<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="VacaRengaWeb.Presentacion.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="text-align:center">ABM Ventas</h1>

    
    <div class="jumbotron">
        <div class="row">
            <div class="col-sm-6">
                <p>
                 <asp:Label ID="id" runat="server" Text="ID:" Width="100px"></asp:Label>
                 <asp:TextBox ID="txtId" runat="server" Enabled="False" Width="200px"></asp:TextBox>
                </p>
       
                <p>
                <asp:Label ID="Label4" runat="server" Text="Tipo Cliente:" Width="120px"></asp:Label>
                <br>
                </p>
                <p>
                <asp:RadioButton id="rbtEmpresa" Text="Empresa" Value="EMP" runat="server" GroupName="Cliente" Checked="True" AutoPostBack="true" OnCheckedChanged="rbtEmpresa_CheckedChanged"></asp:RadioButton>
                </p>
                <p>
                <asp:RadioButton id="rbtPersona" Text="Persona" Value="PER" runat="server"  GroupName="Cliente" AutoPostBack="true" OnCheckedChanged="rbtPersona_CheckedChanged"></asp:RadioButton>
                </p>
                <p>
                <asp:Label ID="Label8" runat="server" Text="Cliente:" Width="100px"></asp:Label>
                <asp:DropDownList ID="ddlClientes" AutoPostBack="true" runat="server" Width="200px"></asp:DropDownList>
                </p>
                <p>
                    <asp:Label ID="Label6" runat="server" Text="Fecha:" Width="100px"></asp:Label>
                    <asp:TextBox ID="txtFecha" type="date" runat="server" Width="200px"></asp:TextBox>
                </p>
                <p>
                    <asp:Label ID="Label7" runat="server" Text="Hora:" Width="100px"></asp:Label>
                    <asp:TextBox ID="txthora" type="time" runat="server" Width="200px"></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="lblInsumo" runat="server" Text="Insumo:" Width="100px"></asp:Label>
                <asp:DropDownList ID="ddlInsumos" AutoPostBack="true" runat="server" Width="200px" OnSelectedIndexChanged="ddlInsumos_SelectedIndexChanged"></asp:DropDownList>
                </p>
                <p>
                <asp:Label ID="Label5" runat="server" Text="Unidades:" Width="100px"></asp:Label>
                <asp:TextBox ID="txtunidades" runat="server" AutoPostBack="true" Width="200px" OnTextChanged="txtunidades_TextChanged" ></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="nombre" runat="server" Text="Precio:" Width="100px"></asp:Label>
                <asp:TextBox ID="txtprecio" runat="server" Enabled="false" Width="200px" ></asp:TextBox>
                </p>
                <p>
                <asp:Label ID="lblMensajes" runat="server" Width="400px" Height="25px"></asp:Label>
                </p>

            </div>

            <div class="col-sm-6">
                <h1 style="font-size: 20px; color: cornflowerblue;"> Listado ventas</h1>
                <asp:ListBox ID="lstVentas" runat="server" Width="600px" Rows="8" AutoPostBack="true" OnSelectedIndexChanged="lstVentas_SelectedIndexChanged" ></asp:ListBox>
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
