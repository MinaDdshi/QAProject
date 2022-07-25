using QAProject.DataAccess.Base;
using QAProject.DataAccess.Context;
using QAProject.Model.Entities;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.DataAccess.Repositories;

public class QuestionRepository : BaseRepository<Question>
{
    private readonly QAProjectContext _context;

    public QuestionRepository(QAProjectContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
        _context = context;

    public async Task Upvote(int Id, CancellationToken cancellationToken = new())
    {
        var question = _context.Questions!.FirstOrDefault(x => x.Id == Id);
        question!.Upvote = question.Upvote + 1;
        await Task.FromResult(_context.Questions!.Update(question));

    }

    public async Task Downvote(int Id, CancellationToken cancellationToken = new())
    {
        var question = _context.Questions!.FirstOrDefault(x => x.Id == Id);
        question!.Downvote = question.Downvote + 1;
        await Task.FromResult(_context.Questions!.Update(question));
    }
}