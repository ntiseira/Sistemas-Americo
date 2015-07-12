<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrepararLibroDiario.aspx.cs" Inherits="IU.Contabilidad.Libro.PrepararLibroDiario" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
<%@ Import Namespace="Siscont.Contabilidad"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<ext:ResourceManager ID="ResourceManager1" runat="server" />

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script runat="server">

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%-- Tipos de asientos --%>
        <ext:FormPanel 
            ID="FormPanel2" 
            runat="server" 
            Padding="5" 
            Width="270"
            Title="Tipos de asientos"
            >
            <Items>
                <ext:Checkbox 
                    ID="CheckboxTodos" 
                    runat="server"
                    Checked="true"
                    FieldLabel="Todos">
                    <DirectEvents>
                        <Check OnEvent="Checkbox_Check"></Check>
                    </DirectEvents>
                    <%--<Listeners>
                        <Check Handler="#{ComboBox1}.setDisabled(#{Checkbox1}.checked);"/>
                    </Listeners>--%>
                </ext:Checkbox>
                    
                <ext:MultiCombo  
                    ID="ComboBox1" 
                    runat="server"
                    FieldLabel="Tipos"
                    SelectionMode="All"
                    AnchorHorizontal="100%">
                </ext:MultiCombo >   
                
            </Items>
        </ext:FormPanel>
        
        <%-- Fechas de asientos --%>
        <br />
        <ext:FormPanel 
            ID="FormPanel1" 
            runat="server" 
            Padding="5" 
            Width="270"
            Title="Fechas de los asientos">
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
                <Click OnEvent="BotonConsultar_OnClick"></Click>
            </DirectEvents>
        </ext:Button>
    </div>
    </form>
</body>
</html>
