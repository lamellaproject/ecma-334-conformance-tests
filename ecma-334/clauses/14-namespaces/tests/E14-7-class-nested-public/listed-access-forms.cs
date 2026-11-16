/*
Rules: E14-7-class-nested-public; E14-7-class-nested-protected-internal; E14-7-class-nested-protected; E14-7-class-nested-internal; E14-7-class-nested-private
Authority: ECMA-334 7th ed 14.7
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public class Visible
Into: private class Visible
*/
using System;
class Container
{
    public class Visible { public const int Code = 17; }
    protected internal class Shared { public const int Code = 23; }
    protected class Family { public const int Code = 31; }
    internal class Local { public const int Code = 43; }
    private class Hidden { public const int Code = 59; }
    public static int Read() { return Shared.Code + Family.Code + Local.Code + Hidden.Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Container.Visible.Code == 17, "public-nested-type");
        Check(Container.Read() == 156, "other-listed-access-forms");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
