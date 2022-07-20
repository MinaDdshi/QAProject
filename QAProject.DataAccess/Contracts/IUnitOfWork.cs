using QAProject.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.DataAccess.Contracts;

public interface IUnitOfWork
{
	UserRoleRepository? UserRoleRepository { get; }
	PersonRepository? PersonRepository { get; }
	RoleRepository? RoleRepository { get; }
	UserRepository? UserRepository { get; }
	QuestionRepository? QuestionRepository { get; }
	AnswerRepository? AnswerRepository { get; }
	CommentQuestionRepository? CommentQuestionRepository { get; }
	CommentAnswerRepository? CommentAnswerRepository { get; }

	int Commit();

	Task<int> CommitAsync(CancellationToken cancellationToken);
}