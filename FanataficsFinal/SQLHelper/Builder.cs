using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLHelper
{
    public class Builder
    {
        public static string Build(Criteria crit)
        {
            string sql = "SELECT * FROM " + crit.TableName;

            if (crit.Fields.Count == 0)
                sql += " WHERE [Deleted]='false'";
            else
                sql += " WHERE ";

            for (int i = 0; i < crit.Fields.Count; i++)
            {
                if (crit.Types[i] == DataTypeHelper.Type.DataType.String_Contains)
                    sql += "[" + crit.Fields[i] + "] LIKE '%" + crit.Values[i] + "%'";

                else if (crit.Types[i] == DataTypeHelper.Type.DataType.String_Starts_With)
                {
                    sql += "[" + crit.Fields[i] + "] LIKE '%" + crit.Values[i] + "%'";
                }

                else if (crit.Types[i] == DataTypeHelper.Type.DataType.String_Ends_With)
                {
                    sql += "[" + crit.Fields[i] + "] LIKE '%" + crit.Values[i] + "%'";

                    if (i < crit.Fields.Count - 1)
                    {
                        sql += " AND ";
                    }
                    else
                        sql += " AND [Deleted] = 'false'";
                }

            }
            return sql;

        }
    }
}
