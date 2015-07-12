<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarCliente.aspx.cs" Inherits="IU.VentasCuentasCobrar.Clientes.SeleccionarCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
        <ext:Store 
        ID="StoreComboCli" 
        runat="server" 
        >
            <Reader>
                <ext:ArrayReader>
                    <Fields>
                        <ext:RecordField Name="id" Type="Int"/>
                        <ext:RecordField Name="razonsocial" Type="String"/>
                    </Fields>
                </ext:ArrayReader>
            </Reader>          
        </ext:Store>   
    
        <ext:FormPanel 
        ID="FormPanel2" 
        runat="server" 
        Padding="5" 
        Width="320"
        Title="Clientes"
        >
        <Items>
            <ext:ComboBox
                Editable="false"
                ID="ComboBoxClientes"
                EmptyText="Seleccione un cliente..." 
                Mode="Local"
                StoreID="StoreComboCli"
                runat="server"
                FieldLabel="Cliente" 
                TriggerAction="All"            
                DisplayField="razonsocial"
                ValueField="id"
                AnchorHorizontal="90%"
            >
            </ext:ComboBox>
        </Items>
        <Buttons>
            <ext:Button ID="BotonNext" runat="server" Text="Siguiente">
                <DirectEvents>
                    <Click OnEvent="BotonNext_Click">
                        <EventMask Msg="Procesando..." MinDelay="500"/>
                    </Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
        </ext:FormPanel>
    </div>
    </form>
</body>
</html>
