using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCAnalytics.Data
{
    public class TrainerProvider : Provider
    {
        public TrainerProvider(dloDbInfo dbInfo) : base(dbInfo)
        {
        }
        public DCAnalytics.Trainer GetTrainer(int id)
        {
            string query = $"select * from dsto_Trainer where OID = {id}";
            var table = DbInfo.ExecuteSelectQuery(query);
            if (table.Rows.Count > 0 && table.Rows.Count == 1)
            {
                System.Data.DataRow row = table.Rows[0];
                Trainer trainer = new Trainer(null);
                InitTrainer(trainer, row);
                return trainer;
            }
            return null;
        }

        private void InitTrainer(Trainer topic, DataRow row)
        {
            topic.Key = row["guid"].ToString();
            topic.CreatedBy = row["created_by"].ToString();
            topic.OID = int.Parse(row["OID"].ToString());
            topic.Name = row["Name"].ToString();
            
        }

        public Trainers GetTrainers(string id)
        {
            Trainers trainers = new Trainers();
            try
            {
                string query = $"select * from dsto_Trainer where yref_training = '{id}' and Deleted=0";
                var table = DbInfo.ExecuteSelectQuery(query);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Trainer trainer = trainers.Add();
                        InitTrainer(trainer, row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return trainers;
        }

        public override bool Save(DCAnalyticsObject obj)
        {
            Trainer trainer = obj as Trainer;

            var exists = RecordExists("dsto_Trainer", trainer.Key);
            string query = string.Empty;
            if(!exists)
            {
                query = $"insert into dsto_Trainer([guid],Name,[created_by],[yref_training]) values('{trainer.Key}','{trainer.Name}','Admin','{trainer.TrainingId}')";
            }
            else
            {
                //update
                query = $"UPDATE dsto_Trainer SET [Name]='{trainer.Name}', " +
                        $"[Deleted]='{trainer.Deleted}' " +
                        $"WHERE [guid] = '{trainer.Key}'";
            }

           
            return DbInfo.ExecuteNonQuery(query) > -1;
        }

        public bool DeleteTrainer(string key)
        {
            string query = $"delete from dsto_Trainer where [guid]='{key}'";

            var rows = DbInfo.ExecuteNonQuery(query);
            return rows > -1;
        }
    }
}
