/*
Rules: E12-8-6-type-existence
Authority: ECMA-334 7th ed 12.8.6
Version: 7.3
Expected: reject
Mutate: var result = (3, null);
Into: var result = (3, (string)null);
Csc: CS0815
*/
class Program { static void Main() { var result = (3, null); } }
