﻿using ExampleHero.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Globalization;

namespace ExampleHero.Api.Middleware.RouteConstraints
{
	public class Iso8601DateTimeOffsetConstraint : IRouteConstraint
	{
		public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
		{
			const string pattern = "yyyy-MM-dd'T'HH:mm:ss.FFFK";
			var value = values[routeKey] as string;
			if (!DateTimeOffset.TryParseExact(value, pattern, null, DateTimeStyles.None, out var dateTime))
			{
				throw new CustomBaseException("DOES_NOT_MATCH_FORMAT_ISO-8601");
			}

			return true;
		}
	}
}
