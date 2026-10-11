/*
Rules: E15-2-5-struct-with-new
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : struct, new()
Into: where T : struct
*/
class Box<T> where T : struct, new() { }
class Program { static void Main() { } }
