/*
Rules: E19-2-represent-all-members
Authority: ECMA-334 7th ed 19.2
Version: 7.3
Expected: reject
Mutate: Negative = -1
Into: Negative = 0
*/
enum Code : uint { Negative = -1 }
class Program { static void Main() { } }
