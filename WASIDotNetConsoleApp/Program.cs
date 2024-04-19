using System;
using Wasmtime;

using var engine = new Engine();

// Uses 'WebAssembly Text Format' (AKA 'WAT') to define a simple WebAssembly module.
// Text parameter: this WebAssembly module imports a function named "hello" and defines a function named "run" that calls "hello".
// The "run" function is exported so it can be called from outside the WebAssembly module.
using var module = Module.FromText(
    engine,
    "hello",
    "(module (func $hello (import \"\" \"hello_csharp_code\")) (func (export \"run\") (call $hello)))"
);

using var linker = new Linker(engine);
using var store = new Store(engine);

linker.Define(
    "",
    "hello_csharp_code",
    Function.FromCallback(store, () => Console.WriteLine("Hello from C#!"))
);

var instance = linker.Instantiate(store, module);
var run = instance.GetAction("run")!;
run();