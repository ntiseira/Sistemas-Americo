<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrepararLibro.aspx.cs" Inherits="IU.VentasCuentasCobrar.Reportes.IvaVentas.PrepararLibro" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<ext:ResourceManager ID="ResourceManager1" runat="server" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script runat="server">

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
           <ext:Store ID="Store1" runat="server">
            <Reader>
                <ext:ArrayReader>                   
                </ext:ArrayReader>
            </Reader>            
        </ext:Store>
    
        <%-- Cliente --%>
        <ext:FormPanel 
            ID="FormPanel2" 
            runat="server" 
            Padding="5" 
            Width="270"
            Title="Clientes"
            >
            <Items>
            
            
      
        
                                    
                <ext:MultiCombo  
                    ID="ComboBox1" 
                    runat="server"
                     StoreID="Store1"
                    FieldLabel="Cliente"
                    SelectionMode="All"
                    AnchorHorizontal="100%">
                </ext:MultiCombo >   
                
            </Items>
        </ext:FormPanel>
        
        <%-- Fechas del libro de iva ventas --%>
        <br />
        <ext:FormPanel 
            ID="FormPanel1" 
            runat="server" 
            Padding="5" 
            Width="270"
            Title="Fechas del libro de iva ventas">
            <Items>
                <ext:DateField 
                    ID="DateFieldDesde" 
                    runat="server"
                    Vtype="daterange"
                    FieldLabel="Desde"
                    AnchorHorizontal="100%">  
                    <CustomConfig>
                        <ext:ConfigItem Name="endDateField" Value="#{DateFieldHasta}" Mode="Value" />
                    </CustomConfig>                        
                </ext:DateField>
                
                <ext:DateField 
                    ID="DateFieldHasta"
                    runat="server" 
                    Vtype="daterange"
                    FieldLabel="Hasta"
                    AnchorHorizontal="100%">    
                    <CustomConfig>
                        <ext:ConfigItem Name="startDateField" Value="#{DateFieldDesde}" Mode="Value" />
                    </CustomConfig>                                 
                </ext:DateField>  
                              
            </Items>
        </ext:FormPanel>
        
        <%-- Botón --%>
        <br />
        <ext:Button ID="BotonConsultar" runat="server" Text="Consultar">
            <DirectEvents>
             
            </DirectEvents>
        </ext:Button>
    </div>
    </form>
</body>
</html>
