/*
Rules: P09-init-static
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public static int Code { get; init; }
Into: public static int Code { get; set; }
*/
class Packet { public static int Code { get; init; } }
class Program { static int Main() { return 0; } }
