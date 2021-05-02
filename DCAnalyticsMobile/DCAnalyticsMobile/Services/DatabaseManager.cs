using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using DCAnalyticsMobile.Models;
using DCAnalyticsMobile.Views;

namespace DCAnalyticsMobile.Services
{
    public class DatabaseManager
    {
        SQLiteConnection dbConnection;
        public DatabaseManager()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();

            dbConnection.CreateTable<SQLiteQuestionaire>();
        }

        public List<SQLiteQuestionaire> GetSQLiteQuestionaires()
        {
            return dbConnection.Table<SQLiteQuestionaire>().ToList();
        }

        public SQLiteQuestionaire GetSQLiteQuestionaire(int ID)
        {
            return dbConnection.Table<SQLiteQuestionaire>().Where(i => i.ID == ID).FirstOrDefault();
        }

        public int SaveSQLiteQuestionaire(SQLiteQuestionaire sQLiteQuestionaire)
        {
            QSections._questionaireStatus = QuestionaireStatus.Modify;
            return dbConnection.Insert(sQLiteQuestionaire);
        }

        public int UpdateReport(Questionaire questionaire)
        {
            try
            {
                SQLiteQuestionaire sQLiteQuestionaire = this.GetSQLiteQuestionaires().Find(x => JsonConvert.DeserializeObject<Questionaire>(x.sqliteQuestionaire).Key == questionaire.Key);
                if (sQLiteQuestionaire != null)
                    return dbConnection.Execute($"UPDATE SQLiteQuestionaire SET sqliteQuestionaire = ? WHERE ID = ?", JsonConvert.SerializeObject(questionaire), sQLiteQuestionaire.ID);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public int DeleteQuestionaire(SQLiteQuestionaire sQLiteQuestionaire)
        {
            if(sQLiteQuestionaire != null)
                return dbConnection.Delete(sQLiteQuestionaire);

            return 0;
        }
    }
}
