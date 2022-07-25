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

    private const string BaseAddress = "/api";

    public QuestionTest(WebApplicationFactory<Program> factory) =>
        _factory = factory;

    [Theory]
    [MemberData(nameof(GenerateCreateData))]
    public async Task Create_ReturnExpectedResult(Question question,Person person,User user ,HttpStatusCode correctStatusCode)
    {
        try
        {
            ////add person test
            //var client = _factory.CreateClient();
            //var personResponse = await client.PostAsync(BaseAddress+"/Person", JsonContent.Create(person));
            //personResponse.StatusCode.Should().Be(correctStatusCode);
            //if (correctStatusCode == HttpStatusCode.Redirect) return;
            //var stringPersonResponse = await personResponse.Content.ReadAsStringAsync();
            //JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            //var apiPersonResponse = JsonSerializer.Deserialize<Response>(stringPersonResponse, jsonSerializerOptions);
            //apiPersonResponse?.IsSuccess.Should().Be(true);

            ////add user test
            //var userResponse = await client.PostAsync(BaseAddress + "/User", JsonContent.Create(user));
            //userResponse.StatusCode.Should().Be(correctStatusCode);
            //if (correctStatusCode == HttpStatusCode.Redirect) return;
            //var stringUserResponse = await userResponse.Content.ReadAsStringAsync();
            //var apiUserResponse = JsonSerializer.Deserialize<Response>(stringUserResponse, jsonSerializerOptions);
            //apiUserResponse?.IsSuccess.Should().Be(true);

            ////add question test
            //var questionResponse = await client.PostAsync(BaseAddress + "/Question", JsonContent.Create(question));
            //questionResponse.StatusCode.Should().Be(correctStatusCode);
            //if (correctStatusCode == HttpStatusCode.Redirect) return;
            //var stringQuestionResponse = await questionResponse.Content.ReadAsStringAsync();
            //var apiQuestionResponse = JsonSerializer.Deserialize<Response>(stringQuestionResponse, jsonSerializerOptions);
            //apiUserResponse?.IsSuccess.Should().Be(true);

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
                    Id = 1,
                    UserId = 1,
                    QuestionContent = "test question",
                    RankQuestion=50,
                    RankUser=25,
                    IsDeleted=false,
                    LastUpdated=DateTime.Now,
                    CreationDate=DateTime.Now,                   
                },
                //new Person
                //{
                  
                         
                //             Id=1,
                //             Name="mina",
                //             Family="mina",
                //             IsDeleted=false,
                //             CreationDate=DateTime.Now,
                //             LastUpdated=DateTime.Now,
                        
                //},
                //new User
                //{
                //         Id = 1,
                //         PersonId = 1,

                //         Username = "Mina",
                //         Password = "mina",
                //         IsDeleted = false,
                //         CreationDate=DateTime.Now,
                //         LastUpdated = DateTime.Now,
                //},
                HttpStatusCode.OK
            }
        };
    }
}

