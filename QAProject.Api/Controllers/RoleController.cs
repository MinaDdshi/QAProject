using QAProject.Api.Base;
using QAProject.Business.Contract;
using QAProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Api.Controllers;

public class RoleController : BaseController<Role>
{
	public RoleController(IBaseBusiness<Role> business) : base(business)
	{
	}
}
