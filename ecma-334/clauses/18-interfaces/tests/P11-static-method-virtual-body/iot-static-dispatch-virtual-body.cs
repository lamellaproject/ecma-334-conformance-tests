/*
Rules: P11-static-method-virtual-body
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: static virtual int Decode(int value);
Into: static virtual int Decode(int value) { return value + 23; }
Csc: CS0501
*/
// Proposal L77 requires a static virtual method body.
interface IDecoder { static virtual int Decode(int value); }
struct Decoder : IDecoder { }
class Program { static void Main() { } }
