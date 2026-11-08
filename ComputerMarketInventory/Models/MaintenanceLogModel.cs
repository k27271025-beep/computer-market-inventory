using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMarketInventory.Models
{
    public class MaintenanceLogModel
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int WorkTypeId { get; set; }
        public System.DateTime WorkDate { get; set; }
        public int EmployeeId { get; set; }
        public string Notes { get; set; }
        public decimal ServicePrice { get; set; }  // НОВОЕ: стоимость обслуживания
    }
}
