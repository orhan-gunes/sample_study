namespace SampleStudy.Domain
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "İşlem başarılıdır.";
        public string ErrorCode { get; set; }
        public string RequestId { get; set; } = Guid.NewGuid().ToString();
        public object Data { get; set; }
    }

    public class BaseResponse<T> : BaseResponse
    {
        public new T Data { get; set; }
    }
}
