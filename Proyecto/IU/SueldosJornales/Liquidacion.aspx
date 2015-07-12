<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Liquidacion.aspx.cs" Inherits="IU.SueldosJornales.Liquidacion" %>

<%@ Register src="../Generico/ControlChildAbm.ascx" tagname="ControlChildAbm" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Liquidaciones de Sueldos</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="Anchor">
    <Items>
        <ext:Panel 
        Collapsible="true"
        ID="Panel1" 
        runat="server" 
        Title="Liquidaciones"
        AnchorVertical="50%" 
        AnchorHorizontal="right">
        <Content>
        <uc1:ControlChildAbm ID="ControlAbm1" runat="server" />
        </Content>
        </ext:Panel>
        <ext:Panel 
        Collapsible="true"
        ID="Panel2" 
        Title="Conceptos"
        runat="server" 
        AnchorVertical="50%" 
        AnchorHorizontal="right">
            <Content>
        <uc1:ControlChildAbm ID="ControlAbm2" runat="server" />
        </Content>
        </ext:Panel>
        <ext:Panel 
        Collapsible="true"
        ID="Panel3" 
        Title="Sueldos"
        runat="server" 
        AnchorVertical="50%" 
        AnchorHorizontal="right">
            <Content>
        <uc1:ControlChildAbm ID="ControlAbm3" runat="server" />
            </Content>
        </ext:Panel>
    </Items>
    </ext:Viewport>
    </div>
    </form>
</body>
</html>
