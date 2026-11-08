using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComputerMarketInventory.Models
{
    // DTO для отображения в DataGridView на MainForm
    public class EquipmentFlatModel
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceName { get; set; }
        public DateTime DisplayStartDate { get; set; }
        public int WearPercentage { get; set; }
        public decimal BasePrice { get; set; }   // НОВОЕ: базовая цена
        public string CategoryName { get; set; }
        public string StatusName { get; set; }

        // Расчётное свойство: цена со скидкой по износу (не хранится в БД)
        public decimal DiscountedPrice =>
            BasePrice * (1m - WearPercentage / 100m);
    }
}
