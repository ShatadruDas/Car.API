using System;

namespace SD.Car.API
{
    public class CarDetails
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        public float Price { get; set; }

        public string Color { get; set; }

        public int TopSpeed { get; set; }
    }
}
