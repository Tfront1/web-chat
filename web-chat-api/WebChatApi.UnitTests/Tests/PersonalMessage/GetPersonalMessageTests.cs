﻿using FluentAssertions;
using WebChatApi.Contracts.Dtos.PersonalMessage;
using WebChatApi.Contracts.Dtos.User;
using WebChatApi.Contracts.Models;
using WebChatApi.Infrastructure.Services.EntityServices;
using WebChatApi.UnitTests.Common;

namespace WebChatApi.UnitTests.Tests.PersonalMessage;

public class GetPersonalMessageTests : BaseTest
{
	[Fact]
	public async Task GetByIdAsync_Should_ReturnSuccessResponse()
	{
		//Arrange
		var userService = new UserService(_context);

		var createUserDto1 = new CreateUserDto
		{
			Username = "Username1",
			FirstName = "FirstName1",
			LastName = "LastName1",
			City = "City1",
			Description = "Description1",
			Email = "Email1",
			PhoneNumber = "PhoneNumber1",
			GitHubUrl = "GitHubUrl1",
			LinkedInUrl = "LinkedInUrl1"
		};
		var createUserDto2 = new CreateUserDto
		{
			Username = "Username2",
			FirstName = "FirstName2",
			LastName = "LastName2",
			City = "City2",
			Description = "Description2",
			Email = "Email2",
			PhoneNumber = "PhoneNumber2",
			GitHubUrl = "GitHubUrl2",
			LinkedInUrl = "LinkedInUrl2"
		};

		await userService.CreateUserAsync(createUserDto1);
		await userService.CreateUserAsync(createUserDto2);

		int user1Id = 1;
		int user2Id = 2;

		var service = new PersonalMessageService(_context);

		var createPersonalMessageDto = new CreatePersonalMessageDto
		{
			AuthorId = user1Id,
			RecipientId = user2Id,
			Content = "Content"
		};

		int personalMessageId = 1;

		await service.CreatePersonalMessageAsync(createPersonalMessageDto);
		//Act
		var res = await service.GetByIdAsync(personalMessageId);

		//Assert
		res.Success.Should().BeTrue();
		res.ErrorMessage.Should().BeNullOrEmpty();
		var personalMessage = res.Payload as PersonalMessageDto;
		personalMessage.Should().NotBeNull();
		personalMessage.Should().Match<PersonalMessageDto>(g =>
			g.Id == personalMessageId &&
			g.AuthorId == createPersonalMessageDto.AuthorId &&
			g.RecipientId == createPersonalMessageDto.RecipientId &&
			g.Content == createPersonalMessageDto.Content &&
			g.IsEdited == false
		);
	}

	[Fact]
	public async Task GetByIdAsync_Should_ReturnEntityNotFound()
	{
		//Arrange
		var service = new PersonalMessageService(_context);

		int personalMessageId = 1;

		//Act
		var res = await service.GetByIdAsync(personalMessageId);

		//Assert
		res.Success.Should().BeFalse();
		res.Payload.Should().BeNull();
		res.ErrorMessage.Should().BeEquivalentTo(ProblemDetailsResponsesModel.EntityNotFound);
	}
}
