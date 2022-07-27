using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Model.Entities;

public class Question : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public string? QuestionContent { get; set; }
    public int Upvote { get; set; }
    public int Downvote { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public int RankQuestion { get; set; }
    public virtual ICollection<Answer>? Answers { get; set; }
    public virtual ICollection<CommentQuestion>? CommentQuestions { get; set; }
    public virtual ICollection<VoteQuestion>? VoteQuestions { get; set; }
}

