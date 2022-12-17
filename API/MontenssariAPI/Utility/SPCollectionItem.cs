using System;
using System.Collections.Generic;

using System.Text;
using System.Data.SqlClient;

namespace MontenssariAPI.Utility
{
    public class SPCollectionItem
    {
        public string ProcedureName;
        public List<SqlParameter> Parameters;
    }
}