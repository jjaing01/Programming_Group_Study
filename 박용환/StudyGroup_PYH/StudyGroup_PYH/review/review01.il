
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0
//  Copyright (c) Microsoft Corporation. All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly review01
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- 다음 사용자 지정 특성이 자동으로 추가됩니다. 주석 처리를 제거하지 마십시오. -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module review01.exe
// MVID: {34CC7717-13CF-4FD5-9551-BC71648C6C00}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x050C0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Base
       extends [mscorlib]System.Object
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 코드 크기       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldstr      "Base()"
    IL_000d:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0012:  nop
    IL_0013:  ret
  } // end of method Base::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int32 i) cil managed
  {
    // 코드 크기       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldstr      "Base(int)"
    IL_000d:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0012:  nop
    IL_0013:  ret
  } // end of method Base::.ctor

} // end of class Base

.class private auto ansi beforefieldinit Derived
       extends Base
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 코드 크기       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void Base::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldstr      "Derived()"
    IL_000d:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0012:  nop
    IL_0013:  ret
  } // end of method Derived::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int32 i) cil managed
  {
    // 코드 크기       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void Base::.ctor()
    IL_0006:  nop
    IL_0007:  nop
    IL_0008:  ldstr      "Derived(int)"
    IL_000d:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0012:  nop
    IL_0013:  ret
  } // end of method Derived::.ctor

} // end of class Derived

.class private auto ansi beforefieldinit Program1
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // 코드 크기       8 (0x8)
    .maxstack  1
    .locals init (class Derived V_0)
    IL_0000:  nop
    IL_0001:  newobj     instance void Derived::.ctor()
    IL_0006:  stloc.0
    IL_0007:  ret
  } // end of method Program1::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // 코드 크기       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program1::.ctor

} // end of class Program1


// =============================================================

// *********** 디스어셈블리 완료 ***********************
// 경고: Win32 리소스 파일 review01.res을(를) 만들었습니다.
