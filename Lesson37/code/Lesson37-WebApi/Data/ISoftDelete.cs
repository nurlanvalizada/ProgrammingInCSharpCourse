namespace Lesson30_WebApi.Data
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
