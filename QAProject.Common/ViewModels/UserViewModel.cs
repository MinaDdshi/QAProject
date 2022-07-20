using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Common.ViewModels;

public class UserViewModel
{
	public int Id { get; set; }

	public string? Username { get; set; }

	public string? PersonFullName { get; set; }

	public ICollection<string>? Roles { get; set; }
}

