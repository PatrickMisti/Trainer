using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Trainer_backend.Model
{
    [Serializable]
    public class Routine: BaseEntity
    {
        [DataMember]
        public virtual List<WorkSet> WorkSets { get; set; } = new ();
        [Required]
        [DataMember]
        public DateTime Date { get; set; }
    }
}
