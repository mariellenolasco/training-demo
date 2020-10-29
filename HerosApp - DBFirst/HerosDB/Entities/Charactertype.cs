using System;
using System.Collections.Generic;

namespace HerosDB.Entities
{
    public partial class Charactertype
    {
        public Charactertype()
        {
            Superpeople = new HashSet<Superpeople>();
        }

        public int Id { get; set; }
        public string Chartype { get; set; }

        public virtual ICollection<Superpeople> Superpeople { get; set; }
    }
}
