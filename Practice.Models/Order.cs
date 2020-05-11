using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string OrderNumber { get; set; }
        [Required]
        public IList<OrderProduct> OrderProducts { get; set; }
        public int Amount { get; set; }

        [DefaultValue(StatusType.Active)]
        public StatusType Status { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedUtc { get; set; }
    }
}