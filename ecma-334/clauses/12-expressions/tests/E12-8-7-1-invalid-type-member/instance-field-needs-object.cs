/*
Rules: E12-8-7-1-invalid-type-member
Authority: ECMA-334 7th ed 12.8.7.1
Version: 7.3
Expected: reject
Mutate: Worker.value
Into: new Worker().value
Csc: CS0120
*/
class Worker { public int value = 3; }
class Program { static void Main() { int result = Worker.value; } }
