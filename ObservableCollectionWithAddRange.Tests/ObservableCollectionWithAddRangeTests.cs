using System.Collections.Generic;
using System.Collections.Specialized;
using NUnit.Framework;

namespace Denxorz.ObservableCollectionWithAddRange.Tests;

[TestFixture]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1861:Avoid constant arrays as arguments")]
public class ObservableCollectionWithAddRangeTests
{
    [Test]
    public void BaseListMethod_AddAndRemoveObjects_NormalListFunctionsApply()
    {
        // Arrange
        var classUnderTest = new ObservableCollectionWithAddRange<int> { 1 };

        // Act
        classUnderTest.Clear();
        classUnderTest.Add(2);
        classUnderTest.Remove(2);
        classUnderTest.Add(3);

        // Assert
        CollectionAssert.AreEqual(new[] { 3 }, classUnderTest);
    }

    [Test]
    public void BaseObserverableCollectionEvents_AddAndRemoveObjects_NormalEventsApply()
    {
        // Arrange
        var classUnderTest = new ObservableCollectionWithAddRange<int> { 1 };

        var listOfEvents = new List<NotifyCollectionChangedEventArgs>(3);
        classUnderTest.CollectionChanged += (s, e) => listOfEvents.Add(e);

        // Act
        classUnderTest.Clear();
        classUnderTest.Add(2);
        classUnderTest.Remove(2);
        classUnderTest.Add(3);

        // Assert
        Assert.AreEqual(NotifyCollectionChangedAction.Reset, listOfEvents[0].Action);

        Assert.AreEqual(NotifyCollectionChangedAction.Add, listOfEvents[1].Action);
        Assert.AreEqual(2, listOfEvents[1].NewItems[0]);

        Assert.AreEqual(NotifyCollectionChangedAction.Remove, listOfEvents[2].Action);
        Assert.AreEqual(2, listOfEvents[2].OldItems[0]);

        Assert.AreEqual(NotifyCollectionChangedAction.Add, listOfEvents[3].Action);
        Assert.AreEqual(3, listOfEvents[3].NewItems[0]);

        Assert.AreEqual(4, listOfEvents.Count);
    }

    [Test]
    public void AddRange_AddARangeOfObjects_NormalListFunctionsApply()
    {
        // Arrange
        var classUnderTest = new ObservableCollectionWithAddRange<int> { 1 };

        // Act
        classUnderTest.AddRange(new[] { 2, 3, 4 });
        classUnderTest.Remove(2);
        classUnderTest.Add(5);

        // Assert
        CollectionAssert.AreEqual(new[] { 1, 3, 4, 5 }, classUnderTest);
    }

    [Test]
    public void AddRange_AddARangeOfObjects_OnlyOneEventIsGiven()
    {
        // Arrange
        var classUnderTest = new ObservableCollectionWithAddRange<int> { 1 };

        var listOfEvents = new List<NotifyCollectionChangedEventArgs>(1);
        classUnderTest.CollectionChanged += (s, e) => listOfEvents.Add(e);

        // Act
        classUnderTest.AddRange(new[] { 2, 3, 4 });

        // Assert
        Assert.AreEqual(NotifyCollectionChangedAction.Reset, listOfEvents[0].Action);
        Assert.AreEqual(null, listOfEvents[0].NewItems);

        Assert.AreEqual(1, listOfEvents.Count);
    }

    [Test]
    public void ClearAndAddRange_AddARangeOfObjects_NormalListFunctionsApply()
    {
#pragma warning disable IDE0028

        // Arrange
        var classUnderTest = new ObservableCollectionWithAddRange<int> { 1, 2, 3 };

        // Act
        classUnderTest.Add(4);

#pragma warning restore IDE0028

        classUnderTest.ClearAndAddRange(new[] { 5, 6, 7 });
        classUnderTest.Remove(6);
        classUnderTest.Add(8);

        // Assert
        CollectionAssert.AreEqual(new[] { 5, 7, 8 }, classUnderTest);
    }

    [Test]
    public void ClearAndAddRange_AddARangeOfObjects_OnlyOneEventIsGiven()
    {
        // Arrange
        var classUnderTest = new ObservableCollectionWithAddRange<int> { 1, 2, 3 };

        var listOfEvents = new List<NotifyCollectionChangedEventArgs>(1);
        classUnderTest.CollectionChanged += (s, e) => listOfEvents.Add(e);

        // Act
        classUnderTest.ClearAndAddRange(new[] { 4, 5, 6 });

        // Assert
        Assert.AreEqual(NotifyCollectionChangedAction.Reset, listOfEvents[0].Action);
        Assert.AreEqual(null, listOfEvents[0].NewItems);

        Assert.AreEqual(1, listOfEvents.Count);
    }
}
