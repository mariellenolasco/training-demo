using System;
using System.Collections.Generic;

namespace HerosDB.Entities
{
    public partial class Powers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Ownerid { get; set; }

        public virtual Superpeople Owner { get; set; }
    }
}
