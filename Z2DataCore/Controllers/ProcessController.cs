using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z2DataCore.Models;
using Z2DataCore.Repository;
using Z2DataCore.Utility;

namespace Z2DataCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        public ProcessController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        public IActionResult GetAllProccess()
        {
            var mesg = new Message<List<Process>>();
            var data = DbClientFactory<ProcessDbClient>.Instance.GetProcess(appSettings.Value.DbConnection);
            mesg.Data = data;
            mesg.IsSuccess = true;
            return Ok(mesg);
        }

        [HttpPost("SaveProcess")]
        public IActionResult SaveProcess([FromBody] Process model)
        {
            var msg = new Message<Process>();
            var data = DbClientFactory<ProcessDbClient>.Instance.SaveProcess(model, appSettings.Value.DbConnection);

            msg.IsSuccess = true;
            msg.ReturnMessage = "Process is saved";
            msg.Data = model;

            return Ok(msg);
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] Process model)
        {
            var msg = new Message<Process>();
            var data = DbClientFactory<ProcessDbClient>.Instance.UpdateProcess(model, appSettings.Value.DbConnection);

            msg.IsSuccess = true;
            msg.ReturnMessage = "Process is saved";
            msg.Data = model;

            return Ok(msg);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Process model)
        {
            var msg = new Message<Good>();
            var data = DbClientFactory<ProcessDbClient>.Instance.DeleteProcess(model.Id, appSettings.Value.DbConnection);

            if (data != null || data!="")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Process was Deleted";
            }
            else
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = "Invalid Record";
            }
            return Ok(msg);

        }






        Z2DataContext db = new Z2DataContext();

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(db.Goods.Include(s=>s.InventoryProcesses).ToList());
        //}

    }
}
