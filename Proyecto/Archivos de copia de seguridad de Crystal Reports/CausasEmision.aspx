<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CausasEmision.aspx.cs" Inherits="IU.VentasCuentasCobrar.CausasEmision" %>

<%@ Import Namespace="MySql.Data" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">

   <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="prueba" />

       
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
        <ext:RecordField  Name="codCausasEmision" Type="Auto"   ></ext:RecordField>
        <ext:RecordField  Name="descripcion" Type="Auto" ></ext:RecordField>
        <ext:RecordField  Name="empresa_idempresa"  Type="Auto"></ext:RecordField>
        <ext:RecordField  Name="codigo"  Type="Auto"></ext:RecordField>
        </Fields>
        </ext:JsonReader>
    </Reader>
    <Listeners>
        <LoadException Handler="Ext.Msg.alert('Error al cargar los datos', 'Por favor recargue la página');" />
        <CommitFailed Handler="Ext.Msg.alert('Error al guardar', 'Verifique que los campos estén correctos');" />
        <SaveException Handler="Ext.Msg.alert('Error al guardar', 'Verifique que los campos estén correctos');" />
    </Listeners>      
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
                         
                    
                                            
                            
                       
                            <ColumnModel ID="ColumnModel1"  runat="server" >
                            <Columns>                         

                      
                            <ext:Column   Align="Center" Header="Codigo" Editable="false" Resizable="true"   DataIndex="Codcausasemision" >                                                         

                                <Editor>                                                  
                                    <ext:TextField ID="TextField1"  DataIndex="codCausasEmision" runat="server" Visible="true"       ></ext:TextField>
                                </Editor>                                

                            </ext:Column>                           
                            <ext:Column Align="Center"   Width="300" Header="Descripcion"  Sortable="true" Editable="true" Resizable="true"  DataIndex="Descripcion"  >   
                                <Editor>
                                <ext:TextField ID="TextField2"  DataIndex="Descripcion" runat="server" Visible="true"        ></ext:TextField>
                                </Editor>
                                
                            </ext:Column>    


                            <ext:Column Align="Center" Header="Empresa" Editable="true" Resizable="true"  DataIndex="Empresa_idempresa"  Hidden="true" >                                                        

                              <Editor>                               
                              <ext:NumberField DataIndex="empresa_idempresa" runat="server"></ext:NumberField>                            

                              </Editor>
                            </ext:Column>

                            <ext:Column  Align="Center" Header="codigo" Editable="true" Resizable="true"  DataIndex="Codigo"  >                                                        

                              <Editor>                              
                                  <ext:TextField ID="TextField4"  DataIndex="codigo" runat="server"   Text="codigo" Visible="true" ></ext:TextField>
                              </Editor>
                            </ext:Column>  
                                                
                            </Columns>                         
                            </ColumnModel>
                        
                            <SelectionModel>                            
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" >
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            
                             
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


</body>
</html>
