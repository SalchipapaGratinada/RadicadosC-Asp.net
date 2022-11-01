<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Consecutivo.aspx.cs" Inherits="GCR.Pages.Consecutivo" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Informacion Consecutivo - Año
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
            <h2>CONSECUTIVO</h2>
        </div>
        <br />
        <div class="container">
            <div class="table small">
                <div class="cTextoKeyCons">
                    <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="tbkey"></asp:TextBox>
                </div>
                <asp:GridView runat="server" ID="gvconsecutivo" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnLeer" Text="Ver" class="btn btn-secondary form-control-sm" OnClick="btnLeer_Click" />
                                <asp:Button runat="server" ID="btnActualizar" Text="Modifiar" class="btn btn-warning form-control-sm" OnClick="btnActualizar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</asp:Content>
