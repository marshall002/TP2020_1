using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoMoldura
    {
        SqlConnection conexion;
            public DataTable ListarMolduras()
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Molduras", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
            public void RegistrarMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Registar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            command.Parameters.AddWithValue("@imagen", objmoldura.VBM_Imagen);
            command.Parameters.AddWithValue("@unidadMet", objmoldura.DM_UnidadMetrica);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            conexion.Open();
            SqlParameter retValue = new SqlParameter("@NewId",SqlDbType.Int);
            retValue.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(retValue);
            using (SqlDataReader dr = command.ExecuteReader())
            { 
                objmoldura.PK_IM_Cod = Convert.ToInt32(retValue.Value);
            }   
            //command.ExecuteNonQuery();
                conexion.Close();
        }
            public void ActualizarMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            command.Parameters.AddWithValue("@imagen", objmoldura.VBM_Imagen);
            command.Parameters.AddWithValue("@unidadMet", objmoldura.DM_UnidadMetrica);
            command.Parameters.AddWithValue("@stock",objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
            public DataSet desplegabletTipoMoldua()
        {
            SqlDataAdapter tipomol = new SqlDataAdapter("SP_Desplegable_Tipo_Moldura", conexion);
            tipomol.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            tipomol.Fill(DS);
            return DS;
        }
            public void ObtenerMoldura(DtoMoldura objmoldura, DtoTipoMoldura objtipo)
        {
            SqlCommand command = new SqlCommand("SP_Obtener_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@codMol", objmoldura.PK_IM_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                objmoldura.PK_IM_Cod = int.Parse(reader[0].ToString());
                objtipo.VTM_Nombre = reader[1].ToString();
                objmoldura.DM_UnidadMetrica = Convert.ToDouble(reader[2].ToString());
                objmoldura.IM_Estado = int.Parse(reader[3].ToString());
                objmoldura.IM_Stock = int.Parse(reader[4].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[5].ToString());
                objmoldura.VBM_Imagen = Convert.ToByte(reader[6].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }

    }
}
