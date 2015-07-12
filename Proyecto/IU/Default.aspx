<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IU.WebFormLogin" %>

<%@ Import Namespace="System.Threading" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Acceso a Sistemas Américo</title>
    <link href="../../../../resources/css/examples.css" rel="stylesheet" type="text/css" />
    
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder1" runat="server" Mode="Script" /> 
    
    <script src="js/util.js" type="text/javascript"></script>
</head>
<body style=" background-image:url(WallpapperLoginPaso2.jpg);">
    <form id="Form1" runat="server">
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
            
        <h1>Acceso a Sistemas Américo</h1>
                      
        <ext:Window 
            ID="Window1" 
            runat="server" 
            Closable="false"
            Resizable="false"
            Height="150" 
            Icon="Lock" 
            Title="Acceso"
            Draggable="false"
            Width="350"
            Modal="true"
            Padding="5"
            Layout="Form">
            <Items>
                <ext:TextField 
                    ID="txtUsername" 
                    runat="server" 
                    FieldLabel="Usuario" 
                    AllowBlank="false"
                    BlankText="Nombre de usuario requerido."
                    Text=""
                    AnchorHorizontal="100%"
                    />
                <ext:TextField 
                    ID="txtPassword" 
                    runat="server" 
                    InputType="Password" 
                    FieldLabel="Contaseña" 
                    AllowBlank="false" 
                    BlankText="Contaseña requerida."
                    Text=""
                    AnchorHorizontal="100%"
                    />
            </Items>
            <Buttons>
                <ext:Button ID="btnLogin" runat="server" Text="Ingresar" Icon="Accept">
                    <Listeners>
                        <Click Handler="
                            if (!#{txtUsername}.validate() || !#{txtPassword}.validate()) {
                                Ext.Msg.alert('Error','Los campos son requeridos.');
                                // return false to prevent the btnLogin_Click Ajax Click event from firing.
                                return false; 
                            }" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLogin_Click">
                            <EventMask ShowMask="true" Msg="Verificando..." MinDelay="500" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCancel" runat="server" Text="Cancelar" Icon="Decline">
                    <DirectEvents>
                        <Click OnEvent="btnCancel_Click">
                            <EventMask ShowMask="true" Msg="Saliendo..." MinDelay="500" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
