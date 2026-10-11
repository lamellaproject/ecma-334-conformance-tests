/*
Rules: E15-2-5-minimum-base-constraint; E15-2-5-compile-time-constraint-check
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: Read<object>()
Into: Read<IReading>()
*/
interface IReading { }
class Program
{
    static void Read<T>() where T : IReading { }
    static void Main() { Read<object>(); }
}
