<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ControlChildAbm.ascx.cs" Inherits="IU.Generico.ControlChildAbm" %>

<%-- Version 2011.11.26 --%>

<%@ Import Namespace="MySql.Data" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">   
    protected void Store1_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.Store1.DataBind();
    }

</script>

<ext:Store 
    ID="Store1" 
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
        <LoadException Handler="Ext.Msg.alert('Load failed', e.message || e);" />
        <CommitFailed Handler="Ext.Msg.alert('Commit failed', 'Reason: ' + msg);" />
        <SaveException Handler="Ext.Msg.alert('Save failed', e.message || e);" />
    </Listeners>      
</ext:Store>

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
                >
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true" >
                            <DirectEvents>
                                <RowSelect OnEvent="OnRowSelect_Event">
                                    <ExtraParams>
                                        <ext:Parameter Name="Values" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                                    </ExtraParams>
                                </RowSelect>
                            </DirectEvents>
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
                        <Click OnEvent="btnDelete_OnClick">
                            <ExtraParams>
                                <ext:Parameter Name="Values" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly:true}))" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnRefresh" runat="server"  Text="Actualizar" Icon="ArrowRefresh">
                    <Listeners>
                        <Click Handler="#{GridPanel1}.store.reload();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Panel>
    </Center>             
</ext:BorderLayout>

<asp:SqlDataSource 
ID="SqlDataSource1" 
runat="server"
>
</asp:SqlDataSource>
