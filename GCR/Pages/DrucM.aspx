<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="DrucM.aspx.cs" Inherits="GCR.Pages.DrucM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Druc M
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <br />
    <div class="mx-auto" style="width: 230px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <label class="form-label">Codigo</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbCodigo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbNombre"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCrear" Text="Crear" Visible="false" OnClick="btnCrear_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnAcualizar" Text="Actualizar" Visible="false" OnClick="btnAcualizar_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnEliminar" Text="Eliminar" Visible="false" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Esta Seguro De Eliminar Modo?');" />
            <asp:Button runat="server" CssClass="btn btn-dark" ID="btnAtras" Text="Volver" Visible="True" OnClick="btnAtras_Click" />
        </div>
    </form>


</asp:Content>
