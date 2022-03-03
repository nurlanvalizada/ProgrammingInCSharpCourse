namespace Lesson30_WebApi.Data.Entitites
{
    public class BaseEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
