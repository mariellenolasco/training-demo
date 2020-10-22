using System;
namespace HerosLib.Models
{
    /// <summary>
    /// Hero Class
    /// </summary>
    public class Hero
    {
        /// <summary>
        /// Hero identification
        /// </summary>
        /// <value>Greater than 0</value>
        public int HeroId { get; set; }
        public string HeroName { get; set; }
        public string SuperPowers { get; set; }
    }
}