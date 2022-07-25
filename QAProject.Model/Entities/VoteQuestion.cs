using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.Model.Entities;

public class VoteQuestion : BaseEntity
{
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public Question? Question { get; set; }
}
