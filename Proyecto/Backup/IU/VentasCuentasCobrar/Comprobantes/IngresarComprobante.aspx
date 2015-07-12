<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresarComprobante.aspx.cs" Inherits="IU.VentasCuentasCobrar.Comprobantes.IngresarComprobante" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="../../Generico/ComboClases.ascx" tagname="ComboClases" tagprefix="americo" %>

<script runat="server">
    protected void StoreItems_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.CargarDatosEnGrid();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <ext:Store ID="StoreComboCliente" runat="server">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="id" Type="Auto"/>
                    <ext:RecordField Name="nombre" Type="String"/>
                </Fields>
            </ext:ArrayReader>
        </Reader>          
    </ext:Store>   
    
     <ext:Store 
        ID="StoreItems" 
        runat="server"
        ShowWarningOnFailure="false"
        UseIdConfirmation="false" 
        OnRefreshData="StoreItems_RefershData"
        >
        <Reader>
            <ext:JsonReader>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    
    <ext:Viewport ID="Viewport1" runat="server">
        <Items>
            <ext:RowLayout ID="RowLayout1" runat="server" Split="false">
                <Rows>
                     <%-- Panel superior --%>
                    <ext:LayoutRow RowHeight="0.25">
                        <ext:Panel ID="Panel1" runat="server" Title="" >
                        <Items>
                            <%-- Panel --%>
                            <ext:FormPanel 
                                ID="FormPanel1" 
                                runat="server" 
                                Title=""
                                MonitorPoll="500" 
                                MonitorValid="true" 
                                Padding="5" 
                                AutoWidth="true"
                                AutoHeight="true"
                                ButtonAlign="Right"
                                Border="false"
                                Layout="Column">
                                <Items>
                                    <%-- Columna izquierda --%>
                                    <ext:Panel ID="Panel12" 
                                        runat="server" 
                                        Border="false" 
                                        Layout="Form" 
                                        ColumnWidth=".4" 
                                        LabelAlign="Left">
                                        <Defaults>
                                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                            <ext:Parameter Name="MsgTarget" Value="side" />
                                        </Defaults>
                                        <Items>
                                            <%-- Fecha --%>
                                            <ext:DateField  
                                                ID="DateFieldFecha"
                                                runat="server" 
                                                FieldLabel="Fecha" 
                                                Format="dd/MM/yyyy"
                                                AnchorHorizontal="90%" >
                                            </ext:DateField>
                                            
                                            <%-- Cliente --%>
                                            <ext:Panel ID="Panel13" runat="server" Border="false" AnchorHorizontal="90%" Layout="Fit">
                                            <Content>
                                            
                                                <americo:ComboClases 
                                                    ID="ComboClasesCliente" runat="server" 
                                                    TextoVacio="Seleccione un cliente" 
                                                    Texto="Cliente" 
                                                    AtributoValor="Codcliente" 
                                                    AtributoDisplay="Razonsocial" 
                                                    />
                                            </Content>
                                            </ext:Panel>
                                            
                                            <%-- Moneda --%>
                                            <ext:Panel runat="server" Border="false" AnchorHorizontal="90%" Layout="Fit">
                                            <Content>
                                                <americo:ComboClases 
                                                    ID="ComboMonedas" runat="server" 
                                                    TextoVacio="Seleccione una moneda" 
                                                    Texto="Moneda" 
                                                    AtributoValor="Idmoneda" 
                                                    AtributoDisplay="Moneda" 
                                                    />
                                            </Content>
                                            </ext:Panel>
                                        </Items>
                                    </ext:Panel>
                                
                                    <%-- Columna derecha --%>
                                    <ext:Panel ID="Panel11" 
                                        runat="server" 
                                        Border="false" 
                                        Header="false" 
                                        ColumnWidth=".4" 
                                        Layout="Form" 
                                        Width="400"
                                        Height="400"
                                        LabelAlign="Left">
                                        <Defaults>
                                            <ext:Parameter Name="MsgTarget" Value="side" />
                                        </Defaults>
                                        <Items>
                                            <%-- Comprobante --%>
                                            <ext:Panel 
                                                runat="server"
                                                AnchorHorizontal="90%"
                                                FieldLabel="Comprobante"
                                                Height="24"
                                                Border="false"
                                            >
                                            <Items>
                                            <ext:ColumnLayout 
                                                runat="server">
                                                <Columns>
                                                    <%-- Tipo de comprobante --%>
                                                    <ext:LayoutColumn ColumnWidth="0.5">
                                                        <ext:TextField 
                                                            ID="TextFieldNum" 
                                                            runat="server" 
                                                            AllowBlank="true"
                                                            >
                                                        </ext:TextField>
                                                    </ext:LayoutColumn>
                                                    
                                                    <%-- Letra --%>
                                                    <ext:LayoutColumn ColumnWidth="0.2">
                                                        <ext:TextField 
                                                            ID="TextField6" 
                                                            runat="server" 
                                                            AllowBlank="true"
                                                            >
                                                        </ext:TextField>
                                                    </ext:LayoutColumn>
                                                    
                                                    <%-- Número --%>
                                                    <ext:LayoutColumn ColumnWidth="0.3">
                                                        <ext:TextField 
                                                            ID="TextField7" 
                                                            runat="server" 
                                                            AllowBlank="true" 
                                                            >
                                                            
                                                           
                                                        </ext:TextField>
                                                    </ext:LayoutColumn>
                                                </Columns>
                                            </ext:ColumnLayout>
                                            </Items>
                                            </ext:Panel>
                                                
                                            <%-- Concepto --%>
                                            <ext:TextField ID="TextFieldConcepto" runat="server" 
                                                FieldLabel="Concepto" 
                                                AllowBlank="false"
                                                AnchorHorizontal="90%" />
                                       
                                        </Items>
                                    </ext:Panel>
                                    
                                    <ext:Panel ID="Panel22" 
                                        runat="server" 
                                        Border="false" 
                                        Header="false" 
                                        Layout="Row" 
                                        Width="80"
                                        LabelAlign="Left">
                                        <Items>
                                            <ext:Button ID="ButtonAceptar" runat="server" Text="Aceptar">
                                                <DirectEvents>
                                                    <Click OnEvent="BotonAceptar_Click">
                                                        <EventMask Msg="Cargando..." ShowMask="true" MinDelay="500" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Panel Height="4" runat="server" Border="false"></ext:Panel>
                                            
                                            <ext:Button ID="ButtonCancelar" runat="server" Text="Cancelar">
                                                <DirectEvents>
                                                    <Click OnEvent="BotonCancelar_Click">
                                                        <EventMask Msg="Cargando..." ShowMask="true" MinDelay="500" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Panel ID="Panel23" Height="4" runat="server" Border="false"></ext:Panel>
                                            
                                            <ext:Button ID="ButtonCerrar" runat="server" Text="Cerrar">
                                                <DirectEvents>
                                                    <Click OnEvent="BotonCerrar_Click">
                                                        <EventMask Msg="Cerrando..." ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                        </Items>
                                    </ext:Panel>
                                </Items>
                            </ext:FormPanel>
                        </Items>
                        </ext:Panel>
                    </ext:LayoutRow>
                    
                    <%-- Panel central --%>
                    <ext:LayoutRow RowHeight="0.60">
                        <ext:Panel ID="Panel2" runat="server" Title="" Layout="Fit">
                        <Items>
                            <ext:TabPanel ID="TabPanel1" runat="server">   
                                <Items>
                                    <%-- Datos generales --%>
                                    <ext:Panel ID="Tab1" runat="server" 
                                        Title="Datos generales" 
                                        AutoScroll="true"
                                        Layout="Form"
                                        Padding="5">
                                        <Items>
                                            <%-- Tipo de lista --%>
                                            <ext:Panel 
                                                ID="PanelTipoLista" 
                                                runat="server" 
                                                Border="false" 
                                                AnchorHorizontal="90%" 
                                                Layout="Fit">
                                                <Content>
                                                    <americo:ComboClases 
                                                        ID="ComboTipoLista" runat="server" 
                                                        TextoVacio="Seleccione un tipo de lista" 
                                                        Texto="Tipo de lista" 
                                                        AtributoValor="Idtipolista" 
                                                        AtributoDisplay="Descrip" 
                                                        />
                                                </Content>
                                            </ext:Panel>
                                            
                                            <%-- Condición de venta --%>
                                            <ext:Panel 
                                            
                                                ID="Panel21" 
                                                runat="server" Border="false" 
                                                AnchorHorizontal="100%" 
                                                FieldLabel="Condición de venta"
                                                >
                                               
                                            <Items>
                                                <%-- Condición de venta --%>
                                                <ext:Panel ID="Panel24" runat="server" Border="false" Layout="Fit" ColumnWidth="0.8">
                                                <Content>                                               
                                                    <americo:ComboClases 
                                                        ID="ComboClasesCondicionVenta" runat="server" 
                                                        TextoVacio="Seleccione una condición" 
                                                        Texto="" 
                                                        AtributoValor="Iddescuentoscomerciales" 
                                                        AtributoDisplay="Descripcion" 
                                                        />
                                                </Content>
                                                </ext:Panel>
                                                
                                                <%-- Otros datos --%>
                                            </Items>
											</ext:Panel>
											
                                            <%-- Descuento comercial --%>
                                            <ext:Panel ID="Panel17" runat="server" Border="false" AnchorHorizontal="100%" Layout="Column">
                                            <Items>
                                                <ext:Checkbox ID="Checkbox2" runat="server" 
                                                    ColumnWidth="0.2" Enabled="false"
                                                    FieldLabel="Descuento comercial">
                                                </ext:Checkbox>
                                                <ext:Panel ID="Panel20" runat="server" Border="false" Layout="Fit" ColumnWidth="0.8">
                                                <Content>                                               
                                                    <americo:ComboClases 
                                                        ID="ComboClases1" runat="server" 
                                                        TextoVacio="Seleccione un descuento" 
                                                        Texto="" 
                                                        AtributoValor="Iddescuentoscomerciales" 
                                                        AtributoDisplay="Descripcion" 
                                                        />
                                                </Content>
                                                </ext:Panel>
                                            </Items>
											</ext:Panel>
                                            <%-- Descuento financiero --%>
                                            <ext:Panel ID="Panel19" runat="server" Border="false" AnchorHorizontal="100%" Layout="Column">
                                            <Items>
                                                <ext:Checkbox ID="Checkbox1" runat="server" 
                                                    ColumnWidth="0.2" Enabled="false"
                                                    FieldLabel="Descuento financiero">
                                                </ext:Checkbox>
                                                <ext:Panel ID="Panel18" runat="server" Border="false" Layout="Fit" ColumnWidth="0.8">
                                                <Content>                                               
                                                    <americo:ComboClases 
                                                        ID="ComboClases2" runat="server" 
                                                        TextoVacio="Seleccione un descuento" 
                                                        Texto="" 
                                                        AtributoValor="Iddescuentosfinancieros" 
                                                        AtributoDisplay="Descripcion" 
                                                        />
                                                </Content>
                                                </ext:Panel>
                                            </Items>
                                            </ext:Panel>
                                            <%-- Fecha entrega --%>
                                            <ext:DateField  
                                                ID="DateFieldFechaEntrega"
                                                runat="server" 
                                                FieldLabel="Fecha entrega" 
                                                Format="dd/MM/yyyy"
                                                AnchorHorizontal="90%" >
                                            </ext:DateField>
                                            
                                            <%-- Fecha probable emisión --%>
                                            <ext:DateField  
                                                ID="DateFieldFechaProbableEmision"
                                                runat="server" 
                                                FieldLabel="Fecha emisión (probable)" 
                                                Format="dd/MM/yyyy"
                                                AnchorHorizontal="90%" >
                                            </ext:DateField>
                                            
                                            <%-- Lote --%>
                                            <ext:NumberField
                                                ID="NumberFieldLote"
                                                runat="server"
                                                FieldLabel="Lote"
                                                AnchorHorizontal="%90"
                                                 MaskRe="[0-9]"
                                                >
                                            </ext:NumberField>
                                            
                                            <%-- Mensaje --%>
                                            <ext:TextField
                                                ID="TextFieldMensaje"
                                                AnchorHorizontal="%90"
                                                runat="server"
                                                FieldLabel="Mensaje"
                                                >
                                            </ext:TextField>
                                            
                                            <%-- Número de remito --%>
                                            <ext:NumberField 
                                                runat="server" 
                                                FieldLabel="N° Remito">
                                            </ext:NumberField>
                                            
                                            <%-- Contrato --%>
                                        </Items>
                                    </ext:Panel>
                                    
                                    <%-- Datos generales impositivos --%>
                                    <ext:Panel ID="Tab2" runat="server" 
                                        Title="Datos generales impositivos" 
                                        AutoScroll="true"
                                        Padding="5" 
                                        Layout="Form">
                                        <Items>
