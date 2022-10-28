<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="DrucRl.aspx.cs" Inherits="GCR.Pages.DrucRl" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Druc Relaciones
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
                <asp:Label runat="server" ID="lbldroptd"  Visible="false" CssClass="form-label" >Tipo Documental</asp:Label>
                <asp:DropDownList ID="dropTipoDocumental" runat="server" Visible="false" CssClass="form-control">

                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lbldropm"  Visible="false" CssClass="form-label">Modo</asp:Label>
                <asp:DropDownList ID="dropModo" runat="server" Visible="false" CssClass="form-control">

                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Label runat="server" ID="lbltd" Visible="false" CssClass="form-label">Tipo Documental</asp:Label>
                <%--<label class="form-label">Codigo</label>--%>
                <asp:TextBox MaxLength="20" runat="server" Visible="false" CssClass="form-control" ID="tbtipod"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lblmodo" Visible="false" CssClass="form-label">Modo</asp:Label>
                <%--<label class="form-label">Nombre</label>--%>
                <asp:TextBox MaxLength="100" runat="server"  Visible="false" CssClass="form-control" ID="tbmodo"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lblconsec" Visible="false" CssClass="form-label">Consecutivo</asp:Label>
                <%--<label class="form-label">Formato</label>--%>
                <asp:TextBox MaxLength="100" runat="server"  Visible="false" CssClass="form-control" ID="tbconsecu"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lblanio"  Visible="false" CssClass="form-label">Año</asp:Label>
                <%--<label class="form-label">Nombre</label>--%>
                <asp:TextBox MaxLength="100" runat="server"  Visible="false" CssClass="form-control" ID="tbanio"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" ID="lblfecha" Visible="false" CssClass="form-label">Fecha</asp:Label>
                <%--<label class="form-label">Formato</label>--%>
                <asp:TextBox MaxLength="100" runat="server"  Visible="false" CssClass="form-control" ID="tbfecha"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCrear" Text="Crear" Visible="false" OnClick="btnCrear_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnAcualizar" Text="Actualizar" Visible="false" OnClick="btnAcualizar_Click" />
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnEliminar" Text="Eliminar" Visible="false" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Esta Seguro De Eliminar Relacion?');" />
            <asp:Button runat="server" CssClass="btn btn-dark" ID="btnAtras" Text="Volver" Visible="True" OnClick="btnAtras_Click" />
        </div>
    </form>

</asp:Content>
