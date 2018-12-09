using System.Collections.Generic;
using System.Linq;
using System;

namespace Tests
{
    using Com.Github.DataStructures;
    using NUnit.Framework;

    [TestFixture]
    public class OrderedDictionaryTester
    {

        [Test]
        public void Construction()
        {

            Dictionary<int, string> other = new Dictionary<int, string>();
            other.Add(1, "one");

            {
                OrderedDictionary<int, string> d = new OrderedDictionary<int, string>();
                Assert.AreEqual(0, d.DictionaryCount);
                Assert.AreEqual(0, d.ListCount);
                Assert.IsNotNull(d.internalList);
                Assert.IsNotNull(d.internalDictionary);
            }

            {
                OrderedDictionary<int, string> dValuesComparer = new OrderedDictionary<int, string>(other, EqualityComparer<int>.Default);

                Assert.AreEqual(1, dValuesComparer.DictionaryCount);
                Assert.AreEqual(1, dValuesComparer.ListCount);

                Assert.IsNotNull(dValuesComparer.internalList);
                Assert.IsNotNull(dValuesComparer.internalDictionary);
            }

            {
                OrderedDictionary<int, string> d = new OrderedDictionary<int, string>(10);
                Assert.AreEqual(10, d.internalList.Capacity);
            }

            {
                OrderedDictionary<int, string> d = new OrderedDictionary<int, string>((IEnumerable<KeyValuePair<int, string>>)other);
                Assert.AreEqual(1, d.internalList.Count);
                Assert.AreEqual(1, d.internalDictionary.Count);
            }

            {
                OrderedDictionary<int, string> d = new OrderedDictionary<int, string>(EqualityComparer<int>.Default);
                Assert.AreEqual(0, d.internalList.Count);
                Assert.AreEqual(0, d.internalDictionary.Count);

                Assert.IsNotNull(d.internalDictionary.Comparer);
                Assert.AreEqual(EqualityComparer<int>.Default, d.internalDictionary.Comparer);
            }

            {
                OrderedDictionary<int, string> d = new OrderedDictionary<int, string>((IDictionary<int, string>)other);
                Assert.AreEqual(1, d.internalList.Count);
                Assert.AreEqual(1, d.internalDictionary.Count);

                Assert.IsNotNull(d.internalDictionary.Comparer);
                Assert.AreEqual(EqualityComparer<int>.Default, d.internalDictionary.Comparer);
            }

            {
                OrderedDictionary<int, string> d = new OrderedDictionary<int, string>(10, EqualityComparer<int>.Default);
                Assert.AreEqual(0, d.internalList.Count);
                Assert.AreEqual(0, d.internalDictionary.Count);

                Assert.AreEqual(10, d.internalList.Capacity);

                Assert.IsNotNull(d.internalDictionary.Comparer);
                Assert.AreEqual(EqualityComparer<int>.Default, d.internalDictionary.Comparer);
            }

            {
                OrderedDictionary<int, string> dValuesComparer = new OrderedDictionary<int, string>((IDictionary<int, string>)other, EqualityComparer<int>.Default);
                Assert.AreEqual(1, dValuesComparer.DictionaryCount);
                Assert.AreEqual(1, dValuesComparer.ListCount);
                Assert.IsNotNull(dValuesComparer.internalList);
                Assert.IsNotNull(dValuesComparer.internalDictionary);
            }

        }

        [Test]
        public void Clear()
        {
            OrderedDictionary<string, string> dictionary = new OrderedDictionary<string, string>();

            List<KeyValuePair<string, string>> tracking = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> one = new KeyValuePair<string, string>("1", "one");
            KeyValuePair<string, string> two = new KeyValuePair<string, string>("2", "two");

            dictionary.Add(one);
            dictionary.Insert(0, two);

            Assert.IsTrue(2 == dictionary.Count);

            dictionary.Clear();

            Assert.IsTrue(0 == dictionary.Count);
        }

