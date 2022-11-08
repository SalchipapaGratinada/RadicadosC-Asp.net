<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="TipoDocumental.aspx.cs" Inherits="GCR.Pages.TipoDocumental" EnableEventValidation="false" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Gestion Tipo Documental
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/JavaScript.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" />
    <script src="https://kit.fontawesome.com/8ff093999c.js" crossorigin="anonymous"></script>
    <link href="../Estilos/EstylePaginaEmergente.css" rel="stylesheet" />
    <script src="../JavaScript/popup.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <asp:ScriptManager ID="asm" runat="server" />
        <br />
        <div class="mx-auto" style="width: 300px; margin-bottom:-0.8rem">
            <h2>Lista Tipos Documentales</h2>
        </div>
        <div class="container">
            <div class="row">
                <div class="mx-auto" style="width: 300px">
                    <asp:Button runat="server" ID="btnCrearTD"  CssClass="btn btn-primary form-control-sm btnCrear" Text="Crear" OnClick="btnCrearTD_Click" ToolTip="Crear Nuevo Tipo Documental" />
                </div>
            </div>
        </div>
        <br />
        <asp:Button runat="server" ID="btnConfig" Text="" Visible="false" class="drupSelecionModo btn btn-light form-control-sm"  ToolTip="Consiguracion Nodo-Consecutivo" />
        <ajax:ModalPopupExtender ID="mpe" runat="server" TargetControlID="btnConfig" PopupControlID="ModalPanel" OkControlID="OKButton"></ajax:ModalPopupExtender>
        <div class="container">
            <div class="table small">
                <div style="overflow: auto; height: 400px">
                    <asp:GridView runat="server" ID="gvtipodocumental" class="table table-borderless table-hover" OnRowDataBound="gvtipodocumental_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Opciones">
                                <ItemTemplate runat="server">
                                    <asp:Button runat="server" ID="btnLeer" Text="Ver" class="btn btn-secondary form-control-sm" OnClick="btnLeer_Click" />
                                    <asp:Button runat="server" ID="btnActualizar" Text="Actualizar" class="btn btn-warning form-control-sm" OnClick="btnActualizar_Click" />
                                    <asp:Button runat="server" ID="btnGestionModos" Text="Ges. Modos" class="btn btn-success form-control-sm" OnClick="btnGestionModos_Click" />
                                    <asp:Button runat="server" ID="btnmodo" Visible="false" Text="A" class="btn btn-light form-control-sm" ToolTip="Añadir Modo" />
                                    <asp:Button runat="server" ID="btnmodoE" Visible="false" Text="E" class="btn btn-light form-control-sm" ToolTip="Eliminar Modo" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
       <%-- <asp:Panel  ID="ModalPanel" runat="server" Width="500px">
            <div class="overlay" id="overlay">
                <div class="popup" id="popup">
                    <h5>CONSECUTIVO - MODO</h5>
                    <h6>Puede Selecionar Consec. Nuevo o Uno Existente.</h6>
                    <h6>Obligatorio Seleccionar Modo.</h6>
                    <div class="contenedor-drop">
                        <asp:DropDownList ID="dropConsec" runat="server" CssClass="dropConsec btn btn-secondary">
                        </asp:DropDownList>
                        <asp:DropDownList ID="dropModo" runat="server" Visible="true" CssClass="dropConsec btn btn-secondary" OnSelectedIndexChanged="dropModo_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:Label runat="server" CssClass="h7" ID="lblReferencia"></asp:Label>
                    </div>
                    <div>
                        <asp:Button ID="OKButton" runat="server" class="btn-submit btn btn-success" Text="OK" />
                    </div>
                </div>
            </div>
        </asp:Panel>--%>
    </form>

</asp:Content>

    
