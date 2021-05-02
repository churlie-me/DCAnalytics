using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCAnalytics.Data
{
    public class TopicProvider : Provider
    {
        public TopicProvider(dloDbInfo dbInfo) : base(dbInfo)
        {
        }

        public DCAnalytics.Topic GetTopic(int id)
        {
            string query = $"select * from dsto_Topic where OID = {id}";
            var table = DbInfo.ExecuteSelectQuery(query);
            if (table.Rows.Count > 0 && table.Rows.Count == 1)
            {
                System.Data.DataRow row = table.Rows[0];
                DCAnalytics.Topic topic = new Topic(null);
                InitTopic(topic, row);
                return topic;
            }
            return null;
        }

        private void InitTopic(Topic topic, DataRow row)
        {
            topic.Key = row["guid"].ToString();
            topic.CreatedBy = row["created_by"].ToString();
            topic.OID = int.Parse(row["OID"].ToString());
            topic.Deleted = bool.Parse(row["deleted"].ToString());
            topic.Name = row["Name"].ToString();
            
        }

        public Topics GetTopics(string id)
        {
            Topics topics = new Topics();
            try
            {
                string query = $"select * from dsto_Topic where yref_training = '{id}' and Deleted=0";
                var table = DbInfo.ExecuteSelectQuery(query);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Topic topic = topics.Add();
                        InitTopic(topic, row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return topics;
        }

        public override bool Save(DCAnalyticsObject obj)
        {
            Topic topic = obj as Topic;
            var exists = RecordExists("dsto_Topic", topic.Key);
            string query = string.Empty;
            if(!exists)
            {
                query = $"insert into dsto_Topic([guid],Name,[created_by],[yref_training]) values('{topic.Key}','{topic.Name}','Admin','{topic.TrainingId}')";
            }
            else
            {
                //update
                query = $"UPDATE dsto_Topic SET [Name]='{topic.Name}', " +
                        $"[Deleted]='{topic.Deleted}' " +
                        $"WHERE [guid]='{topic.Key}'";
            }
           
            return DbInfo.ExecuteNonQuery(query) > -1;
        }

        public bool DeleteTopic(string key)
        {
            string query = $"delete from dsto_Topic where [guid]='{key}'";

            var rows = DbInfo.ExecuteNonQuery(query);
            return rows > -1;
        }

    }
}
