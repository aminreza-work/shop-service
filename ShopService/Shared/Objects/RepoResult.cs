namespace ShopService.Shared.Objects
{

    public class RepoResult
    {
        public RepoResult() { }
        public RepoResult(bool success, string message)
        {
            IsSuccess = success;
            Message = message;
        }

        public RepoResult Error(string message) => new RepoResult(false, Message);
        public RepoResult OK() => new RepoResult(true, null);


        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class RepoResult<TData>
    {
        public RepoResult() { }
        public RepoResult(bool success, string message, TData data)
        {
            IsSuccess = success;
            Message = message;
            Data = data;
        }

        public RepoResult<TData> Error(string message) => new RepoResult<TData>(false, Message, default);
        public RepoResult<TData> OK(TData data) => new RepoResult<TData>(true, null, data);

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }
}
