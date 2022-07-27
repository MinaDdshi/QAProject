using Microsoft.EntityFrameworkCore;
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

public class AnswerRepository : BaseRepository<Answer>
{
    private readonly QAProjectContext _context;

    public AnswerRepository(QAProjectContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
        _context = context;

    public async Task Upvote(int Id)
    {
        var answer = _context.Answers!.FirstOrDefault(x => x.Id == Id);
        answer!.Upvote = answer.Upvote + 1;
        await Task.FromResult(_context.Answers!.Update(answer));
    }

    public async Task Downvote(int Id)
    {
        var answer = _context.Answers!.FirstOrDefault(x => x.Id == Id);
        answer!.Downvote = answer.Downvote + 1;
        await Task.FromResult(_context.Answers!.Update(answer));
    }

    public async Task IsCorrect(int Id)
    {
        var answer = _context.Answers!.FirstOrDefault(x => x.Id == Id);
        answer!.IsCorrectAnswer = true;
        await Task.FromResult(_context.Answers!.Update(answer));
    }

    public async Task<bool> IsUserUpvoteExist(int Id, CancellationToken cancellationToken = new()) =>
        await _context.VoteQuestions!
            .AnyAsync(x => x.UserId == Id, cancellationToken);


    public async Task<bool> IsUserDownvoteExist(int Id, CancellationToken cancellationToken = new()) =>
        await _context.VoteQuestions!
            .AnyAsync(x => x.UserId == Id, cancellationToken);

    public async Task<Answer?> LoadByAnswerId(int Id, CancellationToken cancellationToken = new()) =>
       (await _context.Answers!
           .SingleOrDefaultAsync(x => x.Id == Id, cancellationToken))!;
}
