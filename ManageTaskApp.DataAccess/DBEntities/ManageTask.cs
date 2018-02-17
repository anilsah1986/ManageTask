using System;
using System.Collections.Generic;
using System.Text;

namespace ManageTaskApp.DataAccess.DBEntities
{
    public class ManageTask : BaseEntity
    {
        public string Name { get; set; }
        public string Priority { get; set; }
        public DateTime Date { get; set; }
        public string EstimatedCost { get; set; }
        public string Description { get; set; }
    }
}
