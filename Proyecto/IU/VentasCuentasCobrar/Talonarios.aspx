<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Talonarios.aspx.cs" Inherits="IU.VentasCuentasCobrar.Talonarios" %>
<%@ Import Namespace="MySql.Data" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.UX" Namespace="Ext.Net.UX" TagPrefix="ux" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
   <ext:ResourceManager ID="ResourceManager1" runat="server" />
       
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
    //    this.Store2.DataBind();
    }
  
        
</script>




<%--
<ext:Store 
    ID="Store1" 
    runat="server"
    DataSourceId="SqlDataSource1"
    ShowWarningOnFailure="false"
    OnAfterDirectEvent="Store1_AfterDirectEvent"
    OnBeforeDirectEvent="Store1_BeforeDirectEvent" 
    UseIdConfirmation="true" 
    OnBeforeRecordInserted="Store1_BeforeRecordInserted"
    OnAfterRecordInserted="Store1_AfterRecordInserted"
    OnRefreshData="Store1_RefershData"
>
--%>
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
        <Fields >
                  <ext:RecordField  Name="nroTalonario" Type="Auto"  ></ext:RecordField>
                  <ext:RecordField  Name="descripcion"  Type="Auto"></ext:RecordField>
                  <ext:RecordField  Name="desde" Type="Auto"></ext:RecordField>
                  <ext:RecordField  Name="hasta" Type="Auto"></ext:RecordField>               
                  <ext:RecordField  Name="utilizado"  Type="Auto"></ext:RecordField>               
                  <ext:RecordField  Name="aplicacion" Type="Auto"></ext:RecordField>
                  <ext:RecordField  Name="ultimoUtilizado" Type="Auto"></ext:RecordField>
                  <ext:RecordField  Name="tiposcomprobante_idtipocomprobante" Type="Auto"></ext:RecordField>
                  <ext:RecordField  Name="tiposcomprobante_empresa_idempresa" Type="Auto"></ext:RecordField>
        </Fields>
        </ext:JsonReader>
    </Reader>
    <Listeners>
        <LoadException Handler="Ext.Msg.alert('Error al cargar los datos', 'Por favor recargue la página');" />
        <CommitFailed Handler="Ext.Msg.alert('Error al guardar', 'Verifique que los campos estén correctos');" />
        <SaveException Handler="Ext.Msg.alert('Error al guardar', 'Verifique que los campos estén correctos');" />
    </Listeners>      
</ext:Store>

    <ext:Store 
        ID="StoreComboTipoComprobante" 
        runat="server"       
        DataSourceId="SqlDataSource3"
        >
        <Reader>         
        <ext:JsonReader>
        <Fields>
              <ext:RecordField Name="Idtipocomprobante" ></ext:RecordField>
              <ext:RecordField Name="Descrip"></ext:RecordField>
        </Fields>
        </ext:JsonReader>               
       </Reader>                    
        </ext:Store>   
    

