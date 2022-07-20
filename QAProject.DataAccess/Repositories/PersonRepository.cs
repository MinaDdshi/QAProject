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

public class PersonRepository : BaseRepository<Person>
{
    public PersonRepository(QAProjectContext context, ISieveProcessor sieveProcessor) : base(context, sieveProcessor)
    {
    }
}
