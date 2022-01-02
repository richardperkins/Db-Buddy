# Db-Buddy

C# helper class for interfacing SQLite databases

| :exclaimation: This repo is presently unstable and *highly* experimental. **DO NOT** use for production. |
|----------------------------------------------------------------------------------------------------------|

## What is Db Buddy?
**Db Buddy** lends a helping hand in handling SQLite databases in C#.

## Prerequisites

- System.Data
- Mono.Data.Sqlite

To install both on Linux and Windows use the CLI command:
```bash 
dotnet install System.Data Mono.Data.Sqlite
```

## How to use

The steps to use Db Buddy are simple:

- Copy `DbBuddy.cs` to your project directory
- Insert `using DbBuddy` to your file(s) to use Db Buddy
- Insert `using System.Data` when handling *DataTables*
- Extend *DbBuddy* class to interface with the database
- Use `DataTable Execute(string sql, Dictionary<string, object>)` method to fetch data
- Use `int ExecuteWrite(string sql, Dictionary<string, object> args)` method to add data

## Tutorials

- [Making the demo](docs/tutorial-demo.md)
