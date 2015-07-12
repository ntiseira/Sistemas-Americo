<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Concepto.aspx.cs" Inherits="IU.VentasCuentasCobrar.Concepto" %>
<%@ Register Assembly="Ext.Net.UX" Namespace="Ext.Net.UX" TagPrefix="ux" %>
<%@ Import Namespace="MySql.Data" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Página sin título</title>
</head>
<body> 
    <form id="form1" runat="server">
   <ext:ResourceManager ID="ResourceManager1" runat="server"  DirectMethodNamespace="prueba"/>
       
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

  <script type="text/javascript" language="javascript">
     
           
   function porcentaje (value)
  {              
   return value+"%";

} 
   
    </script>
    
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
            <ext:RecordField  Name="codConcepto" Type="Auto"    ></ext:RecordField>
            <ext:RecordField  Name="descripcion" Type="Auto" ></ext:RecordField>
            <ext:RecordField  Name="clase"  Type="Auto"></ext:RecordField>
            <ext:RecordField  Name="observaciones"  Type="Auto"></ext:RecordField>
            <ext:RecordField  Name="tasaIva" Type="Auto" ></ext:RecordField>
            <ext:RecordField  Name="precioNeto" Type="Auto"  ></ext:RecordField>
            <ext:RecordField  Name="precioFinal"  Type="Auto"></ext:RecordField>
            <ext:RecordField  Name="tipo"  Type="Auto"></ext:RecordField>
            <ext:RecordField  Name="moneda_idmoneda"  Type="Auto"></ext:RecordField>
            <ext:RecordField  Name="empresa_idempresa"  Type="Auto"></ext:RecordField>
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
    ID="StoreTasaIva" 
     runat="server"
    DataSourceId="SqlDataSource2"
  
>
    <Reader>
        <ext:ArrayReader>
            <Fields>  
            <ext:RecordField Name="Idtasaiva" Type="Auto"/>
                <ext:RecordField Name="Tasa" Type="Auto"/>           
            </Fields>
        </ext:ArrayReader>
    </Reader>    
</ext:Store>

<ext:Store 
    ID="StoreComboMonedas" 
     runat="server"
    DataSourceId="SqlDataSource3"
 
>
    <Reader>
        <ext:ArrayReader>
            <Fields>  
            <ext:RecordField Name="idmoneda" Type="Auto"/>
                <ext:RecordField Name="moneda" Type="Auto"/>           
            </Fields>
        </ext:ArrayReader>
    </Reader>    
