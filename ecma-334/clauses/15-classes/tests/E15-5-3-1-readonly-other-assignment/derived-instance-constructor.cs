/*
Rules: E15-5-3-1-readonly-other-assignment
Authority: ECMA-334 7th ed 15.5.3.1
Version: 7.3
Expected: reject
Mutate: protected readonly int Code;
Into: protected int Code;
Csc: CS0191
*/
class Basis { protected readonly int Code; }
class Holder : Basis { public Holder() { Code = 103; } }
class Program { static void Main() { new Holder(); } }
