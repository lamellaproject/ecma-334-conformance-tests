/*
Rules: P09-init-readonly-accessor
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: readonly init { }
Into: init { }
*/
struct Packet
{
    public int Code { get { return 47; } readonly init { } }
}
class Program { static int Main() { return 0; } }
