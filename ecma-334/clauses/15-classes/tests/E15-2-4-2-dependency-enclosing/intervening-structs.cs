/*
Rules: E15-2-4-2-dependency-enclosing; E15-2-4-2-dependency-cycle
Authority: ECMA-334 7th ed 15.2.4.2
Version: 7.3
Expected: reject
Mutate: class Frame : Frame.Route.Level.End
Into: class Frame
*/
class Frame : Frame.Route.Level.End
{
    public struct Route
    {
        public struct Level
        {
            public class End { }
        }
    }
}
class Program
{
    static void Main() { }
}
