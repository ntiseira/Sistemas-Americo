<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevaPrincipal.aspx.cs" Inherits="IU.NuevaPrincipal" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sistema Contable</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>           
        <%-- Resource manager --%>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <%-- Contenedor de todos los componentes --%>
        <ext:Viewport ID="Viewport1" runat="server" Layout="border">
            <Items>
                <%-- Panel superior --%>
                <ext:Panel runat="server" Collapsible="True" Height="100" Region="North" 
                    Split="True" Title="Sistema Contable v1.0">
                    <Items>
                    </Items>
                </ext:Panel>
                <%-- Panel derecho --%>
                <ext:Panel runat="server" Collapsible="true" Layout="Fit" Region="East" 
                    Split="true" Title="East" Width="175">
                    <Items>
                        <ext:TabPanel runat="server" ActiveTabIndex="0" Border="false" 
                            TabPosition="Bottom" Title="Title">
                            <Items>
                                <ext:Panel runat="server" Title="Tab 1">
                                    <Items>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Title="Tab 2">
                                    <Items>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:TabPanel>
                    </Items>
                </ext:Panel>
                
                <%-- Panel inferior --%>
                <ext:Panel runat="server" Collapsible="true" Height="100" Region="South" 
                    Split="true" Title="South">
                    <Items>
                    </Items>
                </ext:Panel>
                
                <%-- Panel izquierdo --%>
                <ext:Panel runat="server" Collapsible="true" Layout="accordion" Region="West" 
                    Split="true" Title="Menú principal" Width="200">
                    <Items>
                        <%-- Administración general --%>
                        <ext:Panel ID="Panel3" runat="server" Border="false" Collapsed="True" Icon="Folder" 
                            Title="Administración general">
                            <Items>
                            </Items>
                        </ext:Panel>                        
                        
                        <%-- Caja y bancos --%>
                        <ext:Panel ID="Panel4" runat="server" Border="false" Collapsed="True" Icon="Folder" 
                            Title="Caja y bancos">
                            <Items>
                            </Items>
                        </ext:Panel>
                        
                        <%-- Compras y cuentas a pagar --%>
                        <ext:Panel ID="Panel6" runat="server" Border="false" Collapsed="True" Icon="Folder" 
                            Title="Compras y cuentas a pagar">
                            <Items>
                            </Items>
                        </ext:Panel>
                        
                        <%-- Contabilidad --%>
                        <ext:Panel ID="Panel1" runat="server" Border="false" Collapsed="true" Icon="Folder" 
                            Title="Contabilidad">
                            <Items>
                                <%-- Submenú --%>
                                <ext:MenuPanel ID="MenuPanel1" runat="server" Height="300" Title="" Width="185">
                                    <Menu runat="server">
                                        <Items>
                                            <%-- Asientos --%>
                                            <ext:MenuItem ID="MenuItem1" runat="server" Text="Asientos">
                                                <Menu>
                                                    <ext:Menu ID="Menu1" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem2" runat="server" Text="Gestión">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem3" runat="server" Text="Reportes">
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            <%-- Centros de costos --%>
                                            <ext:MenuItem ID="MenuItem7" runat="server" Text="Centros de costo">
                                            </ext:MenuItem>
                                            
                                            <%-- Cuentas --%>
                                            <ext:MenuItem ID="MenuItem6" runat="server" Text="Cuentas">
                                            </ext:MenuItem>
                                            
                                            <%-- Tipos de asientos --%>
                                            <ext:MenuItem ID="MenuItem4" runat="server" Text="Tipos de asientos">
                                            </ext:MenuItem>
                                            
                                            <%-- Tipos de movimientos --%>
                                            <ext:MenuItem ID="MenuItem5" runat="server" Text="Tipos de movimientos">
                                            </ext:MenuItem>
                                        </Items>
                                    </Menu>
                                </ext:MenuPanel>
                            </Items>
                        </ext:Panel>
                                                
                        <%-- Impuestos --%>
                        <ext:Panel ID="Panel7" runat="server" Border="false" Collapsed="True" Icon="Folder" 
                            Title="Impuestos">
                            <Items>
                            </Items>
                        </ext:Panel>       
                                    
                        <%-- Sueldos y jornales --%>
                        <ext:Panel ID="Panel2" runat="server" Border="false" Collapsed="true" Icon="Folder" 
                            Title="Sueldos y jornales">
                            <Items>
                             <%-- Submenú --%>
                                <ext:MenuPanel ID="MenuPanel2" runat="server" Height="300" Title="" Width="185">
                                <Menu ID="Menu2" runat="server">
                                        <Items>
                                            <%-- SubMenú General --%>
                                            <ext:MenuItem ID="MenuItem8" runat="server" Text="General">
                                                <Menu>
                                                    <ext:Menu ID="Menu3" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem9" runat="server" Text="Personal">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem10" runat="server" Text="Categoría y Básicos">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem11" runat="server" Text="Feriados">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem12" runat="server" Text="Centro de costos">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem13" runat="server" Text="Datos empleador">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem14" runat="server" Text="Planilla horaria">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem15" runat="server" Text="Obras Sociales">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem16" runat="server" Text="Lugares de pago">
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            </Items>
                                            </Menu>
                                </ext:MenuPanel>
                            </Items>
                        </ext:Panel>
                                                
                        <%-- Ventas y cuentas a cobrar --%>
                        <ext:Panel ID="Panel5" runat="server" Border="false" Collapsed="True" Icon="Folder" 
                            Title="Ventas y cuentas a cobrar">
                            <Items>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:Panel>
                
                <%-- Panel central --%>
                <ext:Panel runat="server" Layout="Fit" Region="Center" Title="Center">
                    <Items>
                        <ext:TabPanel runat="server" ActiveTabIndex="0" Border="false" Title="Center">
                            <Items>
                                <ext:Panel runat="server" Title="asdf">
                                   <Content>
                                       <asp:Label ID="Label1" runat="server" Text="Acá se puede modificar el código del contenido"></asp:Label>
                                   </Content>
                                </ext:Panel>
                            </Items>
                        </ext:TabPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>

                
                        
    </div>
    </form>
</body>
</html>
