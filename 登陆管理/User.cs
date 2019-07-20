using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 宿舍管理系统
{
    public class User
    {
        public string Type { get; set; }
        public int Sno { get; set; }
        public string Pwd { get; set; }
        public User(int sno,string pwd,string type)
        {
            this.Sno = sno;
            this.Pwd = pwd;
            this.Type = type;
        }
    }
}
