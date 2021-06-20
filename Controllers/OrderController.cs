using Logging_Elasticsearch_Kibana.Model;
using Logging_Elasticsearch_Kibana.MokData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging_Elasticsearch_Kibana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MokOrders Mok;
        private readonly ILogger<OrderController> Logger;
        public OrderController(ILogger<OrderController> logger)
        {
            Mok = new MokOrders();
            Logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<OrderModel> GetAsync(int id)
        {
            try
            {
                var data = Mok.InsertOrders().GetOrder(id);
                int wid = data.Id;
                return Ok(data);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "----- an error has occurred  -----");
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<OrderModel> GetAsync()
        {
            try
            {
                return Ok(Mok.InsertOrders().GetOrders());
            }
            catch (Exception e)
            {
                Logger.LogError(e, "----- an error has occurred  -----");
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult PostAsync(OrderModel model)
        {
            try
            {
                Mok.InsertOrders().AddOrder(model);
                return Ok("Row Save Successfully");
            }
            catch (Exception e)
            {
                Logger.LogError("an error has occurred ", e.InnerException);
                return BadRequest(e.Message);
            }
        }
    }
}
