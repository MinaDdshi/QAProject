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

public class UserRepository : BaseRepository<User>
{
	private readonly QAProjectContext _context;

	public UserRepository(QAProjectContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
		_context = context;

	public async Task<bool> IsUsernameAndPasswordValidAsync(string username, string password, CancellationToken cancellationToken = new()) =>
		await _context.Users!.AnyAsync(x =>
			x.Username == username && x.Password == password, cancellationToken);

	public async Task<User> LoadByUsernameAsync(string username, CancellationToken cancellationToken = new()) =>
		(await _context.Users!
			.Include(x => x.Person)
			.SingleOrDefaultAsync(x => x.Username == username, cancellationToken))!;

	public async Task<bool> IsUsernameExistAsync(string username, CancellationToken cancellationToken = new()) =>
		await _context.Users!
			.AnyAsync(x => string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase),
				cancellationToken);
}

