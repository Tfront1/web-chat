﻿namespace WebChatApi.Contracts.Dtos.User;

public record CreateUserDto
{
	public string Username { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string City { get; set; } = string.Empty;
	public string? Description { get; set; }
	public string? Email { get; set; }
	public string? PhoneNumber { get; set; }
	public string? GitHubUrl { get; set; }
	public string? LinkedInUrl { get; set; }
}
