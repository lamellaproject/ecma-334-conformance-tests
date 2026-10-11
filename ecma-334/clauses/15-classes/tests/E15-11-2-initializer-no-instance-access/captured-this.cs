/*
Rules: E15-11-2-initializer-no-instance-access
Authority: ECMA-334 7th ed 15.11.2
Version: 7.3
Expected: reject
Mutate: () => this.N++
Into: () => StaticN++
Csc: CS0027
*/
using System;
class Basis { public Basis(Action action) { } }
class Gauge : Basis { int N; static int StaticN; public Gauge() : base(new Action(() => this.N++)) { } }
class Program { static void Main() { } }
