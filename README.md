# csharp-learning

A small repository for learning C# and .NET, coming from a C and C++ background.

## CAN Message Logger

A toy CAN bus message logger built as a first real C# project. Models CAN messages with IDs, data payloads, and timestamps, and provides a logger that can filter messages by ID using a generator method.

I picked CAN/J1939 as the domain because it's what I work with daily on the Cummins X15 heavy-duty diesel engine line. Grounding the language exploration in something familiar made it easier to focus on what was new (the language) rather than the problem domain.

### What it demonstrates

- Class definitions with auto-properties (`{ get; set; }`)
- Constructor initialization and `ToString()` overrides
- String interpolation with format specifiers (`$"ID=0x{Id:X4}"`)
- Generic collections (`List<T>`)
- Generator methods using `yield return` and `IEnumerable<T>`
- Read-only properties with expression-bodied syntax (`public int Count => _log.Count;`)
- File-scoped namespaces

### Running it

Requires .NET 8 or later.