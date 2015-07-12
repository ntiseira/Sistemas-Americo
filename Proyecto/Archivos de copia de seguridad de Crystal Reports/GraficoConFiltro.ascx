<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GraficoConFiltro.ascx.cs" Inherits="IU.Generico.GraficoConFiltro" %>

<%@ Register tagPrefix="Web" Namespace="WebChart" Assembly="WebChart" %>


<html>
<head><title>Graficador</title></head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server">
    </ext:ResourceManager>
    <ext:Store ID="Store1" runat="server">
    </ext:Store>
    <table>
        
        
        
        <tr>
                <ext:Panel 
                ID="Panel2" 
                runat="server" 
                Height="300" 
                Header="false" 
                Layout="Fit">
                    <Items>  
         <%--Panel de abms--%>
                        <ext:GridPanel 
                        ID="GridPanel1" 
                        runat="server" 
                        Height="300" 
                        StoreID="Store1"              
                        Border="false"   
                        >
                            <Plugins>
                                <ext:GridFilters runat="server" ID="GridFilters1" Local="true">
                                    <Filters>
                                    </Filters>
                                </ext:GridFilters>
                            </Plugins>
                        
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" >
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <TopBar>
                                <ext:Toolbar 
                                runat="server" 
                                ID="TopBarFiltros" 
                                Visible="true" 
                                AutoHeight="true"
                                >
                                    <Items>
                                        <%--Controles de filtros--%>
                                        <ext:ComboBox runat="server" 
                                        ID="CampoFiltro" 
                                        StoreID="Store1"
                                        Mode="Local"
                                        EmptyText="Filtros"
                                        Editable="false"
                                        TypeAhead="true" 
                                        ForceSelection="true"
                                        TriggerAction="All"            
                                        DisplayField="display"
                                        ValueField="display"
                                        ValueNotFoundText=""
                                        >
                                        </ext:ComboBox>
                                        
                                        <ext:Panel ID="Separador1" Width="4" Height="0" Border="false" runat="server">
                                        </ext:Panel>
                                        
                                        <ext:TextField ID="ValorFiltro" runat="server" Text="Valor">
                                        </ext:TextField>
                                        
                                        <ext:Panel ID="Panel3" Width="4" Height="0" Border="false" runat="server">
                                        </ext:Panel>
                                        
                                        <ext:Button runat="server" ID="buttonFiltro" Text="Filtrar">
                                            <DirectEvents>
                                                <Click OnEvent="Button_Click" />
                                            </DirectEvents>
                                        </ext:Button>
                                         
                                        <ext:Button runat="server" ID="buttonClean" Text="Limpiar">
                                            <DirectEvents>
                                                <Click OnEvent="buttonClean_OnClick" />
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            </ext:GridPanel>
                            </Items>
                </ext:Panel>
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
