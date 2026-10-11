/*
Rules: E15-6-2-1-this-in-struct
Authority: ECMA-334 7th ed 15.6.2.1
Version: 7.3
Expected: reject
Mutate: this in T value
Into: this T value
Csc: CS8338
*/
static class Extensions
{
    // The further in-receiver restriction in 15.6.10 excludes type parameters, even struct-constrained ones.
    public static T Read<T>(this in T value) where T : struct { return value; }
}
class Program
{
    static void Main() { int value = 29; value.Read(); }
}
