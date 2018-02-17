using ManageTaskApp.DataAccess.Data;
using ManageTaskApp.Services.APIResponse;
using ManageTaskApp.Services.Interfaces;
using ManageTaskApp.ViewModel.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ManageTaskApp.DataAccess.DBEntities;

namespace ManageTaskApp.Services.Services
{
    public class ManageTaskService : IManageTask
    {
        private readonly ManageTaskContext _context;
        private APIResponse.APIResponse response;
        public ManageTaskService(ManageTaskContext context)
        {
            _context = context;
            response = new APIResponse.APIResponse();
        }

        public APIResponse.APIResponse GetAllTask()
        {
            try
            {
                List<ManageTask> tasklist = _context.ManageTask.ToList();
                response.data.tasklist = tasklist;
                response.StatusCode = StaticResource.StaticResource.successStatusCode;
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.StaticResource.failStatusCode;
                response.Message = StaticResource.StaticResource.SomethingWrong;
                throw;
            }
            return response;
        }

        public APIResponse.APIResponse GetTaskById(long id)
        {
            try
            {
                response.data.task = _context.ManageTask.FirstOrDefault(t => t.Id == id);
                if (response.data.task == null)
                {
                    response.Message = StaticResource.StaticResource.NoDataFound;
                }
                response.StatusCode = StaticResource.StaticResource.successStatusCode;
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.StaticResource.failStatusCode;
                response.Message = StaticResource.StaticResource.SomethingWrong;
                throw;
            }
            return response;
        }

        public APIResponse.APIResponse AddTask(ManageTask model)
        {
            try
            {
                long id = model.Id;
                ManageTask data = _context.ManageTask.FirstOrDefault(t => t.Id == id);
                if (data == null)
                {
                    _context.ManageTask.Add(model);
                    _context.SaveChanges();
                    if (model.Id > 0)
                    {
                        response.StatusCode = StaticResource.StaticResource.successStatusCode;
                        response.data.currentCreatedTaskId = model.Id.ToString();
                    }
                    else
                    {
                        response.StatusCode = StaticResource.StaticResource.failStatusCode;
                    }
                }
                else
                {
                    response.StatusCode = StaticResource.StaticResource.successStatusCode;
                    response.Message = StaticResource.StaticResource.SomethingWrong;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.StaticResource.failStatusCode;
                response.Message = StaticResource.StaticResource.SomethingWrong;
            }
            return response;
        }

        public APIResponse.APIResponse UpdateTask(ManageTask model)
        {
            try
            {
                _context.ManageTask.Update(model);
                _context.SaveChanges();
                response.StatusCode = StaticResource.StaticResource.successStatusCode;
                response.data.currentCreatedTaskId = model.Id.ToString();
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.StaticResource.failStatusCode;
                response.Message = StaticResource.StaticResource.SomethingWrong;
                throw;
            }
            return response;
        }

        public APIResponse.APIResponse DeleteTask(long id)
        {
            try
            {
                ManageTask data = _context.ManageTask.FirstOrDefault(t => t.Id == id);
                if (data != null)
                {
                    _context.ManageTask.Remove(data);
                    _context.SaveChanges();
                    response.StatusCode = StaticResource.StaticResource.successStatusCode;
                }
                else
                {
                    response.StatusCode = StaticResource.StaticResource.failStatusCode;
                    response.Message = StaticResource.StaticResource.SomethingWrong;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = StaticResource.StaticResource.failStatusCode;
                response.Message = StaticResource.StaticResource.SomethingWrong;
                throw;
            }
            return response;
        }
    }
}
