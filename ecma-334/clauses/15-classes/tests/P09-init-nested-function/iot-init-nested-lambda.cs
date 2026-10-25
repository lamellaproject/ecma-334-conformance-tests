/*
Rules: P09-init-nested-function
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: Action write = () => this.Code = 47; write();
Into: this.Code = 47;
*/
using System;
class Packet
{
    public int Code { get; init; }
    public Packet() { Action write = () => this.Code = 47; write(); }
}
class Program { static int Main() { return new Packet().Code == 47 ? 0 : 1; } }
