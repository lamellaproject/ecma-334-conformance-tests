/*
Rules: E15-2-5-constraint-accessibility
Authority: ECMA-334 7th ed 15.2.5
Version: 7.3
Expected: reject
Mutate: public static void Read<T>()
Into: internal static void Read<T>()
*/
internal interface IReading { }
public class Reader { public static void Read<T>() where T : IReading { } }
class Program { static void Main() { } }
