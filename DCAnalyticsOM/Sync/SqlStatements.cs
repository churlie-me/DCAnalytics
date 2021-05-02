using System.Collections.Generic;

namespace DCAnalytics.Sync
{
    public class SqlStatements : List<SqlStatement>
    {
        public void Append(SqlStatements statements)
        {
            foreach (SqlStatement s in statements)
                this.Add(s);
        }
    }
}