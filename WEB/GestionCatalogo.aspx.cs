using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

public partial class GestionCatalogo : System.Web.UI.Page
{
    CtrMoldura objctrMoldura = new CtrMoldura();
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
            int index = Convert.ToInt32(e.CommandArgument);
            var colsNoVisible = gvCatalogo.DataKeys[index].Values;
            string id = colsNoVisible[0].ToString();
            //string estadosol = colsNoVisible[1].ToString();
            ////string tipocitasol = colsNoVisible[2].ToString();
            //string CodigoUsuarioCita = colsNoVisible[3].ToString();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "showNotification", "showNotification('bg-red', '"+ id + "', 'bottom', 'center', null, null);", true);


            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none",
    "<script>$('#Test').modal('show');</script>", false);
            //Session["CodigoSolicitudCita"] = id;
            //Session["estadosol"] = estadosol;
            //Session["TipoCitaSol"] = tipocitasol;
            //Session["CodigoUsuarioCita"] = CodigoUsuarioCita;
            //Response.Redirect("PropiedadMoldura.aspx?Id=" + id);
        }
    }
}