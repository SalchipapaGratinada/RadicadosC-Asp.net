<%@ Page Title="" Language="C#" MasterPageFile="~/MP.Master" AutoEventWireup="true" CodeBehind="Pdf.aspx.cs" Inherits="GCR.Pages.Pdf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <script type="text/javascript">
        function ShowPreviewPdf(input) {
            if (input.files && input.files[0]) {
                var ext = input.files[0].name.split('.').pop().toLowerCase();
                var imageDir = new FileReader();
                imageDir.onload = function (e) {
                    if (ext == 'pdf') {
                        $("#imgage").attr('src', '');
                        document.getElementsByTagName("iframe")[0].setAttribute("src", e.target.result);    
                    }
                }
                imageDir.readAsDataURL(input.files[0]);
            }
        }
        
    </script>      
    <h3 style="text-align:center">Aqui Probare El PDF</h3>
    <form id="Form1" runat="server" method="post" enctype="multipart/form-data" action="Pdf.aspx">
        <div style="text-align:center">
            <div style="margin:0px auto; width:550px; border:solid ">
                <iframe id="iframe" style="width: 500px; height: 400px"></iframe>
            </div>
            <br />
            <div>
                <asp:FileUpload runat="server" ID="fileUPdf" onchange="ShowPreviewPdf(this)" />
                <br />
                <asp:Label runat="server" ID="Label1" Style="color:chocolate; font-weight:bold"></asp:Label>
                <br />
                <br />
                <asp:Button runat="server" CssClass="btn btn-success" Enabled="true"  ID="btnSubirArchivo" Text="Subir Archivo" OnClick="btnSubirArchivo_Click" />
                <asp:Button  runat="server" CssClass="btn btn-warning" ID="btnPrueba" Text="Prueba" OnClick="btnPrueba_Click"/>
            </div>
        </div>
    </form>

</asp:Content>

<%--            <iframe runat="server" id="iframepdf" width="0" height="0" style="border: none"></iframe>--%>