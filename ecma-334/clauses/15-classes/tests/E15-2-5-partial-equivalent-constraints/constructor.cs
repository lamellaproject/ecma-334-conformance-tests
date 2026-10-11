/*
Rules: E15-2-5-partial-equivalent-constraints
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : class, new()
Into: where T : class
*/
partial class Box<T> where T : class { }
partial class Box<T> where T : class, new() { }
class Program { static void Main() { } }
