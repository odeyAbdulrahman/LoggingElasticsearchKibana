using Logging_Elasticsearch_Kibana.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging_Elasticsearch_Kibana.MokData
{
    public class MokOrders
    {
        public Dictionary<int, OrderModel> OrdersList = new Dictionary<int, OrderModel>(5);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public MokOrders InsertOrders()
        {
            if (OrdersList.Count < 5)
            {
                for (int i = 0; i < OrdersList.EnsureCapacity(5); i++)
                {
                    OrdersList.Add(1, new OrderModel { Id = 1, ItemName = $"Item_{i}", Qty = ((short)(i * OrdersList.Count)), Price = 100 * i, OwnerName = $"Owner {i}" });
                }
            }
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderModel GetOrder(int id)
        {
            return OrdersList.FirstOrDefault(x => x.Key == id).Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderModel> GetOrders()
        {
            return OrdersList.Values.ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void AddOrder(OrderModel model)
        {
            OrdersList.Add(model.Id, model);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void RemoveOrder(int id)
        {
            OrdersList.Remove(id);
        }
    }
}
