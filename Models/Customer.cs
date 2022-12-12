using PropertyChanged;

namespace RizkyApps.Models
{
    [AddINotifyPropertyChangedInterface]
    internal class Customer 
    {
        public double Id { get; set; }
        public string Name { get; set; }    
        public string Address { get ; set; }
        public bool IsMarried { get; set; }
        public DateTime Birthday { get; set; }
        public string Notes { get; set; }
        public int Rate { get; set; }
        public string Recommended { get; set; }
    }
}
