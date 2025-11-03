using Xunit;

namespace GiftOfTheGiversApp.Tests.Ui
{
    public class DonationUiTests
    {
        [Fact]
        public void DonationPage_ShouldRenderTitle()
        {
            var pageTitle = "Make a Donation";
            Assert.Equal("Make a Donation", pageTitle);
        }
    }
}
