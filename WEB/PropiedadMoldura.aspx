<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PropiedadMoldura.aspx.cs" Inherits="PropiedadMoldura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <div class="container-fluid">
            <div class="block-header">
                <h1>Agregar moldura</h1>
            </div>
            <div class="row clearfix">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="card">
                        <div class="header">
                            <h2>Completa la solicitud
                                <small></small>
                            </h2>
                            <ul class="header-dropdown m-r--5">
                            </ul>
                        </div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <div class="body">
                            <div class="row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-6">
                                    <div>
                                        <%--<asp:Image ID="imgMoldura" Height="300px" Width="300px" runat="server" />--%>
                                        <asp:FileUpload ID="FileUpload1" CssClass="btn btn-warning" runat="server" Width="100%" />

                                    </div>
                                    <div class="center">
                                        <%--<asp:Button ID="btnPreview" CssClass="btn btn-warning" runat="server" Text="Previsualizar" OnClick="btnPreview_Click" />--%>
                                    </div>
                                </div>
                                <div class="col-sm-3"></div>

                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Codigo</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtCodigo" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Tipo de moldura</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtTipoMoldura" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Unidad métrica</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtUnidadMetrica" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <label class="form-label">Estado</label>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList runat="server" ID="ddlEstadoMoldura" CssClass="form-control" OnSelectedIndexChanged="ddlEstadoMoldura_SelectedIndexChanged">
                                                        <asp:ListItem Value="">Seleccione la hora</asp:ListItem>
                                                        <asp:ListItem Value="1" Selected="True">Habilitado</asp:ListItem>
                                                        <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlEstadoMoldura" EventName="selectedindexchanged" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Stock</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtStock" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="row clearfix">
                                        <div class="col-sm-12">
                                            <div class="form-group form-float">
                                                <label class="form-label">Precio</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtPrecio" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-3 right">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Always"
                                        ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Width="100%" Text="Cancelar" PostBackUrl="~/Sol_Citas_Administracion.aspx" OnClick="btnCancelar_Click">
												<i class="material-icons">arrow_back</i>Regresar
											</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnCancelar" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="col-sm-3 right">

                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always"
                                        ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="100%" Text="Guardar" OnClick="btnGuardar_Click">
												<i class="material-icons">save</i> Guardar
											</asp:LinkButton>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
    <%--<script src="js/RadioButtonCustom.js"></script>--%>
    <script src="../../plugins/jquery-validation/jquery.validate.js"></script>
    <script src="../../plugins/jquery-steps/jquery.steps.js"></script>
    <script src="../../js/pages/forms/form-validation.js"></script>

</asp:Content>

