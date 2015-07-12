<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ComboClases.ascx.cs" Inherits="IU.Generico.ComboClases" %>

<%@ Import Namespace="MySql.Data" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<script runat="server">
  
    protected void StoreCombo_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.StoreCombo.DataBind();
    }
        
</script>

<div>
<ext:Store 
    ID="StoreCombo" 
    runat="server"
    DataSourceId="SqlDataSource1"
    ShowWarningOnFailure="false"
    UseIdConfirmation="false" 
    OnRefreshData="StoreCombo_RefershData"
>
    <Reader>
        <ext:JsonReader>
        </ext:JsonReader>
    </Reader>
</ext:Store>

<ext:ComboBox
    Editable="false"
    ID="ComboBoxObjetos"
    Mode="Local"
    StoreID="StoreCombo"
    runat="server"
    FieldLabel="Tipo" 
    TriggerAction="All"            
    AnchorHorizontal="90%">
</ext:ComboBox>

<asp:SqlDataSource 
ID="SqlDataSource1" 
runat="server"
>
</asp:SqlDataSource>

 
</div>