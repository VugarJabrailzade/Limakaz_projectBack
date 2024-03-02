using System.Runtime.Serialization;

namespace Limakaz.Contracts
{
    public enum PersonType
    {
        [EnumMember(Value = "Fiziki şəxs")]
        Fiziki = 1,

        [EnumMember(Value = "Hüquqi şəxs")]
        Hüquqi = 2


    }
    public static class PersonTypeName
    {
        public const string Juridical = "Hüquqi şəxs";
        public const string Individual = "Fiziki şəxs";
    }
}
