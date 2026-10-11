/*
Rules: E12-19-2-no-parameter-contravariance; E12-19-2-explicit-compatible-types
Authority: ECMA-334 7th ed 12.19.2
Version: 7.3
Expected: reject
Mutate: (Base value) =>
Into: (Derived value) =>
*/
class Base { public int Value; }
class Derived : Base { }
delegate int Read(Derived value);
class Program { static void Main() { Read function = (Base value) => value.Value; } }