</ext:Store>

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
                        AutoExpandColumn="ahora" 
                            
                        SelectionMemory="Auto">      
                                        
             <Listeners>
           
   
        </Listeners>
        
                    <View>                  
                    <ext:GridView ForceFit="true"  ScrollOffset="0"   ></ext:GridView>
                    </View>
                            <Plugins>
                                <ext:GridFilters runat="server" ID="GridFilters1" Local="true">
                                    <Filters>
                                    </Filters>               
                                </ext:GridFilters>                       
                            </Plugins>                         
                            
                       
                            <ColumnModel ID="ColumnModel1"  runat="server" >
                            <Columns>                         
                        
                            <ext:Column 
                              Align="Center" 
                              Header="Codigo" 
                              Editable="false"
                              Resizable="true"
                              DataIndex="Codconcepto"    >              
                                <Editor>                                 
                                    <ext:TextField ID="TextField1"  DataIndex="codConcepto" runat="server" Visible="true" >                                   
                                    </ext:TextField>
                                </Editor>                                                            
                            </ext:Column>  
                                
                            
                              <ext:Column Align="Center" ColumnID="ahora" Header="Tipo de concepto" Editable="true" Resizable="true"  DataIndex="Tipo"  >                                                        
                              <Editor>                              
                                <ext:ComboBox ID="ComboBox2"  runat="server" DataIndex="tipo">
                                   <Items>
                                      <ext:ListItem Text="Mercadería de Reventa"  />
                                      <ext:ListItem Text="Elaboración Propia"  />
                                      <ext:ListItem Text="Producto en proceso" />
                                      <ext:ListItem Text="Materia prima" />
                                      <ext:ListItem Text="Material"  />         
                                      <ext:ListItem Text="Otro"  />      
                                      <ext:ListItem Text="Servicio"  />                       
                                   </Items>                                
                                </ext:ComboBox>
                              </Editor>
                            </ext:Column>   
                                          
                                                 
                            <ext:Column Align="Center"  Header="Descripcion"  Sortable="true" Editable="true" Resizable="true"  DataIndex="Descripcion" ColumnID="prueba"   >   
                              <Editor>                         
                                <ext:TextField ID="TextField2"  DataIndex="descripcion" runat="server" Text="Descripcion" Visible="true"   AllowBlank="false"  EmptyText="escriba aqui">
                                          </ext:TextField>
                              </Editor>                 
                            </ext:Column>
                            
                            <ext:Column  Align="Center" Header="Clase" Editable="true" Resizable="true"  DataIndex="Clase"   >                                                        
                              <Editor>                              
                                <ext:ComboBox ID="ComboBox3"  runat="server" DataIndex="Clase">
                                   <Items>
                                      <ext:ListItem Text="Normal"  Value="1" />
                                      <ext:ListItem Text="Sólo IVA"  Value="2" />
                                      <ext:ListItem Text="Sólo No Gravado" Value="3" />                                                      
                                   </Items>                                
                                </ext:ComboBox>
                              </Editor>
                            </ext:Column>   
                           
                              <ext:Column Align="Center" Header="Tasa Iva" Editable="true" Resizable="true"  DataIndex="Tasaiva"     ColumnID="tasa" >                                                        
                              <Editor>                             
                             
                              <ext:ComboBox   
                              ID="ComboBoxObjetos" 
                              DataIndex="Tasaiva"
                              runat="server"
                              Text="codigo"
                              StoreID="StoreTasaIva"                           
                              TriggerAction="All"  
                              DisplayField="Tasa"
                              ValueField="Idtasaiva"
                            Mode="Local"   
                             >                                      
                                          
                              </ext:ComboBox>       
                                                        
                              </Editor>
                            
                               
                            </ext:Column>   
                            
                               <ext:Column   ColumnID="precio"  Align="Center" Header="Precio Neto" Editable="true" Resizable="true"  DataIndex="PrecioNeto"   >                                                        
                                  <Editor>       
                                <ext:TextField  ID="precioField" DataIndex="precioNeto" runat="server"  Name="precio"  Text="precioNeto"  ></ext:TextField>
                                    
                                  </Editor>                          
                                
                             </ext:Column>   

                              <ext:Column Align="Center" Header="Precio Final"  Editable="true" Resizable="true"  DataIndex="PrecioFinal"  >                                                        
                              <Editor>                              
                                  <ext:TextField ID="TextField6"  Name="precioFinal" DataIndex="precioFinal" runat="server" Text="precioFinal" >
                              
                                  </ext:TextField>
                              
                              </Editor>          
                      
                            </ext:Column>
                               
                              <ext:Column  Align="Center" Header="Moneda" Editable="true" Resizable="true"  DataIndex="Moneda_idmoneda"  >                                                        
                              <Editor>
                              <ext:ComboBox  
                              runat="server" StoreID="StoreComboMonedas" ValueField="idmoneda"
                               DisplayField="idmoneda"
                              Mode="Local"   
                               ></ext:ComboBox>                                                         
                              </Editor>
                            </ext:Column>
                            
                             <ext:Column Align="Center" Header="Observaciones" Editable="true" Resizable="true"  DataIndex="Observaciones"  >                                                        
                              <Editor>                              
                                  <ext:TextField ID="TextField4"  DataIndex="observaciones" runat="server"   Text="codigo" Visible="true" ></ext:TextField>
                              </Editor>
                            </ext:Column>   
                                          
                                          
                            <ext:Column  Align="Center" Hidden="true" Header="Empresa" Editable="false" Resizable="true"  DataIndex="Empresa_idempresa"  >                                                        
                              <Editor>                              
                                  <ext:TextField ID="TextField5"  DataIndex="empresa_idempresa" runat="server"   Text="codigo" Visible="true" ></ext:TextField>
                              </Editor>
                            </ext:Column>               
                        
                            </Columns>                        
                            </ColumnModel>
                     
                        

                           
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
                        <ext:Button ID="btnDelete" runat="server"  Text="Eliminar" Icon="Delete">                         
                            <DirectEvents>
                                <Click OnEvent="btnDelete_OnClick"  >
                                 <ExtraParams>
                                        <ext:Parameter Name="Values" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                    </ExtraParams>                                  
                                
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

