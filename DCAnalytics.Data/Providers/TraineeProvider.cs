﻿using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCAnalytics.Data
{
    public class TraineeProvider : Provider
    {

        public TraineeProvider(dloDbInfo dbInfo) : base(dbInfo)
        {
        }

        public Trainee GetTrainee(int id)
        {
            //string query = $"select * from dsto_Trainee where OID = {id}";
            //var table = DbInfo.ExecuteSelectQuery(query);
            //if (table.Rows.Count > 0 && table.Rows.Count == 1)
            //{
            //    System.Data.DataRow row = table.Rows[0];
            //    Trainee trainee = new Trainee(null);
            //    InitTrainee(trainee, row);
            //    return trainee;
            //}
            return null;
        }

        private void InitTrainee(Questionaire trainee, DataRow row)
        {
            trainee.Key = row["guid"].ToString();
            trainee.CreatedBy = row["created_by"].ToString();
            trainee.OID = int.Parse(row["OID"].ToString());
            trainee.Deleted = bool.Parse(row["deleted"].ToString());
            trainee.Name = row["Name"].ToString();
            trainee.Sections = new SectionProvider(DbInfo).GetSections(trainee.Key);
        }

        public Trainees GetTrainees(string training_id)
        {
            Trainees trainees = new Trainees();
            try
            {
                string query = $"select * from dsto_Trainee where yref_training = '{training_id}' and Deleted=0";           
                var table = DbInfo.ExecuteSelectQuery(query);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Trainee trainee = trainees.Add();
                        trainee.Key = Convert.ToString(row["guid"]);
                        trainee.OID = Convert.ToInt32(row["OID"]);
                        trainee.FarmerKey = Convert.ToString(row["yref_questionaire"]);
                        trainee.Deleted = bool.Parse(row["deleted"].ToString());
                        trainee.CreatedBy = Convert.ToString(row["created_by"]);
                        trainee.TrainingId = Convert.ToString(row["yref_training"]);
                    }
                }
                return trainees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Questionaires GetTrainees(int id)
        {
            Questionaires trainees = new Questionaires();
            try
            {
                string query = $"select dsto_questionaire.* from dsto_questionaire inner join dsto_Trainee " +
                    $"on dsto_questionaire.guid = dsto_trainee.yref_questionaire " +
                    $"where dsto_Trainee.yref_training ='{id}'";
                var table = DbInfo.ExecuteSelectQuery(query);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Questionaire trainee = trainees.Add();
                        InitTrainee(trainee, row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return trainees;
        }

        public Trainees GetRegisteredTrainees(string training_id)
        {
            Trainees trainees = new Trainees();
            try
            {
                string query = $"select dsto_questionaire.* from dsto_questionaire inner join dsto_Trainee " +
                    $"on dsto_questionaire.guid = dsto_trainee.yref_questionaire " +
                    $"where dsto_Trainee.yref_training ='{training_id}'";
                var table = DbInfo.ExecuteSelectQuery(query);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Trainee trainee = trainees.Add();
                        trainee.Questionaire = new Questionaires().Add();
                        trainee.Questionaire.Key = row["guid"].ToString();
                        trainee.Questionaire.CreatedBy = row["created_by"].ToString();
                        trainee.Questionaire.OID = int.Parse(row["OID"].ToString());
                        trainee.Questionaire.Deleted = bool.Parse(row["deleted"].ToString());
                        trainee.Questionaire.Name = new SectionProvider(DbInfo).QuestionaireIdentification(row["yref_template"].ToString(), row["guid"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return trainees;
        }

        public override bool Save(DCAnalyticsObject obj)
        {
            Trainee trainee = obj as Trainee;

            string query = string.Empty;

            var exists = RecordExists("dsto_Trainee", trainee.Key);
            if(!exists)
            {
                query = $"insert into dsto_Trainee([guid],[yref_questionaire],[created_by],[yref_training]) values('{trainee.Key}','{trainee.FarmerKey}','Admin','{trainee.TrainingId}')";
            }
            else
            {
                //update
                query = $"UPDATE dsto_Trainee SET [yref_questionaire]='{trainee.FarmerKey}', " +
                    $"[Deleted]='{trainee.Deleted}' " +
                    $"WHERE [guid]='{trainee.Key}'";
            }

            return DbInfo.ExecuteNonQuery(query) > -1;
        }

        public bool DeleteTrainee(string key)
        {
            string query = $"delete from dsto_Trainee where [guid]='{key}'";

            var rows = DbInfo.ExecuteNonQuery(query);
            return rows > -1;
        }
    }
}
