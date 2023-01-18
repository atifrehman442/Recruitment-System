using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitmentSystem.Connect
{
    public interface Iconnect
    {
        SQLiteConnection GetConnection();
    }
}
