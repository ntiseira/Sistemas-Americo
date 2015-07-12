<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asiento.aspx.cs" Inherits="IU.Contabilidad.Asiento.Asiento" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void Store1_RefershData(object sender, StoreRefreshDataEventArgs e)
    {
        this.CargarDatosEnGrid();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Asiento</title>
    
    <style type="text/css">
        .total-field {
            background-color : #fff;
            font-weight      : bold !important;
            color            : #000;
            border           : solid 1px silver;
            padding          : 2px;
            margin-right     : 5px;
        }
    </style>
</head>
<body>
    <ext:ResourceManager ID="ResourceManager1" runat="server"></ext:ResourceManager>
    
    <ext:Store 
        ID="StoreCombo" 
        runat="server" 
        >
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="id" Type="String"/>
                </Fields>
            </ext:ArrayReader>
        </Reader>          
    </ext:Store>   
        
    <ext:Store 
        ID="StoreComboMov" 
        runat="server" 
        >
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="id" Type="String"/>
                </Fields>
            </ext:ArrayReader>
        </Reader>          
    </ext:Store>   
    
    <ext:Store 
        ID="Store1" 
        runat="server"
        ShowWarningOnFailure="false"
        UseIdConfirmation="false" 
        OnRefreshData="Store1_RefershData"
    >
        <Reader>
            <ext:JsonReader>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    
    <ext:Viewport ID="Viewport1" runat="server" Layout="Anchor">
    <Items>
        <ext:Panel 
        Collapsible="true"
        ID="Panel1" 
        runat="server" 
        Title="Asiento"
        Layout="Fit"
        AnchorHorizontal="right"
        >
        <Items>
            <ext:Panel 
            ID="Panel3"
            runat="server" 
            Border="false" 
            Header="false" 
            AutoWidth="true"
            AutoHeight="true"
            >
                <Items>
                    <ext:FormPanel 
                        ID="FormPanel1" 
                        runat="server" 
                        Title=""
                        MonitorPoll="500" 
                        MonitorValid="true" 
                        Padding="5" 
                        AutoWidth="true"
                        Height="140"
                        ButtonAlign="Right"
                        Border="false"
                        Layout="Column">
                        <Items>
                            <ext:Panel ID="Panel4" 
                                runat="server" 
                                Border="false" 
                                Header="false" 
                                ColumnWidth=".5" 
                                Layout="Form" 
                                LabelAlign="Left">
                                <Defaults>
                                    <ext:Parameter Name="MsgTarget" Value="side" />
                                </Defaults>
                                <Items>
                                    <ext:TextField 
                                        ID="TextFieldNum" 
                                        runat="server" 
                                        ReadOnly="true"
                                        AllowBlank="true"
                                        FieldLabel="Número" 
                                        AnchorHorizontal="90%" />
                                        
                                    <ext:TextField ID="TextFieldNombre" runat="server" 
                                        FieldLabel="Concepto" 
                                        AllowBlank="false"
                                        AnchorHorizontal="90%" />
                                        
                                    <ext:Checkbox
                                        runat="server"
                                        FieldLabel="Editable"
                                        ID="CheckBoxEditable"
                                        >
                                    </ext:Checkbox>
                                        
                                    <ext:Label ID="LabelTotales" runat="server"
                                        Text=""
                                        >
                                    </ext:Label>
                                </Items>
                            </ext:Panel>
                            <ext:Panel ID="Panel5" 
                                runat="server" 
                                Border="false" 
                                Layout="Form" 
                                ColumnWidth=".5" 
                                LabelAlign="Left">
                                <Defaults>
                                    <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                                    <ext:Parameter Name="MsgTarget" Value="side" />
                                </Defaults>
                                <Items>
                                    <ext:DateField  
                                        ID="DateFieldAsiento"
                                        runat="server" 
                                        FieldLabel="Fecha" 
                                        Format="dd/MM/yyyy"
                                        AnchorHorizontal="90%" >
                                    </ext:DateField>
                                    
                                    <ext:ComboBox
                                        Editable="false"
                                        ID="ComboTipoAsiento"
                                        EmptyText="Seleccione un tipo de asiento..." 
                                        Mode="Local"
                                        StoreID="StoreCombo"
                                        runat="server"
                                        FieldLabel="Tipo" 
                                        TriggerAction="All"            
                                        DisplayField="id"
                                        ValueField="id"
                                        AnchorHorizontal="90%">
                                    </ext:ComboBox>
                                    
                                    <ext:Checkbox
                                        runat="server"
                                        FieldLabel="Habilitado"
                                        ID="CheckBoxHabilitado"
                                        >
                                    </ext:Checkbox>
                                </Items>
                            </ext:Panel>
                        </Items>
                        <Buttons>
                            <ext:Button 
                                ID="BotonNuevo" 
                                runat="server" 
                                Text="Nuevo" 
                                Enabled="false">
                                <DirectEvents>
                                    <Click OnEvent="BotonLimpiar_Click">
                                        <EventMask Msg="Cargando..." ShowMask="true" MinDelay="500" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button 
                                ID="BotonConfirmar" 
                                runat="server" 
                                Text="Aceptar" 
                                Enabled="false">
                                <DirectEvents>
                                    <Click OnEvent="BotonConfirmar_Click">
                                        <EventMask Msg="Confirmando..." ShowMask="true" MinDelay="500" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button 
                                ID="Button1" 
                                runat="server" 
                                Text="Limpiar" 
                                Visible="false"
                                Enabled="false">
                                <DirectEvents>
                                    <Click OnEvent="BotonLimpiar_Click">
                                        <EventMask Msg="Limpiando campos..." ShowMask="true" MinDelay="500" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Buttons>
                        <Listeners>
                            <ClientValidation Handler="if(valid){#{BotonConfirmar}.enable();}else{#{BotonConfirmar}.disable();}" />
                        </Listeners>
                    </ext:FormPanel>  
                    
                    <ext:Label 
                    ID="LabelPaso1"
                    Text=""
                    runat="server">
                    </ext:Label>  
                </Items>
            </ext:Panel>
        </Items>
        </ext:Panel>
        
        <ext:Panel 
        Collapsible="false"
        ID="Panel2" 
        Title="Movimientos"
        runat="server" 
        AutoWidth="true"
        Border="false"
        AutoHeight="true"
        AnchorHorizontal="right"
        >
        <Items>
            <ext:GridPanel 
            ID="GridPanel1" 
            runat="server" 
            AutoHeight="true"
            StoreID="Store1"
            Border="false" 
            >
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn />
                        <ext:Column ColumnID="Cuenta" Header="Cuenta" DataIndex="Cuenta" Editable="true">
                        </ext:Column>
                        <ext:Column 
                            Header="Descripción" 
                            DataIndex="Descripcion" 
                            Editable="true" 
                            Width="150">
                        </ext:Column>
                        <ext:Column Header="Debe" DataIndex="Debe" Editable="true">
                            <Renderer Format="UsMoney"/>
                        </ext:Column>
                        <ext:Column Header="Haber" DataIndex="Haber" Editable="true">
                            <Renderer Format="UsMoney"/>
                        </ext:Column>
                        <ext:Column 
                            Header="Leyenda" 
                            DataIndex="Leyenda" 
                            Editable="true"
                            Width="150">
                        </ext:Column>
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
                <Listeners>
                    <ColumnResize Handler="updateTotal(this);" />
                    <AfterRender Handler="updateTotal(this);" Delay="100" />
                </Listeners>
                <BottomBar>
                    <ext:PagingToolbar ID="PagingToolbar1" 
                        runat="server" 
                        PageSize="15" 
                        StoreID="Store1" 
                        DisplayInfo="false" 
                       >
                    </ext:PagingToolbar>
                    
                </BottomBar>
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
    </Items>
    </ext:Viewport>
    
    
    <ext:Window 
            ID="VentanaMov" 
            runat="server" 
            Title="Movimiento"  
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
                        <ext:TextField 
                            ID="TextFieldCuenta" 
                            runat="server" 
                            FieldLabel="Cuenta" 
                            AnchorHorizontal="90%">
                        </ext:TextField>
                        
                        <ext:ComboBox
                            Editable="false"
                            ID="ComboBoxTipoMovimiento"
                            EmptyText="Seleccione un tipo de movimiento..." 
                            Mode="Local"
                            StoreID="StoreComboMov"
                            runat="server"
                            FieldLabel="Tipo" 
                            TriggerAction="All"            
                            DisplayField="id"
                            ValueField="id"
                            AnchorHorizontal="90%">
                        </ext:ComboBox>
            
                        <ext:TextField 
                            ID="TextFieldDescripcion" 
                            runat="server" 
                            FieldLabel="Descripción" 
                            AnchorHorizontal="90%">
                        </ext:TextField>
                                                                           
                        <ext:TextField 
                            ID="TextFieldLeyenda" 
                            runat="server" 
                            FieldLabel="Leyenda" 
                            AnchorHorizontal="90%">
                        </ext:TextField>
                        
                        <ext:ComboBox
                            ID="ComboBoxDebeHaber"
                            FieldLabel="Movimiento"
                            Editable="false"
                            AnchorHorizontal="90%"
                            runat="server">
                            <Items>
                                <ext:ListItem Text="Debe" Value="D" />
                                <ext:ListItem Text="Haber" Value="H" />
                            </Items>
                            <SelectedItem Value="D" />
                        </ext:ComboBox>
                                  
                        <ext:CompositeField ID="CompositeField1"
                            FieldLabel="Monto" 
                            AnchorHorizontal="90%"
                            runat="server">
                        <Items>
                            <ext:DisplayField ID="DisplayFieldMoneda" runat="server" Text="$"></ext:DisplayField>
                            <ext:NumberField
                                ID="TextFieldMonto"
                                DecimalPrecision="2"
                                DecimalSeparator=","
                                NoteAlign="Down"
                                runat="server">
                            </ext:NumberField>
                        </Items>
                        </ext:CompositeField>  
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
</body>
</html>
