using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;

namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Player
{
    public class PlayerListResponse : BaseResponse
    {
        public List<Player> items { get; set; } = new();
    }

    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public int age { get; set; }
        public string common_name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public int nation { get; set; }
        public int? club { get; set; }
        public int? league { get; set; }
        public int? rarity { get; set; }
        public string position { get; set; }
        public string foot { get; set; }
        public string attack_work_rate { get; set; }
        public string defense_work_rate { get; set; }
        public string total_stats { get; set; }
        public int rating { get; set; }
        public int pace { get; set; }
        public int shooting { get; set; }
        public int passing { get; set; }
        public int dribbling { get; set; }
        public int defending { get; set; }
        public int physicality { get; set; }

    }
}


	

	
