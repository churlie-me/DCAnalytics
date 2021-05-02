using DCAnalytics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCAnalytics.Data
{
    public class ConfigurationProvider : Provider
    {

        public ConfigurationProvider(dloDbInfo dbInfo) : base(dbInfo)
        {
        }

        public DCAnalytics.Configuration GetConfiguration(int id)
        {
            try
            {
                string query = $"select * from dsto_configuration where OID = '{id}'";
                var table = DbInfo.ExecuteSelectQuery(query);
                if (table.Rows.Count > 0 && table.Rows.Count == 1)
                {
                    System.Data.DataRow row = table.Rows[0];
                    DCAnalytics.Configuration config = new DCAnalytics.Configuration();
                    InitConfig(config, row);
                    config.Questionaires = new QuestionaireProvider(DbInfo).ConfigurationQuestionaires(config.OID);
                    config.Certifications = new CertificationProvider(DbInfo).ConfigurationCertifications(config.OID);
                    config.Inspections = new FieldInspectionProvider(DbInfo).ConfigurationFieldInspections(config.OID);
                    //config.Trainings = new TrainingProvider(DbInfo).GetTrainings(config.OID);
                    return config;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }

        private void InitConfig(Configuration configuration, DataRow row)
        {
            try
            {
                configuration.Key = row["guid"].ToString();
                configuration.Name = row["name"].ToString();
                configuration.FileName = row["filename"].ToString();
                configuration.Status = Int32.Parse(row["status"].ToString());
                configuration.Version = row["version"].ToString();
                configuration.Deleted = bool.Parse(row["deleted"].ToString());
                configuration.ConfigurationString = row["config"].ToString();
                configuration.OID = int.Parse(row["OID"].ToString());

                if (row["type"] != DBNull.Value)
                    configuration.Type = (ConfigurationTypes)Enum.Parse(typeof(ConfigurationTypes), row["type"].ToString());

                configuration.Client = new ClientProvider(DbInfo).GetClient(int.Parse(row["client_id"].ToString()));
                //configuration.Questionaires = new QuestionaireProvider(DbInfo).GetQuestionairesByConfig(configuration.OID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Configuration GetConfiguration(string key)
        {
            string query = $"select * from dsto_configuration where guid = '{key}'";
            var table = DbInfo.ExecuteSelectQuery(query);
            if (table.Rows.Count > 0 && table.Rows.Count == 1)
            {
                DataRow row = table.Rows[0];
                Configuration config = new Configuration();
                InitConfig(config, row);
                return config;
            }

            return null;
        }

        public List<Configuration> ClientConfigurations(int Id)
        {
            List<Configuration> configurations = new List<Configuration>();
            try
            {
                string query = $"select * from dsto_configuration where client_id = '{Id}' and Deleted=0";
                var table = DbInfo.ExecuteSelectQuery(query);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Configuration configuration = new Configuration();
                        InitConfig(configuration, row);
                        configuration.Users = new UserProvider(DbInfo).ConfigurationUsers(configuration.OID);
                        configurations.Add(configuration);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return configurations;
        }

        public List<Configuration> ClientMobileConfigurations(int Id)
        {
            List<Configuration> configurations = new List<Configuration>();
            try
            {
                string query = $"select * from dsto_configuration where client_id = '{Id}' and Deleted=0";
                var table = DbInfo.ExecuteSelectQuery(query);
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        Configuration configuration = new Configuration();
                        InitConfig(configuration, row);
                        configuration.Users = new UserProvider(DbInfo).ConfigurationUsers(configuration.OID);
                        configuration.Questionaires = new QuestionaireProvider(DbInfo).GetQuestionaires(configuration.OID);
                        configuration.Certifications = new CertificationProvider(DbInfo).GetCertifications(configuration.OID);
                        configuration.Inspections = new FieldInspectionProvider(DbInfo).GetFieldInspections(configuration.OID);
                        configuration.Trainings = new TrainingProvider(DbInfo).GetMobileConfigurationTrainings(configuration.OID);
                        configuration.Regions = new EnumListProvider(DbInfo).GetEnumList(configuration.OID, EnumListTypes.Region);
                        configuration.Products = new EnumListProvider(DbInfo).GetEnumList(configuration.OID, EnumListTypes.Product);
                        configuration.Prices = new EnumListProvider(DbInfo).GetEnumList(configuration.OID, EnumListTypes.Price);
                        configurations.Add(configuration);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return configurations;
        }

        public override bool Save(DCAnalyticsObject obj)
        {
            try
            {
                Configuration configuration = obj as Configuration;
                bool exists = RecordExists("dsto_configuration", configuration.Key);
                string Query = string.Empty;

                if (!exists)
                    Query = $"insert into dsto_configuration([guid],[name],[filename],[version],[status],[config],[client_id],[type]) values('{configuration.Key}','{configuration.Name}','{configuration.FileName}','{configuration.Version}',1,'{configuration.ToJson()}','{configuration.Client.OID}','{(int)configuration.Type}')";
                else
                    Query = $"update dsto_configuration set [name]='{configuration.Name}', [type]='{(int)configuration.Type}', [Deleted]='{configuration.Deleted}' where [guid]='{configuration.Key}'";
                return DbInfo.ExecuteNonQuery(Query) > -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteConfiguration(int id)
        {
            Configuration configuration = GetConfiguration(id);
            string query = $"delete from dsto_configuration where [oid]={id}";
            foreach (var s in configuration.Questionaires)
            {
                new QuestionaireProvider(DbInfo).DeleteQuestionaire(s.Key);
            }

            foreach (var c in configuration.Certifications)
                new CertificationProvider(DbInfo).Delete(c.OID);

            foreach (var inspection in configuration.Inspections)
                new FieldInspectionProvider(DbInfo).DeleteFieldInspection(inspection.OID);

            var rows = DbInfo.ExecuteNonQuery(query);
            return rows > -1;
        }
    }
}
