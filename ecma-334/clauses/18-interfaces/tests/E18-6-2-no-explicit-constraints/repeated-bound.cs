/*
Rules: E18-6-2-no-explicit-constraints
Authority: ECMA-334 7th ed 18.6.2
Version: 7.3
Expected: reject
Mutate: int IRead.Read<T>(T value) where T : IValue
Into: int IRead.Read<T>(T value)
Csc: CS0460
*/
interface IValue { int Value(); }
interface IRead { int Read<T>(T value) where T : IValue; }
class Reader : IRead { int IRead.Read<T>(T value) where T : IValue { return value.Value(); } }
class Program { static void Main() { } }
