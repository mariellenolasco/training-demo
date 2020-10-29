using System;
using System.Collections.Generic;

namespace HerosDB.Entities
{
    public partial class Superpeople
    {
        public Superpeople()
        {
            EnemiesHero = new HashSet<Enemies>();
            EnemiesVillain = new HashSet<Enemies>();
            Powers = new HashSet<Powers>();
        }

        public int Id { get; set; }
        public string Realname { get; set; }
        public string Workname { get; set; }
        public string Hideout { get; set; }
        public int? Chartype { get; set; }

        public virtual Charactertype ChartypeNavigation { get; set; }
        public virtual ICollection<Enemies> EnemiesHero { get; set; }
        public virtual ICollection<Enemies> EnemiesVillain { get; set; }
        public virtual ICollection<Powers> Powers { get; set; }
    }
}
