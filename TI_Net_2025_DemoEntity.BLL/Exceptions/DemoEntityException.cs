namespace TI_Net_2025_DemoEntity.BLL.Exceptions
{
    public abstract class DemoEntityException: Exception
    {
        public int StatusCode { get; set; }
        public Object Content { get; set; } = null!;

        public DemoEntityException(int status, Object content)
        {
            StatusCode = status;
            Content = content;
        }
    }
}
