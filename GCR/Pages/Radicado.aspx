<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Radicado.aspx.cs" Inherits="GCR.Pages.Radicado" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Radicados
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/JavaScript.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width: 230px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
    </div>
    <br />
    <br />
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lbldroptd"  Visible="false" CssClass="form-label" >Tipo Documental</asp:Label>
                <asp:DropDownList ID="dropTipoDocumental" runat="server" Visible="True" CssClass="form-control" OnSelectedIndexChanged="dropTipoDocumental_SelectedIndexChanged" AutoPostBack="true">

                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lbldropm"  Visible="false" CssClass="form-label">Modo</asp:Label>
                <asp:DropDownList ID="dropModo" runat="server" Visible="True" CssClass="form-control">

                </asp:DropDownList>
            </div>
            <div class="mx-auto" style="font-size: 2rem">
                <asp:Label runat="server" CssClass="h2" ID="lblInfoRadicado"></asp:Label>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnGenerar" Text="Generar" Visible="True" OnClick="btnGenerar_Click" />
            <asp:Button runat="server" CssClass="btn btn-dark" ID="btnAtras" Text="Volver" Visible="True" OnClick="btnAtras_Click" />
        </div>
    </form>
</asp:Content>
