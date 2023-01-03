namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.FIFAManagerRequest
{
    public class FIFAManagerPlayerRequest
    {
        public int SourceId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string CommonName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int SourceNationId { get; set; }
        public int? SourceClubId { get; set; }
        public int? Rarity { get; set; }
        public string Position { get; set; }
        public string Foot { get; set; }
        public string AttackWorkRate { get; set; }
        public string DefenseWorkRate { get; set; }
        public string TotalStats { get; set; }
        public int Rating { get; set; }
        public int Pace { get; set; }
        public int Shooting { get; set; }
        public int Passing { get; set; }
        public int Dribbling { get; set; }
        public int Defending { get; set; }
        public int Physicality { get; set; }
        public bool IsActive { get; set; }
    }
}
