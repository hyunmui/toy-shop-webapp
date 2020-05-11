using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        [Required]
        public Order Order { get; set; }
        [Required]
        public Product Product { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
        
        [DefaultValue(StatusType.Active)]
        public StatusType Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedUtc { get; set; }
    }
}