using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Training
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _databaseConnection;
        private static object _lock = new object();

        public string ConnectionString { get; set; }
        private DatabaseConnection()
        {
            ConnectionString = new Random().Next().ToString();
        }

        public static DatabaseConnection Instance
        {
            get
            {

                if (_databaseConnection == null)
                {
                    lock (_lock)
                    {
                        if (_databaseConnection == null)
                        {
                            _databaseConnection = new DatabaseConnection();
                        }
                    }
                }

                return _databaseConnection;
            }
        }
    }
}
