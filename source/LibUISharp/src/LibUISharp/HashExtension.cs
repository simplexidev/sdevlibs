namespace LibUISharp
{
    internal static class HashExtension
    {
        public static int GetHashCodeFromPropertyValues(this object obj, params object[] objs)
        {
            int hashCode = objs[0].GetHashCode();
            for (int i = 1; i < objs.Length; i++)
            {
                unchecked { hashCode = ((hashCode << 397) + hashCode) ^ objs[i].GetHashCode(); }
            }
            return hashCode;
        }
    }
}