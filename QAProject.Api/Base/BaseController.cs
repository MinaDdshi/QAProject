﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QAProject.Api.Contracts;
using QAProject.Api.Filters;
using QAProject.Business.Contract;
using QAProject.Common.ViewModels;
using QAProject.Model.Entities;
using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Api.Base;

[ApiController]
[Route("api/[controller]")]
//[Authorization]
public class BaseController<T> : ControllerBase, IBaseController<T> where T : BaseEntity
{
	private readonly IBaseBusiness<T> _business;

	public BaseController(IBaseBusiness<T> business) =>
		_business = business;

	[HttpPost]
	public async Task<Response?> Create(T t, CancellationToken cancellationToken) =>
		await _business.Create(t, cancellationToken);

	[HttpGet]
	public async Task<Response<List<T>>?> ReadAll(SieveModel sieveModel, CancellationToken cancellationToken) =>
		await _business.ReadAll(sieveModel, cancellationToken);

	[HttpPut]
	public async Task<Response?> Update(T t, CancellationToken cancellationToken) =>
		await _business.Update(t, cancellationToken);

	[HttpDelete]
	public async Task<Response?> Delete(T t, CancellationToken cancellationToken) =>
		await _business.Delete(t, cancellationToken);

	[HttpDelete("{Id}")]
	public async Task<Response?> Delete(int Id, CancellationToken cancellationToken) =>
		await _business.Delete(Id, cancellationToken);

	[HttpOptions]
	public void Options() =>
		Response.Headers.Add("Allow", "POST,PUT,DELETE,GET,HEAD,OPTIONS");
}
