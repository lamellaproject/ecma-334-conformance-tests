/*
Rules: E12-21-1-simple-no-event
Authority: ECMA-334 7th ed 12.21.1
Version: 7.3
Expected: reject
Mutate: target.Changed = Handle
Into: target.Changed += Handle
Csc: CS0079
*/
delegate void Handler();
class Device
{
    public event Handler Changed { add { } remove { } }
}
class Program
{
    static void Handle() { }
    static void Main() { var target = new Device(); target.Changed = Handle; }
}
