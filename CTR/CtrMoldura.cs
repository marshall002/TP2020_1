using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAO;
using DTO;

namespace CTR
{
    public class CtrMoldura
    {
        DaoMoldura objDaoMoldura;
        public CtrMoldura()
        {
            objDaoMoldura = new DaoMoldura();
        }
        public void registrarNuevaMoldura(DtoMoldura objDtoMoldura)
        {
            objDaoMoldura.RegistrarMoldura(objDtoMoldura);
        }
        public DataSet OpcionesTipoMoldura()
        {
            return objDaoMoldura.desplegableTipoMoldura();
        }
        public DataTable ListaMolduras()
        {
            return objDaoMoldura.ListarMolduras();
        }
    }
}
