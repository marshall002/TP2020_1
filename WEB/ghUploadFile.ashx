<%@ WebHandler Language="C#" Class="ghUploadFile" %>

using System;
using System.Web;
using System.IO;

using DTO;
using CTR;

public class ghUploadFile : IHttpHandler
{

    Log _Log = new Log();
    public void ProcessRequest(HttpContext context)
    {
        _Log.CustomWriteOnLog("PropiedadMoldura", "Entro a metodo ashx");
        try
        {
            if (context.Request.Files.Count > 0)
            {
                CtrMoldura oBLAPISol = new CtrMoldura();
                _Log.CustomWriteOnLog("PropiedadMoldura", "1");

                byte[] fileData = null;
                _Log.CustomWriteOnLog("PropiedadMoldura", " 2");
                using (var binaryReader = new BinaryReader(context.Request.Files[0].InputStream))
                {
                    fileData = binaryReader.ReadBytes(context.Request.Files[0].ContentLength);
                }
                _Log.CustomWriteOnLog("PropiedadMoldura", "3");

                oBLAPISol.registrarImgMoldura(fileData, 380);
                _Log.CustomWriteOnLog("PropiedadMoldura", "4");
            }
            _Log.CustomWriteOnLog("PropiedadMoldura", "5");

        }
        catch (Exception ex)
        {
            _Log.CustomWriteOnLog("PropiedadMoldura", "Error" + ex.Message);
        }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}