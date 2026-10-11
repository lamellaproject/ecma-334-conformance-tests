/*
Rules: E18-6-5-indexer-required-accessors
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: public int this[int index] { get { return 359; } }
Into: public int this[int index] { get { return 359; } set { } }
Csc: CS0535
*/
interface ICells { int this[int index] { get; set; } }
class Cells : ICells { public int this[int index] { get { return 359; } } }
class Program { static void Main() { } }
