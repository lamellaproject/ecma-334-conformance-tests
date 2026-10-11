/*
Rules: E12-8-16-6-argument-category
Authority: ECMA-334 7th ed 12.8.16.6
Version: 7.3
Expected: reject
Mutate: new Callback(boxed)
Into: new Callback((Callback)boxed)
*/
delegate void Callback();
class Program
{
    static void Work() { }
    static void Main()
    {
        object boxed = (Callback)Work;
        var copy = new Callback(boxed);
    }
}
