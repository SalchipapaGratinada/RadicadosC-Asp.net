<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="DrucGMT.aspx.cs" Inherits="GCR.Pages.DrucGMT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../Estilos/Estyle.css" rel="stylesheet" />
    <script src="../JavaScript/JavaScript.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

  <br />
    <div class="mx-auto" style="width:230px">
        <asp:Label runat="server" CssClass="h4" ID="lblTitulo">Gestion Modo Y T. Documental.</asp:Label>
    </div>
    <form runat="server" class="divDrucGMT">
        <div  class="containerModosDisponibles">
            <div class="mb-3">
                <label class="form-label">T. Documental</label>
                <asp:TextBox MaxLength="20" runat="server" CssClass="form-control" ID="tbTD"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Modos:</label>
                <asp:DropDownList ID="dropModos" runat="server" CssClass="dropConsec btn">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Consecutivos:</label>
                <asp:DropDownList ID="dropConsec" runat="server" CssClass="dropConsec btn" AutoPostBack="true" OnSelectedIndexChanged="dropConsec_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre Consecutivo</label>
                <asp:TextBox MaxLength="100" runat="server" CssClass="form-control" ID="tbNombreConsec"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnAgregar" Text="Agregar" Visible="True" OnClick="btnAgregar_Click" />
            
            <asp:Button runat="server" CssClass="btn btn-dark" ID="btnAtras" Text="Volver" Visible="True" OnClick="btnAtras_Click"/>
        </div>
        <div class="containerDrupAgregados">
            <div class="mb-3">
                <label class="form-label">Modos Agregados:</label>
                <asp:DropDownList ID="dropModosAgregados" runat="server" CssClass="dropConsec btn">
                </asp:DropDownList>
            </div>
            <asp:Button runat="server" CssClass="btn btn-danger" ID="btnEliminar" Text="Eliminar" Visible="True" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Esta Seguro De Eliminar El Modo Del Tipo Documental?');"/>
        </div>
    </form>



</asp:Content>
