namespace TI_Net_2025_DemoEntity.BLL.Exceptions
{
    public abstract class NotFoundException : DemoEntityException
    {
        public NotFoundException(Object content) : base(404, content)
        {
        }
    }
}
