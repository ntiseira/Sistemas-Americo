<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompensacionComprobante.aspx.cs" Inherits="IU.VentasCuentasCobrar.Cobranzas.CompensacionComprobante" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="../../Generico/ComboClases.ascx" tagname="ComboClases" tagprefix="americo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">

    <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="pruebaa" />
    
    
<script runat="server"> 
    
   
    
    public void filtrarCampo() 
    {
        WebHelper.SqlValor[] Valor = new WebHelper.SqlValor[] { new WebHelper.SqlValor(comboBox1.Text, Text.Text) };
        WebHelper.Storer st = new WebHelper.Storer(Tipo);
        st.Valores = Valores;
        this.OnShow();
    }

    protected void Store1_BeforeRecordInserted(object sender, BeforeRecordInsertedEventArgs e)
    {
        AlInsertarRecord(ref e);
        //object region = e.NewValues["Region"];

        //if (region == null || region.ToString() != "Alabama (AL)")
        //{
        //    e.Cancel = true;
        //this.cancel = true;
        //this.message = "The Region must be 'AL'";
        // }
    }
    
    protected void Store1_BeforeRecordUpdated(object sender, BeforeRecordUpdatedEventArgs e)
    {
        AlModificarRecord(ref e);
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
    
    protected void Store2_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store2.DataBind(); 
    }

   
    
        
