namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base
{
    public class BaseResponse
    {      
        public Pagination pagination { get; set; }
    }

    public class Pagination
    {
        public int countCurrent { get; set; }
        public int countTotal { get; set; }
        public int pageCurrent { get; set; }
        public int pageTotal { get; set; }
        public int itemsPerPage { get; set; }
    }
}


