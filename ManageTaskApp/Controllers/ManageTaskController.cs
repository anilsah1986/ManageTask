using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageTaskApp.DataAccess.Data;
using ManageTaskApp.DataAccess.DBEntities;
using ManageTaskApp.Services.APIResponse;
using ManageTaskApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ManageTaskApp.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/task/[Action]")]
    public class ManageTaskController : Controller
    {
        private readonly IManageTask _IManageTask;
        private APIResponse response;
        private readonly JsonSerializerSettings _serializerSettings;

        public ManageTaskController(IManageTask IManageTask)
        {
            _IManageTask = IManageTask;
            response = new APIResponse();
            _serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                response = _IManageTask.GetAllTask();
                var json = JsonConvert.SerializeObject(response, _serializerSettings);
                return new OkObjectResult(json);
            }
            catch { throw; }

        }

        [HttpGet]
        public IActionResult GetById(long id)
        {
            try
            {
                response = _IManageTask.GetTaskById(id);
                var json = JsonConvert.SerializeObject(response, _serializerSettings);
                return new OkObjectResult(json);
            }
            catch { throw; }
        }

        [HttpPost]
        public IActionResult Create([FromBody] ManageTask model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            try
            {
                response = _IManageTask.AddTask(model);
                var json = JsonConvert.SerializeObject(response, _serializerSettings);
                return new OkObjectResult(json);
            }
            catch { throw; }
        }

        [HttpPost]
        public IActionResult Update([FromBody] ManageTask model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            try
            {
                response = _IManageTask.UpdateTask(model);
                var json = JsonConvert.SerializeObject(response, _serializerSettings);
                return new OkObjectResult(json);
            }
            catch { throw; }
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            try
            {
                response = _IManageTask.DeleteTask(id);
                var json = JsonConvert.SerializeObject(response, _serializerSettings);
                return new OkObjectResult(json);
            }
            catch { throw; }
        }
    }
}

