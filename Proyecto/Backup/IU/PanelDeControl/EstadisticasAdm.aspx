<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasAdm.aspx.cs" Inherits="IU.PanelDeControl.EstadisticasAdm" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Estadísticas</title>
    
    <script type="text/javascript" src="js/util.js">
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <ext:ResourceManager ID="ResourceManager2" runat="server" />
        
        <ext:Viewport ID="Viewport2" runat="server" Layout="border">
            <Items>
                <%--Panel Izquierdo--%>
                <ext:Panel runat="server" Collapsible="true" Layout="accordion" Region="West" 
                    Split="true" Title="Listado de Estadísticas" Width="175">
                    <Items>
                        <ext:MenuPanel ID="Panel1" runat="server" Border="false" Collapsed="True" Icon="FolderGo" 
                        Title="Estadísticas de Ventas">
                        <%--Estadísticas de Ventas--%>
                        
                            <Menu id="Menu1" runat="server">
                            <Items>
                                <ext:MenuItem ID="MenuItem34" runat="server" Text="Ventas Mensuales">
                                    <Listeners>
                                        <Click Handler="addTab(#{TabPanel2}, 'Ventas Mensuales', '/PanelDeControl/Estadisticas/EstadisticasDeVentas/EstadisticasVentas.aspx');" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItem2" runat="server" Text="Estadísticas de Clientes">
                                    <Listeners>
                                        <Click Handler="addTab(#{TabPanel2}, 'Ventas Mensuales', '/PanelDeControl/Estadisticas/EstadisticasDeVentas/EstadisticasClientes.aspx');" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                            </Menu>
                        </ext:MenuPanel>
                        
                        <ext:MenuPanel ID="MenuPanel1" runat="server" Border="false" Collapsed="True" Icon="FolderGo" 
                        Title="Estadísticas de Compras">
                        <%--Estadísticas de Compras--%>
                        
                            <Menu id="Menu2" runat="server">
                            <Items>
                                <ext:MenuItem ID="MenuItem1" runat="server" Text="Compras Anuales">
                                    <Listeners>
                                        <Click Handler="addTab(#{TabPanel2}, 'Compras anuales', '/PanelDeControl/Estadisticas/EstadisticasDeCompras/EstadisticasCompras.aspx');" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                            </Menu>
                        </ext:MenuPanel>
                    </Items>
                 </ext:Panel>

                
                <%--Panel Central--%>
                <ext:Panel runat="server" Layout="Fit" Region="Center" Title="">
                    <Items>
                        <ext:TabPanel 
                        runat="server" 
                        ID="TabPanel2"
                        EnableTabScroll="true"
                        AnimScroll="true">
                        </ext:TabPanel>
                    </Items>
                </ext:Panel>
            </Items>
            
        </ext:Viewport>
    
    </div>
    </form>
</body>
</html>
