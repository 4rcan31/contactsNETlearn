using System;
using System.Collections.Generic;

namespace contactsNETlearn.Models;

public partial class Phone
{
    public int PhoneId { get; set; }

    public int? ContactId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string? PhoneType { get; set; }

    public virtual Contact? Contact { get; set; }
}
