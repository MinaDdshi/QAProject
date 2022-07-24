using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using QAProject.Common.ViewModels;
using QAProject.Model.Entities;
using System.Net;
using System.Text.Json;
using Xunit;

namespace QAProject.Integration.Test;

public class QuestionTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    private const string BaseAddress = "/api/Question";

    public QuestionTest(WebApplicationFactory<Program> factory) =>
        _factory = factory;

    [Theory]
    [MemberData(nameof(GenerateCreateData))]
    public async Task Create_ReturnExpectedResult(Question question, HttpStatusCode correctStatusCode)
    {
        try
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsync(BaseAddress, JsonContent.Create(question));


            response.StatusCode.Should().Be(correctStatusCode);

            if (correctStatusCode == HttpStatusCode.Redirect) return;

            var stringResponse = await response.Content.ReadAsStringAsync();
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            var apiResponse = JsonSerializer.Deserialize<Response>(stringResponse, jsonSerializerOptions);

            apiResponse?.IsSuccess.Should().Be(true);
        }
        catch (Exception)
        {

            throw;
        }

    }

    public static IEnumerable<object[]> GenerateCreateData()
    {
        return new List<object[]>
        {
            new object[]
            {
                new Question
                {
                    User = new User
                    {
                    Id=1,
                    PersonId=1,
                    Username="Mina",
                    Password="mina",
                    UserRoleId=1
                        UserRoles = new List<UserRole>
                        {
                            new UserRole
                            {
                                 Id = 1,
                            RoleId=1,
                            UserId=1,
                            Role = new Role()
                            {
                                Id=1,
                                Title="admin",
                                Description="filan"
                            }
                            }                           
                        },

                    Person = new Person
                    {
                    Id=1,
                    Name="mina",
                    Family="dadashi"
                    }

                    },

                    Id = 1,
                    UserId = 1,
                    QuestionContent = "This is a Question Content",
                    Upvote = 1,
                    Downvote = 0,
                    RankQuestion = 50,
                    RankUser = 25,
                },
                HttpStatusCode.OK
            },

        };
    }
}