<ext:Viewport ID="Viewport1" runat="server">
    <Items>
        <ext:BorderLayout ID="BorderLayout1" runat="server">
            <North MarginsSummary="5 5 5 5">
                <ext:Panel ID="Panel1" 
                    runat="server" 
                    Title="Descripción" 
                    Height="100" 
                    Padding="5"
                    Frame="true" 
                    Collapsible="true"
                    Icon="Information">
                    <Content>
                        <i><b><ext:Label ID="LabelTitulo" runat="server">
                        </ext:Label></b></i>
                        <br />
                        <br />
                        <ext:Label ID="LabelDescrip" runat="server">
                        </ext:Label>
                    </Content>
                </ext:Panel>
            </North>
            <Center MarginsSummary="0 5 0 5">
                <ext:Panel 
                ID="Panel2" 
                runat="server" 
                Height="300" 
                Header="false" 
                Layout="Fit">
                    <Items>                       
                        <%--Panel de abms--%>
                        <ext:GridPanel 
                        ID="GridPanel1" 
                        runat="server" 
                        Height="300" 
                        StoreID="Store1"             
                        Border="false"   
                        EnableColumnResize="false"
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
                                                 
                            <ColumnModel ID="ColumnModel1"  runat="server">
                            
                            <Columns>                            
                               <ext:Column  Align="Center" Header="Codigo" Editable="true" Resizable="true"   DataIndex="NroTalonario" >                                                         
                               <Editor>                                                  
                                 <ext:NumberField  runat="server" DataIndex="nroTalonario"  ></ext:NumberField>
                               </Editor>                                
                            </ext:Column>                           
                            <ext:Column Align="Center" Header="Descripcion"  Sortable="true" Editable="true" Resizable="true"  DataIndex="Descripcion" >   
                              <Editor>                                                      
                                <ext:TextField ID="TextField2"  DataIndex="descripcion" runat="server" Text="Descripcion" Visible="true"   AllowBlank="false"   EmptyText="escriba aqui"> </ext:TextField>
                              </Editor>                                                     
                            </ext:Column>                            
                            <ext:Column Header="Nro.Desde" Editable="true" Resizable="true"  DataIndex="Desde"  Hidden="false" Align="Center">                                                        
                              <Editor>                                
                                <ext:NumberField ID="NumberField1"  DataIndex="desde" runat="server"  ></ext:NumberField>
                              </Editor>
                            </ext:Column>
                            <ext:Column Header="Nro.Hasta" Editable="true" Resizable="true"  DataIndex="Hasta"  Align="Center">                                                        
                              <Editor>                                 
                                 <ext:NumberField ID="NumberField2"  DataIndex="hasta" runat="server"  ></ext:NumberField>
                              </Editor>
                            </ext:Column>     
                          
                         
                            
                         
                                             
                            <ext:CheckColumn Header="Utilizado" Editable="true" Resizable="true" DataIndex="Utilizado" Align="Center">
                             <Editor>  
                              <ext:Checkbox ID="Checkbox1" runat="server" DataIndex="utilizado" >
                             </ext:Checkbox>                                    
                              </Editor>
                            </ext:CheckColumn>                          
                              <ext:Column Header="Aplicacion" Editable="true" Resizable="true"  DataIndex="Aplicacion" Align="Center"  >                                                        
                              <Editor>                              
                                  <ext:TextField ID="TextField7"  DataIndex="aplicacion" runat="server"   Text="codigo" Visible="true" ></ext:TextField>
                              </Editor>
                            </ext:Column>
                              <ext:Column Header="Ultimo utilizado" Editable="true" Resizable="true"  DataIndex="UltimoUtilizado" Align="Center"  >                                                        
                              <Editor>                              
                                   <ext:NumberField ID="NumberField3"  DataIndex="UltimoUtilizado" runat="server"  ></ext:NumberField>                                 
                              </Editor>
                            </ext:Column>
                            
                            <ext:Column Header="Tipo de comprobante" Editable="true" Resizable="true"  DataIndex="tiposcomprobante_idtipocomprobante"  Align="Center" >                                                        
                              <Editor>                                                           
                              <ext:ComboBox  StoreID="StoreComboTipoComprobante" ValueField="Idtipocomprobante" DisplayField="Descrip"  runat="server"   DataIndex="Tiposcomprobante_idtipocomprobante" Text="codigo"></ext:ComboBox>                               
                              </Editor>                              
                            </ext:Column>  
                             
                               <ext:Column Header="Empresa" Editable="true" Resizable="true"  DataIndex="tiposcomprobante_empresa_idempresa"  Align="Center"  Hidden="true">                                                        
                              <Editor>                              
                                  <ext:TextField ID="TextField4"  DataIndex="Tiposcomprobante_empresa_idempresa" runat="server"   Text="codigo" Visible="true" ></ext:TextField>
                              </Editor>
                            </ext:Column>               
                            </Columns>                         
                           
                            </ColumnModel>
                        
                            <SelectionModel>                            
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" >
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
                                        
                                        <ext:Panel ID="Panel3" Width="4" Height="0" Border="false" runat="server">
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
                    <Buttons>
                        <ext:Button ID="btnInsert" runat="server"  Text="Crear" Icon="Add">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.insertRecord(0, {});#{GridPanel1}.getView().focusRow(0);#{GridPanel1}.startEditing(0, 0);" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnSave" runat="server"  Text="Guardar altas/modificaciones" Icon="Disk">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.save();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnDelete" runat="server"  Text="Eliminar" Icon="Delete" >
                            <DirectEvents>
                                <Click OnEvent="btnDelete_OnClick" >                                  
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btnRefresh" runat="server"  Text="Actualizar" Icon="ArrowRefresh">
                            <Listeners>
                                <Click Handler="#{GridPanel1}.reload();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:Panel>
            </Center>             
        </ext:BorderLayout>
    </Items>
</ext:Viewport>
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
