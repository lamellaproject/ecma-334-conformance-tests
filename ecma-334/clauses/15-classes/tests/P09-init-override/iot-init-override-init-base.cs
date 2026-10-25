/*
Rules: P09-init-override
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public override int Code { get; set; }
Into: public override int Code { get; init; }
*/
class BasePacket { public virtual int Code { get; init; } }
class Packet : BasePacket { public override int Code { get; set; } }
class Program { static int Main() { return 0; } }
