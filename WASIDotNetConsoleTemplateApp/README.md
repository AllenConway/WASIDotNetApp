## .NET WASI app

Pre-requisites:
Required wasi-sdk installed. You can download it from https://github.com/WebAssembly/wasi-sdk/releases
The Windows package is the one with the following extension wasi-sdk-22.0.m-mingw.tar.gz
The mingw in the filename indicates that it's meant to be used with MinGW, a minimalist development environment for native Microsoft Windows application

NOTE! This app does not work with MSBuild directly in VS. Use a command line separately:
```
cd C:\Projects\OSS\WASIDotNetApp\WASIDotNetConsoleTemplateApp\bin\Debug\net8.0\wasi-wasm\AppBundle
wasmtime --dir . WASIDotNetConsoleTemplateApp.wasm
```

## Build

You can build the app from Visual Studio or from the command-line:

```
dotnet build -c Debug/Release
```

After building the app, the result is in the `bin/$(Configuration)/net8.0/wasi-wasm/AppBundle` directory.

## Run

You can build the app from Visual Studio or the command-line:

```
dotnet run -c Debug/Release
```

Or directly start node from the AppBundle directory:

```
wasmtime bin/$(Configuration)/net8.0/browser-wasm/AppBundle/WASIDotNetConsoleTemplateApp.wasm
```
