using System;
using System.Collections.Generic;

#nullable disable

namespace Z2DataCore.Models
{
    public partial class Good
    {
        public Good()
        {
            InventoryProcesses = new HashSet<InventoryProcess>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InventoryProcess> InventoryProcesses { get; set; }
    }
}
