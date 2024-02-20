using Limakaz.Database.Abstracts;

namespace Limakaz.Database.DomainModels
{
    public class Officies : IEntity
    {

        public string Name { get; set; }
        public string Location { get; set; }
        public string WorkingDays { get; set; }
        public string OpeningTime { get; set; }
        public string ClosetingTime { get;  set; }


    }
}
