### Installation Arch Linux

```sh
aurget -S --noedit --noconfirm --deps dotnet-sdk-2.0
```

Files are installed to `/opt/dotnet/` (on my machine).

### Installing testing frameworks

#### XUnit

Add the following content to the project file (`*.fsproj`):

```xml
<ItemGroup>
    <PackageReference Include="xunit" Version="2.3.0-beta4-build3742" />
    <DotNetCliToolReference Include="dotnet-xunit" Version="2.3.0-beta4-build3742" />
    ...
  </ItemGroup>
```
The above info is from https://xunit.github.io/docs/getting-started-dotnet-core.html#create-project

You should now be able to run `dotnet restore` and `dotnet xunit` from the command line without error.

Adding tooling support in VS Code is accomplished by adding the following code to `.vscode/tasks.json`:

```json
{
    "taskName": "Tests",
    "command": "dotnet xunit",
    "type": "shell",
    "presentation": {
        "reveal": "always"
    },
    "problemMatcher": "$msCompile",
    "group": {
        "kind": "test",
        "isDefault": true
    }
}
```

Now, pressing `Ctrl+Shift+p`, selecting `Run Task`, then selecting `Testing` should run tests (no tests present yet).

Actually adding a test is done by adding a new file (f.ex. `SimpleXUnitTests.fs`) with the following content:

```fsharp
module Tests
open Xunit // <-- don't forget to include this (it does not happen automatically in VS Code using Arch Linux!)

// You might have to restart VS Code after adding XUnit to the *.fsproj file so that the error squigglies are removed.

let add x y = x + y

[<Fact>]
let TrueIsTrue() =
    Assert.True(true)

[<Fact>]
let AddShouldWorkForSimpleExample() =
    Assert.Equal(add 1 1, 2)
```

Before this works with the previously created task, you have to update the execution order in the `*fsproj` file (!):

```xml
<ItemGroup>
    <PackageReference Include="xunit" Version="2.3.0-beta4-build3742" />
    <DotNetCliToolReference Include="dotnet-xunit" Version="2.3.0-beta4-build3742" />
    <Compile Include="SimpleXUnitTests.fs" />
    <Compile Include="Program.fs" />
  </ItemGroup>
```
Now, pressing `Ctrl+Shift+p`, selecting `Run Task`, then selecting `Testing` should run tests (no tests present yet).

#### FsUnit.XUnit

Installation from the command line:

```sh
dotnet add package FsUnit.xUnit --version 3.0.0
```

New file `SimpleFsUnitTests.fs`:

```fsharp
module FsTests
open Xunit
open FsUnit.Xunit

let add x y = x + y

[<Fact>]
let TrueIsTrue() =
    true |> should equal true

[<Fact>]
let AddShouldWorkForSimpleExample() =
    add 1 1 |> should equal 2
```

Patching `*fsproj`:

```xml
  <ItemGroup>
    <PackageReference Include="FsUnit.xUnit" Version="3.0.0" />
    <PackageReference Include="xunit" Version="2.3.0-beta4-build3742" />
    <DotNetCliToolReference Include="dotnet-xunit" Version="2.3.0-beta4-build3742" />
    <Compile Include="SimpleXUnitTests.fs" />
    <Compile Include="SimpleFsUnitTests.fs" />
    <Compile Include="Program.fs" />
  </ItemGroup>
  ```

# Versions

## Arch Linux

```
dotnet --info
.NET Command Line Tools (2.0.0)

Product Information:
 Version:            2.0.0
 Commit SHA-1 hash:  cdcd1928c9

Runtime Environment:
 OS Name:     arch
 OS Version:  
 OS Platform: Linux
 RID:         linux-x64
 Base Path:   /opt/dotnet/sdk/2.0.0/

Microsoft .NET Core Shared Framework Host

  Version  : 2.0.0
  Build    : e8b8861ac7faf042c87a5c2f9f2d04c98b69f28d
```

## Ubuntu (16.04)

```
dotnet --info
.NET Command Line Tools (2.0.0)

Product Information:
 Version:            2.0.0
 Commit SHA-1 hash:  cdcd1928c9

Runtime Environment:
 OS Name:     ubuntu
 OS Version:  16.04
 OS Platform: Linux
 RID:         ubuntu.16.04-x64
 Base Path:   /usr/share/dotnet/sdk/2.0.0/

Microsoft .NET Core Shared Framework Host

  Version  : 2.0.0
  Build    : e8b8861ac7faf042c87a5c2f9f2d04c98b69f28d
```

## Windows 10

```
dotnet --info
.NET Command Line Tools (2.0.0)

Product Information:
 Version:            2.0.0
 Commit SHA-1 hash:  cdcd1928c9

Runtime Environment:
 OS Name:     Windows
 OS Version:  10.0.15063
 OS Platform: Windows
 RID:         win10-x64
 Base Path:   C:\Program Files\dotnet\sdk\2.0.0\

Microsoft .NET Core Shared Framework Host

  Version  : 2.0.0
  Build    : e8b8861ac7faf042c87a5c2f9f2d04c98b69f28d
  ```

  