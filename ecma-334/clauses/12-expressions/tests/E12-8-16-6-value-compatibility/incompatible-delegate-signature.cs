/*
Rules: E12-8-16-6-value-compatibility; E12-8-16-6-static-binding
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: reject
Mutate: new Wide(source)
Into: new Narrow(source)
*/
delegate void Narrow(string value);
delegate void Wide(object value);
class Program
{
    static void Work(string value) { }
    static void Main()
    {
        Narrow source = Work;
        var copy = new Wide(source);
    }
}
