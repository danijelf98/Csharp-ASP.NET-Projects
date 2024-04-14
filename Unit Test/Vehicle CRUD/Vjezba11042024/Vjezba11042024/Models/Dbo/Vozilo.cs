using System.ComponentModel.DataAnnotations;
using Vjezba11042024.Models.Base;

namespace Vjezba11042024.Models.Dbo
{
    public class Vozilo : VoziloBase
    {
        [Key]
        public int Id { get; set; }
    }
}
