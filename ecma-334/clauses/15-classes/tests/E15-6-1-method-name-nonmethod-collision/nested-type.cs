/*
Rules: E15-6-1-method-name-nonmethod-collision
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: reject
Mutate: public class Read { }
Into: public class Stored { }
Csc: CS0102
*/
class Holder
{
    public class Read { }
    public int Read() { return 1; }
}
class Program { static void Main() { } }
