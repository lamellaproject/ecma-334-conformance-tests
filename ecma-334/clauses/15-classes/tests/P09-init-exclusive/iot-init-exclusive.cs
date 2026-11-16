/*
Rules: P09-init-exclusive
Authority: csc 5.12.0-1.26529.118 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public int Code { get; set; init; }
Into: public int Code { get; init; }
*/
class Packet { public int Code { get; set; init; } }
class Program { static int Main() { return 0; } }
