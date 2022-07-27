using Sieve.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Model.Entities;

public class Answer : BaseEntity
{
    [Sieve(CanFilter = true, CanSort = true)]
    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public Question? Question { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public string? AnswerContent { get; set; }
    public int Upvote { get; set; }
    public int Downvote { get; set; }
    public bool IsCorrectAnswer { get; set; }
    [Sieve(CanFilter = true, CanSort = true)]
    public int RankAnswer { get; set; }
    public ICollection<CommentAnswer>? CommentAnswers { get; set; }
    public virtual ICollection<VoteAnswer>? VoteAnswers { get; set; }
}

