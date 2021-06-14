using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace Session_1
{
    class Manager
    {
        public static Frame MainFrame { get; set; }
        public static string myrole { get; set; }  
        public static SqlConnection connection { get; set; }
    }
}
