using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class EntityDTO<TKey>
    {
        public TKey Id { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
