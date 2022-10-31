<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="TipoDocumental.aspx.cs" Inherits="GCR.Pages.TipoDocumental" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Gestion Tipo Documental
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/JavaScript.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width: 300px">
            <h2>Lista Tipos Documentales</h2>
        </div>
        <div class="container">
            <div class="row">
                <div class="mx-auto" style="width:300px">
                    <asp:Button runat="server" ID="btnCrearTD"  CssClass="btn btn-primary form-control-sm btnCrear" Text="Crear" OnClick="btnCrearTD_Click" ToolTip="Crear Nuevo Tipo Documental" />
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="table small">
                <asp:DropDownList ID="dropModo" runat="server" Visible="true" CssClass="drupSelecionModo btn btn-info" OnSelectedIndexChanged="dropModo_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:GridView runat="server" ID="gvtipodocumental" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate runat="server">
                                <asp:Button runat="server" ID="btnLeer" Text="Ver" class="btn btn-secondary form-control-sm" OnClick="btnLeer_Click" />
                                <asp:Button runat="server" ID="btnActualizar" Text="Actualizar" class="btn btn-warning form-control-sm" OnClick="btnActualizar_Click" />
                                <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" class="btn btn-danger form-control-sm" OnClick="btnEliminar_Click" />
                                <asp:Button runat="server" ID="btnmodo" Text="A" class="btn btn-light form-control-sm" OnClick="btnmodo_Click" ToolTip="Añadir Modo" />
                                <asp:Button runat="server" ID="btnmodoE" Text="E" class="btn btn-light form-control-sm" OnClick="btnmodoe_Click" ToolTip="Eliminar Modo"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>




</asp:Content>


