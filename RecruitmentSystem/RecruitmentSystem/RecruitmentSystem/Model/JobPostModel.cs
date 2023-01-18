using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentSystem.Model
{
    public class JobPostModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Vacancies { get; set; }
        public string Deadline { get; set; }
        public string UserName { get; set; }
    }
}
