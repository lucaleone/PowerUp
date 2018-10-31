# PowerUp, extension methods library for .Net CORE
[](https://raw.githubusercontent.com/lucaleone/Personal-website/master/Git%20resources/PowerUpNuget.png) PowerUp is an extension methods library for .Net CORE, it add usefull functionalities to the framework.<br />
## Download
[PowerupCore Nuget](https://www.nuget.org/packages/PowerupCore)<br />
[PowerupCore Azure Nuget](https://www.nuget.org/packages/PowerupCore.Azure)<br />
## What is different about this library?
⏩ Lightweight: the goal is not to contains 5k methods, but to only have everyday useful methods (in my opinion 😁)<br />
🚀 .Net CORE compatible<br />
🥊 Unit tested<br />
🤓 100% documented<br />

All the extension method are explained and a [Raison d'être](https://en.wikipedia.org/wiki/Raison_d%27%C3%AAtre) is provided in the following documentation.
### Contents
1. [StringExtensions](https://github.com/lucaleone/PowerUp/blob/master/README.md#stringextensions)
2. [EnumExtensions](https://github.com/lucaleone/PowerUp/blob/master/README.md#enumextensions)
3. [CollectionExtensions](https://github.com/lucaleone/PowerUp/blob/master/README.md#collectionextensions)
4. [GenericExtensions](https://github.com/lucaleone/PowerUp/blob/master/README.md#genericextensions)
5. [AzureExtensions](https://github.com/lucaleone/PowerUp/blob/master/README.md#azureextensions)
## StringExtensions
### IsInteger
Simplify the syntax necessary to verify wehather the string content is an inter or not.<br>
__Why?__<br>
To remove repetitive code
```csharp
if("42".IsInteger())
  Foo();
```
### Format
Gives a shorter syntax for the string's method _Format_.<br>
__Why?__<br>
To make the code shorter
```csharp
// .net syntax
string.Format("Debug Level: {0} \"{1}\" {3}", DebugLevel.Info, "Everything is awesome!", DateTime.Now);
// PowerUp syntax
"Debug Level: {0} \"{1}\" {3}".Format(DebugLevel.Info, "Everything is awesome!", DateTime.Now);
```
### ToEnum<>
Allows to easily convert a tring to an enum.<br>
__Why?__<br>
To remove repetitive code
```csharp
private enum TestEnum
{
    Val1,
    Val2,
    Val3
}

var enumVar = "Val1".ToEnum<TestEnum>()
```
## EnumExtensions
### GetDescription<>
Allows to get the readable description of the enum value.
```csharp
private enum TestEnum
{
    [Description("Value with description")]
    ValWithDesc = 1,
    ValNoDesc = 2,
    AnotherNoDesc =3
}
var testObject = TestEnum.ValWithDesc;
string description = testObject.GetDescription();
```
## CollectionExtensions
### RemoveRange<>
Helps to remove more elements at once from a collection.<br>
__Why?__<br>
To provide a usefull addidional features to collections
```csharp
sourceList.RemoveRange(deleteList);
```
### Clone<>
Performs a deep copy frim a collection of _ICloneable_ objects.
```csharp
var testList = _fixture.Create<List<clonableObj>>();
var clone = testList.Clone();
clone.First() != testList.First()
```
### GetLastIndex<>
Gets the last index of a collection.<br>
__Why?__<br>
To remove repetitive code
```csharp
sourceList.GetLastIndex() == (sourceList.Count - 1)
```
## GenericExtensions
### ThrowIfNull<>
Throws ArgumentNullException if the given argument is null.<br>
__Why?__<br>
To replace the Guard.ArgumentNotNull in .net CORE
```csharp
objectShouldNotBeNUll.ThrowIfNull(nameof(objectShouldNotBeNUll));
// Inspired on Microsoft.Practices.EnterpriseLibrary.Common.Utility
Guard.ArgumentNotNull(objectShouldNotBeNUll, nameof(objectShouldNotBeNUll));
```
### IsNull<> and IsNotNull<>
Verify that a object is null or not null.<br>
__Why?__<br>
To make the syntax to verify null cleaner and more human readable
```csharp
var someObject = new object();
//Before
if(someObject!=null)
  Foo();
//PowerUp
if(someObject.isNull())
  Foo();
```
### Between<>
Verify that the object value is between the lower and upper bound.<br>
__Why?__<br>
To simplify the syntax to verify that an onbject value is between a certain range
```csharp
if(5.Between(2, 8))
  Foo();
if(7.Between(7, 12, BetweenOptions.Inclusive))
  Foo();
```
## AzureExtensions
### RedundantParse
The storage access keys in Azure are used in authentication for accessing the storage account.<br>
When you create a storage account you are provided with two storage access keys i.e. Primary and Secondary access keys.<br>
See more https://blogs.msdn.microsoft.com/mast/2013/11/06/why-does-an-azure-storage-account-have-two-access-keys/ <br>
__Why?__<br>
__RedundantParse__ allowes you redundantly connect using the primary key or automatically switch to the seconday.

```xml
<add key="QueueConnectionString1" value="DefaultEndpointsProtocol=https;AccountName=weu##########" />
<add key="QueueConnectionString2" value="DefaultEndpointsProtocol=https;AccountName=weu##########" />
<add key="QueueReference" value="myQueueReference" />
```

```csharp
var storageAccount = CloudStorageAccountHelper.RedundantParse(
                    CloudConfigurationManager.GetSetting("QueueConnectionString1"),
                    CloudConfigurationManager.GetSetting("QueueConnectionString2"));
var queueClient = storageAccount.CreateCloudQueueClient();
var myQueue = queueClient.GetQueueReference(ConfigurationManager.AppSettings["QueueReference"]);
```
