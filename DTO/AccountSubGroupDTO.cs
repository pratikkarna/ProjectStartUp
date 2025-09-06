using System;


namespace DTO
{
    public class AccountSubGroupDTO
    {
        public int SGrpCode { get; set; }
        public string SGrpDesc { get; set; }
        public int SGrpShortName { get; set; }
        public int Source_Module { get; set; }
        public DateTime Action_Date { get; set; }
        public DateTime Action_Time { get; set; }
        public DateTime Action_Miti { get; set; }
        public bool IsActive { get; set; }
        public bool Action { get; set; }

    }
}
