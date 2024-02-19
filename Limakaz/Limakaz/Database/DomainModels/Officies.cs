using Limakaz.Database.Abstracts;

namespace Limakaz.Database.DomainModels
{
    public class Officies : IEntity
    {

        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime ClosetingTime { get;  set; }


    }
}
