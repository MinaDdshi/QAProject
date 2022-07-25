using Microsoft.EntityFrameworkCore;
using QAProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAProject.DataAccess.Context;

public class QAProjectContext : DbContext
{
    public QAProjectContext(DbContextOptions options) : base(options) { }
    public DbSet<Role>? Roles { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Person>? Persons { get; set; }
    public DbSet<UserRole>? UserRoles { get; set; }
    public DbSet<Question>? Questions { get; set; }
    public DbSet<Answer>? Answers { get; set; }
    public DbSet<CommentQuestion>? CommentQuestions { get; set; }
    public DbSet<CommentAnswer>? CommentAnswers { get; set; }
    public DbSet<VoteQuestion>? VoteQuestions { get; set; }
    public DbSet<VoteAnswer>? VoteAnswers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>().HasData(new List<Role>
        {
            new()
            {
                Id = 1,
                Title = "Admin",
                Description = "Admin of Application"
            },
            new()
            {
                Id = 2,
                Title = "User",
                Description = "User of Application"
            },
        });

        modelBuilder.Entity<Person>().HasData(new List<Person>
        {
            new()
            {
                Id = 1,
                Name = "Mina",
                Family = "Dadashi"
            },
            new()
            {
                Id = 2,
                Name = "Mahsa",
                Family = "Mousavi"
            },
            new()
            {
                Id = 3,
                Name = "Zahra",
                Family = "Abedi"
            }
        });

        modelBuilder.Entity<User>().HasData(new List<User>
        {
            new()
            {
                Id = 1,
                Username = "admin",
                Password = "adminPass",
                PersonId = 1
            },
            new()
            {
                Id = 2,
                Username = "m.mousavi",
                Password = "mousaviPass",
                PersonId = 2
            },
            new()
            {
                Id = 3,
                Username = "z.abedi",
                Password = "abediPass",
                PersonId = 3
            }
        });

        modelBuilder.Entity<UserRole>().HasData(new List<UserRole>
        {
            new()
            {
                Id = 1,
                UserId = 1,
                RoleId = 1
            },
            new()
            {
                Id = 2,
                UserId = 2,
                RoleId = 2
            },
            new()
            {
                Id = 3,
                UserId = 3,
                RoleId = 2
            }
        });

        modelBuilder.Entity<Question>().HasData(new List<Question>
        {
            new ()
            {
                Id = 1,
                UserId = 2,
                QuestionContent = "This is a Question",
                Upvote = 1,
                Downvote = 1,
                RankQuestion = 5,
                RankUser = 5,
            },
            new ()
            {
                Id = 2,
                UserId = 3,
                QuestionContent = "This is a Question",
                Upvote = 1,
                Downvote = 1,
                RankQuestion = 5,
                RankUser = 5,
            }
        });

        modelBuilder.Entity<Answer>().HasData(new List<Answer>
        {
            new ()
            {
                Id = 1,
                UserId = 2,
                QuestionId = 1,
                AnswerContent = "This is an Answer",
                Upvote = 1,
                Downvote = 1,
                RankAnswer = 5,
                RankUser = 5,
            },
            new ()
            {
                Id = 2,
                UserId = 3,
                QuestionId = 1,
                AnswerContent = "This is an Answer",
                Upvote = 1,
                Downvote = 1,
                RankAnswer = 5,
                RankUser = 5
            }
        });

        modelBuilder.Entity<CommentQuestion>().HasData(new List<CommentQuestion>
        {
            new()
            {
                Id = 1,
                Content = "This is a Comment",
                QuestionId = 1
            },
            new()
            {
                Id = 2,
                Content = "This is a Comment",
                QuestionId = 1,
            },
        });

        modelBuilder.Entity<CommentAnswer>().HasData(new List<CommentAnswer>
        {
            new()
            {
                Id = 1,
                Content = "This is a Comment",
                AnswerId = 1
            },
            new()
            {
                Id = 2,
                Content = "This is a Comment",
                AnswerId = 1,
            },
        });
    }
}

