<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Grafico.ascx.cs" Inherits="IU.Generico.Grafico" %>

<%@ Register tagPrefix="Web" Namespace="WebChart" Assembly="WebChart" %>

<html>
<head><title>Graficador</title></head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
    <table>
        <tr>
            <td>
                <Label ID="FechaDesde" Text="Fecha Desde" runat="server">
                </Label>
            </td>
            <td>
                <Label ID="FechaHasta" Text="Fecha Hasta" runat="server">
                </Label>
                
            </td>
        </tr>
        
        <tr>
            <td>
                <ext:DatePicker ID="FechaDesdeCombo" PrevText="Fecha desde" runat="server">
                </ext:DatePicker>
            </td>
            <td>
                <ext:DatePicker ID="FechaHastaCombo" PrevText="Fecha hasta" runat="server">
                </ext:DatePicker>
            </td>
        </tr>
        
        <tr>
            <td>
            <asp:Button ID="Button" runat="server" Text="Consultar Estadística" onclick="Button_Click" />
            <Web:ChartControl Width="400" Height="300" id="ChartControl1" runat="Server" />        
            </td>
        </tr>
            
        
    </table>
</body>
</html>
