﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Decorator.Tests
{
    public class OptionalDeserialization {
		[Fact, Trait("Project", "Decorator.Tests")]
		[Trait("Category", nameof(OptionalDeserialization))]
		public void OptionalBehavior() {
			var bm = new BasicMessage("opt", "required", "should default to int value 0");
			var res = Deserializer.Deserialize<OptionalMsg>(bm);

			Assert.Equal("required", res.RequiredString);
			Assert.Equal(default, res.OptionalValue);
		}

		[Fact, Trait("Project", "Decorator.Tests")]
		[Trait("Category", nameof(OptionalDeserialization))]
		public void MessageCountDoesntMatterAtTheEnd() {
			var bm = new BasicMessage("opt", "required");
			var res = Deserializer.Deserialize<OptionalMsg>(bm);

			Assert.Equal("required", res.RequiredString);
			Assert.Equal(default, res.OptionalValue);
		}
	}
}
