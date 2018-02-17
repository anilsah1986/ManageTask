using ManageTaskApp.DataAccess.DBEntities;
using ManageTaskApp.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageTaskApp.Services.APIResponse
{
    public class APIResponse
    {
        public APIResponse()
        {
            data = new data();
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public data data { get; set; }
    }
    public class data
    {
        public ManageTask task { get; set; }
        public List<ManageTask> tasklist { get; set; }
        public string currentCreatedTaskId { get; set; }
    }
}
