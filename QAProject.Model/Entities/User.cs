using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Model.Entities;

public class User : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public string? Username { get; set; }
    public string? Password { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public int PersonId { get; set; }
    [ForeignKey("PersonId")]
    public Person? Person { get; set; }
    public virtual ICollection<UserRole>? UserRoles { get; set; }
}