        [Test]
        public void ItemEnumeration()
        {
            OrderedDictionary<string, string> dictionary = new OrderedDictionary<string, string>();

            List<KeyValuePair<string, string>> tracking = new List<KeyValuePair<string, string>>();
            KeyValuePair<string, string> one = new KeyValuePair<string, string>("1", "one");
            KeyValuePair<string, string> two = new KeyValuePair<string, string>("2", "two");

            int i = 0;

            { // round 1 

                dictionary.Add(one);
                dictionary.Insert(0, two);

                // test implicit pairs order
                foreach (KeyValuePair<string, string> item in dictionary)
                {
                    switch (i)
                    {
                        case 0:
                            Assert.AreEqual("2", dictionary[i].Key);
                            break;
                        case 1:
                            Assert.AreEqual("1", dictionary[i].Key);
                            break;
                        default:
                            Assert.Fail("unexpected element");
                            break;
                    }
                    ++i;
                }

                // test explicit pairs order 
                i = 0;
                foreach (KeyValuePair<string, string> item in dictionary.GetOrderedPairs())
                {
                    switch (i)
                    {
                        case 0:
                            Assert.AreEqual("2", dictionary[i].Key);
                            break;
                        case 1:
                            Assert.AreEqual("1", dictionary[i].Key);
                            break;
                        default:
                            Assert.Fail("unexpected element");
                            break;
                    }
                    ++i;
                }

                // test keys order
                i = 0;
                foreach (string key in dictionary.GetOrderedKeys())
                {
                    switch (i)
                    {
                        case 0:
                            Assert.AreEqual("2", key);
                            break;
                        case 1:
                            Assert.AreEqual("1", key);
                            break;
                        default:
                            Assert.Fail("unexpected element");
                            break;
                    }
                    ++i;
                }

                // test values order
                i = 0;
                foreach (string key in dictionary.GetOrderedValues())
                {
                    switch (i)
                    {
                        case 0:
                            Assert.AreEqual("two", key);
                            break;
                        case 1:
                            Assert.AreEqual("one", key);
                            break;
                        default:
                            Assert.Fail("unexpected element");
                            break;
                    }
                    ++i;
                }
            }

            dictionary.Clear();
            Assert.AreEqual(0, dictionary.Count);
            i = 0;

            { // round 2 

                dictionary.Add(one);
                dictionary.Add(two);

                foreach (KeyValuePair<string, string> item in dictionary)
                {
                    switch (i)
                    {
                        case 0:
                            Assert.AreEqual("1", dictionary[i].Key);
                            break;
                        case 1:
                            Assert.AreEqual("2", dictionary[i].Key);
                            break;
                        default:
                            Assert.Fail("unexpected element");
                            break;
                    }
                    ++i;
                }
            }
        }

        [Test]
        public void RetrieveByDictionaryKey()
        {
            OrderedDictionary<string, string> dictionary = new OrderedDictionary<string, string>();

            dictionary.Add("1", "one");
            dictionary.Insert(0, new KeyValuePair<string, string>("2", "two"));

            Assert.AreEqual("one", dictionary["1"]);
            Assert.AreEqual("two", dictionary["2"]);

        }

        [Test]
        public void RetrieveByListIndex()
        {
            OrderedDictionary<string, string> dictionary = new OrderedDictionary<string, string>();

            dictionary.Add("1", "one");
            dictionary.Insert(0, new KeyValuePair<string, string>("2", "two"));

            Assert.AreEqual(2, dictionary.Count);

            for (int i = 0; i < dictionary.Count; ++i)
            {
                switch (i)
                {
                    case 0:
                        Assert.IsTrue(dictionary[i].Key == "2");
                        break;
                    case 1:
                        Assert.IsTrue(dictionary[i].Key == "1");
                        break;
                    default:
                        Assert.Fail("unexpected element");
                        break;
                }
            }
        }

        [Test]
        public void InsertItem()
        {
            OrderedDictionary<string, string> dictionary = new OrderedDictionary<string, string>();

            dictionary.Add("1", "one");
            dictionary.Insert(0, new KeyValuePair<string, string>("2", "two"));

            Assert.AreEqual(2, dictionary.Count);

            for (int i = 0; i < dictionary.Count; ++i)
            {
                switch (i)
                {
                    case 0:
                        Assert.IsTrue(dictionary[i].Key == "2");
                        break;
                    case 1:
                        Assert.IsTrue(dictionary[i].Key == "1");
                        break;
                    default:
                        Assert.Fail("unexpected element");
                        break;
                }
            }
        }


        [Test]
        public void AppendItem()
        {
            OrderedDictionary<string, string> dictionary = new OrderedDictionary<string, string>();

            dictionary.Add("1", "one");
            dictionary.Add("2", "two");
            Assert.AreEqual(2, dictionary.Count);

        }

