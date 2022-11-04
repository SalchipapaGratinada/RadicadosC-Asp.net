<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Modo.aspx.cs" Inherits="GCR.Pages.Modo" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Gestion Modo
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width: 160px">
            <h2>Lista Modos</h2>
        </div>
        <div class="container">
            <div class="row">
                <div class="mx-auto" style="width:200px">
                    <asp:Button runat="server" ID="btnCrearModo" CssClass="btn btn-primary form-control-sm btnCrear" Text="Crear" OnClick="btnCrearModo_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container">
            <div class="table small">
                <div class="cTextoKeyCons">
                    <asp:TextBox runat="server" CssClass="form-control" ID="tbbuscar"></asp:TextBox>
                    <asp:Button runat="server" ID="btnBuscar" Text="Buscar" class="btn btn-success form-control-sm" OnClick="btnBuscar_Click"/>
                </div>
                <div style="overflow: auto; height: 400px">
                    <asp:GridView runat="server" ID="gvmodo" class="table table-borderless table-hover">
                        <Columns>
                            <asp:TemplateField HeaderText="Opciones">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnLeer" Text="Ver" class="btn btn-secondary form-control-sm" OnClick="btnLeer_Click" />
                                    <asp:Button runat="server" ID="btnActualizar" Text="Actualizar" class="btn btn-warning form-control-sm" OnClick="btnActualizar_Click" />
                                    <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" class="btn btn-danger form-control-sm" OnClick="btnEliminar_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>

</asp:Content>
