/*
Rules: E12-2-1-event-other-context
Authority: ECMA-334 7th ed 12.2.1
Version: 7.3
Expected: reject
Mutate: Action handler = box.Signal;
Into: box.Signal += Handler;
*/
using System;
class Box { public event Action Signal; }
class Program
{
    static void Handler() { }
    static void Main() { Box box = new Box(); Action handler = box.Signal; }
}
