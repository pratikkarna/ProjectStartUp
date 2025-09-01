using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountSubGroupDAO
    {
        private readonly string connectionString;

        public AccountSubGroupDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

    }
}
