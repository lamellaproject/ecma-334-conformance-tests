/*
Rules: E7-6-ed2-ref-out-only-overloads
Authority: ECMA-334 2nd ed 10.6
Version: ISO-1
Expected: reject
Mutate: Register(out byte value)
Into: Register(out int value)
*/
interface IManifest
{
    void Register(ref byte value);
    void Register(out byte value);
}
class ManifestEntry { static void Main() {} }
