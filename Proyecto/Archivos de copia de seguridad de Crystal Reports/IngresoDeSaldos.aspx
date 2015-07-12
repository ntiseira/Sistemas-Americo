<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoDeSaldos.aspx.cs" Inherits="IU.VentasCuentasCobrar.CuentaCorrienteyCobranzas.IngresoDeSaldos" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
     
        <ext:Store 
        ID="StoreComboClientes" 
        runat="server"       
        DataSourceId="SqlDataSource1"
        >
        <Reader>         
        <ext:JsonReader>
        <Fields>
              <ext:RecordField Name="Codcliente" ></ext:RecordField>
              <ext:RecordField Name="Razonsocial"></ext:RecordField>
        </Fields>
        </ext:JsonReader>               
       </Reader>                    
        </ext:Store>   
    
        <ext:Store 
        ID="StoreComboMoneda" 
        runat="server" 
        DataSourceId="SqlDataSource2"
        >
            <Reader>
               <ext:JsonReader>
                     <Fields>
                        <ext:RecordField Name="Idmoneda" ></ext:RecordField>
                        <ext:RecordField Name="Moneda"></ext:RecordField>
                    </Fields>
        </ext:JsonReader>
            </Reader>          
        </ext:Store>   

         <ext:Store 
        ID="StoreComboCausaEmision" 
        runat="server" 
        DataSourceId="SqlDataSource3"
        >
            <Reader>
            <ext:JsonReader>
                  <Fields>
                        <ext:RecordField Name="Codcausasemision" ></ext:RecordField>
                         <ext:RecordField Name="Descripcion"></ext:RecordField>
                 </Fields>
        </ext:JsonReader>
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
                StoreID="StoreComboClientes"
                runat="server"
                FieldLabel="Cliente" 
                TriggerAction="All"            
                DisplayField="Razonsocial"
                ValueField="Codcliente"
                AnchorHorizontal="90%" 
            >
            </ext:ComboBox>
          
        </Items>
        
        
        </ext:FormPanel>
       
        <ext:FormPanel ID="FormPanel1" 
        runat="server"
         Padding="1"
          Width="500"
            Title="Descripcion del ingreso">             
            
              <Items>
             
             <ext:ComboBox  
             Id="comboCausaEmision"
             runat="server"
              ValueField="Codcausasemision"
               StoreID="StoreComboCausaEmision"
              DisplayField="Descripcion"
              FieldLabel="Causa de emision" >
             
             </ext:ComboBox>
             
             <ext:ComboBox
             Id="ComboMonedas"
             runat="server"
              StoreID="StoreComboMoneda"
             FieldLabel="Moneda" 
              ValueField="Idmoneda"
              DisplayField="Moneda">
             
             </ext:ComboBox>
             

                                 
            <ext:ComboBox 
            runat="server"
            ID="comboTipoComprobante"
            FieldLabel="Tipo de comprobante" 
            EmptyText="ingrese un tipo"
            >
               <Items>
               <ext:ListItem Text="Ajustes de créditos en cta. cte" Value="4" />
               <ext:ListItem Text="Ajustes de débitos en cta. cte" Value="5" />               
               </Items>               
           </ext:ComboBox>

           <ext:DateField
            ID="fechaComprobante"
            FieldLabel="Fecha" 
             runat="server"
              AnchorHorizontal="50%"
              EmptyText = "ingresar fecha"
            ></ext:DateField>
            
            <ext:NumberField
             ID="Importe"
             FieldLabel="Importe" 
             runat="server"
             EmptyText="Ingresar saldo"
             >                
            </ext:NumberField>
              

                </Items>            
            <Buttons>
           <ext:Button ID="Button1" runat="server" Text="Ingresar Saldo">
               <DirectEvents>        
                    <Click OnEvent="BotonIngresarSaldo">        
                    <EventMask Msg="Procesando" MinDelay="500"  />       
                    </Click>    
               </DirectEvents>               
           </ext:Button>           
           <ext:Button ID="Button2" runat="server" Text="Cancelar">
               <DirectEvents>        
                    <Click OnEvent="BotonCancelar_Click">        
                    <EventMask Msg="Procesando" MinDelay="500" />       
                    </Click>    
               </DirectEvents>               
           </ext:Button>
        </Buttons>            
            </ext:FormPanel>
        
       
    </div>
    </form>
   
   <asp:SqlDataSource 
ID="SqlDataSource1" 
runat="server"
>
</asp:SqlDataSource>

  <asp:SqlDataSource 
ID="SqlDataSource2" 
runat="server"
>
</asp:SqlDataSource>

  <asp:SqlDataSource 
ID="SqlDataSource3" 
runat="server"
>
</asp:SqlDataSource>

</body>
</html>
