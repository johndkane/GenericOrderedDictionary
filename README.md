OrderedDictionary&lt;TKey, TValue&gt;
=================================

Represents a strongly typed collection of key/value pairs that are accessible by the key or index, for the .NET Framework 2.0 and higher. 
This collection also acts as a drop-in replacement for the standard System.Collections.Generic.Dictionary<TKey, TValue> class. 
Enumeration of the collection yields items back in their originally built order. 
This class provides an alternative to the weakly typed System.Collections.Specialized.OrderedDictionary class.

Quick Usage
--------------- 

    using Com.Github.DataStructures;
    using System.Collections.Generic; 

    //...

    OrderedDictionary<int, string> od = new OrderedDictionary<int, string>();
    od.Add(2, "two");
    od.Add(new KeyValuePair<int, string>(3, "three"));

    od.Insert(0, new KeyValuePair(1, "one"));
    od.Clear();
    
    // ordered enumerator 
    foreach(var kvp in od)
        Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
    

General Information
--------------- 

This class has been cobbled together from existing .NET data structures internally wrapping: one Dictionary for random access operations, and and one List for ordered operations on the same set of key/value pairs; it's not written from scratch or optimized beyond inherent optimizations present in the use of the List and Dictionary classes it wraps.

Contains one class library project hosting the Ordered Dictionary and one project for Unit tests. 

The unit test library uses NUnit and is hosted on .NET 4 to leverage syntax features that allow for more curt tests. 

Developers
--------------- 

Project files: Visual Studio 2017 +  
Ordered Dictionary Class Library written in: C# targeting .NET 2.0  
Tests Class Library: C# .NET 4.0, NUnit 3 Framework and Visual Studio Adapter
