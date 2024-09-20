using System;
using System.Collections.Generic;

namespace contactsNETlearn.Models;

public partial class Email
{
    public int EmailId { get; set; }

    public int? ContactId { get; set; }

    public string Email1 { get; set; } = null!;

    public string? EmailType { get; set; }

    public virtual Contact? Contact { get; set; }
}