</script>

 <script type="text/javascript">

     function mensaje() {

         alert('HAY QUE HACER QUE EN VEZ DE ESTE CARTEL MUESTRE EL CONTEXT MENU');
//         var contextmenu = document.getelementbyid("companymenu");
//         contextmenu.show();
     }
 
    
    </script>


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
    DataSourceId="SqlDataSource1"
    ShowWarningOnFailure="false"
    UseIdConfirmation="false" 
    OnRefreshData="Store1_RefershData"
    OnBeforeRecordInserted="Store1_BeforeRecordInserted"
    OnBeforeRecordUpdated="Store1_BeforeRecordUpdated"
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


    <ext:Viewport ID="Viewport1" runat="server" Layout="Anchor">
    <Items>
       
          <%-- Panel --%>
                            <ext:FormPanel 
                                ID="FormPanel1" 
                                runat="server" 
                                Title="Compensacion entre Comprobantes"
                                MonitorPoll="500" 
                                MonitorValid="true" 
                                Padding="5" 
                                AutoWidth="true"
                                AutoHeight="true"
                                ButtonAlign="Right"
                                AnchorVertical="100%"
                                Border="false">
                                <Items>
                                
                                     <%-- Cliente --%>
                                            <ext:Panel ID="Panel13" runat="server" Border="false" AnchorHorizontal="90%" Layout="Fit">
                                            <Content>
                                         
                                                <americo:ComboClases 
                                                    ID="ComboClasesCliente" runat="server" 
                                                    TextoVacio="Seleccione un cliente" 
                                                    Texto="Cliente" 
                                                    AtributoValor="Codcliente" 
                                                    AtributoDisplay="Razonsocial"                                                     
                                                    />                                          
                                            
                                            </Content>                                       
                                            </ext:Panel>

                                  <%-- Moneda --%>
                                            <ext:Panel ID="Panel3" runat="server" Border="false" AnchorHorizontal="90%" Layout="Fit">
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
                                </ext:FormPanel>
        <ext:Panel 
        Collapsible="true"
        ID="Panel1" 
        runat="server" 
        Title="Credito"
        Height="150"
        AnchorHorizontal="right" 
        ContextMenuID ="MenuGridCredito"
        Layout="Fit"
        >
            <Content>
   
      <%--Panel de abms--%>
                        <ext:GridPanel 
                        ID="GridPanelCredito" 
                        runat="server" 
                        AnchorVertical="100%" 
                        StoreID="Store1"              
                        Border="false"   
                     
                        >
                    
                    <View>                  
                        <ext:GridView ForceFit="true"  ScrollOffset="0"   ></ext:GridView>
                    </View>

                            <Plugins>
                                <ext:GridFilters runat="server" ID="GridFilters1" Local="true">
                                    <Filters>
                                    </Filters>
                                </ext:GridFilters>
                            </Plugins>
                        
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1"  runat="server" SingleSelect="true"  >                                
                                </ext:RowSelectionModel>                            
                            </SelectionModel>
                          
                          
                            <Listeners>
                              <RowContextMenu Handler="e.preventDefault(); #{MenuGridCredito}.dataRecord = this.store.getAt(rowIndex);#{MenuGridCredito}.showAt(e.getXY());" />
                           </Listeners>
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
                                        
                                        <ext:Panel ID="Panel4" Width="4" Height="0" Border="false" runat="server">
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
                            <ext:Toolbar runat="server">
                             <Items>
                            <ext:PagingToolbar ID="PagingToolbarDebito" 
                                    runat="server" 
                                    PageSize="10" 
                                    StoreID="Store1" 
                                    DisplayInfo="false"                                      
                                     Width="800px"
                                    />                                    
                                 <ext:TextField  ID="TotalCredito" LabelAlign="Left" LabelWidth="30" FieldLabel="Total" Width="150"  runat="server" >
                                 </ext:TextField>
                               </Items>
                             </ext:Toolbar>
                            </BottomBar>
                          
                            <SaveMask ShowMask="true" Msg="Guardando..." />
                            <LoadMask ShowMask="true" Msg="Cargando..." />
                
                       </ext:GridPanel>   
                     </Items>              
                         
                         <ext:Menu runat="server" ShowSeparator="true" ID="MenuGridCredito" Height="50">
                            <Items>
                                <ext:MenuItem ID="mnuCreate" runat="server" Text="Aplicar a comprobante" Icon="Money"/>                            
                                <ext:MenuItem ID="mnuDelete" runat="server" Text="Deshacer Aplicar" Icon="Cross" />  
                            </Items>
                         </ext:Menu>
            </Content>
        </ext:Panel>
    
       
        
         <ext:Panel 
        Collapsible="true"
        ID="Panel2" 
        runat="server" 
        Title="Debito"        
        AnchorHorizontal="right"
        ContextMenuID="MenuGridDebito"
        Layout="Fit" 
        >
            <Content>
                

      <%--Panel de abms--%>
                        <ext:GridPanel 
                        ID="GridPanelDebito" 
                        runat="server" 
                        Height="160"
                        StoreID="Store1"              
                        Border="false"   
                       >

                    <View>                  
                        <ext:GridView ForceFit="true"  ScrollOffset="0"   ></ext:GridView>
                    </View>
                            <Listeners>
                              <RowContextMenu  Handler="e.preventDefault(); #{MenuGridDebito}.dataRecord = this.store.getAt(rowIndex);#{MenuGridDebito}.showAt(e.getXY());" />
                           </Listeners>
                           
                            <Plugins>
                                <ext:GridFilters runat="server" ID="GridFilters2" Local="true">
                                    <Filters>
                                    </Filters>
                                </ext:GridFilters>
                            </Plugins>
                        
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true" >
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
                                        
                                        <ext:Panel ID="Panel5" Width="4" Height="0" Border="false" runat="server">
                                        </ext:Panel>
                                        
                                        <ext:TextField runat="server" ID="TextField1">
                                        </ext:TextField>
                                        
                                        <ext:Panel ID="Panel6" Width="4" Height="0" Border="false" runat="server">
                                        </ext:Panel>
                                        
                                        <ext:Button runat="server" ID="button1" Text="Filtrar">
                                            <DirectEvents>
                                                <Click OnEvent="buttonFiltro_OnClick" />
                                            </DirectEvents>
                                        </ext:Button>
                                        
                                        <ext:Button runat="server" ID="button2" Text="Limpiar">
                                            <DirectEvents>
                                                <Click OnEvent="buttonClean_OnClick" />
                                            </DirectEvents>
                                        </ext:Button>
                                       </Items>
                                </ext:Toolbar>
                            </TopBar>
                  
                            <BottomBar>
                            <ext:Toolbar ID="Toolbar2" runat="server">
                             <Items>
                            <ext:PagingToolbar ID="PagingToolbarCredito" 
                                    runat="server" 
                                    PageSize="10" 
                                    StoreID="Store1" 
                                    DisplayInfo="false"                                      
                                     Width="800px"
                                    />                                    
                                 <ext:TextField  ID="TextField2" LabelAlign="Left" LabelWidth="30" FieldLabel="Total" Width="150"  runat="server" >
                                 </ext:TextField>
                               </Items>
                             </ext:Toolbar>
                            </BottomBar>
                          
                            <SaveMask ShowMask="true" Msg="Guardando..." />
                            <LoadMask ShowMask="true" Msg="Cargando..." />
                       </ext:GridPanel>   
                     </Items>  
                     
                          <ext:Menu runat="server" ShowSeparator="true" ID="MenuGridDebito">
                            <Items>
                                <ext:MenuItem ID="MenuItem1" runat="server" Text="Aplicar a comprobante Debito" Icon="Money"/>                            
                                <ext:MenuItem ID="MenuItem2" runat="server" Text="Deshacer Aplicar Debito" Icon="Cross" />  
                            </Items>
                        </ext:Menu>
                         
              </Content>
        </ext:Panel>
            
    </Items>
    </ext:Viewport>
    </form>

    <asp:SqlDataSource 
      ID="SqlDataSource1" 
      runat="server"
     >
    </asp:SqlDataSource>

</body>
</html>