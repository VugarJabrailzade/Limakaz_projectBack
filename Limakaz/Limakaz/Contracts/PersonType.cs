using System.Runtime.Serialization;

namespace Limakaz.Contracts
{
    public enum PersonType
    {
        [EnumMember(Value = "Fiziki şəxs")]
        Fiziki,

        [EnumMember(Value = "Hüquqi şəxs")]
        Hüquqi


    }
    public static class PersonTypeName
    {
        public const string Juridical = "Hüquqi şəxs";
        public const string Individual = "Fiziki şəxs";
    }
}
