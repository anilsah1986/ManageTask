using System;
using System.Collections.Generic;
using System.Text;

namespace ManageTaskApp.ViewModel.ViewModel
{
    public class TaskViewModel
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public DateTime Date { get; set; }
        public string EstimatedCost { get; set; }
        public string Description { get; set; }
    }
}
