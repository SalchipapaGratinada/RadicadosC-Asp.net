<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GCR.Pages.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Inicio
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div class="bienvenida">
        <p class="subBienvenida">BIENVENIDOS</p>
        <label class="sub2Bienvenida"><br /> Gases Caribe ®</label>
    </div>
    <form runat="server">
        <div class="card-group">
            <div class="card">
                <div class="divImg">
                    <img src="/Images/Pone.png" class="imgIndex" alt="Cargando...">
                </div>
                <div class="card-body">
                    <h5 class="card-title">Gestion Tipos Documentales</h5>
                    <p class="card-text">Aqui Gestiona Todos Los Tipos Documentales Que Se Han Ido Creando Y Modificando.</p>
                </div>
                <div class="card-footer divBotonIndexTD ">
                    <%--<small class="text-muted">Last updated 3 mins ago</small>--%>
                    <asp:Button runat="server" ID="btnTipoDocumental" CssClass="btn btn-success botonIndexTD" Text="Entrar" OnClick="btnTipoDocumental_Click" />
                </div>
            </div>
            <div class="card">
                <div class="divImg">
                    <img src="/Images/Ptow.png" class="imgIndex" alt="Cargando...">
                </div>
                <div class="card-body">
                    <h5 class="card-title">Gestion Modo</h5>
                    <p class="card-text">Aqui Gestiona Todos Los Modo De Los Diferentes Radicados.</p>
                </div>
                <div class="card-footer divBotonIndexTD ">
                    <%--<small class="text-muted">Last updated 3 mins ago</small>--%>
                    <asp:Button runat="server" ID="btnModo" CssClass="btn btn-success botonIndexTD" Text="Entrar" OnClick="btnModo_Click" />
                </div>
            </div>
            <div class="card">
                <div class="divImg">
                    <img src="/Images/Pthere.png" class="imgIndex" alt="Cargando...">
                </div>
                <div class="card-body">
                    <h5 class="card-title">Gestion Consecutivo-Año</h5>
                    <p class="card-text">ADMIN - Gestion De Conscutivo Y Año.</p>
                </div>
                <div class="card-footer divBotonIndexTD">
                    <%--<small class="text-muted">Last updated 3 mins ago</small>--%>
                    <asp:Button runat="server" ID="btnConsecutivo" CssClass="btn btn-success botonIndexTD" Text="Entrar" OnClick="btnConsecutivo_Click" />
                </div>
            </div>
        </div>
    </form>

</asp:Content>
