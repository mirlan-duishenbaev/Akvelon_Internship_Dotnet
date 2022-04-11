

using Xunit;

namespace Managed_Threading_Task1.Test
{
    public class DanceFloorMethodsTesting
    {
        DanceFloor danceFloor = new DanceFloor();
        [Fact]
        public void AllAreDancingMethodTest()
        {
            Assert.NotNull(danceFloor);
        }
    }
}