using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using DTO;
using CTR;
using DAO;


public partial class Prueba : System.Web.UI.Page
{
    CtrMoldura objCtrMoldura = new CtrMoldura();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.Attributes.Add("enctype", "multipart/form-data");
        if (!IsPostBack)
        {
            OpcionesTipoMoldura();
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

    }


    public void OpcionesTipoMoldura()
    {
        DataSet ds = new DataSet();
        ds = objCtrMoldura.OpcionesTipoMoldura();
        ddlTipoMoldura.DataSource = ds;
        ddlTipoMoldura.DataTextField = "VTM_Nombre";
        ddlTipoMoldura.DataValueField = "PK_ITM_Tipo";
        ddlTipoMoldura.DataBind();
        ddlTipoMoldura.Items.Insert(0, new ListItem("Seleccione", "0"));
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile == false)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Debe agregar una imagen valida', 'bottom', 'center', null, null);", true);

            }
            else
            {
                //string FileName = FileUpload1.FileName;
                //UploadDetails.Text = string.Format(
                //        @"Uploaded file: {0}<br />
                // File size (in bytes): {1:N0}<br />
                // Content-type: {2}",
                //          FileName,
                //          FileUpload1.FileBytes.Length,
                //          FileUpload1.PostedFile.ContentType);

                //Save the file
                //string filePath = Server.MapPath("~/Brochures/" + FileUpload1.FileName);
                //FileUpload1.SaveAs(filePath);
                HttpPostedFile postedFile = FileUpload1.PostedFile;
                string FileName = Path.GetFileName(postedFile.FileName);
                string fileExtension = Path.GetExtension(postedFile.FileName);
                int fileSize = postedFile.ContentLength;
                _log.CustomWriteOnLog("PropiedadMoldura_aspx", "txtTipoMoldura = " + ddlTipoMoldura.SelectedValue);
                _log.CustomWriteOnLog("PropiedadMoldura_aspx", "ddlEstadoMoldura = " + ddlEstadoMoldura.SelectedValue);
                _log.CustomWriteOnLog("PropiedadMoldura_aspx", "txtStock = " + txtStock.Text);
                _log.CustomWriteOnLog("PropiedadMoldura_aspx", "txtPrecio = " + txtPrecio.Text);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
                {
                    Stream stream = postedFile.InputStream;
                    BinaryReader binaryReader = new BinaryReader(stream);
                    byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                    objDtoMoldura.VBM_Imagen = bytes;
                    objDtoMoldura.DM_Precio = Double.Parse(txtPrecio.Text);
                    objDtoMoldura.IM_Estado = int.Parse(ddlEstadoMoldura.SelectedValue);
                    objDtoMoldura.IM_Stock = int.Parse(txtStock.Text);
                    objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);
                    objDtoMoldura.VM_Descripcion = txtDescripcion.Text;
                    objDtoMoldura.DM_Medida = Double.Parse(txtMedida.Text);

                    objCtrMoldura.registrarNuevaMoldura(objDtoMoldura);
                    _log.CustomWriteOnLog("PropiedadMoldura_aspx", "Agregado");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', 'Agregado', 'bottom', 'center', null, null);", true);

                }

            }

        }
        catch (Exception ex)
        {
            _log.CustomWriteOnLog("PropiedadMoldura_aspx", "Error  = " + ex.Message + "posicion" + ex.StackTrace);

            throw;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }

    protected void ddlEstadoMoldura_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}