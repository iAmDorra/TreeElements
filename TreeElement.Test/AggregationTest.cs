using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TreeElements;

namespace TreeElement.Test
{
    [TestClass]
    public class AggregationTest
    {
        [TestMethod]
        public void ShouldAggregateByCounterpartAndByBucket()
        {
            var bucketAggregator = new BucketBrakdownAggregator(null);
            var cptrAggregator = new CounterpartBreakdownAggregator(bucketAggregator);
            var rows = cptrAggregator.GetAggregatedRow(GetBalance());
            Assert.AreEqual(3, rows.Count);
        }

        [TestMethod]
        public void ShouldAggregateByBucketAndByCounterpart()
        {
            var cptrAggregator = new CounterpartBreakdownAggregator(null);
            var bucketAggregator = new BucketBrakdownAggregator(cptrAggregator);
            var rows = bucketAggregator.GetAggregatedRow(GetBalance());
            Assert.AreEqual(2, rows.Count);
        }

        private Balance GetBalance()
        {
            var items = GetItems();
            Balance balance = new Balance(items);
            return balance;
        }

        private List<Item> GetItems()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Amount = 16,
                    Side = "A",
                    Bucket = "1M",
                    Group = new List<string> {"EF", "External Loans"},
                    Category = "Central bank",
                    Code = "Central bank"
                },
                new Item
                {
                    Amount = 3,
                    Side = "A",
                    Bucket = "2M",
                    Group = new List<string> {"EF", "External Loans"},
                    Category = "Central bank",
                    Code = "Central bank"
                },
                new Item
                {
                    Amount = 117,
                    Side = "L",
                    Bucket = "1M",
                    Group = new List<string> {"EF", "External Loans"},
                    Category = "Central bank",
                    Code = "Central bank"
                },
                new Item
                {
                    Amount = 3,
                    Side = "A",
                    Bucket = "1M",
                    Group = new List<string> {"EF", "Client Deposit"},
                    Category = "Supra",
                    Code = "EPIC"
                },
                new Item
                {
                    Amount = 40,
                    Side = "L",
                    Bucket = "1M",
                    Group = new List<string> {"GBIS", "GLFI"},
                    Category = "BANK",
                    Code = "Bank and credit invest"
                },
                new Item
                {
                    Amount = 6,
                    Side = "L",
                    Bucket = "1M",
                    Group = new List<string> {"EF", "Client Deposit"},
                    Category = "Supra",
                    Code = "EPIC"
                },
                new Item
                {
                    Amount = 34,
                    Side = "A",
                    Bucket = "1M",
                    Group = new List<string> {"GBIS", "GLFI"},
                    Category = "BANK",
                    Code = "Bank and credit invest"
                }
            };

            return items;
        }
    }
}
