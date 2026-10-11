/*
Rules: E18-6-5-explicit-property-exact-accessors
Authority: ECMA-334 7th ed 18.6.5
Version: 7.3
Expected: reject
Mutate: get { return 347; } set { }
Into: get { return 347; }
Csc: CS0550
*/
interface IRead { int Value { get; } }
class Reader : IRead { int IRead.Value { get { return 347; } set { } } }
class Program { static void Main() { } }
