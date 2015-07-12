<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SueldosJornalesPrincipal.aspx.cs" Inherits="IU.SueldosJornales.SueldosJornalesPrincipal" %>

<%@ Register src="CategoriasSueldos.ascx" tagname="CategoriasSueldos" tagprefix="uc1" %>

<%@ Register src="LugaresDePago.ascx" tagname="LugaresDePago" tagprefix="uc2" %>

<%@ Register src="DatosEmpleador.ascx" tagname="DatosEmpleador" tagprefix="uc3" %>
<%@ Register src="ObrasSociales.ascx" tagname="ObrasSociales" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sistema de Sueldos y Jornales</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center; font-weight: 700; font-size: 32pt;">
    Sistema de Sueldos y Jornales
    </div>
    
    <table style="width:100%;">
        <tr>
        
            <th style="width:33%;">
                <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" 
                    DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
                    ForeColor="#666666" StaticSubMenuIndent="10px" 
                    onmenuitemclick="Menu1_MenuItemClick">
                    <StaticSelectedStyle BackColor="#1C5E55" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#E3EAEB" />
                    <DynamicSelectedStyle BackColor="#1C5E55" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#666666" ForeColor="White" />
                    <Items>
                        <asp:MenuItem Text="General" Value="General">
                            <asp:MenuItem Text="Personal" Value="Personal"></asp:MenuItem>
                            <asp:MenuItem Text="Categorias y Básicos" Value="2">
                            </asp:MenuItem>
                            <asp:MenuItem Text="Feriados" Value="Feriados"></asp:MenuItem>
                            <asp:MenuItem Text="Centro de Costos" Value="Centro de Costos"></asp:MenuItem>
                            <asp:MenuItem Text="Datos Empleador" Value="5"></asp:MenuItem>
                            <asp:MenuItem Text="Planilla Horaria" Value="Planilla Horaria"></asp:MenuItem>
                            <asp:MenuItem Text="Obras Sociales" Value="Obras Sociales"></asp:MenuItem>
                            <asp:MenuItem Text="Lugares de Pago" Value="8"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Formulas Liquidación" Value="Formulas Liquidación">
                            <asp:MenuItem Text="Conceptos" Value="Conceptos"></asp:MenuItem>
                            <asp:MenuItem Text="Fórmulas" Value="Fórmulas"></asp:MenuItem>
                            <asp:MenuItem Text="Retenciones de 4ta Cat." Value="Retenciones de 4ta Cat.">
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Liquidación" Value="Liquidación">
                            <asp:MenuItem Text="Liquidar Período" Value="Liquidar Período"></asp:MenuItem>
                            <asp:MenuItem Text="Borrar Liquidación" Value="Borrar Liquidación">
                            </asp:MenuItem>
                            <asp:MenuItem Text="Aumento de Sueldo" Value="Aumento de Sueldo"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Listados" Value="Listados">
                            <asp:MenuItem Text="Recibos" Value="Recibos"></asp:MenuItem>
                            <asp:MenuItem Text="Libro de Sueldos" Value="Libro de Sueldos"></asp:MenuItem>
                            <asp:MenuItem Text="Total por Período" Value="Total por Período"></asp:MenuItem>
                            <asp:MenuItem Text="Certificado de Trabajo" Value="Certificado de Trabajo">
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Utilidades" Value="Utilidades"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </th>
            
            <th style="width:33%;">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ObrasSocialesView" runat="server">
                        <uc4:ObrasSociales ID="ObrasSociales1" runat="server" />
                    </asp:View>
                    <asp:View ID="DatosEmpleadorView" runat="server">
                        <uc3:DatosEmpleador ID="DatosEmpleador1" runat="server" />
                    </asp:View>
                    <asp:View ID="LugaresPagoView" runat="server">
                        <uc2:LugaresDePago ID="LugaresDePago1" runat="server" />
                    </asp:View>
                    <asp:View ID="PrincipalView" runat="server">
                    </asp:View>
                    <asp:View ID="CategoriasSueldosView" runat="server">
                        <uc1:CategoriasSueldos ID="CategoriasSueldos1" runat="server" />
                    </asp:View>
                </asp:MultiView>
            </th>
            
            <th style="width:33%;">
            </th>
        </tr>
      
    </table>
    
    </form>
</body>
</html>
