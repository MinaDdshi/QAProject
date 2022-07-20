using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Model.Entities;

public class UserRole : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public int RoleId { get; set; }
    [ForeignKey("RoleId")]
    public Role? Role { get; set; }
}
