﻿using FastEndpoints;
using Microsoft.AspNetCore.Http;

namespace WebChatApi.Infrastructure.EndpointSettings.Groups;

public class ChannelUserEndpointsGroup : Group
{
	public ChannelUserEndpointsGroup()
	{
		Configure(
			"channel/user",
			ep =>
			{
				ep.Description(
					x => x.WithTags("ChannelUser"));
			});
	}
}