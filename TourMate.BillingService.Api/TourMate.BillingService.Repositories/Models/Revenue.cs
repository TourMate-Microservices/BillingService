﻿using System;
using System.Collections.Generic;

namespace TourMate.BillingService.Repositories.Models;

public partial class Revenue
{
    public int RevenueId { get; set; }

    public int TourGuideId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal ActualReceived { get; set; }

    public decimal PlatformCommission { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool PaymentStatus { get; set; }

    public int InvoiceId { get; set; }
}
