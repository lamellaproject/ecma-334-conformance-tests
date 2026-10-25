/*
Rules: P11-static-method-abstract-body
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: static abstract int Decode(int value) { return value + 23; }
Into: static abstract int Decode(int value);
Csc: CS0500
*/
// Proposal L60: static abstract declarations have no body.
interface IDecoder { static abstract int Decode(int value) { return value + 23; } }
struct Decoder : IDecoder { public static int Decode(int value) { return value + 23; } }
class Program { static void Main() { } }
