/*
Rules: E8-7-dynamic-object-signature
Authority: ECMA-334 7th ed 8.7
Version: 7.3
Expected: reject
Mutate: static int Read(Box<dynamic> value)
Into: static int Read(Box<int> value)
*/
class Box<T> { }
class Program { static int Read(Box<object> value) { return 1; } static int Read(Box<dynamic> value) { return 2; } static void Main() { } }
