using System;
using System.ComponentModel.DataAnnotations;

namespace REST.Models
{
    ///<summary>
    ///This class handles the relationship between Occupations and their topics
    ///</summary>.
    public class OccupationsTopicsJoin
    {
        [Key]
        public int JoinId { get; set; }
        public int OccupationsId { get; set; }
        public Occupation Occupations { get; set; }
        public int TopicsId { get; set; }
        public Topic Topics { get; set; }
        public OccupationsTopicsJoin()
        {
        }
    }
}


