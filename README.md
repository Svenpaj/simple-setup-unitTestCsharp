# How to get started with C# .Net unitTesting in VScode

## Setup

* Open up an empty folder in VScode.

### Step 1 - Installing extensions

* Go to extensions and get C# Dev Kit *( This will automatically install C# as it depends on C# base lang)*.
* Go to extensions and **DO NOT** get ```NuGet Package Manager``` - This was needed to be able to use .Net Core packages. Like xUnit in this case. *(This one is bugged and no longer worked on by the author and does not work due to casing issues in its fetch)*
* Instead use ```Visual NuGet``` extension.

### Step 2 - Start up .net environment

* Open up a terminal and type following command -> ```dotnet new console```.
* This will give you the needed tools like .net debug etc and set up your environment with the necessary files to run a .net C# program.

### Step 3 - Installing packages

* *Assuming you have created some functions in your program class or other classes with logic.*

* Right-click on your .csproj file and select Visual NuGet: Manage Packages 
    - From there search for ```Microsoft.NET.Test.Sdk``` and download.
    - From there search for ```xUnit``` and download.
    - From there search for ```xunit.runner.visualstudio``` and download.

* Inside your ```.csproj``` file you should see something like this:
```c#
<ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.9.0" />
    <PackageReference Include="xunit" Version="2.7.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.8">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>
```
* *For reference the whole file should look like this*:
```c#
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <GenerateProgramFile>false</GenerateProgramFile>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.9.0" />
    <PackageReference Include="xunit" Version="2.7.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.8">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

</Project>
```

### Step 4 - Test Build

* Run command in a new console -> ```dotnet build``` (this will give an error) as of now.
* Why do we get this error. The reason is that we have an entrypoint for our program in our main method. But when we installed ```xunit``` unitTests SDK it created another entrypoint in the background, so build does not know which one to use.

* We have to add a line of code inside our .csproj file to tell the unitTest SDK to not generate a new entrypoint.
* Add line ->```<GenerateProgramFile>false</GenerateProgramFile>``` in our ```<PropertyGroup>```
* It should now work properly.

### Step 5 - Writing tests

* Create a new file *(class in C#)* with whatever name you want, lets say ```Testclass.cs```
* Write some tests against your methods in your program.
* The first thing you need to do is to add at the very top: ```using Xunit;```
- Then create a public class inside our *Testclass.cs*, lets call it **TestClass**
- Then add a test method inside the **TestClass**. The syntax for writing a test method that is a **Fact** looks like this ->
```c#
[Fact]
public void TestAdd()
{
    // Arrange

    // Act

    // Assert
    Assert.Equal(11, Program.Add(5, 6));
}
```
* *Fact* are tests which are always true. They test invariant conditions.
* Here we are testing a method call Add in the program. And all we need to do is to do an Assert to see if the value is correct.
* How Assert.Equal works: Assert.Equal(expected, actual)
* To run your test/tests open up a new terminal and run this command -> ```dotnet test```

#### Another type of test *[Theory]*

* Theories are tests which are only true for a particular set of data.
* The syntax for writing a **Theory** test looks like this ->
```c#
[Theory]
[InlineData(6)]
[InlineData(8)]
[InlineData(10)]
public void MyEvenTheory(int number)
{
    // Arrange

    // Act

    // Assert
    Assert.True(Program.IsEven(number));
}
```

### *END VScode*

### *NEXT Visual Studio*

# How to get started with C# .Net unitTesting in Visual Studio

## Setup

### Step 1 - Creating the project structure
* Create a new project
  * In this case we choose a console app.
  * Name it what you want. For the sake of this readme we will call it **ConsoleApp**.
  * Choose **framework** ```.NET 8.0 (LTS)```.
  * Leave boxes unchecked.

* In your solution explorer, right-click Solution **'ConsoleApp' (1 of 1 project)**.
  * Go to add in the dropdown menu that is shown, and choose ```Add a new project```.
  * Search/Browse for ```xUnit Test Project``` and click **next**.
  * Name your project and follow naming convention, so in this case it will be **ConsoleApp.Tests** and click **next**.
  * Now we should see **(2 of 2 projects)** in our solution.
  * You should also see an autogenerated Class called *UnitTests.cs* inside your new folder.


### Step 2 - Getting the packages
* Click on **tools** in your top navbar of visual studio.
* Go to ```NuGet Package Manager``` and choose -> ```Manage NuGet packages for Solution```.
  * From there click on **Browse** and write in the search field just below -> ```xunit``` and install it.
  * Next search for ```xunit.runner.visualstudio``` and install it.

### Step 3 - Adding a reference to the project that is being tested.
* In your Solution Explorer, right-click your new Test-Project, in this case it is called **ConsoleApp.Tests** and click on **add** followed by **Project Reference...**.
  * In here you choose the solution/project that you want to reference in your tests, in this case its **ConsoleApp**.
  * Check the box and click **ok**.

### Step 4 - Writing tests
* At the very top you need two lines: 
  * ```using Xunit;```
  * ```using ConsoleApp;``` (Change *ConsoleApp* to the name of your project)
```c#
[Fact]
public void TestAdd()
{
    // Arrange

    // Act

    // Assert
    Assert.Equal(11, Program.Add(5, 6));
}
```
* *Fact* are tests which are always true. They test invariant conditions.
* Here we are testing a method call Add in the program. And all we need to do is to do an Assert to see if the value is correct.
* How Assert.Equal works: Assert.Equal(expected, actual)

#### Another type of test *[Theory]*

* Theories are tests which are only true for a particular set of data.
* The syntax for writing a **Theory** test looks like this ->
```c#
[Theory]
[InlineData(6)]
[InlineData(8)]
[InlineData(10)]
public void MyEvenTheory(int number)
{
    // Arrange

    // Act

    // Assert
    Assert.True(Program.IsEven(number));
}
```

### Step 5 - Running the tests
* In the Visual Studio navbar locate **Test** and click run all tests - this will open a *Test Explorer* that shows all the tests being run and from there it is easy to rerun all tests when you make changes to the code or add more tests.

* Happy Hunting

#### End







