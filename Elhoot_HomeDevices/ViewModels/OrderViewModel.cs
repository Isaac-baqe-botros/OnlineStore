﻿namespace Elhoot_HomeDevices.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public bool IsSelected { get; set; }  
        public string Statuse { get; set; }
        public DateTime? DateFree { get; set; }
        public string? Paypalce { get; set; }
    }
}
