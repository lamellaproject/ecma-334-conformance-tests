/*
Rules: E15-7-1-external-property-semicolon-accessors
Authority: ECMA-334 7th ed 15.7.1
Version: 7.3
Expected: reject
Mutate: set { }
Into: set;
Csc: CS0179
*/
class Box { public extern int Item { get; set { } } }
class Program { static void Main() { } }
