using System;
using System.Collections.Generic;

namespace TourMate.BillingService.Repositories.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public float Price { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string PaymentType { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public int AccountId { get; set; }

    public int? MembershipPackageId { get; set; }

    public int? InvoiceId { get; set; }
}
