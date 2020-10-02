using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Aws.Entities
{
    public abstract class BaseEntity
    {
        [Column(Order=100)]
        public virtual string CreatedBy { get; protected set; }
        [Column(Order=101)]
        public virtual string LastUpdatedBy { get; protected set; }
        [Column(Order=102)]
        public virtual DateTime CreatedDate { get; protected set; }
        [Column(Order=103)]
        public virtual DateTime LastUpdateDate { get; protected set; }

    }
}