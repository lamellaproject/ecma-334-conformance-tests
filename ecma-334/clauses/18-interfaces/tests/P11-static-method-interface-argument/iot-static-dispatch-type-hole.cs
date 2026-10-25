/*
Rules: P11-static-method-interface-argument
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: static abstract int Decode(int value);
Into: static virtual int Decode(int value) { return value + 13; }
Csc: CS8920
*/
// Proposal L171: an interface with an unresolved static slot is not a type argument.
interface IDecoder { static abstract int Decode(int value); }
class Box<T> { }
class Program { static void Main() { Box<IDecoder> box = new Box<IDecoder>(); } }
