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

public class RoleRepository : BaseRepository<Role>
{
	private readonly QAProjectContext _context;

	public RoleRepository(QAProjectContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor) =>
		_context = context;

	public async Task<List<Role?>> LoadByUserIdAsync(int userId, CancellationToken cancellationToken = new()) =>
		await _context.UserRoles!
			.Where(x => x.UserId == userId)
			.Include(x => x.Role)
			.Select(x => x.Role)
			.ToListAsync(cancellationToken);
}
