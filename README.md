OrderedDictionary&lt;TKey, TValue&gt;
=================================

Represents a strongly typed collection of key/value pairs that are accessible by the key or index, for the .NET Framework 2.0 and higher.

Quick Usage
--------------- 

    using Com.Github.Johndkane.Cobbled;
    using System.Collections.Generic; 

    //...

    Dictionary<int, string> od = new Dictionary<int, string>();
    od.Add(2, "two");
    od.Add(new KeyValuePair<int, string>(3, "three"));

    od.Insert(0, new KeyValuePair(1, "one"));
    od.Clear();
    
    // ordered enumerator 
    foreach(var kvp in od)
        Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
    

General Information
--------------- 

This class has been cobbled together from existing .NET data structures internally wrapping: one Dictionary for random access operations, and and one List for ordered operations on the same set of key/value pairs. 

The class is hosted in the Cobbled namespace to indicate it's not written from scratch or optimized beyond inherent optimizations present in the use of the List and Dictionary classes it wraps.

Contains one class library project hosting the Ordered Dictionary and one project for Unit tests. 

The unit test library uses NUnit and is hosted on .NET 4 to leverage syntax features that allow for more curt tests. 

Developers
--------------- 

Project files: Visual Studio 2010 +  
Ordered Dictionary Class Library: C#, .NET 2.0  
Tests Class Library: C#, .NET 4.0, NUnit 2.5.9

License: MIT, http://opensource.org/licenses/MIT
----------------

The MIT License (MIT)
Copyright (c) 2013 John Kane

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

