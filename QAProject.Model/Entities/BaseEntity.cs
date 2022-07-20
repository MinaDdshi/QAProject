using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Model.Entities;

public class BaseEntity
{
	public BaseEntity() =>
	CreationDate = LastUpdated = DateTime.Now;
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Sieve(CanFilter = true, CanSort = true)]
	public int Id { get; set; }
	[Sieve(CanSort = true)]
	public DateTime CreationDate { get; set; }
	[Sieve(CanSort = true)]
	public DateTime LastUpdated { get; set; }
	public bool IsDeleted { get; set; } = false;
}
