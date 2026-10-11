/*
Rules: E15-6-9-partial-unimplemented-no-runtime-effects; E15-6-9-partial-implementation-optional; E15-6-9-partial-unimplemented-removal; E15-6-9-partial-invocation-without-implementation; E15-6-9-partial-defining-semicolon; E15-6-9-partial-method-classification
Authority: ECMA-334 7th ed 15.6.9
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: partial void Discard(int value);
Into: void Discard(int value) { }
*/
using System;
partial class Program { partial void Discard(int value); }
partial class Program
{
    static int effects;
    static Program Receiver() { effects++; return null; }
    static int Argument() { effects += 10; throw new InvalidOperationException(); }
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool completed = false, argumentException = false, receiverException = false;
        try { Receiver().Discard(Argument()); completed = true; }
        catch (InvalidOperationException) { argumentException = true; }
        catch (NullReferenceException) { receiverException = true; }
        catch (Exception) { }
        Check(completed, "unimplemented-call-completes-without-evaluating-throwing-argument");
        Check(effects == 0, "unimplemented-call-erases-receiver-and-argument-side-effects");
        Check(!argumentException && !receiverException, "erased-call-neither-throws-nor-dereferences-null-receiver");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
