<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boleto.aspx.cs" Inherits="UnimedVsfSystem.Boleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<script type="text/javascript">
    function Imprimir() {
        document.getElementById('divImpressao1').style.visibility = 'hidden';
        //document.getElementById('divImpressao2').style.visibility = 'hidden';
        window.print();
    }
</script>
<body style="width: 100%">
    <form id="form1" runat="server">
        <div style="text-align:center;" id="divImpressao1">
            <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="Imprimir(); " 
                Height="50px" Width="180px" ImageUrl="~/Imagens/Icones/Imprimir.png" OnClick="ImprimirBehind"/>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Panel ID="panelBoleto" runat="server" style="margin-left: 25px"/>
        </div>
<%--        <div style="text-align:center;" id="divImpressao2">
            <asp:ImageButton ID="ImageButton2" runat="server" OnClientClick="Imprimir();" 
                Height="50px" Width="180px" ImageUrl="~/Imagens/Icones/Imprimir.png" OnClick="ImprimirBehind"/>
        </div>--%>
    </form>
</body>
</html>
