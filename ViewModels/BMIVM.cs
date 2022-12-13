using RizkyApps.Models;

namespace RizkyApps.ViewModels
{
    internal class BMIVM
    {
        public BMIEntity BMI { get; set; }

        public BMIVM()
        {
            BMI = new BMIEntity();
            BMI.Height = 180;
            BMI.Weight = 73;
        }
    }
}
