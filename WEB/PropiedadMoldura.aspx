<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PropiedadMoldura.aspx.cs" Inherits="Prueba" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_body" runat="Server">
    <section>
        <form id="form1" runat="server">
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
                        <div class="body">
                            <div class="row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-6">
                                    <div>
                                        <asp:FileUpload ID="FileUpload1" CssClass="btn btn-warning" runat="server" Width="100%" /><br />
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
                                            <div class="form-group form-float">
                                                <label class="form-label">Tipo de moldura</label>
                                                <div class="form-line focused">
                                                    <div class="form-line">
                                                        <asp:DropDownList ID="ddlTipoMoldura" class="form-control" runat="server"></asp:DropDownList>
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
                                                        <asp:TextBox ID="txtUnidadMetrica" class="form-control" runat="server" ReadOnly></asp:TextBox>
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
                                                <asp:ListItem Value="">Seleccione la hora</asp:ListItem>
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

                                    <asp:LinkButton ID="btnCancelar" runat="server" CssClass="btn bg-red waves-effect" Style="float: right" Width="100%" Text="Cancelar"  OnClick="btnCancelar_Click">
												<i class="material-icons">arrow_back</i>Regresar
											</asp:LinkButton>

                                </div>
                                <div class="col-sm-3 right">

                                    <asp:LinkButton ID="btnGuardar" runat="server" CssClass="btn bg-indigo waves-effect" Style="float: right" Width="100%" Text="Guardar" OnClick="btnGuardar_Click">
												<i class="material-icons">save</i> Guardar
											</asp:LinkButton>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <asp:Button ID="btnUpload" runat="server" Text="Cargar" OnClick="btnUpload_Click" />
            <br />

            <br />
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            <br />
            <asp:HyperLink ID="hyperlink" runat="server"> View Upload image</asp:HyperLink>

        </form>

    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_footer" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cph_Js" runat="Server">
</asp:Content>

