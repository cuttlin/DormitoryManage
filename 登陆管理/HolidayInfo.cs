using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 宿舍管理系统
{
    public class HolidayInfo
    {
        public int Sno { get; set; }
        public DateTime LeaveTime { get; set; }
        public DateTime ArriveTime { get; set; }
        public string State { get; set; }
        public HolidayInfo(int sno,DateTime leavetime,DateTime arrivetime,string state)
        {
            this.Sno = sno;
            this.LeaveTime = leavetime;
            this.ArriveTime = arrivetime;
            this.State = state;
        }
    }
}
