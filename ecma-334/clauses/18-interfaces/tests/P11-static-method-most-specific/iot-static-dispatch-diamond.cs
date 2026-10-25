/*
Rules: P11-static-method-most-specific
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: reject
Mutate: struct Parcel : ILeft, IRight { }
Into: struct Parcel : ILeft, IRight { public static int Decode(int value) { return value * 5; } }
Csc: CS8705
*/
// alpha-v13 interfaces L545: neither sibling implementation is most specific.
interface IDecoder { static virtual int Decode(int value) { return value * 7; } }
interface ILeft : IDecoder { static int IDecoder.Decode(int value) { return value + 13; } }
interface IRight : IDecoder { static int IDecoder.Decode(int value) { return value - 13; } }
struct Parcel : ILeft, IRight { }
class Program { static void Main() { } }
