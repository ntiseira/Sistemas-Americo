<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="IU.PanelDeControl.Reportes" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reportes</title>
    
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
                <ext:Panel ID="Panel1" runat="server" Collapsible="true" Layout="accordion" Region="West" 
                    Split="true" Title="Listado de Reportes e Informes" Width="175">
                    <Items>
                        <ext:MenuPanel ID="MenuPanel1" runat="server" Border="false" Collapsed="True" Icon="FolderGo" 
                        Title="Reportes de Ventas">
                        <%--Reportes de Ventas--%>
                        
                            <Menu id="Menu1" runat="server">
                            <Items>
                                <ext:MenuItem ID="MenuItem34" runat="server" Text="Ventas Anuales">
                                    <Listeners>
                                        <Click Handler="addTab(#{TabPanel2}, 'Ventas anuales', '/PanelDeControl/EjemploGrafico.aspx');" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                            </Menu>
                        </ext:MenuPanel>
                        
                        <ext:MenuPanel ID="MenuPanel2" runat="server" Border="false" Collapsed="True" Icon="FolderGo" 
                        Title="Reportes de Compras">
                        <%--Reportes de Compras--%>
                        
                            <Menu id="Menu2" runat="server">
                            <Items>
                                <ext:MenuItem ID="MenuItem1" runat="server" Text="Compras Anuales">
                                    <Listeners>
                                        <Click Handler="addTab(#{TabPanel2}, 'Compras anuales', '/PanelDeControl/EjemploGrafico.aspx');" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                            </Menu>
                        </ext:MenuPanel>
                        
                        <ext:MenuPanel ID="MenuPanel3" runat="server" Border="false" Collapsed="True" Icon="FolderGo" 
                        Title="Reportes Administrador General">
                        <%--Reportes de Administrador General--%>
                        
                            <Menu id="Menu3" runat="server">
                            <Items>
                                <ext:MenuItem ID="MenuItem2" runat="server" Text="Usuarios de las Sucursales">
                                    <Listeners>
                                        <Click Handler="addTab(#{TabPanel2}, 'Usuarios de las Sucursales', '/PanelDeControl/GenReportes/General/UsuariosDeSucursales1.aspx');" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                            </Menu>
                        </ext:MenuPanel>
                    </Items>
                 </ext:Panel>

                
                <%--Panel Central--%>
                <ext:Panel ID="Panel2" runat="server" Layout="Fit" Region="Center" Title="">
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
