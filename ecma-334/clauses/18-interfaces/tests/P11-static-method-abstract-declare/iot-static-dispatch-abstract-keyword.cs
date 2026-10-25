/*
Rules: P11-static-method-abstract-declare
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: static int Decode(int value);
Into: static abstract int Decode(int value);
Csc: CS0501
*/
// alpha-v13 interfaces L249: bodyless static methods specify abstract.
interface IDecoder { static int Decode(int value); }
struct Decoder : IDecoder { public static int Decode(int value) { return value + 23; } }
class Program { static void Main() { } }
