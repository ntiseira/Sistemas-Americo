<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContabilidadLogin.aspx.cs" Inherits="IU.Contabilidad.ContabilidadLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Módulo de contabilidad - Ingreso</title>
    </head>
<body style="background-color:Silver;">
    <form id="form1" runat="server">
    <div style="text-align:center; font-size:large;">
        <b style="font-size: 40pt">Sistema de Gestión Contable
    </b>
    </div>
    
    <p>
        INGRESAR A MÓDULO DE CONTABILIDAD</p>
    <table style="width:100%;">
        <tr>
            <td>
                Empresa</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownEmpresas" runat="server" 
                    onselectedindexchanged="DropDownEmpresas_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Puesto de trabajo</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownPuestos" runat="server" 
                    onselectedindexchanged="DropDownPuestos_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                Ejercicio</td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="DropDownEjercicios" runat="server" 
                    onselectedindexchanged="DropDownEjercicios_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BotonIngresar" runat="server" Text="Ingresar" 
                    onclick="BotonIngresar_Click" />
            </td>
        </tr>
    </table>
        
    <asp:Label ID="LabelError" runat="server" ForeColor="Red"></asp:Label>
        
    <br />
    <asp:Label ID="LabelStack" runat="server"></asp:Label>
        
    </form>
    </body>
</html>
