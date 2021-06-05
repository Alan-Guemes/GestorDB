using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestorDB
{
    class Conexion
    {
        public SqlConnection conexion =
            new SqlConnection("server = NOUT ; database=master ; integrated security = true");
    }
}
