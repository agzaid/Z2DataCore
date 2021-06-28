using System;
using System.Collections.Generic;

#nullable disable

namespace Z2DataCore.Models
{
    public partial class InventoryProcess
    {
        public int Id { get; set; }
        public int? GoodId { get; set; }
        public int? Count { get; set; }
        public int? Cost { get; set; }
        public DateTime? Date { get; set; }
        public int? ProcessId { get; set; }

        public virtual Good Good { get; set; }
        public virtual Process Process { get; set; }
    }
}
