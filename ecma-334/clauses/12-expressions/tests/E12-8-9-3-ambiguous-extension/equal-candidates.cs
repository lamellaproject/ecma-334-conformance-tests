/*
Rules: E12-8-9-3-ambiguous-extension
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: reject
Mutate: 5.Read()
Into: First.Read(5)
*/
static class First { public static int Read(this int value) { return 1; } }
static class Second { public static int Read(this int value) { return 2; } }
class Program { static void Main() { 5.Read(); } }
