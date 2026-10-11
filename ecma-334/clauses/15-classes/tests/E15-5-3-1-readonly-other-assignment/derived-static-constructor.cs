/*
Rules: E15-5-3-1-readonly-other-assignment
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: reject
Mutate: protected static readonly int Code;
Into: protected static int Code;
Csc: CS0198
*/
class Basis { protected static readonly int Code; }
class Holder : Basis { static Holder() { Code = 107; } }
class Program { static void Main() { new Holder(); } }
