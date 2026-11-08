using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerMarketInventory.Models
{
    public class MaintenanceFlatModel
    {
        public int LogId { get; set; }
        public string DeviceName { get; set; }
        public string SerialNumber { get; set; }
        public string CategoryName { get; set; }
        public string WorkType { get; set; }
        public System.DateTime WorkDate { get; set; }
        public string EmployeeName { get; set; }
        public string Notes { get; set; }
        public decimal ServicePrice { get; set; }
        public int WearPercentage { get; set; }
        public string StatusName { get; set; }
    }
}
