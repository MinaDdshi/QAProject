using QAProject.Business.Base;
using QAProject.Common.ViewModels;
using QAProject.DataAccess.Contracts;
using QAProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Business.Businesses;

public class QuestionBusiness : BaseBusiness<Question>
{
	private readonly IUnitOfWork _unitOfWork;

	public QuestionBusiness(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.QuestionRepository!) =>
		_unitOfWork = unitOfWork;

	public async Task<Response?> Upvote(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.QuestionRepository!.Upvote(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = Id,
			Message = "Added"
		};
	}

	public async Task<Response?> Downvote(int Id, CancellationToken cancellationToken)
	{
		await _unitOfWork.QuestionRepository!.Downvote(Id);
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = Id,
			Message = "Decreased"
		};

	}

	public async Task<Response?> IsUserUpvoteExist(int Id, CancellationToken cancellationToken = new())
	{
		var user = await _unitOfWork.QuestionRepository!.IsUserUpvoteExist(Id, cancellationToken);

		if (!user)
        {
			await _unitOfWork.QuestionRepository!.Upvote(Id);
			await _unitOfWork.CommitAsync(cancellationToken);

			return new Response
			{
				IsSuccess = true,
				ChangedId = Id,
				Message = "Upvote"
			};
		}
		else
        {
			return new Response
			{
				IsSuccess = false,
				ChangedId = Id,
				Message = "User Not Found"
			};
		}
	}
	public async Task<Response?> IsUserDownvoteExist(int Id, CancellationToken cancellationToken = new())
	{
		var user = await _unitOfWork.QuestionRepository!.IsUserDownvoteExist(Id, cancellationToken);

		if (!user)
		{
			await _unitOfWork.QuestionRepository!.Downvote(Id);
			await _unitOfWork.CommitAsync(cancellationToken);

			return new Response
			{
				IsSuccess = true,
				ChangedId = Id,
				Message = "Downvote"
			};
		}
		else
		{
			return new Response
			{
				IsSuccess = false,
				ChangedId = Id,
				Message = "User Not Found"
			};
		}
	}

	public async Task<Response?> RankQuestion(int Id, CancellationToken cancellationToken)
	{
		var question = await _unitOfWork.QuestionRepository!.LoadByQuestionId(Id);
		var diffrence = question!.Upvote - question.Downvote;

		if (diffrence < 0)
        {
			question.RankQuestion -= diffrence;
        }
		else if (diffrence > 0)
        {
			question.RankQuestion += diffrence;
        }
		else
        {
			return new Response
			{
				IsSuccess = false,
				ChangedId = Id,
				Message = "No Change"
			};

		}
		await _unitOfWork.CommitAsync(cancellationToken);
		return new Response
		{
			IsSuccess = true,
			ChangedId = Id,
			Message = "Changed"
		};
	}
}
