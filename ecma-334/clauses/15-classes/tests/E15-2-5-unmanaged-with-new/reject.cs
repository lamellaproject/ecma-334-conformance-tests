/*
Rules: E15-2-5-unmanaged-with-new
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: where T : unmanaged, new()
Into: where T : unmanaged
*/
class Box<T> where T : unmanaged, new() { }
class Program { static void Main() { } }
