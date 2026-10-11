/*
Rules: E15-6-10-extension-no-pointer-receiver
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: reject
Mutate: this int* receiver
Into: int* receiver
Csc: CS1103
*/
static class Extensions { public static unsafe int Read(this int* receiver) { return *receiver; } }
class Program { static void Main() { } }
