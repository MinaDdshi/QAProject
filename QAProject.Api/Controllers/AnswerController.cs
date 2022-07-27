using Microsoft.AspNetCore.Mvc;
using QAProject.Api.Base;
using QAProject.Business.Businesses;
using QAProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : BaseController<Answer>
{
    private readonly AnswerBusiness? _answerBusiness;

    public AnswerController(AnswerBusiness answerBusiness) : base(answerBusiness) =>

    _answerBusiness = answerBusiness;

    [HttpPut]
    [Route("Upvote")]
    public async Task<ActionResult> Upvote(int Id, CancellationToken cancellationToken)
    {
        await _answerBusiness!.IsUserUpvoteExist(Id, cancellationToken);
        await _answerBusiness!.Upvote(Id, cancellationToken);
        await _answerBusiness!.RankAnswer(Id, cancellationToken);
        return Ok();
    }

    [HttpPut]
    [Route("Downvote")]
    public async Task<ActionResult> Downvote(int Id, CancellationToken cancellationToken)
    {
        await _answerBusiness!.IsUserDownvoteExist(Id, cancellationToken);
        await _answerBusiness!.Downvote(Id, cancellationToken);
        await _answerBusiness!.RankAnswer(Id, cancellationToken);
        return Ok();
    }

    [HttpPut]
    [Route("IsCorrect")]
    public async Task<ActionResult> IsCorrect(int Id, CancellationToken cancellationToken)
    {
        await _answerBusiness!.IsCorrect(Id, cancellationToken);
        return Ok();
    }

    //[HttpPut]
    //[Route("IsUserUpvoteExist")]
    //public async Task<ActionResult> IsUserUpvoteExist(int Id, CancellationToken cancellationToken)
    //{
    //    await _answerBusiness!.IsUserUpvoteExist(Id, cancellationToken);
    //    return Ok();
    //}
    
    //[HttpPut]
    //[Route("IsUserDownvoteExist")]
    //public async Task<ActionResult> IsUserDownvoteExist(int Id, CancellationToken cancellationToken)
    //{
    //    await _answerBusiness!.IsUserDownvoteExist(Id, cancellationToken);
    //    return Ok();
    //}
}