        [Test]
        public void ReplaceItem_ByIndex()
        {
            OrderedDictionary<string, string> od = new OrderedDictionary<string, string>();

            od.Add("1", "one");
            od.Add("2", "two");

            KeyValuePair<string, string> three = new KeyValuePair<string, string>("3", "three");

            od[1] = three; // replace key "2" with key "3"

            Assert.AreEqual(2, od.internalDictionary.Count);
            Assert.AreEqual(2, od.internalList.Count);

            //1
            Assert.AreEqual("3", od.internalList[1].Key);
            Assert.AreEqual("three", od.internalList[1].Value);
            Assert.IsTrue(od.internalDictionary.Keys.Any(k => "3".Equals(k)));
            Assert.IsFalse(od.internalDictionary.Keys.Any(k => "2".Equals(k)));
            //0
            Assert.AreEqual("1", od.internalList[0].Key);
        }

        [Test]
        public void ReplaceItem_ByKey()
        {
            OrderedDictionary<string, string> od = new OrderedDictionary<string, string>();

            od.Add("str1", "one");
            od.Add("str2", "two");
            od.Add("str3", "three");

            Assert.True(od.Count == od.internalDictionary.Count && od.internalDictionary.Count == od.internalList.Count);

            Assert.AreEqual("str1", od.internalList[0].Key);
            Assert.AreEqual("str2", od.internalList[1].Key);
            Assert.AreEqual("str3", od.internalList[2].Key);

            Assert.IsTrue(od.internalDictionary.Keys.Any(k => "str1".Equals(k)));
            Assert.IsTrue(od.internalDictionary.Keys.Any(k => "str2".Equals(k)));
            Assert.IsTrue(od.internalDictionary.Keys.Any(k => "str3".Equals(k)));

            Assert.AreEqual(od.internalDictionary["str1"], "one");
            Assert.AreEqual(od.internalDictionary["str2"], "two");
            Assert.AreEqual(od.internalDictionary["str3"], "three");

            od["str2"] = "bumblebee";

            Assert.True(od.Count == od.internalDictionary.Count && od.internalDictionary.Count == od.internalList.Count);

            Assert.AreEqual("str1", od.internalList[0].Key);
            Assert.AreEqual("str2", od.internalList[1].Key);
            Assert.AreEqual("str3", od.internalList[2].Key);

            Assert.IsTrue(od.internalDictionary.Keys.Any(k => "str1".Equals(k)));
            Assert.IsTrue(od.internalDictionary.Keys.Any(k => "str2".Equals(k)));
            Assert.IsTrue(od.internalDictionary.Keys.Any(k => "str3".Equals(k)));

            Assert.AreEqual(od.internalDictionary["str1"], "one");
            Assert.AreEqual(od.internalDictionary["str2"], "bumblebee");
            Assert.False(od.internalDictionary.ContainsValue("two"));
            Assert.AreEqual(od.internalDictionary["str3"], "three");
        }

        [Test]
        public void RemoveItem()
        {
            OrderedDictionary<string, string> dictionary = new OrderedDictionary<string, string>();

            dictionary.Add("1", "one");
            dictionary.Add("2", "two");

            Assert.AreEqual(2, dictionary.Count);

            // remove existing key
            Assert.IsTrue(dictionary.Remove("1"));

            Assert.AreEqual(1, dictionary.internalList.Count);
            Assert.AreEqual(1, dictionary.internalDictionary.Count);

            // remove non-existent key 
            Assert.IsFalse(dictionary.Remove("1")); // doesn't exist 

            Assert.AreEqual(1, dictionary.internalList.Count);
            Assert.AreEqual(1, dictionary.internalDictionary.Count);
        }

        [Test]
        public void RemoveAt()
        {
            OrderedDictionary<string, string> dictionary = new OrderedDictionary<string, string>();

            // put two items in dictionary 
            dictionary.Add("1", "one");
            dictionary.Add("2", "two");

            Assert.AreEqual(2, dictionary.Count);

            // remove at first index (leaves one)
            dictionary.RemoveAt(0);

            Assert.AreEqual(1, dictionary.internalList.Count);
            Assert.AreEqual(1, dictionary.internalDictionary.Count);
            Assert.AreEqual("2", dictionary[0].Key);

            // remove at non-existent index
            Assert.Throws(
                typeof(ArgumentOutOfRangeException),
                delegate() { dictionary.RemoveAt(1); }
                ); // doesn't exist 

            Assert.AreEqual(1, dictionary.internalList.Count);
            Assert.AreEqual(1, dictionary.internalDictionary.Count);

            // remove remaining item at first index
            dictionary.RemoveAt(0);

            Assert.AreEqual(0, dictionary.internalList.Count);
            Assert.AreEqual(0, dictionary.internalDictionary.Count);

        }

    }
}
