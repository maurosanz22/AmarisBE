﻿using System;

namespace Models
{
    public class Policies
    {
        public string Id { get; set; }
        public decimal AmountInsured { get; set; }
        public string Email { get; set; }
        public DateTime InceptionDate { get; set; }
        public bool InstallmentPayment { get; set; }
        public ApplicationUser Client { get; set; }
    }
}
