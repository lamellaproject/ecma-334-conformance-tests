/*
Rules: E18-6-5-property-required-accessors
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public int Value { get { return 331; } }
Into: public int Value { get { return 331; } set { } }
Csc: CS0535
*/
interface ICell { int Value { get; set; } }
class Cell : ICell { public int Value { get { return 331; } } }
class Program { static void Main() { } }
