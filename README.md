# PowerUp is an extension methods library for .Net CORE
<img src="https://raw.githubusercontent.com/lucaleone/Personal-website/master/Git%20resources/PowerUpNuget.png" width="50" title="PowerUp Icon">  

## StringExtensions
### IsInteger
Simplify the syntax necessary to verify wehather the string content is an inter or not.
```csharp
if("42".IsInteger())
  Foo();
```
### Format
Gives a shorter syntax for the string's method _Format_ 
```csharp
// .net syntax
string.Format("Debug Level: {0} \"{1}\" {3}", DebugLevel.Info, "Everything is awesome!", DateTime.Now);
// PowerUp syntax
"Debug Level: {0} \"{1}\" {3}".Format(DebugLevel.Info, "Everything is awesome!", DateTime.Now);
```
### ToEnum<>
Allows to easily convert a tring to an enum 
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
Allows to get the readable description of the enum value
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
Helps to remove more elements at once from a collection
```csharp
sourceList.RemoveRange(deleteList);
```
### Clone<>
Performs a deep copy frim a collection of _ICloneable_ objects
```csharp
var testList = _fixture.Create<List<clonableObj>>();
var clone = testList.Clone();
clone.First() != testList.First()
```
### GetLastIndex<>
Gets the last index of a collection
```csharp
sourceList.GetLastIndex() == (sourceList.Count - 1)
```
## GenericExtensions
### ThrowIfNull<>
Throws ArgumentNullException if the given argument is null.
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
Verify that the object value is included between the lower and upper bound.<br>
__Why?__<br>
To simplify the syntax to verify that an onbject value is between a certain range
```csharp
if(5.Between(2, 8))
  Foo();
```
