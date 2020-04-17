using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Timers;
namespace WebServiceSV1.Models
{
    public class TodoItem
    {
        public const string cs = "Persist Security Info=False;Integrated Security=true;Initial Catalog=TodoRun;server=(local)";
        public const string ms = "Persist Security Info=False;Integrated Security=true;Initial Catalog=TaskArchive;server=(local)";
        public string CurrentCounter { get; set; }
        public string UserID { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Flag { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        
    }
  
   
}
