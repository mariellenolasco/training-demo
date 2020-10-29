namespace HerosDB.Models
{
    public class Enemies
    {
        public int HeroID { get; set; }
        public SuperHero Hero { get; set; }
        public int VillainID { get; set; }
        public SuperVillain Villain { get; set; }
        public int EnemyID { get; set; }
    }

}