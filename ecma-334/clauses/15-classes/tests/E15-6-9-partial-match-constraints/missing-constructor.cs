/*
Rules: E15-6-9-partial-match-constraints
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: reject
Mutate: partial void Record<U>() where U : class
Into: partial void Record<U>() where U : class, new()
Csc: CS0761
*/
partial class Gauge
{
    partial void Record<T>() where T : class, new();
    partial void Record<U>() where U : class { }
}
class Program { static void Main() { } }
