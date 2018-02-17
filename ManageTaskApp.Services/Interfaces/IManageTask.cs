using ManageTaskApp.DataAccess.DBEntities;
using ManageTaskApp.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManageTaskApp.Services.Interfaces
{
    public interface IManageTask
    {
        APIResponse.APIResponse GetAllTask();
        APIResponse.APIResponse GetTaskById(long id);
        APIResponse.APIResponse AddTask(ManageTask model);
        APIResponse.APIResponse UpdateTask(ManageTask model);
        APIResponse.APIResponse DeleteTask(long id);
    }
}
