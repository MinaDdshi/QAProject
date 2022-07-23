using FluentValidation;
using QAProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Common.Validations;

public class RoleValidator : AbstractValidator<Role>
{
	public RoleValidator() =>
		RuleFor(x => x.Title).NotEmpty();
}
