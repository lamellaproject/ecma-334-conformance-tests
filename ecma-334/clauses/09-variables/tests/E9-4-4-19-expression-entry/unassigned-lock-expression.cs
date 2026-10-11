/*
Rules: E9-4-4-19-expression-entry
Authority: ECMA-334 7th ed 9.4.4.19
Version: 7.3
Expected: reject
Mutate: object monitor;
Into: object monitor = new object();
Csc: CS0165
*/
class Program { static void Main() { object monitor; lock (monitor) { } } }
