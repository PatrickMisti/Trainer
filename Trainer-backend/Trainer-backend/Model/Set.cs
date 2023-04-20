using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Trainer_backend.Model
{
    [Serializable]
    public class Set: BaseEntity
    {
        [Required]
        [DataMember]
        public double Weight { get; set; }
        [Required]
        [DataMember]
        public int Repetition { get; set; }
        [DataMember]
        public int WorkSetId { get; set; }
    }
}
