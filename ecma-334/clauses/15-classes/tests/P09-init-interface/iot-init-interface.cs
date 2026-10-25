/*
Rules: P09-init-interface
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public int Code { get; set; }
Into: public int Code { get; init; }
*/
interface ICode { int Code { get; init; } }
class Packet : ICode { public int Code { get; set; } }
class Program { static int Main() { return 0; } }
