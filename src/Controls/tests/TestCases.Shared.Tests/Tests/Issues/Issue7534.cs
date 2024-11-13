﻿using NUnit.Framework;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue7534 : _IssuesUITest
	{
		public Issue7534(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "Span with tail truncation and paragraph breaks with Java.Lang.IndexOutOfBoundsException";


		[Test]
		[Category(UITestCategories.Label)]

		public void ExpectingPageNotToBreak()
		{
			App.Screenshot("Test passed, label is showing as it should!");
		}

	}
}
