/*
Rules: P09-init-after-construction
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public int Code { get; init; }
Into: public int Code { get; set; }
*/
class Packet { public int Code { get; init; } }
class Program
{
    static int Main()
    {
        Packet packet = new Packet();
        packet.Code = 47;
        return packet.Code == 47 ? 0 : 1;
    }
}
