/*
Rules: E15-2-5-unmanaged-argument
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: Box<int?>
Into: Box<int>
*/
class Box<T> where T : unmanaged { }
class Program { static void Main() { Box<int?> item = null; } }
