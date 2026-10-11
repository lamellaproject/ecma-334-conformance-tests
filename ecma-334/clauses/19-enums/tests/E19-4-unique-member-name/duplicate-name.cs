/*
Rules: E19-4-unique-member-name
Authority: ECMA-334 7th ed 19.4
Version: 7.3
Expected: reject
Mutate: Repeated = 2
Into: Other = 2
*/
enum Code { Repeated = 1, Repeated = 2 }
class Program { static void Main() { } }
