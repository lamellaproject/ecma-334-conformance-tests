/*
Rules: E12-6-2-3-expanded-convertible
Authority: ECMA-334 7th ed 12.6.2.3
Version: 7.3
Expected: reject
Mutate: Read(3, "violet", 7)
Into: Read(3, 5, 7)
*/
class Program { static void Read(params int[] values) { } static void Main() { Read(3, "violet", 7); } }
