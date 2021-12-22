namespace Book_API.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool sucesss { get; set; } = true;

        public string message { get; set; } = string.Empty;
    }
}
