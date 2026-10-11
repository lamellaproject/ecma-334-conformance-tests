/*
Rules: E15-6-10-extension-nongeneric-class
Authority: ECMA-334 7th ed 15.6.10
Version: 7.3
Expected: reject
Mutate: static class Extensions<T>
Into: static class Extensions
Csc: CS1106
*/
static class Extensions<T> { public static int Read(this int receiver) { return receiver; } }
class Program { static void Main() { } }
