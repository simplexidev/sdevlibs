namespace LibUISharp
{
    internal static class ObjectExtensions
    {
        // This method works as described here: https://stackoverflow.com/a/263416
        public static int GetHashCode(this object obj, params object[] objs)
        {
            unchecked
            {
                int hash = 181;
                for (int i = 0; i < objs.Length; i++)
                {
                    hash = (hash * 373) + objs[i].GetHashCode();
                }
                return hash;
            }
        }
    }
}