using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

public partial class GestionCatalogo : System.Web.UI.Page
{
    CtrMoldura objctrMoldura = new CtrMoldura();
    DtoMoldura objDtoMoldura = new DtoMoldura();
    Log _log = new Log();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            gvCatalogo.DataSource = objctrMoldura.ListaMolduras();
            gvCatalogo.DataBind();
        }
    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PropiedadMoldura.aspx");
    }

    protected void gvCatalogo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Ver")
        {
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = gvCatalogo.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '" + id + "', 'bottom', 'center', null, null);", true);
                objDtoMoldura.PK_IM_Cod = int.Parse(id);
                objctrMoldura.ObtenerImagen_Desc_Moldura(objDtoMoldura);
                _log.CustomWriteOnLog("GestionCatalogo", "ID" + id);
                _log.CustomWriteOnLog("GestionCatalogo", "Descripcion" + objDtoMoldura.VM_Descripcion);
                _log.CustomWriteOnLog("GestionCatalogo", "VBM_Imagen" + Convert.ToBase64String(objDtoMoldura.VBM_Imagen));

                txtDescripcionModal.Text = objDtoMoldura.VM_Descripcion;
                byte[] bytes = (byte[])objDtoMoldura.VBM_Imagen;
                //string strbase64 = Convert.ToBase64String(bytes);
                //Image1.ImageUrl = "data:Image/png;base64," + strbase64;


                var base64 = Convert.ToBase64String(bytes);
                var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                Image1.ImageUrl = imgSrc;

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
       "<script>$('#defaultmodal').modal('show');</script>", false);

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("GestionCatalogo", "Error =" + ex.Message);
            }

        }
    }
}