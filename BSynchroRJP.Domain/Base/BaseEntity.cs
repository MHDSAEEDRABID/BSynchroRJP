using System.ComponentModel.DataAnnotations;

namespace BSynchroRJP.Domain.Base
{
    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public virtual TKey Id { get; protected set; }
        protected BaseEntity()
        {
        }

        protected BaseEntity(TKey id)
        {
            Id = id;
        }
    }

    public class BaseEntity 
    {
        [ConcurrencyCheck]
        public virtual string ConcurrencyStamp { get; private set; } = Guid.NewGuid().ToString();
    }
}
