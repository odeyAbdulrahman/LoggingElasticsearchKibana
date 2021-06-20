using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging_Elasticsearch_Kibana.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public short Qty { get; set; }
        public double Price { get; set; }
        public string OwnerName { get; set; }

    }
}
