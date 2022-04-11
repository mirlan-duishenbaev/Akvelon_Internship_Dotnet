using Xunit;

namespace Managed_Threading_Task2.Test
{
    public class ImageTest
    {
        [Fact]
        public void CreateImageListTesting()
        {
            string url = "https://jsonplaceholder.typicode.com/photos";
            var result = Image.CreateImageList(url);
            Assert.NotNull(result);
        }
    }
}
