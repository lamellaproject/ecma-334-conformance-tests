/*
Rules: E19-2-represent-all-members
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: reject
Mutate: Excess = 256
Into: Excess = 255
*/
enum Code : byte { Excess = 256 }
class Program { static void Main() { } }
