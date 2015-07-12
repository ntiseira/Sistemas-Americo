<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gestionar.aspx.cs" Inherits="IU.Contabilidad.PlanCuentas.Gestionar" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>
<%@ Register src="../../Generico/ControlChildAbm.ascx" tagname="ControlChildAbm" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
    <ext:Viewport ID="Viewport1" runat="server" Layout="Anchor">
    <Items>
        <ext:Panel 
        Collapsible="true"
        ID="Panel1" 
        runat="server" 
        Title="Plan de cuentas"
        AnchorVertical="60%" 
        AnchorHorizontal="right">
            <Content>
                <uc2:ControlChildAbm ID="ControlAbm1" runat="server" />
            </Content>
        </ext:Panel>
        <ext:Panel 
        Collapsible="true"
        ID="Panel2" 
        Title="Jerarquía"
        runat="server" 
        AnchorVertical="40%" 
        AnchorHorizontal="right">
            <Content>
                <uc2:ControlChildAbm ID="ControlAbm2" runat="server" />
            </Content>
        </ext:Panel>
    </Items>
    </ext:Viewport>
</body>
</html>
