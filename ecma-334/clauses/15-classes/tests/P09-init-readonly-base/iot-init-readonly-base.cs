/*
Rules: P09-init-readonly-base
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: protected readonly int code;
Into: protected int code;
*/
class BasePacket { protected readonly int code; }
class Packet : BasePacket
{
    public int Code { get { return code; } init { base.code = value; } }
}
class Program { static int Main() { return 0; } }
