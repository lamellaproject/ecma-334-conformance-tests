/*
Rules: P11-static-method-implicit-implementation
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: private static int Decode(int value)
Into: public static int Decode(int value)
Csc: CS0737
*/
// Proposal L163 applies public implicit implementation matching to static slots.
interface IDecoder { static abstract int Decode(int value); }
struct Parcel : IDecoder { private static int Decode(int value) { return value + 13; } }
class Program { static void Main() { } }
