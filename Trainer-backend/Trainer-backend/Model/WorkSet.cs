using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Trainer_backend.Model
{
    [Serializable]
    public class WorkSet: BaseEntity
    {
        [Required]
        [DataMember]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataMember]
        public virtual List<Set> Sets { get; set; } = new ();

        [DataMember]
        [JsonIgnore]
        public int RoutineId { get; set; }
    }
}
