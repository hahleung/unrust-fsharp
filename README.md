# Eclair Fsharp

Learning F# :zap:.

## F# setup

- [F#](https://docs.microsoft.com/en-us/dotnet/fsharp/get-started/get-started-vscode?tabs=macos)

## Run the stranger things

- `alt + enter` for a code block
- `alt + /` for a line of code

## Cheat sheet

```
System.Console.WriteLine "here"
findNb(4183059834009UL) |> printfn "%A" // 2022
```

## Create a Suave project

### Seed

- `CMD + SHIFT + P` -> `F#: New Project`
- Directory -> `.`
- Name -> `Name?`

### Run

```
paket install
dotnet restore
dotnet build
dotnet run
```

## Create giraffe project

```
dotnet new -i "giraffe-template::*"
dotnet new giraffe -lang F# --UsePaket --IncludeTests
```
