using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWeblog.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }

        public List<Log> Logs { get; set; }

    }
    public class Log
    {
        public int LogID { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }


        public Member Member { get; set; }
    }
}
