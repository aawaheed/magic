# Function; Compile and load C# Hyperlambda extension
FUNCTION ==> compile-and-load-csharp-extension

This function compiles C# code into a DLL byte array and loads it into the AppDomain as a Hyperlambda extension.
Your code must include a class that implements `ISlot` (or `ISlotAsync`) and is decorated with the `[Slot]` attribute.

___
FUNCTION_INVOCATION[/misc/workflows/workflows/misc/compile-and-load-csharp-extension.hl]:
{
  "code": "[STRING_VALUE]",
  "assembly_name": "[STRING_VALUE]",
  "references": [
    "[VALUE_1]",
    "[VALUE_2]"
  ]
}
___

Arguments:

- `code` is required C# source code.
- `assembly_name` is required DLL name (e.g. `my-slots.dll`).
- `references` is required list of assembly names already loaded into the AppDomain, such as for instance `System.Text` or `System.IO`, etc.

Example C#:

```csharp
using System;
using magic.node;
using magic.signals.contracts;

[Slot(Name = "hello")]
public class Hello : ISlot
{
   public void Signal(ISignaler signaler, Node input)
   {
      input.Value = "Hello from C#";
   }
}
```

**IMPORTANT** - You must include references for `magic.node` and `magic.signals.contracts` at minimum.

After invoking this function, your slot can be used as a Hyperlambda keyword.

## Creating Hyperlambda slots that accepts arguments

If you need to have the slot accept input arguments, and/or return multiple values to caller, you can do so using something resembling the following.

```csharp
using System;
using magic.node;
using magic.signals.contracts;

[Slot(Name = "hello2")]
public class Hello : ISlot
{
   public void Signal(ISignaler signaler, Node input)
   {
      inputAdd(new Node("result", "Hello " + input.Children.FirstOrNull(x => x.Name == "your_name").GetEx<string>()));
   }
}
```

**Notice**, slot names *must* be unique. And the slot is not persisted permanently into the cloudlet, but only kept in memory during the process lifetime.
