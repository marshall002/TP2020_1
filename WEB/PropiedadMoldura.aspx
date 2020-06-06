<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PropiedadMoldura.aspx.cs" Inherits="Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <form id="form1" runat="server" method="POST">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="block-header">
                        <h1 id="txtPagina" runat="server"></h1>
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
                                <div class="body">
                                    <div class="row">
                                        <div class="col-sm-3"></div>
                                        <div class="col-sm-6">
                                            <div>

                                                <asp:Image ID="Image1" Height="500px" Width="500px" runat="server" class="rounded" />


                                                <asp:FileUpload ID="FileUpload1" CssClass="btn btn-warning" runat="server" Width="100%" />
                                                <br />


                                                <%--<asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />--%>
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
                                                                <asp:TextBox ID="txtCodigo" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">
                                                    <label class="form-label">Tipo de moldura</label>
                                                    <asp:DropDownList ID="ddlTipoMoldura" class="form-control" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">
                                                    <div class="form-group form-float">
                                                        <label class="form-label">Medida</label>
                                                        <div class="form-line focused">
                                                            <div class="form-line">
                                                                <asp:TextBox ID="txtMedida" class="form-control" runat="server"></asp:TextBox>
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
                                                    <asp:DropDownList runat="server" ID="ddlEstadoMoldura" CssClass="form-control" OnSelectedIndexChanged="ddlEstadoMoldura_SelectedIndexChanged">
                                                        <asp:ListItem Value="">--Seleccione--</asp:ListItem>
                                                        <asp:ListItem Value="1">Habilitado</asp:ListItem>
                                                        <asp:ListItem Value="0">Deshabilitado</asp:ListItem>
                                                    </asp:DropDownList>
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
                                                        <label class="form-label">Precio S/.</label>
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
                                        <div class="col-lg-12">
                                            <div class="row clearfix">
                                                <div class="col-sm-12">
                                                    <div class="form-group">
                                                        <label class="form-label">Descripción</label>
                                                        <div class="form-line">
                                                            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="multiline" Rows="4" class="form-control no-resize"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 right">

                                            <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Width="100%" Text="Cancelar" OnClick="btnCancelar_Click">
												<i class="material-icons">arrow_back</i>Regresar
                                            </asp:LinkButton>

                                        </div>
                                        <div class="col-sm-3 right">
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Button ID="btnGuardar" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="100%" Text="Guardar"
                                                        OnClick="btnGuardar_Click"></asp:Button>
                                                </ContentTemplate>

                                            </asp:UpdatePanel>


                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnGuardar" />
                </Triggers>
            </asp:UpdatePanel>

            <div class="modal fade" id="defaultmodal" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <asp:UpdatePanel runat="server" ID="updPanelModal" UpdateMode="Always">
                        <ContentTemplate>
                            <div class="modal-header navbar">
                                <h4 class="modal-title" id="tituloModal" runat="server" style="color: white;"></h4>
                            </div>
                            <div class="modal-body">

                                <div class="row">
                                    <div class="text-center">
                                        <asp:Image ID="Image2" Height="500px" Width="500px" runat="server" class="rounded" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="row clearfix">
                                            <div class="form-group form-float">
                                                <label class="form-label">Descripción :</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:TextBox ID="txtDescripcionModal" class="form-control" runat="server" ReadOnly></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-link waves-effect" data-dismiss="modal">Cerrar</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        </form>

    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

