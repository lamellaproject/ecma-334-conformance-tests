/*
Rules: E15-8-1-event-unsafe-context
Authority: ECMA-334 7th ed 15.8.1
Version: 7.3
Expected: reject
Requirements: unsafe-disabled
Mutate: public unsafe event Action Signal;
Into: public event Action Signal;
Csc: CS0227
*/
using System;
class Source { public unsafe event Action Signal; }
class Program { static void Main() { } }
