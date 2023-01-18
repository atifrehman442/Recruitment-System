using Foundation;
using RecruitmentSystem.Connect;
using RecruitmentSystem.iOS;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqlitedbios))]
namespace RecruitmentSystem.iOS
{
    public class Sqlitedbios : Iconnect
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "mydatabase.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbPath, dbName);
            var db = new SQLiteConnection(path);
            return db;
        }
    }
}