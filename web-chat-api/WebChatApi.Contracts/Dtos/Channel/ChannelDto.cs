﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChatApi.Contracts.Dtos.Channel;

public class ChannelDto
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string? Description { get; set; }
	public DateTime CreatedAt { get; set; }
	public int CreatorId { get; set; }
	public string? AvatarUrl { get; set; }
}
