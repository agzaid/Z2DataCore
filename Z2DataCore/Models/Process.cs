using System;
using System.Collections.Generic;

#nullable disable

namespace Z2DataCore.Models
{
    public partial class Process
    {
        public Process()
        {
            InventoryProcesses = new HashSet<InventoryProcess>();
        }

        public int Id { get; set; }
        public DateTime? DateProcess { get; set; }
        public string CustomerName { get; set; }
        public int? ProcessType { get; set; }

        public virtual ICollection<InventoryProcess> InventoryProcesses { get; set; }
    }
}
