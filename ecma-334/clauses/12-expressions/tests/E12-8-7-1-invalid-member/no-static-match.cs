/*
Rules: E12-8-7-1-invalid-member
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: reject
Mutate: source.Missing
Into: source.value
Csc: CS1061
*/
class Worker { public int value = 3; }
class Program { static void Main() { Worker source = new Worker(); int result = source.Missing; } }
