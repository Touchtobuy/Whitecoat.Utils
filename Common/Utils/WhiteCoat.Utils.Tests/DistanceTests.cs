using WhiteCoat.Utils.Locations;
using Xunit;

namespace WhiteCoat.Utils.Tests
{
    public class DistanceTests
    {
        [Fact]
        public void Less_than_150_m_Test()
        {
            // 60 Clarence Street, Sydney NSW
            double lat1 = -33.8663372;
            double lng1 = 151.2046542;

            // 82 Clarence Street, Sydney NSW
            double lat2 = -33.8673911;
            double lng2 = 151.2046589;
            var dis = LocationsExtensionClass.Distance(lat1, lng1, lat2, lng2).MilesToKilometer()*1000;
            Assert.True(dis < 150.00);
        }
    }
}
