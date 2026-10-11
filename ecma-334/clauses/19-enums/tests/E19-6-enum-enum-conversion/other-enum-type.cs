/*
Rules: E19-6-enum-enum-conversion
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: reject
Mutate: Second value = First.Mark
Into: Second value = (Second)First.Mark
*/
enum First { Mark = 3 }
enum Second { Mark = 3 }
class Program { static void Main() { Second value = First.Mark; } }
