using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class ImageLeakTests : _IssuesUITest
    {
        public ImageLeakTests(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Image Leak Test";
        [Test]
        [Category(UITestCategories.Image)]
        public  void ImageDoesNotLeak()
        {
            
        }
    }
}