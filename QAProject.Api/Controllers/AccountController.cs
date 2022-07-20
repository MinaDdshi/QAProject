using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAProject.Business.Businesses;
using QAProject.Common.ViewModels;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
	private readonly AccountBusiness? _accountBusiness;

	public AccountController(AccountBusiness accountBusiness)
	{
		_accountBusiness = accountBusiness;
	}

	[HttpPost]
	[Route("Login")]
	[AllowAnonymous]
	public async Task<bool> Login([FromForm] LoginViewModel login, CancellationToken cancellationToken)
	{
			return await _accountBusiness!.LoginAsync(login, HttpContext, cancellationToken);
	}

	[HttpGet]
	public async Task<List<UserViewModel>> GetAllUsersAsync([FromQuery] SieveModel sieveModel, CancellationToken cancellationToken) =>
		await _accountBusiness!.LoadAllUsersViewModelAsync(sieveModel, cancellationToken);

	[Authorization]
	[HttpGet]
	[Route("Logout")]
	public async Task<ActionResult> Logout()
	{
			await HttpContext.SignOutAsync();
			return Ok();
	}
}

