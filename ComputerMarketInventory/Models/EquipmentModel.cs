using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMarketInventory.Models
{
    // Модель, точно повторяющая таблицу DemoEquipments в БД для INSERT/UPDATE
    public class EquipmentModel
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public int CategoryId { get; set; }
        public string SerialNumber { get; set; }
        public System.DateTime DisplayStartDate { get; set; }
        public int WearPercentage { get; set; }
        public int StatusId { get; set; }
        public decimal BasePrice { get; set; }  
    }
}
