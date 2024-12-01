﻿namespace InanceMVC.Models
{
    public class Order : BaseEntity
    {
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientEmail { get; set; }
        public string Problem { get; set; }
        public int ServiceId { get; set; }
        public Service? Service { get; set; }
        public int MasterId { get; set; }
        public Master? Master { get; set; }
    }
}
