using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Model.Entities;

public class CommentQuestion : BaseEntity
{
    public string? Content { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public Question? Question { get; set; }
}
