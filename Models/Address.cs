using System;
using System.Collections.Generic;

namespace contactsNETlearn.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int? ContactId { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }

    public string? Country { get; set; }

    public virtual Contact? Contact { get; set; }
}
