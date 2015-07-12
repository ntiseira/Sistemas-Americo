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
    
 
   
    
        
</script>

 <script type="text/javascript">

     function mensaje() {

         alert('HAY QUE HACER QUE EN VEZ DE ESTE CARTEL MUESTRE EL CONTEXT MENU');
//         var contextmenu = document.getelementbyid("companymenu");
//         contextmenu.show();
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
                <ext:RecordField  Name="numero" Type="Auto"   ></ext:RecordField>
                <ext:RecordField  Name="cliente_codcliente" Type="Auto" ></ext:RecordField>
                <ext:RecordField  Name="talonario_tiposcomprobante_idtipocomprobante"  Type="Auto"></ext:RecordField>
                <ext:RecordField  Name="total"  Type="Auto"></ext:RecordField>
        </Fields>





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
                              

                                </Items>
                                </ext:FormPanel>
        <ext:Panel 
        Collapsible="true"
        ID="Panel1" 
        runat="server" 
       
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
                        Border="false"  >
                    
                    <View>                  
                        <ext:GridView ForceFit="true"  ScrollOffset="0"   ></ext:GridView>
                    </View>                           
                        
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1"  runat="server" SingleSelect="true"  >                                
                                <DirectEvents>
                            <RowSelect OnEvent="OnRowSelect_EventItems">
                            <ExtraParams>
                                <ext:Parameter Name="values" Value="Ext.encode(#{GridPanelCredito}.getRowsValues({selectedOnly:true}))" Mode="Raw"  />
                           </ExtraParams>
                            </RowSelect>
                            </DirectEvents>



                                </ext:RowSelectionModel>                            
                            </SelectionModel>
                            

                          
                       
                            <ColumnModel ID="ColumnModel1"  runat="server" >
                            <Columns>                         
                                         
         
                            <ext:Column   Align="Center" Header="numero" Editable="false" Resizable="true"   DataIndex="Numero" >                                                         

                                <Editor>                                                  
                                    <ext:TextField ID="TextField1"  DataIndex="numero" runat="server" Visible="true"       ></ext:TextField>
                                </Editor>                                

                            </ext:Column>                           
                            <ext:Column Align="Center"   Width="300" Header="cliente_codcliente"  Sortable="true" Editable="true" Resizable="true"  DataIndex="Cliente_codcliente"  >   
                                <Editor>
                                <ext:TextField ID="clientecredito"  DataIndex="cliente_codcliente" runat="server" Visible="true"        ></ext:TextField>
                                </Editor>
                                
                            </ext:Column>    


                            <ext:Column Align="Center" Header="Empresa" Editable="true" Resizable="true"  DataIndex="Talonario_tiposcomprobante_idtipocomprobante"  Hidden="true" >                                                        

                              <Editor>                               
                              <ext:NumberField ID="NumberField1" DataIndex="talonario_tiposcomprobante_idtipocomprobante" runat="server"></ext:NumberField>                            

                              </Editor>
                            </ext:Column>

                            <ext:Column  Align="Center" Header="Total" Editable="true" Resizable="true"  DataIndex="Total"  >                                                        

                              <Editor>                              
                                  <ext:TextField ID="TextField4"  DataIndex="total" runat="server"   Text="codigo" Visible="true" ></ext:TextField>
                              </Editor>
                            </ext:Column>  
                                           
                                           
                            
                            <ext:Column  Align="Center" Header="Total aplicado" Editable="true" Resizable="true"    >                                                        

                              <Editor>                              
                                  <ext:TextField ID="totalCompensar"   runat="server"  Visible="true" ></ext:TextField>
                              </Editor>
                            </ext:Column>       
                            </Columns>                         
                            </ColumnModel>
                       
                            <BottomBar>
                            <ext:Toolbar runat="server">
                             <Items>
                            <ext:PagingToolbar ID="PagingToolbarDebito" 
                                    runat="server" 
                                    PageSize="10" 
                                    StoreID="Store1" 
                                    DisplayInfo="false"                                      
                                     Width="650px"
                                    />                                    
                               <ext:Button ID="aplicarCompensaciones" LabelAlign="Left" LabelWidth="30"  Text="Aplicar Compensacion" Width="150"  runat="server">
                                 <DirectEvents>
                        <Click OnEvent="Aplicar_Click">                          
                        </Click>
                    </DirectEvents>
                               
                               </ext:Button>
                       
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
                                <ext:MenuItem ID="mnuCreate" runat="server" Text="Aplicar a comprobante" Icon="Money" />                            
                                <ext:MenuItem ID="mnuDelete" runat="server" Text="Deshacer Aplicar" Icon="Cross" />  
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