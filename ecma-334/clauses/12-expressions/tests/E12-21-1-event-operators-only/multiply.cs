/*
Rules: E12-21-1-event-operators-only
Authority: ECMA-334 7th ed 12.21.1
Version: 7.3
Expected: reject
Mutate: target.Changed *= handler
Into: target.Changed += handler
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
    static void Main() { var target = new Device(); Handler handler = Handle; target.Changed *= handler; }
}
