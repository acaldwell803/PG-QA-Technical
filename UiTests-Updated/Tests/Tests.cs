using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using static System.Random;

namespace UiTests.Tests
{
    public class ContactTest
    {
        [Test]
        public async Task SearchAndValidateContactUs()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchPersistentContextAsync(
                "user-data",
                new BrowserTypeLaunchPersistentContextOptions 
                { 
                    Headless = false, 
                    Args = new[] { "--start-maximized", "--disable-blink-features=AutomationControlled" }
                }
            );
            var page = browser.Pages[0];
            var random = new Random();
            await page.GotoAsync("https://www.google.com", new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
            var agreeButton = page.Locator("text=Not interested");
            if (await agreeButton.IsVisibleAsync()) await agreeButton.ClickAsync();
            var searchBox = page.Locator("textarea[name='q']");
            await searchBox.TypeAsync("Prometheus Group", new LocatorTypeOptions
            {
                Delay = 100
            });
            await page.Keyboard.PressAsync("Enter");
            await page.Locator("text=Prometheus Group").WaitForAsync(new LocatorWaitForOptions { Timeout = 60000 });
            await page.ClickAsync("text=Careers");
            await page.ClickAsync("text=Contact Sales");
            await page.FillAsync("input[name='firstname']", "Ashton");
            await page.FillAsync("input[name='lastname']", "Caldwell");
            await page.Keyboard.PressAsync("PageDown");
            await page.ClickAsync("input[type='submit'][value='Contact Us']");
            var form = page.Locator("form.hs-form");
            var requiredMarkers = form.Locator("[class='hs-input invalid error'], [class='hs-input invalid error is-placeholder'], [class='hs-input hs-fieldtype-textarea invalid error']");
            var count = await requiredMarkers.CountAsync();
            Assert.That(count, Is.EqualTo(7));
        }
    }
}
