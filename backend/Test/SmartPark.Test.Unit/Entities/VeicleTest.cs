using SmartPark.Domain.Entities;

namespace SmartPark.Test.Unit.Entities
{
    public class VeicleTest
    {

        [Fact]
        public void ShouldBeAbleTo_CalculateTheStayingTime_WhenValidDataAreProvided()
        {
            var veicle = new Veicle()
            {
                Id = Guid.NewGuid(),
                Plate = "my-plate",
                ParkingAt = DateTime.Parse("2025-01-01T12:00:00"),
                FinishAt = DateTime.Parse("2025-01-01T12:30:00")
            };

            Assert.Equal(TimeSpan.Parse("-00:30:00"), veicle.StayingTime);
        }

        [Fact]
        public void ShouldNotBeAble_ToCalculateTheStayingTime_WhenFinishAtAreNull()
        {
            var veicle = new Veicle()
            {
                Id = Guid.NewGuid(),
                Plate = "my-plate",
                ParkingAt = DateTime.Parse("2025-01-01T12:00:00"),
                FinishAt = null // not provided
            };

            Assert.Null(veicle.StayingTime);
        }
    }
}
