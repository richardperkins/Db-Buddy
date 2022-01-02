# Demo Tutorial

This tutorial will guide you through the process of connecting and interfacing with an SQLite database using **Db Buddy**. 

## About this tutorial

This tutorial assumes you have familiarity with C# and SQLite.

## Before we begin

Before we begin, we must install dependencies.

### Windows

[Install Mono]()

[Install .Net]()


### Linux

Install Sqlite3

```bash
sudo apt install sqlite3
```

[Install Mono](https://www.mono-project.com/download/stable/#download-lin)

[Install dotnet CLI](https://docs.microsoft.com/en-us/dotnet/core/install/linux)

Run the following command in the terminal to install System.Data and Mono.Data.Sqlite:

```bash
dotnet install System.Data Mono.Data.Sqlite
```

## Installation

Copy and paste `DbBuddy.cs` into your project directory. 

That's it!

## Creating a database

Create a new (empty) file named `data.db` in your project directory.

Enter SQLite3 CLI
```bash
sqlite3 data.db
```



## Creating an interface

## Displaying results