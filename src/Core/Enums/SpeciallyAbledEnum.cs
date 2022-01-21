using Ardalis.SmartEnum;

namespace Core.Enums
{
    public sealed class SpeciallyAbledEnum : SmartEnum<SpeciallyAbledEnum>
    {
        public static readonly SpeciallyAbledEnum OH = new(nameof(OH), 1);
        public static readonly SpeciallyAbledEnum HH = new(nameof(HH), 2);
        public static readonly SpeciallyAbledEnum VH = new(nameof(VH), 3);

        private SpeciallyAbledEnum(string name, int value) : base(name, value)
        {
        }
    }
}
