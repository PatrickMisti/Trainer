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
        public string Name { get; set; }

        [Required]
        [DataMember]
        public List<Set> Sets { get; set; }

        [DataMember]
        [JsonIgnore]
        public int RoutineId { get; set; }
    }
}
