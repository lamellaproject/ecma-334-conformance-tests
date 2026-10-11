/*
Rules: E12-21-2-invalid-assignment
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: reject
Mutate: target.Readonly = 3
Into: target.Writeable = 3
Csc: CS0191
*/
class Storage
{
    public readonly int Readonly;
    public int Writeable;
}
class Program
{
    static void Main() { var target = new Storage(); target.Readonly = 3; }
}
