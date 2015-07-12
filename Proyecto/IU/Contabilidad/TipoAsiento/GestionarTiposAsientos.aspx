<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarTiposAsientos.aspx.cs" Inherits="IU.Contabilidad.TipoAsiento.GestionarTiposAsientos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="MySql.Data" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        //XmlDocument xml = new XmlDocument();
       //xml.Load(Server.MapPath("States.xml"));
        //foreach (XmlNode state in xml.SelectNodes("states/state"))
        //{
        //    this.cbStates.Items.Add(new Ext.Net.ListItem(state.Attributes["label"].InnerText, state.Attributes["data"].InnerText));
        //}
    }

    private bool cancel;
    private string message;
    private string insertedValue;

    protected void Store1_BeforeRecordInserted(object sender, BeforeRecordInsertedEventArgs e)
    {
        /*object region = e.NewValues["Region"];
        
        if (region == null || region.ToString() != "Alabama (AL)")
        {
            e.Cancel = true;
            this.cancel = true;
            this.message = "The Region must be 'AL'";
        }*/
    }

    protected void Store1_AfterRecordInserted(object sender, AfterRecordInsertedEventArgs e)
    {
        //The deleted and updated records confirms automatic (depending AffectedRows field)
        //But you can override this in AfterRecordUpdated and AfterRecordDeleted event
        //For insert we should set new id for refresh on client
        //If we don't set new id then old id will be used
        /*if (e.Confirmation.Confirm && !string.IsNullOrEmpty(insertedValue))
        {
            e.Confirmation.ConfirmRecord(insertedValue);
            insertedValue = "";
        }*/
    }

    protected void SqlDataSource1_Inserted(object sender, SqlDataSourceStatusEventArgs e)
    {
        //use e.AffectedRows for ensure success action. The store read this value and set predefined Confirm depend on e.AffectedRows
        //The Confirm can be granted or denied in OnRecord....ed event
        /*insertedValue = e.Command.Parameters["@newId"].Value != null
                            ? e.Command.Parameters["@newId"].Value.ToString()
                            : "";*/
    }

    protected void Store1_AfterDirectEvent(object sender, AfterDirectEventArgs e)
    {
        /*if (e.Response.Success)
        {
            // set to .Success to false if we want to return a failure
            e.Response.Success = !cancel;
            e.Response.Message = message;
            //if (this.cancel)
           // {
               // GridPanel1.AddScript("alert({0});", JSON.Serialize(this.message));
            //}
        }*/
    }

    protected void Store1_BeforeDirectEvent(object sender, BeforeDirectEventArgs e)
    {
        /*string emulError = e.Parameters["EmulateError"];
        
        if (emulError == "1")
        {
            throw new Exception("Emulating error");
        }*/
    }

    protected void Store1_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store1.DataBind();
    }
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gestionar tipos de asientos</title>
</head>
<body>
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        
        <asp:SqlDataSource 
            ID="SqlDataSource1"
            runat="server" 
            ProviderName="MySql.Data.MySqlClient"
            ConnectionString="Server=localhost;Database=siscont;Uid=root;Pwd=;"
            DeleteCommand="DELETE FROM tipoasiento WHERE (Descripcion = @Descripcion AND CodEmpresa = @CodEmpresa)"
            InsertCommand="INSERT INTO tipoasiento 
                               (Descripcion,
                                Habilitado,
                                CodEmpresa) 
                            VALUES 
                                (@Descripcion,
                                 @Habilitado,
                                 @CodEmpresa)"
                            
            SelectCommand="SELECT 
                                Descripcion, 
                                Habilitado, 
                                CodEmpresa                        
                           FROM tipoasiento"
                           
            UpdateCommand="UPDATE tipoasiento SET 
                                Habilitado = @Habilitado
                           WHERE (Descripcion = @Descripcion AND CodEmpresa = @CodEmpresa)"
                           
            OnInserted="SqlDataSource1_Inserted">
            
            <DeleteParameters>
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="CodEmpresa" Type="Int32" />
            </DeleteParameters>
            
            <UpdateParameters>
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="Habilitado" Type="String" />
                <asp:Parameter Name="CodEmpresa" Type="Int32" />
            </UpdateParameters>
            
            <InsertParameters>
                <asp:Parameter Name="Descripcion" Type="String" />
                <asp:Parameter Name="Habilitado" Type="String" />
                <asp:Parameter Name="CodEmpresa" Type="Int32" />
            </InsertParameters>
        </asp:SqlDataSource>
        
        <ext:Store 
            ID="Store1" 
            runat="server" 
            DataSourceID="SqlDataSource1" 
            ShowWarningOnFailure="false"
            UseIdConfirmation="false" 
            OnRefreshData="Store1_RefershData">
            <Reader>
                <ext:JsonReader>
                    <Fields>
                        <ext:RecordField Name="Descripcion" />
                        <ext:RecordField Name="Habilitado" />
                        <ext:RecordField Name="CodEmpresa" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <Listeners>
                <LoadException Handler="Ext.Msg.alert('Suppliers - Load failed', e.message || e);" />
                <CommitFailed Handler="Ext.Msg.alert('Suppliers - Commit failed', 'Reason: ' + msg);" />
                <SaveException Handler="Ext.Msg.alert('Suppliers - Save failed', e.message || e);" />
                <CommitDone Handler="Ext.Msg.alert('Suppliers - Commit', 'The data successfully saved');" />
            </Listeners>      
        </ext:Store>
        
        <ext:Viewport ID="Viewport1" runat="server">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <North MarginsSummary="5 5 5 5">
                        <ext:Panel ID="Panel1" 
                            runat="server" 
                            Title="Description" 
                            Height="100" 
                            Padding="5"
                            Frame="true" 
                            Icon="Information">
                            <Content>
                                <b>Gestionar tipos de asientos</b>
                                <br />
                                <br />
                                Permite administrar los tipos de asientos de la empresa.
                            </Content>
                        </ext:Panel>
                    </North>
                    <Center MarginsSummary="0 5 0 5">
                        <ext:Panel ID="Panel2" runat="server" Height="300" Header="false" Layout="Fit">
                            <Items>
                                <ext:GridPanel 
                                    ID="GridPanel1" 
                                    runat="server"  
                                    Title="Tipos de asientos" 
                                    StoreID="Store1" 
                                    Border="false" 
                                    Icon="Lorry">
                                    <ColumnModel ID="ColumnModel1" runat="server" >
                                        <Columns>
                                            <ext:Column 
                                                ColumnID="Descripcion" 
                                                DataIndex="Descripcion" 
                                                Header="Descripcion"
                                                >
                                                <Editor>
                                                    <ext:TextField runat="server"></ext:TextField>
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column 
                                                DataIndex="Habilitado" 
                                                Header="Habilitado"
                                                Editable="true">
                                                <Editor>
                                                    <ext:ComboBox runat="server">
                                                        <Items>
                                                            <ext:ListItem Text="Sí" Value="true"/>
                                                            <ext:ListItem Text="No" Value="false"/>
                                                        </Items>
                                                    </ext:ComboBox>
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column 
                                                DataIndex="CodEmpresa" 
                                                Header="CodEmpresa">
                                                <Editor>
                                                    <ext:TextField ID="TextField1" runat="server"></ext:TextField>
                                                </Editor>
                                            </ext:Column>        
                                        </Columns>
                                    </ColumnModel>                                    
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                                    </SelectionModel>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar1" 
                                            runat="server" 
                                            PageSize="10" 
                                            StoreID="Store1" 
                                            DisplayInfo="false" 
                                            />
                                    </BottomBar>
                                    <SaveMask ShowMask="true" />
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                            <Buttons>
                                <ext:Button ID="btnSave" runat="server"  Text="Save" Icon="Disk">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.save();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnDelete" runat="server"  Text="Delete selected records" Icon="Delete">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.deleteSelected();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnInsert" runat="server"  Text="Insert" Icon="Add">
                                    <Listeners>
                                        <Click Handler="#{GridPanel1}.insertRecord(0, {});#{GridPanel1}.getView().focusRow(0);#{GridPanel1}.startEditing(0, 0);" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnRefresh" runat="server"  Text="Refresh" Icon="ArrowRefresh">
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
</body>
</html>