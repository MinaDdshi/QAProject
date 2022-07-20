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

    [HttpPut("Upvote")]
    public async Task<ActionResult> Upvote(int Id, CancellationToken cancellationToken)
    {
        await _questionBusiness!.Upvote(Id, cancellationToken);
        return Ok();
    }

    [HttpPut("Downvote")]
    public async Task<ActionResult> Downvote(int Id, CancellationToken cancellationToken)
    {
        await _questionBusiness!.Downvote(Id, cancellationToken);
        return Ok();
    }
}