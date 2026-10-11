/*
Rules: E8-3-10-enum-distinct-type
Authority: ECMA-334 7th ed 8.3.10
Version: 7.3
Expected: reject
Mutate: First item = Second.On;
Into: First item = (First)Second.On;
*/
enum First { Off, On }
enum Second { Off, On }
class Program { static void Main() { First item = Second.On; } }
