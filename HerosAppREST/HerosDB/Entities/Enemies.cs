using System;
using System.Collections.Generic;

namespace HerosDB.Entities
{
    public partial class Enemies
    {
        public int Id { get; set; }
        public int? Heroid { get; set; }
        public int? Villainid { get; set; }

        public virtual Superpeople Hero { get; set; }
        public virtual Superpeople Villain { get; set; }
    }
}
