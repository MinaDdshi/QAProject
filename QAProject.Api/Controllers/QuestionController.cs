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
public class QuestionController : BaseController<Question>
{
    private readonly QuestionBusiness? _questionBusiness;

    public QuestionController(QuestionBusiness questionBusiness) : base(questionBusiness) =>

    _questionBusiness = questionBusiness;

    [HttpPut]
    [Route("Upvote")]
    public async Task<ActionResult> Upvote(int Id, CancellationToken cancellationToken)
    {
        await _questionBusiness!.IsUserUpvoteExist(Id, cancellationToken);
        await _questionBusiness!.Upvote(Id, cancellationToken);
        await _questionBusiness!.RankQuestion(Id, cancellationToken);
        return Ok();
    }

    [HttpPut]
    [Route("Downvote")]
    public async Task<ActionResult> Downvote(int Id, CancellationToken cancellationToken)
    {
        await _questionBusiness!.IsUserDownvoteExist(Id, cancellationToken);
        await _questionBusiness!.Downvote(Id, cancellationToken);
        await _questionBusiness!.RankQuestion(Id, cancellationToken);
        return Ok();
    }

    //[HttpPut]
    //[Route("IsUserUpvoteExist")]
    //public async Task<ActionResult> IsUserUpvoteExist(int Id, CancellationToken cancellationToken)
    //{
    //    await _questionBusiness!.IsUserUpvoteExist(Id, cancellationToken);
    //    return Ok();
    //}

    //[HttpPut]
    //[Route("IsUserDownvoteExist")]
    //public async Task<ActionResult> IsUserDownvoteExist(int Id, CancellationToken cancellationToken)
    //{
    //    await _questionBusiness!.IsUserDownvoteExist(Id, cancellationToken);
    //    return Ok();
    //}
}