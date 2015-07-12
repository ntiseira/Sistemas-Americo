<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrepararLibroIvaVentas.aspx.cs" Inherits="IU.VentasCuentasCobrar.LibroIvaVentas.PrepararLibroIvaVentas" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      
      <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
     
        <ext:Store 
        ID="StoreComboCli" 
        runat="server" 
        >
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="id" Type="Int"/>
                        <ext:RecordField Name="razonsocial" Type="String"/>
                    </Fields>
                </ext:ArrayReader>
            </Reader>          
        </ext:Store>   
    
        <ext:FormPanel 
        ID="FormPanel2" 
        runat="server" 
        Padding="5" 
        Width="320"
        Title="Clientes"
        >
        <Items>
            <ext:ComboBox
                Editable="false"
                ID="ComboBoxClientes"
                EmptyText="Seleccione un cliente..." 
                Mode="Local"
                StoreID="StoreComboCli"
                runat="server"
                FieldLabel="Cliente" 
                TriggerAction="All"            
                DisplayField="razonsocial"
                ValueField="id"
                AnchorHorizontal="90%"
            >
            </ext:ComboBox>
        </Items>
        
        
        </ext:FormPanel>
        <ext:FormPanel ID="FormPanel1" 
        runat="server"
         Padding="1"
          Width="500"
            Title="Fecha">             
            
              <Items>
                <ext:Checkbox 
                    ID="CheckboxMesActual" 
                    runat="server"
                    Checked="true"
                    FieldLabel="Mes actual">
                    <DirectEvents>
                        <Check OnEvent="Checkbox_Check"></Check>
                    </DirectEvents>
                    
                </ext:Checkbox>
              
                <ext:Checkbox 
                    ID="CheckboxFechas" 
                    runat="server"
                    Checked="true"
                    FieldLabel="Fecha">
                    <DirectEvents>
                        <Check OnEvent="Checkbox_Check"></Check>
                    </DirectEvents>                    
                </ext:Checkbox>
                
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
            
            <Buttons>
           <ext:Button ID="Button1" runat="server" Text="Siguiente">
               <DirectEvents>        
                    <Click OnEvent="BotonNext_Click">        
                    <EventMask Msg="Procesando" MinDelay="500" />       
                    </Click>    
               </DirectEvents>               
           </ext:Button>
        </Buttons>
            
            </ext:FormPanel>
        
      
    </div>
    </form>
</body>
</html>