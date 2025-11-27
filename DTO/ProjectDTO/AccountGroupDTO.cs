using System;

namespace DTO
{
    public class AccountGroupDTO
    {
        public int Ac_GrpCode { get; set; }
        public string Ac_Desc { get; set; }
        public char Ac_Type { get; set; }
        public char BP_Type { get; set; }
        public string Source_Module { get; set; }
        public string MainGroup { get; set; }
        public DateTime Action_Date { get; set; }
        public DateTime Action_Time { get; set; }
        public DateTime Action_Miti { get; set; }
        public string Ac_Schedul { get; set; }
        public string Action { get; set; }
    }
}
