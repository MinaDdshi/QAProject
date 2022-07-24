using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using QAProject.Common.ViewModels;
using QAProject.Model.Entities;
using System.Net;
using System.Text.Json;
using Xunit;

namespace QAProject.IntegrationTest;

public class QuestionTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    private const string BaseAddress = "/api/QuestionApi";

    public QuestionTest(WebApplicationFactory<Program> factory) =>
        _factory = factory;

	[Theory]
	[MemberData(nameof(GenerateCreateData))]
	public async Task Create_ReturnExpectedResult(Question question, HttpStatusCode correctStatusCode)
	{
		var client = _factory.CreateClient();
		var response = await client.PostAsync(BaseAddress + "/Create", JsonContent.Create(question));
		
		response.StatusCode.Should().Be(correctStatusCode);

		if (correctStatusCode == HttpStatusCode.Redirect) return;

		var stringResponse = await response.Content.ReadAsStringAsync();
		JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
		var apiResponse = JsonSerializer.Deserialize<Response>(stringResponse,jsonSerializerOptions);

		apiResponse?.IsSuccess.Should().Be(true);
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
					QuestionContent = "This is a Question Content",
					Upvote = 1,
					Downvote = 0,
					RankQuestion = 50,
					RankUser = 25,
				},
				HttpStatusCode.OK
		    },

			new object[]
			{
				new Question
				{
					Id = 2,
					UserId = 2,
					QuestionContent = "This is a Question Content",
					Upvote = 1,
					Downvote = 0,
					RankQuestion = 50,
					RankUser = 25,
				},
				HttpStatusCode.OK
			},

			new object[]
			{
				new Question
				{
					Id = 3,
					UserId = 3,
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
