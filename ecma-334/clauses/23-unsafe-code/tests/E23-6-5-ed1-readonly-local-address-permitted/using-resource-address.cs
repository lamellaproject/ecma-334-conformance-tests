/*
Rules: E23-6-5-ed1-readonly-local-address-permitted
Authority: ECMA-334 1st ed 25.5.4
Version: ISO-1
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: Voucher* address = &resource;
Into: Voucher* address = &other;
*/
// ECMA-334 1st ed 25.3, p. 326 (PDF p. 340), lines 18-23 permits a fixed local address;
// ECMA-334 1st ed 15.13, p. 201 (PDF p. 215), lines 5-7 bans resource writes/ref/out, not
// this address/read operation.
using System;
struct Voucher : IDisposable
{
    public int value;
    public Voucher(int value) { this.value = value; }
    public void Dispose() { Entry.disposed = value; }
}
class Entry
{
    public static int disposed;
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static unsafe int Main()
    {
        Voucher other = new Voucher(19);
        using (Voucher resource = new Voucher(76))
        {
            Voucher* address = &resource;
            Check(address->value == 76, "resource-address-read");
            GC.KeepAlive(other);
        }
        Check(disposed == 76, "resource-disposed");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}
