<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarComprobante.aspx.cs" Inherits="IU.VentasCuentasCobrar.Comprobantes.IngresarComprobante" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="../../Generico/ComboClases.ascx" tagname="ComboClases" tagprefix="americo" %>

<script runat="server">
    
    protected void StoreItems_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.CargarDatosEnGrid();
    }


    public void filtrarCampo()
    {
        WebHelper.SqlValor[] Valor = new WebHelper.SqlValor[] { new WebHelper.SqlValor(comboBox1.Text, Text.Text) };
        WebHelper.Storer st = new WebHelper.Storer(Tipo);
        st.Valores = Valores;
        this.OnShow();
        
    }

    [DirectMethod]
    public void setCantidad(int cant)
    {
     this.Cantidad = cant;
    }
    

    protected void Store1_AfterRecordInserted(object sender, AfterRecordInsertedEventArgs e)
    {
       
        //The deleted and updated records confirms automatic (depending AffectedRows field)
        //But you can override this in AfterRecordUpdated and AfterRecordDeleted event
        //For insert we should set new id for refresh on client
        //If we don't set new id then old id will be used
        //if (e.Confirmation.Confirm && !string.IsNullOrEmpty(insertedValue))
        //{
        //    e.Confirmation.ConfirmRecord(insertedValue);
        //    insertedValue = "";
        //}
    }

    protected void Store1_AfterDirectEvent(object sender, AfterDirectEventArgs e)
    {
        if (e.Response.Success)
        {
            // set to .Success to false if we want to return a failure
            //e.Response.Success = true;
            //e.Response.Message = "message";
            //if (this.cancel)
            // {
            // GridPanel1.AddScript("alert({0});", JSON.Serialize(this.message));
            //}
        }
    }

    protected void Store1_BeforeDirectEvent(object sender, BeforeDirectEventArgs e)
    {

    }

    protected void Store1_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store1.DataBind();
    }


  
    
    
</script>
<script language="javascript" type="text/javascript">

    function asignar(value) 
    {       
        prueba.setCantidad(value);
    }

    var ChangeValue = function (value) {

    var comboBox = ComboClasesCliente,
    valueCombo = comboBox.getValue();
    record = comboBox.findRecordByValue(valueCombo),
    index = comboBox.getStore().indexOf(record);
    ComboClasesCliente.SelectedItem.Value = valueCombo;      
    }

</script>




<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server"  DirectMethodNamespace="prueba"/>
    
  <ext:Store 
    ID="Store2" 
    runat="server"
>
    <Reader>
        <ext:ArrayReader>
            <Fields>
                <ext:RecordField Name="atributo" Type="String"/>
                <ext:RecordField Name="display" Type="String"/>
            </Fields>
        </ext:ArrayReader>
    </Reader>    
</ext:Store>
<ext:Store 
    ID="Store1" 
    runat="server"
    DataSourceId="SqlDataSource3"
    ShowWarningOnFailure="false"
    UseIdConfirmation="false" 
    OnRefreshData="Store1_RefershData"
  
>
    <Reader>
        <ext:JsonReader>
        </ext:JsonReader>
    </Reader>
    <Listeners>
        <LoadException Handler="Ext.Msg.alert('Error al cargar los datos', 'Por favor recargue la página');" />
        <CommitFailed Handler="Ext.Msg.alert('Error al guardar', 'Verifique que los campos estén correctos');" />
        <SaveException Handler="Ext.Msg.alert('Error al guardar', 'Verifique que los campos estén correctos');" />
    </Listeners>      
</ext:Store>

<ext:Store 
    ID="Store3" 
    runat="server"
    DataSourceId="SqlDataSource1"
    ShowWarningOnFailure="false"
    UseIdConfirmation="false" 
    OnRefreshData="Store1_RefershData"
  
>
    <Reader>
        <ext:JsonReader>
        </ext:JsonReader>
    </Reader>
    <Listeners>
        <LoadException Handler="Ext.Msg.alert('Error al cargar los datos', 'Por favor recargue la página');" />
        <CommitFailed Handler="Ext.Msg.alert('Error al guardar', 'Verifique que los campos estén correctos');" />
        <SaveException Handler="Ext.Msg.alert('Error al guardar', 'Verifique que los campos estén correctos');" />
    </Listeners>      
