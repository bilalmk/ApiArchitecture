using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIArchitecture.Settings
{
    public class MySqlSettings
    {
        public string Server { get; init; }
        public string Database { get; init; }
        public string User { get; init; }
        public string Password { get; init; }

        public string ConnectionString => $"server={Server};database={Database};user={User};password={Password}";
    }
}
