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
    protected void Page_Load(object sender, EventArgs e)
    {
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
        ds= objCtrMoldura.OpcionesTipoMoldura();
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
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string FileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(postedFile.FileName);
            int fileSize = postedFile.ContentLength;
            Log.WriteLog("txtTipoMoldura = " + ddlTipoMoldura.SelectedValue);
            Log.WriteLog("ddlEstadoMoldura = " + ddlEstadoMoldura.SelectedValue);
            Log.WriteLog("txtStock = " + txtStock.Text);
            Log.WriteLog("txtPrecio = " + txtPrecio.Text);

            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".bmp" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);
                objDtoMoldura.VBM_Imagen = bytes;
                objDtoMoldura.DM_Precio = Double.Parse(txtPrecio.Text);
                objDtoMoldura.VM_Descripcion = txtDescripcion.Text;
                objDtoMoldura.IM_Estado = int.Parse(ddlEstadoMoldura.SelectedValue);
                objDtoMoldura.IM_Stock = int.Parse(txtStock.Text);
                objDtoMoldura.FK_ITM_Tipo = int.Parse(ddlTipoMoldura.SelectedValue);

                //falta unidad de medida
                //objCtrMoldura.registrarNuevaMoldura(objDtoMoldura);


            }
            else
            {

            }


        }
        catch (Exception ex)
        {
            Log.WriteLog("Error  = " + ex.Message + "posicion" + ex.StackTrace);

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