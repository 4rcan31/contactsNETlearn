using System;
using System.Collections.Generic;

namespace contactsNETlearn.Models;

public partial class Contact
{
    public int ContactId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Email> Emails { get; set; } = new List<Email>();

    public virtual ICollection<Phone> Phones { get; set; } = new List<Phone>();

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
