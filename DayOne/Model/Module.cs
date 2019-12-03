namespace DayOne.Model
{
    public class Module
    {
        public int Mass { get; set; }
        public CalculationType CalculationType { get; }
        public int RequiredFuel
        {
            get { return CalculateRequiredFuelForMass(Mass, CalculationType); }
        }

        public Module(int mass, CalculationType calculationType)
        {
            Mass = mass;
            CalculationType = calculationType;
        }

        private int CalculateRequiredFuelForMass(int mass, CalculationType type)
        {
            if (type == CalculationType.Simple)
            {
                return RequiredFuelSimpleModel(mass);
            }
            else
            {
                return RequiredFuelComplexModel(mass);
            }
        }

        private int RequiredFuelComplexModel(int mass)
        {
            var requiredFuel = 0;

            mass = RequiredFuelSimpleModel(mass);

            if (mass > 0)
            {
                requiredFuel += mass + RequiredFuelComplexModel(mass);
            }

            return requiredFuel;
        }

        private int RequiredFuelSimpleModel(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}
