<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="DrucC.aspx.cs" Inherits="GCR.Pages.DrucC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
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
                <label class="form-label">Consecutivo</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbConsecutivo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Año</label>
                <asp:TextBox MaxLength="4" runat="server" CssClass="form-control" ID="tbAnio"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Referencia</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbReferencia"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnAcualizar" Text="Modificar" Visible="false" OnClick="btnAcualizar_Click" />
            <asp:Button runat="server" CssClass="btn btn-dark" ID="btnAtras" Text="Volver" Visible="True" OnClick="btnAtras_Click" />
        </div>
    </form>
</asp:Content>
