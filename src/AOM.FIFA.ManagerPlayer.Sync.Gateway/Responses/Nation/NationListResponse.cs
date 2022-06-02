using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Nation
{
    public class NationListResponse : BaseResponse
    {
        public List<Nation> items { get; set; } = new();
    }

    public class Nation
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
