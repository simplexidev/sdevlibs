using System;
using LibUISharp.Runtime;

Console.WriteLine($"Is 32-Bit: {Platform.Is32Bit}");
Console.WriteLine($"Is 64-Bit: {Platform.Is64Bit}");
Console.WriteLine($"Is ARM32: {Platform.IsARM32Bit}");
Console.WriteLine($"Is ARM64: {Platform.IsARM64Bit}");
Console.WriteLine($"Is WebAssembly: {Platform.WASM}");
Console.WriteLine();
Console.WriteLine($"Is Windows: {Platform.IsWindows}");
Console.WriteLine($"Is Linux: {Platform.IsLinux}");
Console.WriteLine($"Is macOS: {Platform.IsMacOS}");
Console.WriteLine($"Is FreeBSD: {Platform.IsFreeBSD}");
Console.WriteLine($"Is Browser: {Platform.IsBrowser}");
Console.WriteLine($"Is Android: {Platform.IsAndroid}");
Console.WriteLine($"Is iOS: {Platform.IsIOS}");
Console.WriteLine();
Console.WriteLine($"Is Desktop: {Platform.IsDesktop}");
Console.WriteLine($"Is Web: {Platform.IsWeb}");
Console.WriteLine($"Is Mobile: {Platform.IsMobile}");
Console.WriteLine();
Console.WriteLine($"Runtime ID: {Platform.RuntimeID}");
Console.WriteLine();
Console.Write($"Fallback Rnuntime ID(s): ");
int i = 0;
for (int i = 0; i < Platform.FallbackRuntimeIDs.Length; i++)
{
    Console.Write(rid);
    if (i != Platform.FallbackRuntimeIds.Length - 1)
        Console.Write(";")
}
Console.WriteLine();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();