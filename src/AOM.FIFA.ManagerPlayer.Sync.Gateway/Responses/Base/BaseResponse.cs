namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base
{
    public class BaseResponse
    {
        public int count { get; set; }
        public int count_total { get; set; }
        public int page { get; set; }
        public int page_total { get; set; }
        public int items_per_page { get; set; }
    }
}
