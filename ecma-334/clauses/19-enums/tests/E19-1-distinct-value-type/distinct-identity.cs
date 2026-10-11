/*
Rules: E19-1-distinct-value-type
Authority: ECMA-334 7th ed 19.1
Version: 7.3
Expected: reject
Mutate: Right value = Left.Ready;
Into: Left value = Left.Ready;
Csc: CS0266
*/
enum Left { Ready = 3 }
enum Right { Ready = 3 }
class Program { static void Main() { Right value = Left.Ready; } }
