using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Bologna.Datos
{
    public class Base
    {
        const string keyCon = "conStr";

        private SqlConnection sqlCon;

        public SqlConnection SqlCon { get => sqlCon; set => sqlCon = value; }

        public Base()
        {
            string strConn = ConfigurationManager.ConnectionStrings[keyCon].ConnectionString;
            SqlCon = new SqlConnection(strConn);
        }
    }
}
