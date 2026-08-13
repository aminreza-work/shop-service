namespace ShopService.Shared.Objects
{

    public class RepoResult
    {
        public RepoResult(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class RepoResult<TData>
    {
        public RepoResult(bool success, string message, TData data)
        {
            IsSuccess = success;
            Message = message;
            Data = data;
        }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }
}
