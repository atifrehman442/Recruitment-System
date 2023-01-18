using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentSystem.Model
{
    public class ApplicationModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Qualification { get; set; }
        public string CurrentlyEmployee { get; set; }
        public string CurrentSalary { get; set; }
        public string ExpectedSalary { get; set; }
        public string Relocate { get; set; }
        public string ManagerName { get; set; }
        public string ApplicantName { get; set; }
        public string PostName { get; set; }
    }
}
