namespace OnlineShop.Core.Extensions
{
    public static class DelegateExtensions
    {
        public static Func<T, bool> And<T>(this Func<T, bool> predicate, Func<T, bool> predicateForAnd)
        {
            Func<T, bool> func = query => predicate(query) && predicateForAnd(query);
            return func;
        }
    }
}
