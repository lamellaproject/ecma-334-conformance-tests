/*
Rules: P09-init-constructor-receiver
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: other.Code = 47;
Into: this.Code = 47;
*/
class Packet
{
    public int Code { get; init; }
    public Packet(Packet other) { other.Code = 47; }
}
class Program { static int Main() { return 0; } }
