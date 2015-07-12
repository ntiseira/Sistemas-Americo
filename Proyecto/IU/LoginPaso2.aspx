<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPaso2.aspx.cs" Inherits="IU.LoginPaso2" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    protected void RefreshSucursales(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            IList sucur = Admin.ObtenerSucursales(CodEmpresa);
            StoreSucursales.DataSource = sucur;
            StoreSucursales.DataBind();
        }
        catch (Exception ex)
        {
            IU.UIHelper.MostrarExcepcionSimple(ex, "Error al intentar actualizar listados");
        }
    }
    
    protected void RefreshPuestos(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            IList puestos = Admin.ObtenerPuestosDeTrabajo(CodEmpresa);
            StorePuestos.DataSource = puestos;
            StorePuestos.DataBind();
        }
        catch (Exception ex)
        {
            IU.UIHelper.MostrarExcepcionSimple(ex, "Error al intentar actualizar listados");
        }
    }
    
    protected void RefreshEjercicios(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            IList ejercicios = Admin.ObtenerEjercicios(CodEmpresa);
            StoreEjercicios.DataSource = ejercicios;
            StoreEjercicios.DataBind();
        }
        catch (Exception ex)
        {
            IU.UIHelper.MostrarExcepcionSimple(ex, "Error al intentar actualizar listados");
        }
    }

    protected void RefreshEmpresas(object sender, EventArgs e)
    {
        this.ObtenerEmpresas();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Acceso a Sistemas Américo</title>
    <style type="text/css">
        .cbStates-list 
        {
            width: 298px;
            font: 11px tahoma,arial,helvetica,sans-serif;
        }
        
        .cbStates-list th {
            font-weight: bold;
        }
        
        .cbStates-list td, .cbStates-list th {
            padding: 3px;
        }
        .style1
        {
            text-align: center;
        }
        
        .notas
        {
        	color: White;
        	font-style: normal;
        	font-weight: bold;
        }
    </style>
</head>

<body style="background-image:url(images/wallpaperlogin.jpg);">
    <form id="form1" runat="server">

<table id="tablaPrincipal" style="height:100%; width:100%;">
    <tr style="height:30%;">
        <br />
        <br />
        <br />
        <br />
        <br />
    </tr>
    
    <tr style="height:70%; width:100%;">
        <td style="width:43%;">
        </td>
        
        <td style="width:33%;">

    <ext:ResourceManager ID="ResourceManager1" runat="server"/>
    
    <ext:Store ID="StoreEmpresas" runat="server">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="id"/>
                    <ext:RecordField Name="nombre" />
                </Fields>
            </ext:ArrayReader>
        </Reader>          
    </ext:Store>    
    
    <ext:Store ID="StorePlanes" runat="server" OnRefreshData="RefreshPlanesDeCuentas" AutoLoad="false">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="id"/>
                    <ext:RecordField Name="descrip" />
                </Fields>
            </ext:ArrayReader>
        </Reader>          
    </ext:Store>    
        
    <ext:Store ID="StoreSucursales" runat="server" OnRefreshData="RefreshSucursales" AutoLoad="false">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="id"/>
                    <ext:RecordField Name="nombre" />
                    <ext:RecordField Name="central" />
                </Fields>
            </ext:ArrayReader>
        </Reader>          
    </ext:Store>    
    
    <ext:Store ID="StorePuestos" runat="server" OnRefreshData="RefreshPuestos" AutoLoad="false">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="nombre" />
                </Fields>
            </ext:ArrayReader>
        </Reader>
              
    </ext:Store>
    
    <ext:Store ID="StoreEjercicios" runat="server" OnRefreshData="RefreshEjercicios" AutoLoad="false">
        <Reader>
            <ext:ArrayReader>
                <Fields>
                    <ext:RecordField Name="id" />
                    <ext:RecordField Name="inicio"/>
                    <ext:RecordField Name="fin"/>
                    <ext:RecordField Name="estado" />
                </Fields>
            </ext:ArrayReader>
        </Reader>            
    </ext:Store>
            
    <h1>Acceso a Sistemas Américo</h1>
    <div>
        <br />
        <div class="style1">
        <ext:ComboBox ID="ComboEmpresas" runat="server" StoreID="StoreEmpresas"
            Editable="false"
            TypeAhead="true" 
            Mode="Local"
            ForceSelection="true"
            TriggerAction="All"            
            DisplayField="nombre"
            ValueField="id"
            EmptyText="Seleccione una empresa..."
            ValueNotFoundText=""
            SelectOnFocus="true"
            Note="Empresas" NoteAlign="Top" NoteCls="notas"
            >
            <Listeners>
                <Select Handler="#{ComboPuestos}.clearValue();#{ComboBoxPlanes}.clearValue();#{StorePuestos}.reload();#{ComboEjercicios}.clearValue();#{StoreEjercicios}.reload();#{ComboSucursales}.clearValue();#{StoreSucursales}.reload();" />
            </Listeners>
        </ext:ComboBox>
        </div>
        
        <br />
        
        <div class="style1">
            <ext:ComboBox ID="ComboPuestos" runat="server" StoreID="StorePuestos"
                Editable="false"
                TypeAhead="true" 
                Mode="Local"
                ForceSelection="true"
                TriggerAction="All"            
                DisplayField="nombre"
                ValueField="nombre"
                EmptyText="Seleccione un puesto de trabajo..." 
                Note="Puestos de trabajo" NoteAlign="Top" NoteCls="notas"
                ValueNotFoundText="">
            </ext:ComboBox>
        </div>
        
        <br />
        
        <div class="style1">
        
        <ext:ComboBox ID="ComboEjercicios" runat="server" 
            StoreID="StoreEjercicios"
            Editable="false"
            TypeAhead="true" 
            Mode="Local"
            ForceSelection="true"
            TriggerAction="All"            
            DisplayField="id"
            ValueField="id"
            EmptyText="Seleccione un ejercicio..." 
            ValueNotFoundText=""
            MinChars="1"
            ListWidth="350"
            Note="Períodos de ejercicio" NoteAlign="Top" NoteCls="notas"
            PageSize="10"
            ItemSelector="tr.list-item">
            <DirectEvents>
                <Select OnEvent="RefreshPlanesDeCuentas" After="#{ComboBoxPlanes}.clearValue();#{StorePlanes}.reload();"></Select>
            </DirectEvents>
            <Template ID="Template1" runat="server">
                <Html>
					<tpl for=".">
						<tpl if="[xindex] == 1">
							<table class="cbStates-list">
								<tr>
									<th>Id   </th>
									<th>Inicio</th>
									<th>Fin  </th>
									<th>Estado</th>
								</tr>
						        </tpl>
						        <tr class="list-item">
							        <td style="padding:3px 0px;">{id}</td>
							        <td>{inicio}</td>
							        <td>{fin}</td>
							        <td>{estado}</td>
						        </tr>
						        <tpl if="[xcount-xindex]==0">
							</table>
						</tpl>
					</tpl>
				</Html>
            </Template>
        </ext:ComboBox> 
        
        <br />
        
        <ext:ComboBox ID="ComboSucursales" runat="server" 
            StoreID="StoreSucursales"
            Editable="false"
            TypeAhead="true" 
            Mode="Local"
            ForceSelection="true"
            TriggerAction="All"            
            DisplayField="id"
            ValueField="id"
            EmptyText="Seleccione una sucursal..." 
            ValueNotFoundText=""
            MinChars="1"
            ListWidth="350"
            PageSize="10"
            Note="Sucursales" NoteAlign="Top" NoteCls="notas"
            ItemSelector="tr.list-item">
            <Template ID="Template2" runat="server">
                <Html>
					<tpl for=".">
						<tpl if="[xindex] == 1">
							<table class="cbStates-list">
								<tr>
									<th>Id   </th>
									<th>Nombre</th>
									<th>Central  </th>
								</tr>
						        </tpl>
						        <tr class="list-item">
							        <td style="padding:3px 0px;">{id}</td>
							        <td>{nombre}</td>
							        <td>{central}</td>
						        </tr>
						        <tpl if="[xcount-xindex]==0">
							</table>
						</tpl>
					</tpl>
				</Html>
            </Template>
        </ext:ComboBox> 
        
        </div>
        <br />
        
        <ext:ComboBox ID="ComboBoxPlanes" runat="server" StoreID="StorePlanes"
            Editable="false"
            TypeAhead="true" 
            Mode="Local"
            ForceSelection="true"
            TriggerAction="All"            
            DisplayField="descrip"
            ValueField="id"
            EmptyText="Seleccione un plan de cuentas..." 
            Note="Plan de cuentas" NoteAlign="Top" NoteCls="notas"
            ValueNotFoundText="">
        </ext:ComboBox>
        
    </div>    
    <div>
        <br /> 
        <br />
        <ext:Button ID="BotonAcceder" runat="server" Text="Ingresar" Scale="Medium">
            <DirectEvents>
                <Click OnEvent="BotonAcceder_Click">
                    <EventMask ShowMask="true" MinDelay="500" Msg="Ingresando..."/>
                </Click>
            </DirectEvents>
        </ext:Button>
    </div>
    
                </td>
                
                <td style="width:23%;">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
