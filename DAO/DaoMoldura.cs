﻿using System;
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
        public DaoMoldura()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
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
        public DataTable ListarMoldurasByTipoMoldura(DtoTipoMoldura objtipo)
        {
            DataTable dtmolduras = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Moldura_by_TipoMoldura", conexion);
            command.Parameters.AddWithValue("@idTipoMold", objtipo.PK_ITM_Tipo);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtmolduras = new DataTable();
            daAdaptador.Fill(dtmolduras);
            conexion.Close();
            return dtmolduras;
        }
        public void RegistrarMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            //command.Parameters.AddWithValue("@imagen", DBNull.Value);
            var binary1 = command.Parameters.Add("@imagen", SqlDbType.VarBinary, -1);
            binary1.Value = DBNull.Value;
            command.Parameters.AddWithValue("@medida", objmoldura.DM_Medida);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
            conexion.Open();
            command.ExecuteNonQuery();

            //SqlParameter retValue = new SqlParameter("@NewId", SqlDbType.Int).Direction=Par;
            //retValue.Direction = ParameterDirection.ReturnValue;
            //command.Parameters.Add(retValue);
            using (SqlDataReader dr = command.ExecuteReader())
            {
                objmoldura.PK_IM_Cod = Convert.ToInt32(command.Parameters["@NewId"].Value);
            }
            conexion.Close();
        }
        public void RegistrarImgMoldura(byte[] bytes, int id)
        {
            SqlCommand command = new SqlCommand("SP_Registrar_Img_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", id);
            command.Parameters.AddWithValue("@imagen", bytes);
            conexion.Open();
            //SqlParameter retValue = new SqlParameter("@NewId", SqlDbType.Int);
            //retValue.Direction = ParameterDirection.ReturnValue;
            //command.Parameters.Add(retValue);
            //using (SqlDataReader dr = command.ExecuteReader())
            //{
            //    objmoldura.PK_IM_Cod = Convert.ToInt32(retValue.Value);
            //}
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ActualizarMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@descripcion", objmoldura.VM_Descripcion);
            command.Parameters.AddWithValue("@medida", objmoldura.DM_Medida);
            command.Parameters.AddWithValue("@stock", objmoldura.IM_Stock);
            command.Parameters.AddWithValue("@precio", objmoldura.DM_Precio);
            command.Parameters.AddWithValue("@estado", objmoldura.IM_Estado);
            command.Parameters.AddWithValue("@idtipom", objmoldura.FK_ITM_Tipo);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ActualizarImgMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_Actualizar_Img_Moldura", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@idMol", objmoldura.PK_IM_Cod);
            command.Parameters.AddWithValue("@imagen", objmoldura.VBM_Imagen);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public DataSet desplegableTipoMoldura()
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

            while (reader.Read())
            {
                objmoldura.PK_IM_Cod = int.Parse(reader[0].ToString());
                objmoldura.VM_Descripcion = reader[1].ToString();
                objtipo.PK_ITM_Tipo = int.Parse(reader[2].ToString());
                objtipo.VTM_Nombre = reader[3].ToString();
                objmoldura.DM_Medida = Convert.ToDouble(reader[4].ToString());
                objtipo.VTM_UnidadMetrica = reader[5].ToString();
                objmoldura.IM_Estado = int.Parse(reader[6].ToString());
                objmoldura.IM_Stock = int.Parse(reader[7].ToString());
                objmoldura.DM_Precio = Convert.ToDouble(reader[8].ToString());
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[9].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }
        public void ObtenerImgMoldura(DtoMoldura objmoldura)
        {
            SqlCommand command = new SqlCommand("SP_GetImageById", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", objmoldura.PK_IM_Cod);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objmoldura.VBM_Imagen = Encoding.ASCII.GetBytes(reader[1].ToString());
                objmoldura.VM_Descripcion = reader[1].ToString();
            }
            conexion.Close();
            conexion.Dispose();
        }

    }
}
