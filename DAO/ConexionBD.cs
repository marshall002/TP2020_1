﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ConexionBD
    {
        public static string CadenaConexion
        {
            get
            {
                return @"data source=LAPTOP-UEI1JFVM; initial catalog=BD_SCPEDR; integrated security=SSPI;";
            }
        }
    }
}
