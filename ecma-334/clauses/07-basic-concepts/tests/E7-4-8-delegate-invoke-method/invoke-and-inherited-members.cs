/*
Rules: E7-4-8-delegate-invoke-method; E7-4-8-delegate-invoke-return-type; E7-4-8-delegate-invoke-parameters; E7-4-8-delegate-invoke-equivalence; E7-4-8-delegate-inherited-members
Authority: ECMA-334 7th ed 7.4.8
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: project.Invoke(ref first, "leaf")
Into: project.Invoke(ref first, "branch")
*/
using System;
delegate int Project(ref int value, string suffix);
class Receiver { public int Read(ref int value, string suffix) { value += suffix.Length; return value; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        var receiver = new Receiver();
        Project project = receiver.Read;
        int first = 17, second = 17;
        int invoked = project.Invoke(ref first, "leaf");
        int direct = project(ref second, "leaf");
        Check(invoked == 21 && first == 21, "invoke-signature-return-and-ref-parameter");
        Check(invoked == direct && first == second, "invoke-and-delegate-call-identical");
        Check(ReferenceEquals(project.Target, receiver), "inherited-delegate-target-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
