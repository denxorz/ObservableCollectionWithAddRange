# ObservableCollectionWithAddRange

## What does it do?
ObservableCollectionWithAddRange adds the AddRange and ClearAndAddRange methods to the ObservableCollection.

This can be used to speed up operations with WPF collection bindings that handle a lot of changes.

This package is based on the following articles: 
http://codeblog.vurdalakov.net/2013/06/fast-addrange-method-for-observablecollection.html

## Examples

What it looks like with the default System.Collections.ObjectModel.ObservableCollection:

```C#
var collection = new ObservableCollection<int> { 1, 2 };
collection.CollectionChanged += (s, e) => Console.WriteLine($"CollectionChanged: {e.Action}");

// Array with new items
var newItems = new[] { 3, 4, 5 };

// Replace all items by new items
collection.Clear();
foreach (var item in newItems)
{
    collection.Add(item);
}

// Output:
//   CollectionChanged: Reset
//   CollectionChanged: Add
//   CollectionChanged: Add
//   CollectionChanged: Add
```

What it looks like with ObservableCollectionWithAddRange:

```C#
// Denxorz.ObservableCollectionWithAddRange
var collection = new ObservableCollectionWithAddRange<int> { 1, 2 };
collection.CollectionChanged += (s, e) => Console.WriteLine($"CollectionChanged: {e.Action}");

// Array with new items
var newItems = new[] { 3, 4, 5 };

// Replace all items by new items
collection.ClearAndAddRange(newItems);

// Output:
//   CollectionChanged: Reset
```

## Tools and Products Used

* [Microsoft Visual Studio Community](https://www.visualstudio.com)
* [JetBrains Resharper](https://www.jetbrains.com/resharper/)
* [NUnit](https://www.nunit.org/)
* [Icons8](https://icons8.com/)
* [NuGet](https://www.nuget.org/)
* [GitHub](https://github.com/)