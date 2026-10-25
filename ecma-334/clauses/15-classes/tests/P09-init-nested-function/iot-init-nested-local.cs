/*
Rules: P09-init-nested-function
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: void Write() { this.Code = 47; } Write();
Into: this.Code = 47;
*/
class Packet
{
    public int Code { get; init; }
    public Packet() { void Write() { this.Code = 47; } Write(); }
}
class Program { static int Main() { return new Packet().Code == 47 ? 0 : 1; } }
