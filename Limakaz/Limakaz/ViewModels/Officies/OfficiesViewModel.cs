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

        [Required(ErrorMessage = "Çalışma günlərini qeyd edin.")]
        public string WorkingDays { get; set; }

        [Required(ErrorMessage = "Açılış saatını əlavə edin.")]
        public string OpeningTime { get; set; }

        [Required(ErrorMessage = "Bağlanış saatını əlavə edin.")]
        public string ClosetingTime { get; set; }
    }
}
