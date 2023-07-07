using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.AuditLog
{
    [Table("AuditLogEvent")]
    public class AuditLogEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("event_type")]
        public string? EventType { get; set; }

        [Column("time_stamp")]
        public DateTime? Timestamp { get; set; }

        [Column("user")]
        public string? User { get; set; }

        [Column("event_data")]
        public string? EventData { get; set; }
    }
}
