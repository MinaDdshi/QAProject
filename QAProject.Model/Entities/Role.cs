using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Model.Entities;

public class Role : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public string? Title { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public string? Description { get; set; }
    public virtual ICollection<UserRole>? UserRoles { get; set; }
}