<%--                                             Punto de registración
                                            <ext:Panel 
                                                ID="Panel14" 
                                                runat="server" 
                                                Border="false" 
                                                AnchorHorizontal="90%" 
                                                Layout="Fit">
                                                <Content>
                                                    <americo:ComboClases 
                                                        ID="ComboClasesPunto" runat="server" 
                                                        TextoVacio="Seleccione una punto" 
                                                        Texto="Punto de registración" 
                                                        AtributoValor="Codigopuntoregistracion" 
                                                        AtributoDisplay="Descripcion" 
                                                        />
                                                </Content>
                                            </ext:Panel>--%>
                                            
                                            <%-- Fecha de contabilización --%>
                                            <ext:DateField  
                                                ID="DateField1"
                                                runat="server" 
                                                FieldLabel="Fecha de contabilización" 
                                                Format="dd/MM/yyyy"
                                                AnchorHorizontal="30%" >
                                            </ext:DateField>
                                                
                                            <%-- Fecha de declaración jurada --%>
                                            <ext:DateField  
                                                ID="DateField2"
                                                runat="server" 
                                                FieldLabel="Fecha de declaración jurada" 
                                                Format="MM/yyyy"
                                                AnchorHorizontal="30%" >
                                            </ext:DateField>
                                            
                                            <%-- Provincia --%>
                                            <ext:Panel 
                                                ID="Panel15" 
                                                runat="server" 
                                                Border="false" 
                                                AnchorHorizontal="90%" 
                                                Layout="Fit">
                                                <Content>
                                                    <americo:ComboClases 
                                                        ID="ComboClasesProvincia" runat="server" 
                                                        TextoVacio="Seleccione una provincia" 
                                                        Texto="Provincia" 
                                                        AtributoValor="Codprov" 
                                                        AtributoDisplay="Descripcion" 
                                                        />
                                                </Content>
                                            </ext:Panel>
                                                
                                            <%-- Bien de uso --%>
                                            <ext:Checkbox
                                                runat="server"
                                                FieldLabel="Bien de uso"
                                                ID="CheckBoxBienDeUso"
                                                >
                                            </ext:Checkbox>
                                            
                                            <%-- Tipo de operación --%>
                                            <ext:Panel 
                                                ID="Panel16" 
                                                runat="server" 
                                                Border="false" 
                                                AnchorHorizontal="90%" 
                                                Layout="Fit">
                                                <Content>
                                                    <americo:ComboClases 
                                                        ID="ComboClasesTipoOperacion" runat="server" 
                                                        TextoVacio="" 
                                                        Texto="Tipo de operación" 
                                                        AtributoValor="" 
                                                        AtributoDisplay="" 
                                                        Enabled="false"
                                                        />
                                                </Content>
                                            </ext:Panel>
                                        </Items>
                                    </ext:Panel>
                                    
                                    <%-- Items --%>
                                    <ext:Panel ID="Tab3" 
                                        runat="server" 
                                        Title="Detalle de items" 
                                        Layout="form"
                                        Height="1000"
                                        Padding="5">
                                        <Items>
                                            <ext:RowLayout runat="server" Split="true">
                                                <Rows>
                                                    <%-- Detalle --%>
                                                    <ext:LayoutRow RowHeight="0.4">
                                                    <ext:Panel runat="server">
                                                     <Content >
                                                     <asp:Label Text="ANDA" runat="server">
                                                     </asp:Label>
                                                     </Content>
                                                    </ext:Panel>
                                                    </ext:LayoutRow>
                                                    
                                                    <%-- Items --%>
                                                    
                                                    <ext:LayoutRow RowHeight="0.6">
                                                        <%-- Panel de items --%>
                                                        <ext:Panel 
                                                        Collapsible="false"
                                                        ID="PanelItems" 
                                                        Title=""
                                                        runat="server" 
                                                        AutoWidth="true"
                                                        Border="true"
                                                        AnchorHorizontal="right"
                                                        AutoScroll="true"
                                                        >
                                                            <Items>
                                                                <ext:GridPanel 
                                                                ID="GridPanelItems" 
                                                                runat="server" 
                                                                AutoHeight="true"
                                                                StoreID="StoreItems"
                                                                Border="false" 
                                                                >
                                                                    <ColumnModel ID="ColumnModel1" runat="server">
                                                                        <Columns>                                                               
                                                                        </Columns>
                                                                    </ColumnModel>
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
                                                                    <Buttons>
                                                                        <ext:Button runat="server" Text="Agregar" Icon="Add">
                                                                            <DirectEvents>
                                                                                <Click OnEvent="BotonAgregar_Click" Before="#{FormPanelMov}.getForm().reset();">
                                                                                    <EventMask ShowMask="true" Msg="Cargando..." />
                                                                                </Click>
                                                                            </DirectEvents>
                                                                        </ext:Button>
                                                                        <ext:Button ID="BotonModificar" runat="server" Text="Modificar" Icon="TableEdit">
                                                                            <DirectEvents>
                                                                                <Click OnEvent="BotonModificar_Click">
                                                                                    <EventMask ShowMask="true" Msg="Cargando..." />
                                                                                </Click>
                                                                            </DirectEvents>
                                                                        </ext:Button>
                                                                        <ext:Button runat="server" Text="Quitar" Icon="Delete">
                                                                            <DirectEvents>
                                                                                <Click OnEvent="BotonQuitar_Click">
                                                                                    <EventMask ShowMask="true" Msg="Cargando..." />
                                                                                </Click>
                                                                            </DirectEvents>
                                                                        </ext:Button>
                                                                    </Buttons>
                                                                    <LoadMask ShowMask="true" />
                                                                </ext:GridPanel>                        
                                                            </Items>
                                                        </ext:Panel>
                                                        <%-- Fin del panel de items --%>
                                                    </ext:LayoutRow>
                                                </Rows>
                                            </ext:RowLayout>
                                        
                                        </Items>
                                        
                                    </ext:Panel>
                                </Items>                            
                            </ext:TabPanel>
                        </Items>
                        </ext:Panel>
                    </ext:LayoutRow>
                    
                    <%-- Panel inferior --%>
                    <ext:LayoutRow RowHeight="0.15">
                        <ext:Panel ID="Panel3" runat="server" Title="" >
                        <Items>
                            <ext:ColumnLayout ID="ColumnLayout1" runat="server" Split="false" FitHeight="true">
                                <Columns>
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel4" runat="server" Title="Neto">
                                            <Items>
                                                <ext:TextField ID="TotalNeto" runat="server" ReadOnly="true">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel5" runat="server" Title="No gravado">
                                            <Items>
                                                <ext:TextField ID="TextField1" runat="server" ReadOnly="true">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                        
                                    </ext:LayoutColumn>
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel7" runat="server" Title="IVA Inscripto">
                                            <Items>
                                                <ext:TextField ID="TextField2" runat="server" ReadOnly="true">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel8" runat="server" Title="IVA No inscripto">
                                            <Items>
                                                <ext:TextField ID="TextField3" runat="server" ReadOnly="true">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel9" runat="server" Title="Otros">
                                            <Items>
                                                <ext:TextField ID="TextField4" runat="server" ReadOnly="true">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                    
                                    <ext:LayoutColumn ColumnWidth="0.14">
                                        <ext:Panel ID="Panel10" runat="server" Title="Total">
                                            <Items>
                                                <ext:TextField ID="TextField5" runat="server" ReadOnly="true">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                                    
                                    <ext:LayoutColumn ColumnWidth="0.26">
                                        <ext:Panel 
                                            ID="Panel6" 
                                            runat="server" 
                                            Title="" 
                                            Border="false" 
                                            Layout="HBoxLayout">
                                            <LayoutConfig>
                                                <ext:HBoxLayoutConfig Padding="5" Align="Middle" Pack="Center" />
                                            </LayoutConfig>
                                            <Items>  
                                                <ext:Button ID="BotonRegimenEsp" Text="Regímenes Especiales" Enabled="false" runat="server">
                                                </ext:Button>
                                            </Items>
                                        </ext:Panel>
                                    </ext:LayoutColumn>
                                </Columns>
                            </ext:ColumnLayout>
                        </Items>
                        </ext:Panel>
                    </ext:LayoutRow>
                </Rows>
            </ext:RowLayout>
        </Items>
    </ext:Viewport>
    
    
    <%-- Ventana de ingreso de items --%>
    <ext:Window 
        ID="VentanaMov" 
        runat="server" 
        Title="Item"  
        Icon="Application"
        AutoHeight="true" 
        Width="350px"
        BodyStyle="background-color: #fff;" 
        Padding="5"
        Closable="false"
        Collapsible="false" 
        Hidden="true"
        Modal="true">
        <Items>
            <ext:FormPanel ID="FormPanelMov" 
                runat="server" 
                Border="false" 
                Header="false" 
                LabelAlign="Left">
                <Defaults>
                    <ext:Parameter Name="Editable" Value="true" />
                    <ext:Parameter Name="MsgTarget" Value="side" />
                </Defaults>
                <Items>
                    <ext:NumberField
                        runat="server"
                        AllowBlank="false"
                        AllowNegative="false"
                        ID="NumberFieldCantidad"
                        FieldLabel="Cantidad"
                        AnchorHorizontal="90%" MaskRe="[0-9]"
                    >                    
                    </ext:NumberField>
                  
                </Items>
            </ext:FormPanel>
        </Items>
        <Buttons>
            <ext:Button ID="BotonAceptar"
                Text="Aceptar"
                runat="server">
                <DirectEvents>
                    <Click OnEvent="Window1_BotonAceptar_Click">
                        <ExtraParams>
                            <ext:Parameter Name="values" Value="#{FormPanelMov}.getForm().getValues()" Mode="Raw" Encode="true" />
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="BotonCancelar" 
                Text="Cancelar"
                runat="server">
                <DirectEvents>
                    <Click OnEvent="Window1_BotonCancelar_Click" Before="#{FormPanelMov}.getForm().reset();"></Click>
                </DirectEvents>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <%-- Fin de ventana --%>
</body>
</html>
