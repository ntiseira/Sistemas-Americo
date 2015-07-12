<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContabilidadPrincipal.aspx.cs" Inherits="IU.Contabilidad.ContabilidadPrincipal" %>

<%@ Register src="TipoAsiento/ListarTiposAsientos.ascx" tagname="ListarTiposAsientos" tagprefix="uc1" %>

<%@ Register src="ControlListar.ascx" tagname="ControlListar" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Sistema de Sueldos y Jornales</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; font-weight: 700; font-size: 32pt;">
        <span lang="es-ar">Contabilidad</span></div>
    
    <table style="width:100%;">
        <tr>
        
            <th style="width:33%;">
                <asp:Menu ID="MenuContabilidad" runat="server" BackColor="#E3EAEB" 
                    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#666666" StaticSubMenuIndent="10px" 
                    onmenuitemclick="MenuContabilidad_MenuItemClick">
                    <StaticSelectedStyle BackColor="#1C5E55" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#E3EAEB" />
                    <DynamicSelectedStyle BackColor="#1C5E55" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                    <Items>
                        <asp:MenuItem Text="Asientos" Value="Asientos">
                            <asp:MenuItem Text="Nuevo asiento" Value="Nuevo asiento"></asp:MenuItem>
                            <asp:MenuItem Text="Listar asientos" Value="Listar asientos"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Asientos automáticos" Value="Asientos automáticos">
                        </asp:MenuItem>
                        <asp:MenuItem Text="Centros de costos" Value="Centros de costos">
                            <asp:MenuItem Text="Nuevo centro de costos" Value="Nuevo centro de costos">
                            </asp:MenuItem>
                            <asp:MenuItem Text="Listar centros de costos" Value="Listar centros de costos">
                            </asp:MenuItem>
                            <asp:MenuItem Text="Áreas" Value="Áreas">
                                <asp:MenuItem Text="Listar áreas" Value="Listar areas"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Departamentos" Value="Departamentos">
                                <asp:MenuItem Text="Listar departamentos" Value="Listar departamentos">
                                </asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Cuentas" Value="Cuentas"></asp:MenuItem>
                        <asp:MenuItem Text="Tipos de asientos" Value="Tipos de asientos">
                            <asp:MenuItem Text="Nuevo tipo de asiento" Value="Nuevo tipo de asiento">
                            </asp:MenuItem>
                            <asp:MenuItem Text="Modificar tipo de asiento" 
                                Value="Modificar tipo de asiento"></asp:MenuItem>
                            <asp:MenuItem Text="Eliminar tipo de asiento" Value="Eliminar tipo de asiento">
                            </asp:MenuItem>
                            <asp:MenuItem Text="Listar tipos de asientos" Value="Listar tipos de asientos">
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Tipos de movimientos" Value="Tipos de movimientos">
                            <asp:MenuItem Text="Listar tipos de movimientos" 
                                Value="Listar tipos de movimientos"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Unidades" Value="Unidades"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </th>
            
            <th style="width:33%;">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="ViewListar" runat="server">
                        <uc2:ControlListar ID="ControlListar1" runat="server" />
                    </asp:View>
                    <asp:View ID="ViewPreListarAgrupaciones" runat="server">
                    </asp:View>
                    <asp:View ID="ViewListarTipoAsiento" runat="server">
                        <uc1:ListarTiposAsientos ID="ListarTiposAsientos1" runat="server" />
                    </asp:View>
                </asp:MultiView>
            </th>
            
            <th style="width:33%;">
            </th>
        </tr>
      
    </table>
    
    <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Label ID="LabelStack" runat="server"></asp:Label>
    
    </form>
</body>
</html>
