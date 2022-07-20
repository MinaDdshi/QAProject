using QAProject.Business.Base;
using QAProject.DataAccess.Contracts;
using QAProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Business.Businesses;

public class CommentAnswerBusiness : BaseBusiness<CommentAnswer>
{
	public CommentAnswerBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.CommentAnswerRepository!)
	{
	}
}
