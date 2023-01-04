using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Leagues
{
    public class LeagueListResponse : BaseResponse
    {
        public List<League> items { get; set; } = new();
    }

    public class League 
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class FIFAManagerResponse 
    {
        public int id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
