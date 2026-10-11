/*
Rules: E13-9-4-for-break-end-reachable
Authority: ECMA-334 7th ed 13.9.4
Version: 7.3
Expected: reject
Mutate: break;
Into: return 3;
*/
class Program
{
    static int Read() { for (; ; ) { break; } }
    static void Main() { }
}
