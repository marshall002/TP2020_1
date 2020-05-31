using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GestionarCatalogo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            //string tipocitasol = colsNoVisible[2].ToString();
            //string CodigoUsuarioCita = colsNoVisible[3].ToString();



            //Session["CodigoSolicitudCita"] = id;
            //Session["estadosol"] = estadosol;
            //Session["TipoCitaSol"] = tipocitasol;
            //Session["CodigoUsuarioCita"] = CodigoUsuarioCita;
            Response.Redirect("PropiedadMoldura.aspx?Id=" + id);
        }
    }
}