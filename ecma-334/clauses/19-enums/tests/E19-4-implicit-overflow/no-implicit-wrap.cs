/*
Rules: E19-4-implicit-overflow
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: reject
Mutate: High = 255, Following
Into: High = 255, Following = 0
*/
enum Code : byte { High = 255, Following }
class Program { static void Main() { } }
