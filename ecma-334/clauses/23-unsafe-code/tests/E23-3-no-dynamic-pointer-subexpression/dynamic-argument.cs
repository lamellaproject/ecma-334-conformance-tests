/*
Rules: E23-3-no-dynamic-pointer-subexpression
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: reject
Mutate: receiver.Hit(p);
Into: receiver.Hit((long)p);
*/
using System;
public class Receiver { public void Hit(long value) { } }
class Program
{
    static void Main()
    {
        unsafe
        {
            dynamic receiver = new Receiver();
            int* p = null;
            receiver.Hit(p);
        }
    }
}
