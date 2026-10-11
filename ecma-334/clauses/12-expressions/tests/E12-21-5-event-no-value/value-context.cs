/*
Rules: E12-21-5-event-no-value; E12-21-5-event-statement-only
Authority: ECMA-334 7th ed 12.21.5
Version: 7.3
Expected: reject
Mutate: var result = (target.Changed += Handle);
Into: target.Changed += Handle;
Csc: CS0815
*/
delegate void Handler();
class Device
{
    public event Handler Changed { add { } remove { } }
}
class Program
{
    static void Handle() { }
    static void Main() { var target = new Device(); var result = (target.Changed += Handle); }
}
