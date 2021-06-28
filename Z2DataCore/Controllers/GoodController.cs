﻿using Microsoft.AspNetCore.Http;
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
    public class GoodController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        public GoodController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        public IActionResult GetAllGoods()
        {
            var data = DbClientFactory<UserDbClient>.Instance.GetGoods(appSettings.Value.DbConnection);
            return Ok(data);
        }

        [HttpPost("SaveGood")]
        public IActionResult SaveUser([FromBody] Good model)
        {
            var msg = new Message<Good>();
            var data = DbClientFactory<UserDbClient>.Instance.SaveGood(model, appSettings.Value.DbConnection);

            msg.IsSuccess = true;
            msg.ReturnMessage = "Good is saved";
            msg.Data = model;

            return Ok(msg);
        }
        [HttpPost("update")]
        public IActionResult Update([FromBody] Good model)
        {
            var msg = new Message<Good>();
            var data = DbClientFactory<UserDbClient>.Instance.UpdateGood(model, appSettings.Value.DbConnection);

            msg.IsSuccess = true;
            msg.ReturnMessage = "Good is saved";
            msg.Data = model;

            return Ok(msg);
        }
        [HttpDelete]
        public IActionResult Delete([FromBody] Good model)
        {
            var msg = new Message<Good>();
            var data = DbClientFactory<UserDbClient>.Instance.DeleteGood(model.Id, appSettings.Value.DbConnection);

            if (data != null || data!="")
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Good was Deleted";
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
