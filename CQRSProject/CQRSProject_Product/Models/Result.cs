namespace CQRSProject_Product.Product
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public static Result<T> Success(T data, string message = "Success")
        {
            return new Result<T> { IsSuccess = true, Data = data, ErrorMessage = message };
        }
        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T> { IsSuccess = false, ErrorMessage = errorMessage, Data = default };
        }
    }
}
