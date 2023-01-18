using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentSystem.Model
{
    public class SignUpModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string User { get; set; }
    }
}
