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
        await _answerBusiness!.Upvote(Id, cancellationToken);
        return Ok();
    }

    [HttpPut]
    [Route("Downvote")]
    public async Task<ActionResult> Downvote(int Id, CancellationToken cancellationToken)
    {
        await _answerBusiness!.Downvote(Id, cancellationToken);
        return Ok();
    }

    [HttpPut]
    [Route("IsCorrect")]
    public async Task<ActionResult> IsCorrect(int Id, CancellationToken cancellationToken)
    {
        await _answerBusiness!.IsCorrect(Id, cancellationToken);
        return Ok();
    }
}
