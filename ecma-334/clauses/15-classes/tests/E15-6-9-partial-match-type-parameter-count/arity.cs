/*
Rules: E15-6-9-partial-match-type-parameter-count
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record<T, U>()
Into: partial void Record<T>()
Csc: CS0759
*/
partial class Gauge
{
    partial void Record<T>();
    partial void Record<T, U>() { }
}
class Program { static void Main() { } }
