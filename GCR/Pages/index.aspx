<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GCR.Pages.index" EnableEventValidation="false" %>
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
        <div class="row row-cols-1 row-cols-md-2 g-4" style="max-width:700px">
            <div class="col" style="max-width:350px">
                <div class="card">
                    <img src="/Images/Pfour.jpg" class="imgIndex" alt="Cargando...">
                    <div class="card-body">
                        <h5 class="card-title">Radicados</h5>
                        <p class="card-text">Generacion De Radicados.</p>
                        <a href="Radicado.aspx" class="btn btn-primary botonIndexTD">Entrar</a>
                    </div>
                </div>
            </div>
            <div class="col" style="max-width:350px">
                <div class="card">
                    <img src="/Images/Pfive.jpg" class="imgIndex" alt="Cargando...">
                    <div class="card-body">
                        <h5 class="card-title">Relaciones</h5>
                        <p class="card-text">Generacion De Relaciones.</p>
                        <a href="Radicado.aspx" class="btn btn-primary botonIndexTD">Entrar</a>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <br />
        <div class="card-group" >
            <div class="card">
                <div class="divImg">
                    <img src="/Images/Pone.png" class="imgIndex" alt="Cargando...">
                </div>
                <div class="card-body">
                    <h5 class="card-title">Gestion Tipos Documentales</h5>
                    <p class="card-text">Aqui Gestiona Todos Los Tipos Documentales Que Se Han Ido Creando Y Modificando.</p>
                </div>
                <div class="card-footer divBotonIndexTD ">
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
                    <asp:Button runat="server" ID="btnConsecutivo" CssClass="btn btn-success botonIndexTD" Text="Entrar" OnClick="btnConsecutivo_Click" />
                </div>
            </div>
        </div>      
    </form>
    <br />
    <br />
    <br />

</asp:Content>
