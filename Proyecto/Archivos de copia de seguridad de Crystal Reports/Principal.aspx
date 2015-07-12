<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="IU.NuevaPrincipal" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sistema Contable Américo</title>
    
    <script type="text/javascript" src="js/util.js">
    </script>
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
                <ext:Panel ID="panelSuperior" runat="server" Height="100" Region="North" 
                    Split="True" Title="Sistema Contable Américo v1.0">
                    <Content>
                        <asp:Image ID="Image1" runat="server" ImageUrl="/images/banner.jpg" />
                    </Content>
                </ext:Panel>
                <%-- Panel derecho --%>
                <ext:Panel ID="panelDerecho1" runat="server" 
                    Collapsible="true" 
                    Layout="Fit" 
                    Region="East" 
                    Collapsed="false"
                    Split="true" Title="Datos del usuario" Width="175">
                    <Items>
                        <ext:Panel ID="panelDerecho2" runat="server" Layout="row">
                            <Items>
                                <ext:MenuPanel ID="MenuPanel6" runat="server" Border="false">
                                <Menu ID="Menu19" runat="server">
                                    <Items>
                                        <ext:Label ID="Label2" runat="server" Text="Usuario">
                                        </ext:Label>
                                        <ext:MenuItem ID="MenuItem32" Icon="DoorOpen" Text="Cerrar sesión" runat="server">
                                            <DirectEvents>
                                                <Click OnEvent="CerrarSesion_Click">
                                                    <EventMask ShowMask="true" Msg="Saliendo..." MinDelay="500"/>
                                                </Click>
                                            </DirectEvents>
                                        </ext:MenuItem>
                                    </Items>
                                </Menu>
                                </ext:MenuPanel>
                                
                                <ext:Panel ID="Panel4" runat="server" Layout="accordion"
                                    Border="false" RowHeight="0.7">
                                    <Items>
                                        <%-- Información --%>
                                        <ext:MenuPanel ID="MenuPanelDerecho1" runat="server" Title="Información">
                                        <Menu ID="Menu30" runat="server">
                                            <Items>
                                                <ext:MenuItem ID="LabelEmpresa" Icon="World" runat="server">
                                                </ext:MenuItem>
                                                <ext:MenuItem ID="LabelSucursal" Icon="Application" runat="server">
                                                </ext:MenuItem>
                                                <ext:MenuItem ID="LabelUsuario" Icon="Photos" runat="server">
                                                </ext:MenuItem>
                                                <ext:MenuItem ID="LabelPermisos" Icon="DatabaseKey" runat="server">
                                                </ext:MenuItem>
                                                <ext:MenuSeparator ID="MenuSeparatorCot" runat="server"></ext:MenuSeparator>
                                            </Items>
                                        </Menu>
                                        </ext:MenuPanel>

                                        <%-- Cotizaciones --%>
                                        <ext:MenuPanel ID="MenuPanelCotizacion" runat="server" Title="Cotizaciones">
                                            <Menu ID="Menu18" runat="server">
                                                <Items>
                                                    <ext:MenuItem ID="MenuItem30" runat="server" Icon="MoneyDollar" Text="Cotización dólar">
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="DolarFecha" runat="server">
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="DolarHora" runat="server">
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="DolarCompra" runat="server">
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="DolarVenta" runat="server">
                                                    </ext:MenuItem>
                                                    <ext:MenuSeparator ID="MenuSeparator1" runat="server"></ext:MenuSeparator>
                                                    <ext:MenuItem ID="MenuItem73" runat="server" Icon="MoneyEuro" Text="Cotización euro">
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="EuroFecha" runat="server">
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="EuroHora" runat="server">
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="EuroCompra" runat="server">
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="EuroVenta" runat="server">
                                                    </ext:MenuItem>
                                                </Items>
                                            </Menu>
                                            </ext:MenuPanel>  
                                    </Items>
                                </ext:Panel>
                                                           
                            </Items>          
                        </ext:Panel>
                    </Items>
                </ext:Panel>
                
                <%-- Panel inferior --%>
                <ext:Panel runat="server" Collapsible="true" Height="100" Region="South" 
                    Split="true" Title="Panel de Control">
                    <Items>
                        <ext:MenuPanel runat="server">
                            <Menu runat="server">
                                <Items>
                                    <ext:MenuItem Icon="ApplicationXpTerminal" Text="Listados de Reportes">
                                        <Listeners>
                                            <Click Handler="addTab(#{TabPanel1}, 'Reportes', '/PanelDeControl/Reportes.aspx');" />
                                        </Listeners>                        
                                    </ext:MenuItem>
                        
                                    <ext:MenuItem Icon="ClockGo" Text="Estadisticas">
                                        <Listeners>
                                            <Click Handler="addTab(#{TabPanel1}, 'Estadísticas', '/PanelDeControl/EstadisticasAdm.aspx');" />
                                        </Listeners>
                                    </ext:MenuItem>
                                </Items>
                            </Menu>
                        </ext:MenuPanel>
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
                                <%-- Submenú --%>
                                <ext:MenuPanel ID="MenuPanel4" runat="server" Height="300" Title="" Width="185">
                                    <Menu ID="Menu25" runat="server">
                                        <Items>
                                            <%-- Empresas --%>
                                            <ext:MenuItem ID="MenuItem76" runat="server" Text="Empresas">
                                                <Menu>
                                                    <ext:Menu ID="Menu28" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem77" runat="server" Text="Gestionar sucursales">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar sucursales', '/AdministradorGral/Empresas/GestionarSucursales.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            <%-- Tablas --%>
                                            <ext:MenuItem ID="MenuItem52" runat="server" Text="Tablas">
                                                <Menu>
                                                    <ext:Menu ID="Menu26" runat="server">
                                                        <Items>
                                                            
                                                            <%-- Bancos --%>
                                                            <ext:MenuItem ID="MenuItem36" runat="server" Text="Bancos">
                                                                <Menu>
                                                                    <ext:Menu ID="Menu20" runat="server">
                                                                    <Items>
                                                                        <%-- Bancos --%>
                                                                        <ext:MenuItem ID="MenuItem40" runat="server" Text="Bancos">
                                                                            <Listeners>
                                                                                <Click Handler="addTab(#{TabPanel1}, 'Gestionar bancos', '/AdministradorGral/Tablas/GestionarBancos.aspx');" />
                                                                            </Listeners>
                                                                        </ext:MenuItem>
                                                                        <%-- Bancos y sucursales --%>
                                                                        <ext:MenuItem ID="MenuItem50" runat="server" Text="Bancos y sucursales">
                                                                            <Listeners>
                                                                                <Click Handler="addTab(#{TabPanel1}, 'Gestionar bancos y sucursales', '/AdministradorGral/Tablas/BancosYSucursales.aspx');" />
                                                                            </Listeners>
                                                                        </ext:MenuItem>
                                                                        <%-- Cheques propios --%>
                                                                        <ext:MenuItem ID="MenuItem41" runat="server" Text="Cheques propios">
                                                                            <Listeners>
                                                                                <Click Handler="addTab(#{TabPanel1}, 'Cheques propios', '/AdministradorGral/Tablas/GestionarCheques.aspx');" />
                                                                            </Listeners>
                                                                        </ext:MenuItem> 
                                                                        <%-- Cheques de terceros --%>
                                                                        <ext:MenuItem ID="MenuItem45" runat="server" Text="Cheques de terceros">
                                                                            <Listeners>
                                                                                <Click Handler="addTab(#{TabPanel1}, 'Cheques de terceros', '/AdministradorGral/Tablas/GestionarChequesTerceros.aspx');" />
                                                                            </Listeners>
                                                                        </ext:MenuItem>
                                                                        
                                                                    </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:MenuItem>
                                                            <%-- Conceptos --%>
                                                            <ext:MenuItem ID="MenuItem33" runat="server" Text="Gestionar conceptos no gravados en IVA">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Conceptos no gravados en IVA', '/AdministradorGral/Tablas/ConceptoNoGravadoEnIva.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <%-- Índices --%>
                                                            <ext:MenuItem runat="server" Text="Gestionar índices">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar índices', '/AdministradorGral/Tablas/GestionarIndices.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <%-- Monedas --%>
                                                            <ext:MenuItem ID="MenuItem58" runat="server" Text="Consultar monedas">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Monedas y cambios', '/AdministradorGral/Tablas/ConsultarMonedas.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <%-- Régimen especial --%>
                                                            <ext:MenuItem ID="MenuItem60" runat="server" Text="Regimenes especiales">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Regimenes especiales', '/AdministradorGral/Tablas/GestionarRegimenesEsp.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <%-- Tasas de IVA --%>
                                                            <ext:MenuItem runat="server" Text="Gestionar tasas de IVA">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar tasas IVA', '/AdministradorGral/Tablas/GestionarTasasIVA.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <%-- Unidades --%>
                                                            <ext:MenuItem ID="MenuItem78" runat="server" Text="Gestionar unidades">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar unidades', '/AdministradorGral/Tablas/GestionarUnidades.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            
                                            <%-- Seguridad --%>
                                            <ext:MenuItem ID="MenuItem25" runat="server" Text="Seguridad">
                                                <Menu>
                                                    <ext:Menu ID="Menu6" runat="server">
                                                        <Items>
                                                            <%-- Gestionar Usuario-Empresa --%>
                                                            <ext:MenuItem ID="MenuItem26" runat="server" Text="Permisos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar permisos', '/AdministradorGral/Seguridad/Usuarios.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <%-- Permisos tablas --%>
                                                            <ext:MenuItem ID="MenuItem57" runat="server" Text="Permisos tablas">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar permisos de tablas', '/AdministradorGral/Seguridad/Permisos.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <%-- Permisos sucursales --%>
                                                            <ext:MenuItem ID="MenuItem29" runat="server" Text="Permisos sucursales">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar permisos en sucursales', '/AdministradorGral/Seguridad/Sucursales.aspx');" />
                                                                </Listeners>
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
                        
                        <%-- Compras y cuentas a pagar --%>
                        <ext:Panel ID="Panel6" 
                            runat="server" 
                            Border="false" 
                            Collapsed="True" 
                            Icon="Folder" 
                            Title="Compras y cuentas a pagar">
                            <Items>
                                <ext:MenuPanel runat="server" Height="300" Title="" Width="185">
                                    <Menu runat="server">
                                        <Items>
                                            <%-- Comprobantes --%>
                                            <ext:MenuItem ID="MenuItemComprobantesCompra" runat="server" Text="Comprobantes">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                <Items>
                                                    <ext:MenuItem ID="MenuItem83" runat="server" Text="Ingresar comprobantes">
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Gestionar proveedores', '/enconstruccion.htm');" />
                                                        </Listeners>
                                                    </ext:MenuItem>
                                                </Items>
                                                </ext:Menu>
                                            </Menu>
                                            </ext:MenuItem>
                                            <%-- Proveedores --%>
                                            <ext:MenuItem ID="MenuItemComprasProv" runat="server" Text="Proveedores">
                                            <Menu>
                                                <ext:Menu ID="MenuComprasProv" runat="server">
                                                <Items>
                                                    <ext:MenuItem ID="MenuItemCCGestionarProv" runat="server" Text="Gestionar proveedores">
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Gestionar proveedores', '/ComprasCuentasPagar/Proveedores/GestionarProveedores.aspx');" />
                                                        </Listeners>
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="MenuItem74" runat="server" Text="Proveedores (datos)">
                                                        <Menu>
                                                            <ext:Menu ID="Menu31" runat="server">
                                                                <Items>
                                                                    <ext:MenuItem ID="MenuItem75" runat="server" Text="Datos impositivos">
                                                                        <Listeners>
                                                                            <Click Handler="addTab(#{TabPanel1}, 'Datos impositivos proveedor', '/ComprasCuentasPagar/Proveedores/DatosImpositivosProv.aspx');" />
                                                                        </Listeners>
                                                                    </ext:MenuItem>
                                                                    <ext:MenuItem ID="MenuItem81" runat="server" Text="Otros datos">
                                                                        <Listeners>
                                                                            <Click Handler="addTab(#{TabPanel1}, 'Otros datos proveedor', '/ComprasCuentasPagar/Proveedores/DatosProveedor.aspx');" />
                                                                        </Listeners>
                                                                    </ext:MenuItem>
                                                                </Items>
                                                            </ext:Menu>
                                                        </Menu>
                                                    </ext:MenuItem>
                                                        
                                                    <ext:MenuItem ID="MenuItem82" runat="server" Text="Tipos de proveedor">
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Tipos de proovedor', '/ComprasCuentasPagar/Proveedores/GestionarTiposProveed.aspx');" />
                                                        </Listeners>
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
                                                            <ext:MenuItem ID="MenuItem34" runat="server" Text="Ingresar asientos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Ingresar asientos', '/Contabilidad/Asiento/Asiento.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem2" runat="server" Text="Gestionar asientos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar asientos', '/Contabilidad/Asiento/GestionarAsientos.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem3" runat="server" Text="Gestionar movimientos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar movimientos', '/Contabilidad/Asiento/Movimientos.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuSeparator Visible="false"></ext:MenuSeparator>
                                                            <ext:MenuItem ID="MenuItem27" runat="server" Text="Asientos automáticos" Visible="false">
                                                                <Menu>
                                                                    <ext:Menu ID="Menu23" runat="server">
                                                                    <Items>
                                                                        <ext:MenuItem ID="AsientoCierre" Text="Asientos de cierre"></ext:MenuItem>
                                                                    </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            <%-- Centros de costos --%>
                                            <ext:MenuItem ID="MenuItem7" runat="server" Text="Centros de costo">
                                                <Menu>
                                                    <ext:Menu ID="Menu8" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem21" runat="server" Text="Centros de costo">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar centros de costo', '/Contabilidad/CentrosCosto/Gestionar.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuSeparator runat="server"></ext:MenuSeparator>
                                                            <ext:MenuItem ID="MenuItem18" runat="server" Text="Áreas">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar áreas', '/Contabilidad/CentrosCosto/Areas.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem23" runat="server" Text="Departamentos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar departamentos', '/Contabilidad/CentrosCosto/Departamentos.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            <%-- Cuentas --%>
                                            <ext:MenuItem ID="MenuItem6" runat="server" Text="Cuentas">
                                                <Menu>
                                                    <ext:Menu ID="Menu14" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem24" runat="server" Text="Gestionar cuentas">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar cuentas', '/Contabilidad/Cuentas/Gestionar.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItemGestionarCuentas" 
                                                                runat="server" 
                                                                Text="Gestionar cuentas (debug)"
                                                                Visible="false">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar planes', '/Contabilidad/PlanCuentas/ArbolPlan.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            <%-- Libros e informes --%>
                                            <ext:MenuItem ID="MenuItem69" runat="server" Text="Libros e informes">
                                                <Menu>
                                                    <ext:Menu ID="Menu22" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem70" runat="server" Text="Libro diario">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Libro diario', '/Contabilidad/Libros/PrepararLibroDiario.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            <%-- Planes de cuentas --%>
                                            <ext:MenuItem ID="MenuItem71" runat="server" Text="Planes de cuentas">
                                                <Menu>
                                                    <ext:Menu ID="Menu24" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem72" runat="server" Text="Gestionar planes">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar planes', '/Contabilidad/PlanCuentas/GestionarPlanes.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            <%-- Tipos de asientos --%>
                                            <ext:MenuItem ID="MenuItem4" runat="server" Text="Tipos de asientos">
                                                <Menu>
                                                    <ext:Menu ID="Menu4" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem22" runat="server" Text="Gestionar tipos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Tipos de asiento', '/Contabilidad/TipoAsiento/GestionarTiposDeAsientos.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                            <%-- Tipos de movimientos --%>
                                            <ext:MenuItem ID="MenuItem5" runat="server" Text="Tipos de movimiento">
                                                <Menu>
                                                    <ext:Menu ID="Menu9" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem35" runat="server" Text="Gestionar tipos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Tipos de movimiento', '/Contabilidad/TiposMovimiento/Gestionar.aspx');" />
                                                                </Listeners>
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
                                                
                        <%-- Impuestos --%>
                        <%-- <ext:Panel ID="Panel7" runat="server" Border="false" Collapsed="True" Icon="Folder" 
                            Title="Impuestos">
                            <Items>
                            </Items>
                        </ext:Panel>  --%>     
                                    
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
                                                                <Menu>
                                                                    <ext:Menu ID="Menu15" runat="server">
                                                                        <Items>
                                                                            
                                                                            <ext:MenuItem ID="MenuItem51" runat="server" Text="Gestionar personal">
                                                                                <Listeners>
                                                                                    <Click Handler="addTab(#{TabPanel1}, 'Personal', '/SueldosJornales/Personal.aspx');" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>    
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem10" runat="server" Text="Categoría y básicos">
                                                                <Menu>
                                                                    <ext:Menu ID="Menu17" runat="server">
                                                                        <Items>
                                                                            <ext:MenuItem ID="MenuItem54" runat="server" Text="Gestión de categorías de Sueldos">
                                                                                <Listeners>
                                                                                    <Click Handler="addTab(#{TabPanel1}, 'Categorias y sueldos', '/SueldosJornales/CategoriasSueldos.aspx');" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem55" runat="server" Text="Gestión de sueldos de empleados">
                                                                                <Listeners>
                                                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar sueldos (emple.)', '/SueldosJornales/Sueldos.aspx');" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem11" runat="server" Text="Feriados">
                                                                <Listeners>
                                                                <Click Handler="addTab(#{TabPanel1}, 'Feriados', '/SueldosJornales/Feriados.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem14" runat="server" Text="Planilla horaria">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'PlanillaHoraria', '/SueldosJornales/Horarios.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem15" runat="server" Text="Obras Sociales">
                                                                <Menu>
                                                                    <ext:Menu ID="Menu16" runat="server">
                                                                        <Items>
                                                                            <ext:MenuItem ID="MenuItem53" runat="server" Text="Gestionar Tipos de Obras Sociales">
                                                                                <Listeners>
                                                                                    <Click Handler="addTab(#{TabPanel1}, 'TiposObrasSociales', '/SueldosJornales/ObrasSociales.aspx');" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="MenuItem12" runat="server" Text="Gestionar Obras Sociales de Empleados">
                                                                                <Listeners>
                                                                                    <Click Handler="addTab(#{TabPanel1}, 'ObrasSocialesEmpleados', '/SueldosJornales/ObrasSocialesEmpleados.aspx');" />
                                                                                </Listeners>    
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem16" runat="server" Text="Lugares de pago">
                                                                <Listeners>
                                                                <Click Handler="addTab(#{TabPanel1}, 'LugaresDePago', '/SueldosJornales/LugaresDePago.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                             <%-- SubMenú Formulas de Liquidación --%>
                                            <ext:MenuItem ID="MenuItem17" runat="server" Text="Formulas de Liquidación">
                                                <Menu>
                                                    <ext:Menu ID="Menu5" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem56" runat="server" Text="Tipos de Conceptos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'tiposconceptos', '/SueldosJornales/TiposDeConceptos.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            
                                                            <ext:MenuItem ID="MenuItem13" runat="server" Text="Conceptos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'conceptos', '/SueldosJornales/Conceptos.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>                                                                           
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                            
                                             <%-- SubMenú Liquidación --%>
                                            <ext:MenuItem ID="MenuItem19" runat="server" Text="Liquidación de Sueldo/Jornal">
                                                    <Listeners>
                                                        <Click Handler="addTab(#{TabPanel1}, 'liquidacionSueldos', '/SueldosJornales/Liquidaciones.aspx');" />
                                                    </Listeners>
                                            </ext:MenuItem>
                                            
                                            <%-- Listados --%>
                                            <ext:MenuItem ID="MenuItem20" runat="server" Text="Listados">
                                                <Menu>
                                                     <ext:Menu ID="Menu7" runat="server">
                                                        <Items>
                                                        <ext:MenuItem ID="MenuItem28" runat="server" Text="Recibos">
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem31" runat="server" Text="Certificado de trabajo">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'certificadodetrabajo', '/SueldosJornales/CertificadoDeTrabajo.aspx');" />
                                                                </Listeners>
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
                            <ext:MenuPanel ID="MenuPanel3" runat="server" Height="300" Title="" Width="185">    
                                <Menu ID="Menu10" runat="server">
                                <Items>
                                    <%-- Clientes --%>
                                    <ext:MenuItem ID="MenuItem46" runat="server" Text="Clientes">
                                    <Menu>
                                        <ext:Menu ID="Menu13" runat="server">
                                        <Items>
                                            <ext:MenuItem ID="MenuItemGestionarClientes" runat="server" Text="Gestionar clientes">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabPanel1}, 'Gestionar clientes', '/VentasCuentasCobrar/Clientes/GestionarClientes.aspx');" />
                                                </Listeners>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="MenuItem66" runat="server" Text="Clientes">
                                                <Menu>
                                                    <ext:Menu ID="Menu27" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem67" runat="server" Text="Datos impositivos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Datos impositivos cliente', '/VentasCuentasCobrar/Clientes/DatosImpositivosCliente.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem61" runat="server" Text="Otros datos">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Otros datos cliente', '/VentasCuentasCobrar/Clientes/DatosClientes.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem>
                                                
                                            <ext:MenuItem ID="MenuItem62" runat="server" Text="Tipos de cliente">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabPanel1}, 'Tipos de cliente', '/VentasCuentasCobrar/Clientes/GestionarTiposClientes.aspx');" />
                                                </Listeners>
                                            </ext:MenuItem>
                                        </Items>
                                        </ext:Menu>
                                    </Menu>
                                    </ext:MenuItem>
                                    
                                    <%-- Comprobantes de venta --%>
                                    <ext:MenuItem ID="MenuItem48" runat="server" Text="Comprobantes de ventas">
                                        <Menu>
                                            <ext:Menu ID="Menu29" runat="server">
                                                <Items>                      
                                                    <ext:MenuItem ID="MenuItemIngresoComprobantes" runat="server" Text="Ingreso de comprobantes">      
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Ingreso de comprobantes de venta', '/VentasCuentasCobrar/Comprobantes/IngresarComprobante.aspx');" />
                                                        </Listeners>                           
                                                    </ext:MenuItem>    
                                                    <ext:MenuItem ID="MenuItem79" runat="server" Text="Gestionar de Tipo de Comprobantes">      
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Gestionar de Tipo de Comprobantes', '/VentasCuentasCobrar/Comprobantes/tiposcomprobante.aspx');" />
                                                        </Listeners>                           
                                                    </ext:MenuItem>  
                                                     
                                                       <ext:MenuItem ID="MenuItem68" runat="server" Text="Gestionar Anulacion de comprobantes">
                                                <Menu>
                                                    <ext:Menu ID="Menu33" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem64" runat="server" Text="Anular Comprobantes">      
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Anulacion de Comprobantes', '/VentasCuentasCobrar/Comprobantes/GestionarAnulaciones.aspx');" />
                                                        </Listeners>                           
                                                    </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem87" runat="server" Text="Ver Comprobantes Anulados">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Lista de Comprobantes Anulados', '/VentasCuentasCobrar/Comprobantes/VerComprobantesAnulados.aspx');" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:MenuItem> 
                                                    <ext:MenuItem ID="MenuItem49" runat="server" Text="Lista de comprobantes" >      
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Lista de comprobantes de venta', '/VentasCuentasCobrar/Comprobantes/ListadosComprobantes.aspx');" />
                                                        </Listeners>                           
                                                    </ext:MenuItem>                                                                                              
                                                    
                                                </Items>                    
                                            </ext:Menu>                          
                                        </Menu>
                                    </ext:MenuItem>
                                    
                                    <%-- Condiciones de venta --%>
                                    <ext:MenuItem ID="MenuItem47" runat="server" Text="Condiciones de venta">
                                        <Menu>
                                            <ext:Menu ID="Menu21" runat="server">
                                                <Items>
                                                    <%-- Condiciones de venta --%>
                                                    <ext:MenuItem ID="MenuItem65" runat="server" Text="Condiciones de venta">
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Condiciones de venta', '/VentasCuentasCobrar/CondicionesVenta/GestionarCondicionesVenta.aspx');" />
                                                        </Listeners>                           
                                                    </ext:MenuItem>
                                                    <%-- Tipos de condiciones de venta --%>
                                                    <ext:MenuItem ID="MenuItem80" runat="server" Text="Tipos de condiciones de venta">
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Tipos de condiciones de venta', '/VentasCuentasCobrar/CondicionesVenta/GestionarTiposCondicionesVenta.aspx');" />
                                                        </Listeners>                           
                                                    </ext:MenuItem>
                                                </Items>
                                            </ext:Menu>
                                        </Menu>
                                    </ext:MenuItem>
                                    <%-- Cuenta corriente --%>
                                 <ext:MenuItem runat="server" Text="Cuenta corriente">
                                 <Menu>
                                 <ext:Menu runat="server" >
                                 <Items>
                                   <ext:MenuItem runat="server" Text="Gestionar Cuenta corriente">
                                     <Listeners> 
                                                            <Click Handler="addTab(#{TabPanel1}, 'Gestionar cuenta corriente', '/VentasCuentasCobrar/CuentaCorrienteyCobranzas/GestionarCuentaCorriente.aspx');" />
                                                        </Listeners> 
                                   </ext:MenuItem>
                                    
                                   <ext:MenuItem runat="server" Text="Dar Resumen de cuenta">
                                     <Listeners> 
                                                            <Click Handler="addTab(#{TabPanel1}, 'Dar Resumen de cuenta', '/VentasCuentasCobrar/CuentaCorrienteyCobranzas/PrepararResumenDeCuenta.aspx');" />
                                                        </Listeners> 
                                   </ext:MenuItem> 
                                   
                                    <ext:MenuItem ID="MenuItem39" runat="server" Text="Ingreso de saldos y ajustes">
                                                        <Listeners> 
                                                            <Click Handler="addTab(#{TabPanel1}, 'Ingreso de saldos y ajustes', '/VentasCuentasCobrar/CuentaCorrienteyCobranzas/IngresoDeSaldos.aspx');" />
                                                        </Listeners>                                                               
                                                    </ext:MenuItem>
                                                    </Items>
                                                    </ext:Menu>
                                                    </Menu>
                                                    </ext:MenuItem>
                                    
                                    <%-- Cuentas a cobrar --%>
                                    <ext:MenuItem runat="server" Text="Cuentas a cobrar">
                                        <Menu>
                                            <ext:Menu runat="server">
                                                <Items>
                                                    <ext:MenuItem runat="server" Text="Cobranzas">
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Cobranzas', '/VentasCuentasCobrar/CuentaCorrienteyCobranzas/RegistracionCobranza.aspx');" />
                                                        </Listeners>                           
                                                    </ext:MenuItem>
                                                   
                                                    <ext:MenuItem runat="server" Text="Compensación de comprobantes">                                   
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Compensación de comprobantes', '/VentasCuentasCobrar/CuentaCorrienteyCobranzas/CompensacionComprobante.aspx');" />
                                                        </Listeners>                    
                                                    </ext:MenuItem>                                   
                                                </Items>
                                            </ext:Menu>                             
                                        </Menu>
                                    </ext:MenuItem>
                                  
                                    <%-- Descuentos --%>
                                    <ext:MenuItem ID="MenuItem42" runat="server" Text="Descuentos">
                                        <Menu>
                                            <ext:Menu ID="Menu12" runat="server">
                                                <Items>
                                                    <ext:MenuItem ID="MenuItem44"  runat="server" Text="Descuentos comerciales">
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Descuentos comerciales', '/VentasCuentasCobrar/Descuentos/DescuentoComercial.aspx');" />
                                                        </Listeners>
                                                    </ext:MenuItem>
                                                    <ext:MenuItem ID="MenuItem43"  runat="server" Text="Descuentos financieros">
                                                        <Listeners>
                                                            <Click Handler="addTab(#{TabPanel1}, 'Descuentos financieros', '/VentasCuentasCobrar/Descuentos/DescuentosFinancieros.aspx');" />
                                                        </Listeners>
                                                    </ext:MenuItem>
                                                </Items>
                                            </ext:Menu>
                                        </Menu>
                                    </ext:MenuItem>
                                      
                                    <%-- General --%>
                                    <ext:MenuItem ID="MenuItem37" runat="server" Text="General">
                                        <Menu>
                                        <ext:Menu ID="Menu11" runat="server">
                                            <Items>
                                                <ext:MenuItem ID="MenuItem38" runat="server" Text="Talonarios">
                                                    <Listeners>
                                                        <Click Handler="addTab(#{TabPanel1}, 'Talonarios', '/VentasCuentasCobrar/Talonarios.aspx');" />
                                                    </Listeners>
                                                </ext:MenuItem>
                                                <ext:MenuItem ID="MenuItem63" runat="server" Text="Causa de emisión">
                                                    <Listeners>
                                                        <Click Handler="addTab(#{TabPanel1}, 'Causas de emisión', '/VentasCuentasCobrar/CausasEmision.aspx');" />
                                                    </Listeners>
                                                </ext:MenuItem>
                                                <%--<ext:MenuItem ID="MenuItem39" runat="server" Text="Vendedores">
                                                    <Listeners>
                                                        <Click Handler="addTab(#{TabPanel1}, 'Vendedores', '/VentasCuentasCobrar/Vendedor.aspx');" />
                                                    </Listeners>                                       
                                                </ext:MenuItem>  --%>                                
                                                                       
                                                <ext:MenuItem ID="MenuItem59" runat="server" Text="Gestionar conceptos">
                                                    <Listeners>
                                                        <Click Handler="addTab(#{TabPanel1}, 'Conceptos de facturación', '/VentasCuentasCobrar/ConceptoFacturacion.aspx');" />
                                                    </Listeners>                                                  
                                                </ext:MenuItem>   
                                                
                                            </Items>
                                        </ext:Menu>
                                        </Menu>
                                    </ext:MenuItem>
                                    <%--Libros e informes--%>
                                     <ext:MenuItem ID="MenuItem84" runat="server" Text="Libros e informes">
                                                <Menu>
                                                    <ext:Menu ID="Menu32" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem85" runat="server" Text="Libro Iva Ventas">
                                                                <Listeners>
                                                                    <Click Handler="addTab(#{TabPanel1}, 'Libro diario', '/VentasCuentasCobrar/LibroIvaVentas/PrepararLibroIvaVentas.aspx');" />
                                                                </Listeners>
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
                        
                      <%-- cierro items panel izquierdo --%>
                    </Items>
                </ext:Panel>
                
                <%-- Panel central --%>
                <ext:Panel runat="server" Layout="Fit" Region="Center" ID="Center">
                    <Items>
                        <ext:TabPanel 
                        runat="server" 
                        ID="TabPanel1"
                        EnableTabScroll="true"
                        AnimScroll="true"
                        >
                            <%--Menú al tabpanel--%>
                            <%--<DefaultTabMenu>
                                <ext:Menu ID="Menu18" runat="server" EnableScrolling="false">
                                     <Items>
                                         <ext:MenuItem ID="MenuItemTabReload" runat="server" Text="Recargar" Icon="Reload">
                                         <DirectEvents>
                                            <Click OnEvent="MenuItemTab_Click">
                                                <ExtraParams>
                                                    <ext:Parameter Name="Evento" Value="Reload"></ext:Parameter>
                                                </ExtraParams>
                                            </Click>
                                         </DirectEvents>
                                         </ext:MenuItem>
                                         <ext:MenuItem ID="MenuItemTabClose" runat="server" Text="Cerrar" Icon="Cancel" />
                                     </Items>
                                </ext:Menu>
                            </DefaultTabMenu>     
                            <Listeners>
                                <BeforeTabMenuShow Fn="beforeMenu"/>
                            </Listeners>   --%>   
                        </ext:TabPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Viewport>

                
                        
    </div>
    </form>
</body>
</html>
