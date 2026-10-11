/*
Rules: E23-6-9-other-sizeof-implementation; E23-6-9-struct-member-order; E23-6-9-padding-beginning; E23-6-9-padding-within; E23-6-9-padding-end
Authority: ECMA-334 7th ed 23.6.9
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: int total = sizeof(Item);
Into: int total = sizeof(byte);
*/
using System;
struct Item { public byte Small; public int Wide; public short Tail; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        value.Small = 17; value.Wide = 1234567; value.Tail = 2345;
        int total = sizeof(Item);
        byte* start = (byte*)&value;
        long small = (byte*)&value.Small - start;
        long wide = (byte*)&value.Wide - start;
        long tail = (byte*)&value.Tail - start;
        // Accept every member order and every amount of leading, internal, or trailing padding.
        Check(total >= sizeof(byte) + sizeof(int) + sizeof(short), "size-contains-members");
        Check(small >= 0 && wide >= 0 && tail >= 0, "arbitrary-leading-padding");
        bool separated = (small + sizeof(byte) <= wide || wide + sizeof(int) <= small) &&
                         (small + sizeof(byte) <= tail || tail + sizeof(short) <= small) &&
                         (wide + sizeof(int) <= tail || tail + sizeof(short) <= wide);
        Check(separated, "arbitrary-internal-padding");
        bool contained = small + sizeof(byte) <= total && wide + sizeof(int) <= total &&
                         tail + sizeof(short) <= total;
        Check(contained, "arbitrary-trailing-padding");
        Check(value.Small == 17 && value.Wide == 1234567 && value.Tail == 2345, "independent-member-values");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
