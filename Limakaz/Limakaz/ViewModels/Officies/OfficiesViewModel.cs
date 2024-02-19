using System.ComponentModel.DataAnnotations;

namespace Limakaz.ViewModels.Officies
{
    public class OfficiesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Adı əlavə edin.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yerləşdiyi yeri əlavə edin.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Açılış saatını əlavə edin.")]
        public DateTime OpeningTime { get; set; }

        [Required(ErrorMessage = "Bağlanış saatını əlavə edin.")]
        public DateTime ClosetingTime { get; set; }
    }
}
