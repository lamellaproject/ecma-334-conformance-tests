/*
Rules: E13-9-2-while-break-end-reachable
Authority: ECMA-334 7th ed 13.9.2
Version: 7.3
Expected: reject
Mutate: break;
Into: return 3;
*/
class Program
{
    static int Read() { while (true) { break; } }
    static void Main() { }
}
