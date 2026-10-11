/*
Rules: E15-6-10-extension-in-value-type
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: reject
Mutate: this in T receiver
Into: this T receiver
Csc: CS8338
*/
static class Extensions
{
    // The in restriction does not include ref's additional struct-constrained type-parameter permission.
    public static T Read<T>(this in T receiver) where T : struct { return receiver; }
}
class Program { static void Main() { } }