</ext:Store>

      <ext:Store 
        ID="StoreComboClientes" 
        runat="server"       
        DataSourceId="SqlDataSource2"
        >
        <Reader>         
        <ext:JsonReader>
        <Fields>
              <ext:RecordField Name="Codcliente"   ></ext:RecordField>
              <ext:RecordField Name="Razonsocial"></ext:RecordField>


        </Fields>
        </ext:JsonReader>               
       </Reader>                    
        </ext:Store>   


        <ext:Store 
        ID="StoreComboDescuentoComerciales" 
        runat="server"       
        DataSourceId="SqlDataSource4"
        >
        <Reader>         
        <ext:JsonReader>
        <Fields>              
               <ext:RecordField Name="Iddescuentoscomerciales"   ></ext:RecordField>
              <ext:RecordField Name="Descripcion"></ext:RecordField>

        </Fields>
        </ext:JsonReader>               
       </Reader>                    
        </ext:Store>   

                
        <ext:Store 
        ID="StoreComboDescuentoFinancieros" 
        runat="server"       
        DataSourceId="SqlDataSource5"
        >
        <Reader>         
        <ext:JsonReader>
        <Fields>                        
               <ext:RecordField Name="Iddescuentosfinancieros"   ></ext:RecordField>
              <ext:RecordField Name="Descripcion"></ext:RecordField>

        </Fields>
        </ext:JsonReader>               
       </Reader>                    
        </ext:Store>   
    
     <ext:Store 
        ID="StoreItems" 
        runat="server"
        ShowWarningOnFailure="false"
        UseIdConfirmation="false" 
        OnRefreshData="StoreItems_RefershData"
        >
        <Reader>
            <ext:JsonReader>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    
    <ext:Viewport ID="Viewport1" runat="server">
        <Items>
            <ext:RowLayout ID="RowLayout1" runat="server" Split="false">
                <Rows>
                     <%-- Panel superior --%>
                    <ext:LayoutRow RowHeight="0.25">
                        <ext:Panel ID="Panel1" runat="server" Title="" >
                        <Items>
                            <%-- Panel --%>
                            <ext:FormPanel 
                                ID="FormPanel1" 
                                runat="server" 
                                Title=""
                                MonitorPoll="500" 
                                MonitorValid="true" 
                                Padding="5" 
                                AutoWidth="true"
                                AutoHeight="true"
                                ButtonAlign="Right"
                                Border="false"
                                Layout="Column">
                                <Items>
                                    <%-- Columna izquierda --%>
                                    <ext:Panel ID="Panel12" 
                                        runat="server" 
                                        Border="false" 
                                        Layout="Form" 
                                        ColumnWidth=".4" 
                                        LabelAlign="Left">
                                        <Defaults>
                                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                            <ext:Parameter Name="MsgTarget" Value="side" />
                                        </Defaults>
                                    
                                        <Items>

                                     
                                            <%-- Fecha --%>
                                            <ext:DateField  
                                                ID="DateFieldFecha"
                                                runat="server" 
                                                FieldLabel="Fecha" 
                                                Format="dd/MM/yyyy"
                                                AnchorHorizontal="90%"                                                 

                                                >
                                            </ext:DateField>
                                            
                                            <%-- Cliente --%>
                                            <ext:Panel ID="Panel13" runat="server" Border="false" AnchorHorizontal="90%" Layout="Fit">
                                            <Content>
                                            
  
                                            <ext:ComboBox 
            
                                                Editable="false"
                                                ID="ComboClasesCliente"
                                                EmptyText="Seleccione un cliente..." 
                                                Mode="Local"                
                                                StoreID="StoreComboClientes"
                                                runat="server"
                                                FieldLabel="Cliente" 
                                                TriggerAction="All"                            
                                                ValueField="Codcliente"
                                                DisplayField="Razonsocial"  
                                                DataIndex="Codcliente"
                                                AnchorHorizontal="90%" 
                                            >       
                                             
                                             <DirectEvents>
                                             <Select OnEvent="ChangeHandle" Type="Load"    Method="POST">
                                                <ExtraParams>
                                                    <ext:Parameter Name="item" Value="ComboClasesCliente.SelectedItem.Value()" Mode="Raw" />
                                                </ExtraParams>
                                             </Select>                                            
                                             </DirectEvents>
                                              
                                              <Listeners>
                                                  <Select Handler="#{DirectMethods}.asignarSituacionIva();" />                                                   
                                               </Listeners>                                     
                                              
                                            </ext:ComboBox>         
                                       
                                                                                                   
                                            </Content>
                                            </ext:Panel>
                                            
                                            <%-- Moneda --%>
                                            <ext:Panel runat="server" Border="false" AnchorHorizontal="90%" Layout="Fit">
                                            <Content>
                                                <americo:ComboClases 
                                                    ID="ComboMonedas" runat="server" 
                                                    TextoVacio="Seleccione una moneda" 
                                                    Texto="Moneda" 
                                                    AtributoValor="Idmoneda" 
                                                    AtributoDisplay="Moneda" 
                                                    />
                                            </Content>
                                            </ext:Panel>
                                        </Items>
                                    </ext:Panel>
                                
                                    <%-- Columna derecha --%>
                                    <ext:Panel ID="Panel11" 
                                        runat="server" 
                                        Border="false" 
                                        Header="false" 
                                        ColumnWidth=".4" 
                                        Layout="Form" 
                                        Width="400"
                                        Height="400"
                                        LabelAlign="Left">
                                        <Defaults>
                                            <ext:Parameter Name="MsgTarget" Value="side" />
                                        </Defaults>
                                        <Items>
                                            <%-- Comprobante --%>
                                            <ext:Panel 
                                                runat="server"
                                                AnchorHorizontal="90%"
                                                FieldLabel="Comprobante"
                                                Height="24"
                                                Border="false"
                                            >
                                            <Items>
                                            <ext:ColumnLayout 
                                                runat="server">
                                                <Columns>
                                                    <%-- Tipo de comprobante --%>
                                                    <ext:LayoutColumn ColumnWidth="0.5">
                                                        <ext:TextField 
                                                            ID="txtTipoComprobante" 
                                                            runat="server" 
                                                            AllowBlank="true"
                                                            >
                                                        </ext:TextField>
                                                    </ext:LayoutColumn>
                                                    
                                                    <%-- Letra --%>
                                                    <ext:LayoutColumn ColumnWidth="0.2">
                                                        <ext:TextField 
                                                            ID="txtLetra" 
                                                            runat="server" 
                                                            AllowBlank="true"
                                                            >
                                                        </ext:TextField>
                                                    </ext:LayoutColumn>
                                                    
                                                    <%-- Número --%>
                                                    <ext:LayoutColumn ColumnWidth="0.3">
                                                        <ext:TextField 
                                                            ID="txtNumero" 
                                                            runat="server" 
                                                            AllowBlank="true" 
                                                            >                                                        
                                                           
                                                        </ext:TextField>
                                                    </ext:LayoutColumn>
                                                </Columns>
                                            </ext:ColumnLayout>
                                            </Items>
                                            </ext:Panel>
                                                
                                            <%-- Concepto --%>
                                            <ext:TextField ID="txtConcepto" runat="server" 
                                                FieldLabel="Concepto" 
                                                AllowBlank="false"
                                                AnchorHorizontal="90%" />                                       
                                            </Items>
                                        </ext:Panel>
                                    
                                    <ext:Panel ID="Panel22" 
                                        runat="server" 
                                        Border="false" 
                                        Header="false" 
                                        Layout="Row" 
                                        Width="80"
                                        LabelAlign="Left">
                                        <Items>
                                            <ext:Button ID="ButtonAceptar" runat="server" Text="Aceptar">
                                                <DirectEvents>
                                                    <Click OnEvent="BotonAceptar_Click" >
                                                        <EventMask Msg="Cargando..." ShowMask="true" MinDelay="500" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Panel Height="4" runat="server" Border="false"></ext:Panel>
                                            
                                            <ext:Button ID="ButtonCancelar" runat="server" Text="Cancelar">
                                                <DirectEvents>
                                                    <Click OnEvent="BotonCancelar_Click">
                                                        <EventMask Msg="Cargando..." ShowMask="true" MinDelay="500" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Panel ID="Panel23" Height="4" runat="server" Border="false"></ext:Panel>
                                            
                                            <ext:Button ID="ButtonCerrar" runat="server" Text="Cerrar">
                                                <DirectEvents>
                                                    <Click OnEvent="BotonCerrar_Click">
                                                        <EventMask Msg="Cerrando..." ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                        </Items>
                                    </ext:Panel>
                                </Items>
                            </ext:FormPanel>
                        </Items>
                        </ext:Panel>
                    </ext:LayoutRow>
                    
                    <%-- Panel central --%>
                    <ext:LayoutRow RowHeight="0.60">
                        <ext:Panel ID="Panel2" runat="server" Title="" Layout="Fit">
                        <Items>
                            <ext:TabPanel ID="TabPanel1" runat="server">   
                                <Items>
                                    <%-- Datos generales --%>
                                    <ext:Panel ID="Tab1" runat="server" 
                                        Title="Datos generales" 
                                        AutoScroll="true"
                                        Layout="Form"
                                        Padding="5">
                                        <Items>
                                            <%-- Tipo de lista --%>
                                            <ext:Panel 
                                                ID="PanelTipoLista" 
                                                runat="server" 
                                                Border="false" 
                                                AnchorHorizontal="90%" 
                                                Layout="Fit">
                                                <Content>
                                                    <americo:ComboClases 
                                                        ID="ComboTipoLista" runat="server" 
                                                        TextoVacio="Seleccione un tipo de lista" 
                                                        Texto="Tipo de lista" 
                                                        AtributoValor="Idtipolista" 
                                                        AtributoDisplay="Descrip" 
                                                        />
                                                </Content>
                                            </ext:Panel>
                                            
                                            <%-- Condición de venta --%>
                                            <ext:Panel 
                                            
                                                ID="Panel21" 
                                                runat="server" Border="false" 
                                                AnchorHorizontal="100%" 
                                                FieldLabel="Condición de venta"
                                                >
                                               
                                            <Items>
                                                <%-- Condición de venta --%>
                                                <ext:Panel ID="Panel24" runat="server" Border="false" Layout="Fit" ColumnWidth="0.8">
                                                <Content>                                               
                                                    <americo:ComboClases 
                                                        ID="ComboClasesCondicionVenta" runat="server" 
                                                        TextoVacio="Seleccione una condición" 
                                                        Texto="" 
                                                        AtributoValor="Iddescuentoscomerciales" 
                                                        AtributoDisplay="Descripcion" 
                                                        />

                                                </Content>
                                                </ext:Panel>
                                                
                                                <%-- Otros datos --%>
                                            </Items>
											</ext:Panel>
											
                                        
                                            <%-- Descuento comercial --%>
                                            <ext:Panel ID="Panel17" runat="server" Border="false" AnchorHorizontal="100%" Layout="Column">
                                            <Items>
                                                <ext:Checkbox ID="CheckboxDescuentoComercial" runat="server" 
                                                    ColumnWidth="0.2" Enabled="false"
                                                    FieldLabel="Descuento comercial">
                                                
                                                </ext:Checkbox>
                                                <ext:Panel ID="Panel20" runat="server" Border="false" Layout="Fit" ColumnWidth="0.8">
                                                <Content>                                               
                                                                                                          
                                                <ext:ComboBox 
                                                    Editable="false"
                                                    ID="ComboBoxDescuentoComercial"
                                                    EmptyText="Seleccione un descuento" 
                                                    Mode="Local"                
                                                    StoreID="StoreComboDescuentoComerciales"
                                                    runat="server"
                                                    FieldLabel="Descuento Comercial" 
                                                    TriggerAction="All"                            
                                                    ValueField="Iddescuentoscomerciales"
                                                    DisplayField="Descripcion"                         
                                                    AnchorHorizontal="90%" 
                                                >
                                               <Listeners>
                                                  <Select Handler="#{DirectMethods}.aplicarDescuentoComerciales();" /> 
                                               </Listeners>
                                              </ext:ComboBox>


                                                </Content>
                                                </ext:Panel>
                                            </Items>
											</ext:Panel>
                                            <%-- Descuento financiero --%>
                                            <ext:Panel ID="Panel19" runat="server" Border="false" AnchorHorizontal="100%" Layout="Column">
                                            <Items>
                                                <ext:Checkbox ID="CheckboxDescuentoFinanciero" runat="server" 
                                                    ColumnWidth="0.2" Enabled="false"
                                                    FieldLabel="Descuento financiero">
                                                </ext:Checkbox>
                                                <ext:Panel ID="Panel18" runat="server" Border="false" Layout="Fit" ColumnWidth="0.8">
                                                <Content>                                               
                                               
                                            <ext:ComboBox             
                                            Editable="false"
                                            ID="ComboBoxDescuentoFinanciero"
                                            EmptyText="Seleccione un descuento" 
                                            Mode="Local"                
                                            StoreID="StoreComboDescuentoFinancieros"
                                            runat="server"
                                            FieldLabel="Descuento Financiero" 
                                            TriggerAction="All"                            
                                            ValueField="Iddescuentosfinancieros"
                                            DisplayField="Descripcion"                         
                                            AnchorHorizontal="90%" 
                                             DataIndex="Iddescuentosfinancieros"
                                        >

                                           <Listeners>          
                                            <Select Handler="#{DirectMethods}.aplicarDescuentoFinancieros();" /> 
                                            </Listeners>
                                            </ext:ComboBox>

                                                </Content>
                                                </ext:Panel>
                                            </Items>
                                            </ext:Panel>
                                            <%-- Fecha entrega --%>
                                            <ext:DateField  
                                                ID="DateFieldFechaEntrega"
                                                runat="server" 
                                                FieldLabel="Fecha entrega" 
                                                Format="dd/MM/yyyy"
                                                AnchorHorizontal="50%" >
                                            </ext:DateField>
                                            
                                            <%-- Fecha probable emisión --%>
                                            <ext:DateField  
                                                ID="DateFieldFechaProbableEmision"
                                                runat="server" 
                                                FieldLabel="Fecha emisión (probable)" 
                                                Format="dd/MM/yyyy"
                                                AnchorHorizontal="50%" >
                                            </ext:DateField>
                                            
                                          <ext:TextField ID="RegimenEspecial" runat="server"  FieldLabel="Regimen especial aplicado">
                                          </ext:TextField>
                                            
                                            <%-- Contrato --%>
                                        </Items>
                                    </ext:Panel>
                                    
                                    <%-- Datos generales impositivos --%>
                                    <ext:Panel ID="Tab2" runat="server" 
                                        Title="Datos generales impositivos" 
                                        AutoScroll="true"
                                        Padding="5" 
                                        Layout="Form">
                                        <Items>

                                            <%-- Fecha de contabilización --%>
                                            <ext:DateField  
                                                ID="DateFieldFechaContabilizacion"
                                                runat="server" 
                                                FieldLabel="Fecha de contabilización" 
                                                Format="dd/MM/yyyy"
                                                AnchorHorizontal="30%" >
                                            </ext:DateField>
                                                
                                            <%-- Fecha de declaración jurada --%>
                                            <ext:DateField  
                                                ID="DateFieldFechaDeclaracionJurada"
                                                runat="server" 
                                                FieldLabel="Fecha de declaración jurada" 
                                                Format="MM/yyyy"
                                                AnchorHorizontal="30%" >
                                            </ext:DateField>
                                            
                                            <%-- Provincia --%>
                                            <ext:Panel 
                                                ID="Panel15" 
                                                runat="server" 
                                                Border="false" 
                                                AnchorHorizontal="90%" 
                                                Layout="Fit">
                                                <Content>
                                                    <americo:ComboClases 
                                                        ID="ComboClasesProvincia" runat="server" 
                                                        TextoVacio="Seleccione una provincia" 
                                                        Texto="Provincia" 
                                                        AtributoValor="Id" 
                                                        AtributoDisplay="Nombre"                                                          
                                                        />
                                                </Content>
                                            </ext:Panel>
                                                
                                            <%-- Bien de uso --%>
                                            <ext:Checkbox
                                                runat="server"
                                                FieldLabel="Bien de uso"
                                                ID="CheckBoxBienDeUso"
                                                >
                                            </ext:Checkbox>
                                            
                                            <%-- Tipo de operación --%>
                                            <ext:Panel 
                                                ID="Panel16" 
                                                runat="server" 
                                                Border="false" 
                                                AnchorHorizontal="50%" 
                                                Layout="Fit"
                                                Title="Tipo de operacion"
                                                >                                                
                                                <Content>                                                
                                                <ext:ComboBox 
                                                 ID="ComboClasesTipoOperacion" runat="server"
                                                  Text="Tipo de operacion"                               
                                                >
                                                <Items>
                                                <ext:ListItem Text="Contado" Value="Contado" />
                                                <ext:ListItem Text="Cuotas" Value="Cuotas" />                                                
                                                </Items>
                                                </ext:ComboBox>                                                      
                                                </Content>
                                            </ext:Panel>
                                        </Items>
                                    </ext:Panel>
                                    
                                    <%-- Items --%>
                                    <ext:Panel ID="Tab3" 
                                        runat="server" 
                                        Title="Detalle de items" 
                                        Layout="form"
                                        Height="1000"
                                        Padding="5">
                                        <Items>
                                            <ext:RowLayout runat="server" Split="true">
                                                <Rows>
                                                    <%-- Detalle --%>
                                                    <ext:LayoutRow RowHeight="0.4">
                                                    <ext:Panel runat="server">
                                                     <Content >
                                                     <asp:Label Text="ANDA" runat="server">
                                                     </asp:Label>
                                                     </Content>
                                                    </ext:Panel>
                                                    </ext:LayoutRow>
                                                    
                                                    <%-- Items --%>
                                                    
                                                    <ext:LayoutRow RowHeight="0.6">
                                                        <%-- Panel de items --%>
                                                        <ext:Panel 
                                                        Collapsible="false"
                                                        ID="PanelItems" 
                                                        Title=""
                                                        runat="server" 
                                                        AutoWidth="true"
                                                        Border="true"
                                                        AnchorHorizontal="right"
                                                        AutoScroll="true"
                                                        >
                                                            <Items>
                                                                <ext:GridPanel 
                                                                ID="GridPanelItems" 
                                                                runat="server" 
                                                                AutoHeight="true"
                                                                StoreID="StoreItems"
                                                                Border="false" 
                                                                  
                                                                >
                                                                    <ColumnModel ID="ColumnModel1" runat="server"  >
                                                                        <Columns>                                                               
                                                                        </Columns>
                                                                    </ColumnModel>
                                                                    <SelectionModel>
                                                                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true"   >
                                                                             <DirectEvents>
                                                                 <RowSelect OnEvent="OnRowSelect_EventItems">
                                                                 <ExtraParams>
                                                            <ext:Parameter Name="values1" Value="Ext.encode(#{GridPanelItems}.getRowsValues({selectedOnly:true}))" Mode="Raw"  />
                                                                          </ExtraParams>
                                                           </RowSelect>
                                                           </DirectEvents>
                                                                        </ext:RowSelectionModel>
                                                                    </SelectionModel>
                                                                    <Buttons>
                                                                        <ext:Button runat="server" Text="Agregar" Icon="Add">
                                                                            <DirectEvents>
                                                                                <Click OnEvent="BotonAgregar_Click" Before="#{FormPanelMov}.getForm().reset();">
                                                                                    <EventMask ShowMask="true" Msg="Cargando..." />
                                                                                </Click>
                                                                            </DirectEvents>
                                                                        </ext:Button>
                                                                        <ext:Button ID="BotonModificar" runat="server" Text="Modificar" Icon="TableEdit">
                                                                            <DirectEvents>
                                                                                <Click OnEvent="BotonModificar_Click">
                                                                                    <EventMask ShowMask="true" Msg="Cargando..." />
                                                                                </Click>
                                                                            </DirectEvents>
                                                                        </ext:Button>
                                                                        <ext:Button runat="server" Text="Quitar" Icon="Delete">
                                                                            <DirectEvents>
                                                                                <Click OnEvent="BotonQuitar_Click">
                                                                                    <EventMask ShowMask="true" Msg="Cargando..." />
                                                                                </Click>
                                                                            </DirectEvents>
                                                                        </ext:Button>
                                                                    </Buttons>
                                                                    <LoadMask ShowMask="true" />
                                                                </ext:GridPanel>                        
                                                            </Items>
                                                        </ext:Panel>
                                                        <%-- Fin del panel de items --%>
                                                    </ext:LayoutRow>
                                                </Rows>
                                            </ext:RowLayout>
                                        
                                        </Items>
                                        
                                    </ext:Panel>
                                </Items>                            
                            </ext:TabPanel>
                        </Items>
                        </ext:Panel>
                    </ext:LayoutRow>
                    
                    <%-- Panel inferior --%>
                    <ext:LayoutRow RowHeight="0.15">
                        <ext:Panel ID="Panel3" runat="server" Title="" >
                        <Items>
                            <ext:ColumnLayout ID="ColumnLayout1" runat="server" Split="false" FitHeight="true">
                                <Columns>
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel4" runat="server" Title="Total Neto">
                                            <Items>
                                                <ext:TextField ID="TotalNeto" runat="server" ReadOnly="true" >
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel5" runat="server" Title="IVA">
                                            <Items>
                                                <ext:TextField ID="IVA" runat="server" ReadOnly="true" >
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                        
                                    </ext:LayoutColumn>
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel7" runat="server" Title="Descuentos">
                                            <Items>
                                                <ext:TextField ID="TotalDescuentos" runat="server" ReadOnly="true" >
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel8" runat="server" Title="Recargos">
                                            <Items>
                                                <ext:TextField ID="TotalRecargos" runat="server" ReadOnly="true" >
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel9" runat="server" Title="Otros">
                                            <Items>
                                                <ext:TextField ID="TotalOtros" runat="server" ReadOnly="true" >
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel10" runat="server" Title="Total">
                                            <Items>
                                                <ext:TextField ID="Total" runat="server" ReadOnly="true" >
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                                    
                                    <ext:LayoutColumn ColumnWidth="0.26">
                                        <ext:Panel 
                                            ID="Panel6" 
                                            runat="server" 
                                            Title="" 
                                            Border="false" 
                                            Layout="HBoxLayout">
                                            <LayoutConfig>
                                                <ext:HBoxLayoutConfig Padding="5" Align="Middle" Pack="Center" />
                                            </LayoutConfig>
                                            <Items>  
                                        
                                                <ext:Button ID="BotonRegimenEsp" Text="Regímenes Especiales" Enabled="false" runat="server">
                                                <DirectEvents>
                                                    <Click OnEvent="BotonRegimenEspecial_Click">
                                                          <EventMask ShowMask="true" Msg="Cargando..." />
                                                    </Click>
                                                </DirectEvents>
                                                </ext:Button>
                                            
                                                
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                </Columns>
                            </ext:ColumnLayout>
                        </Items>
                        </ext:Panel>
                    </ext:LayoutRow>
                </Rows>
            </ext:RowLayout>
        </Items>
       
       
    </ext:Viewport>
    
    
    <%-- Ventana de ingreso de items --%>
    <ext:Window 
        ID="VentanaMov" 
        runat="server" 
        Title="Item"  
        Icon="Application"
        AutoHeight="true" 
        Width="500px"
        BodyStyle="background-color: #fff;" 
        Padding="5"
        Closable="false"
        Collapsible="false" 
        Hidden="true"
        Modal="true">
        <Items>
            <ext:FormPanel ID="FormPanelMov" 
                runat="server" 
                Border="false" 
                Header="false" 
                LabelAlign="Left"> 

                <Defaults>
                
                    <ext:Parameter Name="Editable" Value="true" />
                    <ext:Parameter Name="MsgTarget" Value="side" />
                </Defaults>
                <Items>
               <ext:Panel 
                ID="Panel14" 
                runat="server" 
                Height="300" 
                Header="false" 
                Layout="Fit">
                    <Items>                       
                        <%--Panel de abms--%>
                        <ext:GridPanel 
                        ID="GridPanelConceptos" 
                        runat="server" 
                        Height="300" 
                        StoreID="Store1"              
                        Border="false"    
               
                        >
                            <Plugins>
                                <ext:GridFilters runat="server" ID="GridFilters1" Local="true">
                                    <Filters>
                                    </Filters>
                                </ext:GridFilters>
                            </Plugins>
                        
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true"   >
                                  <DirectEvents>
                                <RowSelect OnEvent="OnRowSelect_Event" >
                                <ExtraParams>
                                       <ext:Parameter Name="Values" Value="Ext.encode(#{GridPanelConceptos}.getRowsValues({selectedOnly:true}))" Mode="Raw"  />

                               </ExtraParams>
                                 </RowSelect>
                              </DirectEvents>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <TopBar>
                                <ext:Toolbar 
                                runat="server" 
                                ID="TopBarFiltros" 
                                Visible="true" 
                                AutoHeight="true"
                                >
                                    <Items>
                                        <%--Controles de filtros--%>
                                        <ext:ComboBox runat="server" 
                                        ID="comboBox1" 
                                        StoreID="Store2"
                                        Mode="Local"
                                        EmptyText="Filtros"
                                        Editable="false"
                                        TypeAhead="true" 
                                        ForceSelection="true"
                                        TriggerAction="All"            
                                        DisplayField="display"
                                        ValueField="display"
                                        ValueNotFoundText=""
                                        >
                                        </ext:ComboBox>
                                        
                                        <ext:Panel ID="Separador1" Width="4" Height="0" Border="false" runat="server">
                                        </ext:Panel>
                                        
                                        <ext:TextField runat="server" ID="Text">
                                        </ext:TextField>
                                        
                                        <ext:Panel ID="Panel25" Width="4" Height="0" Border="false" runat="server">
                                        </ext:Panel>
                                        
                                        <ext:Button runat="server" ID="buttonFiltro" Text="Filtrar">
                                            <DirectEvents>
                                                <Click OnEvent="buttonFiltro_OnClick" />
                                            </DirectEvents>
                                        </ext:Button>
                                        
                                        <ext:Button runat="server" ID="buttonClean" Text="Limpiar">
                                            <DirectEvents>
                                                <Click OnEvent="buttonClean_OnClick" />
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" 
                                    runat="server" 
                                    PageSize="10" 
                                    StoreID="Store1" 
                                    DisplayInfo="false" 
                                    />
                            </BottomBar>
                            <SaveMask ShowMask="true" Msg="Guardando..." />
                            <LoadMask ShowMask="true" Msg="Cargando..." />
                        </ext:GridPanel>                        
                    </Items>                 
                </ext:Panel>              
                </Items>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button ID="BotonAceptar"
                Text="Aceptar"
                runat="server">
                <DirectEvents>                   
                        <Click OnEvent="Window1_BotonAceptar_Click">
                            <ExtraParams>
                                <ext:Parameter Name="values" Value="#{FormPanelMov}.getForm().getValues()" Mode="Raw" Encode="true" />
                            </ExtraParams>
                        </Click>                 
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="BotonCancelar" 
                Text="Cancelar"
                runat="server">
                <DirectEvents>
                    <Click OnEvent="Window1_BotonCancelar_Click" Before="#{FormPanelMov}.getForm().reset();"></Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <%-- Fin de ventana --%>
    
    
      <%-- Ventana de Cantidad conceptos --%>
     <ext:Window 
            ID="Window2" 
            runat="server" 
            Title="Cantidad"  
            Icon="Application"
            AutoHeight="true" 
            Width="350px"
            BodyStyle="background-color: #fff;" 
            Padding="5"
            Closable="false"
            Collapsible="false" 
            Hidden="true"
            Modal="true">
            <Items>
                <ext:FormPanel ID="FormPanel2" 
                    runat="server" 
                    Border="false" 
                    Header="false" 
                    LabelAlign="Left">
                   
                    <Defaults>
                        <ext:Parameter Name="Editable" Value="true" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                    </Defaults>
                    
                    <Items>                           
                                 <ext:NumberField 
                                    ID="FieldCantidad"
                                    runat="server"
                                    FieldLabel="Cantidad"
                                    AnchorHorizontal="90%"                                                                                                        
                                    Selectable="true"                                    
                                     >
                                     </ext:NumberField>                                                            
                    
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button ID="Button1"
                    Text="Aceptar"
                    runat="server">
                    <DirectEvents>
                        <Click OnEvent="Window2_BotonAceptar_Click">
                            <ExtraParams>
                                <ext:Parameter Name="values" Value="#{FormPanel2}.getForm().getValues()" Mode="Raw" Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button2" 
                    Text="Cancelar"
                    runat="server">
                    <DirectEvents>
                        <Click OnEvent="Window2_BotonCancelar_Click" Before="#{FormPanel2}.getForm().reset();"></Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Window>
          <%-- Fin de ventana de cantidad de conceptos --%>


             <%-- Ventana de regimenes especiales --%>
   
    <ext:Window 
        ID="WindowRegimenEspecial" 
        runat="server" 
        Title="Item"  
        Icon="Application"
        AutoHeight="true" 
        Width="500px"
        BodyStyle="background-color: #fff;" 
        Padding="5"
        Closable="false"
        Collapsible="false" 
        Hidden="true"
        Modal="true">
        <Items>
            <ext:FormPanel ID="FormPanel3" 
                runat="server" 
                Border="false" 
                Header="false" 
                LabelAlign="Left"> 

                <Defaults>
                
                    <ext:Parameter Name="Editable" Value="true" />
                    <ext:Parameter Name="MsgTarget" Value="side" />
                </Defaults>
                <Items>
               <ext:Panel 
                ID="Panel26" 
                runat="server" 
                Height="300" 
                Header="false" 
                Layout="Fit">
                    <Items>                       
                        <%--Panel de abms--%>
                        <ext:GridPanel 
                        ID="GridPanelRegimenesEspeciales" 
                        runat="server" 
                        Height="300" 
                        StoreID="Store3"              
                        Border="false"    
               
                        >
                            <Plugins>
                                <ext:GridFilters runat="server" ID="GridFilters2" Local="true">
                                    <Filters>
                                    </Filters>
                                </ext:GridFilters>
                            </Plugins>
                        
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" SingleSelect="true"   >
                                  <DirectEvents>
                                <RowSelect OnEvent="OnRowSelectRegimen_Event" >
                                <ExtraParams>
                                       <ext:Parameter Name="ValuesRegimen" Value="Ext.encode(#{GridPanelRegimenesEspeciales}.getRowsValues({selectedOnly:true}))" Mode="Raw"  />

                               </ExtraParams>
                                 </RowSelect>
                              </DirectEvents>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <TopBar>
                                <ext:Toolbar 
                                runat="server" 
                                ID="Toolbar1" 
                                Visible="true" 
                                AutoHeight="true"
                                >
                                    <Items>
                                        <%--Controles de filtros--%>
                                        <ext:ComboBox runat="server" 
                                        ID="comboBox2" 
                                        StoreID="Store2"
                                        Mode="Local"
                                        EmptyText="Filtros"
                                        Editable="false"
                                        TypeAhead="true" 
                                        ForceSelection="true"
                                        TriggerAction="All"            
                                        DisplayField="display"
                                        ValueField="display"
                                        ValueNotFoundText=""
                                        >
                                        </ext:ComboBox>
                                        
                                        <ext:Panel ID="Panel27" Width="4" Height="0" Border="false" runat="server">
                                        </ext:Panel>
                                        
                                        <ext:TextField runat="server" ID="TextField1">
                                        </ext:TextField>
                                        
                                        <ext:Panel ID="Panel28" Width="4" Height="0" Border="false" runat="server">
                                        </ext:Panel>
                                        
                                        <ext:Button runat="server" ID="button3" Text="Filtrar">
                                            <DirectEvents>
                                                <Click OnEvent="buttonFiltro_OnClick" />
                                            </DirectEvents>
                                        </ext:Button>
                                        
                                        <ext:Button runat="server" ID="button4" Text="Limpiar">
                                            <DirectEvents>
                                                <Click OnEvent="buttonClean_OnClick" />
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar2" 
                                    runat="server" 
                                    PageSize="10" 
                                    StoreID="Store1" 
                                    DisplayInfo="false" 
                                    />
                            </BottomBar>
                            <SaveMask ShowMask="true" Msg="Guardando..." />
                            <LoadMask ShowMask="true" Msg="Cargando..." />
                        </ext:GridPanel>                        
                    </Items>                 
                </ext:Panel>              
                </Items>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button ID="Button5"
                Text="Aceptar"
                runat="server">
                <DirectEvents>                   
                        <Click OnEvent="WindowRegimenEspecial_BotonAceptar_Click">
                            <ExtraParams>
                                <ext:Parameter Name="values" Value="#{FormPanelMov}.getForm().getValues()" Mode="Raw" Encode="true" />
                            </ExtraParams>
                        </Click>                 
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button6" 
                Text="Cancelar"
                runat="server">
                <DirectEvents>
                    <Click OnEvent="WindowRegimenEspecial_BotonCancelar_Click" Before="#{FormPanelMov}.getForm().reset();"></Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>

          <%-- Fin de ventana de regimenes especiales --%>


            <%-- Ventana de Tarjeta de credito --%>
     <ext:Window 
            ID="WindowTarjetaCredito" 
            runat="server" 
            Title="Registro de cupon tarjeta de credito"  
            Icon="Application"
            AutoHeight="true" 
            Width="500px"
            BodyStyle="background-color: #fff;" 
            Padding="5"
            Closable="false"
            Collapsible="false" 
            Hidden="true" 
            Modal="true">
            <Items>
                <ext:FormPanel ID="FormPanel4" 
                    runat="server" 
                    Border="false" 
                    Header="false" 
                    LabelAlign="Left">
                   
                    <Defaults>
                        <ext:Parameter Name="Editable" Value="true" />
                        <ext:Parameter Name="MsgTarget" Value="side" />
                    </Defaults>
                    
                    <Items>            
                                <ext:DateField  
                                    ID="FechaCuponTarjeta"
                                    runat="server" 
                                    FieldLabel="Fecha" 
                                    Format="dd/MM/yyyy"
                                    AnchorHorizontal="100%"                                                 
                                    >
                                </ext:DateField>
                       
                           <ext:ComboBox 
            
                            Editable="false"
                            ID="ComboBoxTarjetaCredito"
                            EmptyText="Seleccione una tarjeta..." 
                            Mode="Local"           
                       
                            runat="server"
                            FieldLabel="Tarjeta de credito" 
                            TriggerAction="All"                        
                         
                            AnchorHorizontal="100%" 
                        >        </ext:ComboBox>
                                            
                                                         
                                 <ext:NumberField 
                                    ID="NumeroEstablecimiento"
                                    runat="server"
                                    FieldLabel="N° estable"
                                    AnchorHorizontal="100%"                                                                                                        
                                    Selectable="true"                                    
                                     >
                                     </ext:NumberField>                                                            
                    
                                               
                                 <ext:NumberField 
                                    ID="TelefonoAutorizado"
                                    runat="server"
                                    FieldLabel="Telefono Autorizado"
                                    
                                    AnchorHorizontal="100%"                                                                                                        
                                    Selectable="true"                                    
                                     >
                                     </ext:NumberField>   

                                          <ext:TextField 
                                        ID="TitularTarjeta" 
                                        runat="server" 
                                        AllowBlank="false"
                                         AnchorHorizontal="100%"    
                                         FieldLabel="Tarjeta a nombre de" 
                                       LabelWidth="200"
                                        >
                                    </ext:TextField>

                                         <ext:NumberField 
                                    ID="NumeroTarjeta"
                                    runat="server"
                                    FieldLabel="Numero de tarjeta"
                                   AnchorHorizontal="100%"                                                                                                    
                                    Selectable="true"                                    
                                     >
                                     </ext:NumberField>   

                                      <ext:DateField  
                                    ID="VencimienotCupon"
                                    runat="server" 
                                    FieldLabel="Vencimiento" 
                                    Format="dd/MM/yyyy"
                                    AnchorHorizontal="100%"                                                  
                                    >
                                </ext:DateField>

                                    <ext:NumberField 
                                    ID="CantCuotas"
                                    runat="server"
                                    FieldLabel="Cantidad de Cuotas"
                                   AnchorHorizontal="100%"                                                                                                           
                                    Selectable="true"                                    
                                     >
                                     </ext:NumberField>   

                                    <ext:NumberField 
                                    ID="CodAutorizado"
                                    runat="server"
                                    FieldLabel="Codigo de Autorizacion"
                                   AnchorHorizontal="100%"                                                                                                        
                                    Selectable="true"                                    
                                     >
                                   </ext:NumberField>   
                                     
                                      <ext:NumberField 
                                    ID="TelefonoTarjeta"
                                    runat="server"
                                    FieldLabel="Telefono"
                                   AnchorHorizontal="100%"                                                                                                         
                                    Selectable="true"                                    
                                     >
                                   </ext:NumberField>   
                                       
                                    <ext:NumberField 
                                    ID="DniTarjeta"
                                    runat="server"
                                    FieldLabel="Dni"  
                                   AnchorHorizontal="100%"                                                                                                          
                                    Selectable="true"                                    
                                     >
                                   </ext:NumberField>  

            
                            <ext:ComboBox 
            
                            Editable="false"
                            ID="ComboBoxCuentaCliente"
                            EmptyText="Seleccione una cuenta..." 
                            Mode="Local"                          
                            runat="server"
                            FieldLabel="Cuenta corriente del cliente" 
                            TriggerAction="All"                           
                            AnchorHorizontal="100%"    
                            >        
                            </ext:ComboBox>

                        <ext:TextField 
                        ID="ConceptoTarjeta" 
                        runat="server" 
                        AllowBlank="false"
                        FieldLabel="Concepto"
                         AnchorHorizontal="100%"    
                        >
                        </ext:TextField>
                                                    
                        <ext:NumberField 
                        ID="ImporteTarjeta"
                        runat="server"
                        FieldLabel="Importe"
                       AnchorHorizontal="100%"                                                                                                       
                        Selectable="true"                                    
                            >
                        </ext:NumberField>  

                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button ID="Button7"
                    Text="Aceptar"
                    runat="server">
                    <DirectEvents>
                        <Click OnEvent="Window2_BotonAceptar_Click">
                            <ExtraParams>
                                <ext:Parameter Name="values" Value="#{FormPanel2}.getForm().getValues()" Mode="Raw" Encode="true" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button8" 
                    Text="Cancelar"
                    runat="server">
                    <DirectEvents>
                        <Click OnEvent="Window2_BotonCancelar_Click" Before="#{FormPanel2}.getForm().reset();"></Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Window>
          <%-- Fin de ventana de tarjeta de credito --%>




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


<asp:SqlDataSource 
ID="SqlDataSource4" 
runat="server"
>
</asp:SqlDataSource>

<asp:SqlDataSource 
ID="SqlDataSource5" 
runat="server"
>
</asp:SqlDataSource>


</body>
</html>
