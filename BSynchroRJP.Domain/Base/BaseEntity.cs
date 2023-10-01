using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual string ConcurrencyStamp { get; private set; } = Guid.NewGuid().ToString();
    }
}
