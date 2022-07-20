using QAProject.Business.Base;
using QAProject.DataAccess.Contracts;
using QAProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Business.Businesses;

public class RoleBusiness : BaseBusiness<Role>
{
	public RoleBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.RoleRepository!)
	{
	}
}
