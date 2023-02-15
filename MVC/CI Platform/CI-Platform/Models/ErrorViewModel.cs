namespace CI_Platform.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}