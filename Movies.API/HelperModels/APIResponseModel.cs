namespace Movies.API.HelperModels
{
    public class APIResponseModel<T>
    {
        public bool Error { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
