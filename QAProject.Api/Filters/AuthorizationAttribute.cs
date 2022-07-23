using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Api.Filters;

public class AuthorizationAttribute : TypeFilterAttribute
{
	public AuthorizationAttribute(params string[] roles) : base(typeof(AuthorizationFilter)) =>
		Arguments = new object[] { roles };
}
