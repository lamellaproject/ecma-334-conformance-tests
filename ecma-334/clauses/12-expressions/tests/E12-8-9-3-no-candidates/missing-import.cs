/*
Rules: E12-8-9-3-no-candidates
Authority: ECMA-334 7th ed 12.8.9.3
Version: 7.3
Expected: reject
Mutate: 5.Read()
Into: Available.Extensions.Read(5)
*/
namespace Available { public static class Extensions { public static int Read(this int value) { return value; } } }
class Program { static void Main() { 5.Read(); } }
