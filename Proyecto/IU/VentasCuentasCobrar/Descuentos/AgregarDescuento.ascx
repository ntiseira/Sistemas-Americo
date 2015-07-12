<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AgregarDescuento.ascx.cs" Inherits="IU.VentasCuentasCobrar.Descuentos.AgregarDescuento1" %>
    <form id="form1" runat="server">
    <div>
        
    </div>
    
    <div>
        <table style="border-bottom-style:"hidden">
            <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Código"></asp:Label>
            </td>
                <th>
                    
                    <asp:TextBox ID="TextBox1" runat="server" Enabled="false"></asp:TextBox>
                </th>
            </tr>
            
            <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
            </td>
                <th>
                    
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </th>

            </tr>
            
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Agregar" />
                </td>
            </tr>
         </table>   
    </div>
    </form>
