/*
Rules: E12-6-4-2-generic-constraints
Authority: ECMA-334 7th ed 12.6.4.2
Version: 7.3
Expected: reject
Mutate: Pick<string>("x")
Into: Pick<int>(3)
*/
class Program
{
    static void Pick<T>(T x) where T : struct { }
    static void Main() { Pick<string>("x"); }
}
