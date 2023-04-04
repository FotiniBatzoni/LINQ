using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace LINQSamples
{
    public class SamplesViewModel : ViewModelBase
    {
        #region GetAllQuery
        /// <summary>
        /// Put all products into a collection using LINQ
        /// </summary>
        public List<Product> GetAllQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Query Syntax Here
            list = (from prod in products
                    select prod).ToList();

            return list;
        }
        #endregion

        #region GetAllMethod
        /// <summary>
        /// Put all products into a collection using LINQ
        /// </summary>
        public List<Product> GetAllMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Method Syntax Here
            list = products.Select(prod => prod).ToList();

            return list;
        }
        #endregion

        #region GetSingleColumnQuery
        /// <summary>
        /// Select a single column
        /// </summary>
        public List<string> GetSingleColumnQuery()
        {
            List<Product> products = GetProducts();
            List<string> list = new();

            // Write Query Syntax Here
            list.AddRange(from prod in products
                          select prod.Name);

            return list;
        }
        #endregion

        #region GetSingleColumnMethod
        /// <summary>
        /// Select a single column
        /// </summary>
        public List<string> GetSingleColumnMethod()
        {
            List<Product> products = GetProducts();
            List<string> list = new();

            // Write Method Syntax Here
            list.AddRange(products.Select(prod => prod.Name));

            return list;
        }
        #endregion

        #region GetSpecificColumnsQuery
        /// <summary>
        /// Select a few specific properties from products and create new Product objects
        /// </summary>
        public List<Product> GetSpecificColumnsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Query Syntax Here
            list = (from prod in products
                    select new Product
                    {
                        ProductID = prod.ProductID,
                        Name = prod.Name,
                        Size = prod.Size
                    }).ToList();

            return list;
        }
        #endregion

        #region GetSpecificColumnsMethod
        /// <summary>
        /// Select a few specific properties from products and create new Product objects
        /// </summary>
        public List<Product> GetSpecificColumnsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Method Syntax Here
            list = products.Select(prod => new Product
            {
                ProductID = prod.ProductID,
                Name = prod.Name,
                Size = prod.Size
            }).ToList();

            return list;
        }
        #endregion

        #region AnonymousClassQuery
        /// <summary>
        /// Create an anonymous class from selected product properties
        /// </summary>
        public string AnonymousClassQuery()
        {
            List<Product> products = GetProducts();
            StringBuilder sb = new(2048);

            // Write Query Syntax Here
            var list = (from prod in products
                        select new
                        {
                            Identifier = prod.ProductID,
                            ProductName = prod.Name,
                            ProductSize = prod.Size
                        });

            // Loop through anonymous class
            foreach (var prod in list)
            {
                sb.AppendLine($"Product ID: {prod.Identifier}");
                sb.AppendLine($"   Product Name: {prod.ProductName}");
                sb.AppendLine($"   Product Size: {prod.ProductSize}");
            }

            return sb.ToString();
        }
        #endregion

        #region AnonymousClassMethod
        /// <summary>
        /// Create an anonymous class from selected product properties
        /// </summary>
        public string AnonymousClassMethod()
        {
            List<Product> products = GetProducts();
            StringBuilder sb = new(2048);

            // Write Method Syntax Here
            var list = products.Select(prod => new
            {
                Identifier = prod.ProductID,
                ProductName = prod.Name,
                ProductSize = prod.Size
            });

            // Loop through anonymous class
            foreach (var prod in list)
            {
                sb.AppendLine($"Product ID: {prod.Identifier}");
                sb.AppendLine($"   Product Name: {prod.ProductName}");
                sb.AppendLine($"   Product Size: {prod.ProductSize}");
            }

            return sb.ToString();
        }
        #endregion

        #region OrderByQuery
        /// <summary>
        /// Order products by Name
        /// </summary>
        public List<Product> OrderByQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from prod in products
                    orderby prod.Name 
                    select prod).ToList();

            return list;
        }
        #endregion

        #region OrderByMethod
        /// <summary>
        /// Order products by Name
        /// </summary>
        public List<Product> OrderByMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.OrderBy(prod => prod.Name).ToList();

            return list;
        }
        #endregion

        #region OrderByDescendingQuery Method
        /// <summary>
        /// Order products by name in descending order
        /// </summary>
        public List<Product> OrderByDescendingQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from prod in products
                    orderby prod.Name descending
                    select prod).ToList();

            return list;
        }
        #endregion

        #region OrderByDescendingMethod Method
        /// <summary>
        /// Order products by name in descending order
        /// </summary>
        public List<Product> OrderByDescendingMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.OrderByDescending(prod => prod.Name).ToList();

            return list;
        }
        #endregion

        #region OrderByTwoFieldsQuery Method
        /// <summary>
        /// Order products by Color descending, then Name
        /// </summary>
        public List<Product> OrderByTwoFieldsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from p in products
                    orderby p.Color descending, p.Name ascending
                    select p).ToList();

            return list;
        }
        #endregion

        #region OrderByTwoFieldsMethod Method
        /// <summary>
        /// Order products by Color descending, then Name
        /// </summary>
        public List<Product> OrderByTwoFieldsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.OrderByDescending(prod => prod.Color)
                  .ThenBy(prod => prod.Name).ToList();

            return list;
        }
        #endregion

        #region OrderByTwoFieldsDescMethod Method
        /// <summary>
        /// Order products by Color descending, then Name Descending
        /// </summary>
        public List<Product> OrderByTwoFieldsDescMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.OrderByDescending(prod => prod.Color)
                 .ThenByDescending(prod => prod.Name).ToList();

            return list;
        }
        #endregion


        #region WhereQuery
        /// <summary>
        /// Filter products using where. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from prod in products
                    where prod.Name.StartsWith("S")
                    select prod).ToList();

            return list;
        }
        #endregion

        #region WhereMethod
        /// <summary>
        /// Filter products using where. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.Where(p  => p.Name.StartsWith("S")).ToList();

            return list;
        }
        #endregion

        #region WhereTwoFieldsQuery
        /// <summary>
        /// Filter products using where with two fields. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereTwoFieldsQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = ( from prod in products
                     where prod.Name.StartsWith("L") && prod.StandardCost > 200
                     select prod).ToList();

            return list;
        }
        #endregion

        #region WhereTwoFieldsMethod
        /// <summary>
        /// Filter products using where with two fields. If the data is not found, an empty list is returned
        /// </summary>
        public List<Product> WhereTwoFieldsMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.Where(p => p.Name.StartsWith("L") && p.StandardCost >200).ToList();

            return list;
        }
        #endregion

        #region WhereExtensionQuery
        /// <summary>
        /// Filter products using a custom extension method
        /// </summary>
        public List<Product> WhereExtensionQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from prod in products
                    select prod).ByColor("Red").ToList();

            return list;
        }
        #endregion

        #region WhereExtensionMethod
        /// <summary>
        /// Filter products using a custom extension method
        /// </summary>
        public List<Product> WhereExtensionMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.ByColor("Red").ToList();

            return list;
        }
        #endregion

        #region FirstQuery
        /// <summary>
        /// Locate a specific product using First(). First() searches forward in the collection.
        /// NOTE: First() throws an exception if the result does not produce any values
        /// Use First() when you know or expect the sequence to have at least one element.
        /// Exceptions should be exceptional, so try to avoid them.
        /// </summary>
        public Product FirstQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Query Syntax Here
            value = (from prod in products
                     select prod)
                      .First(prod => prod.Color == "Red");


            // Test the exception handling
            //  value = (from prod in products
            //           select prod)
            //.First(prod => prod.Color == "purple");

            return value;
        }
        #endregion

        #region FirstMethod
        /// <summary>
        /// Locate a specific product using First(). First() searches forward in the collection.
        /// NOTE: First() throws an exception if the result does not produce any values
        /// Use First() when you know or expect the sequence to have at least one element.
        /// Exceptions should be exceptional, so try to avoid them.
        /// </summary>
        public Product FirstMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Method Syntax Here
            value = products.First(p => p.Color == "Red");

            return value;
        }
        #endregion

        #region FirstOrDefaultQuery
        /// <summary>
        /// Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list.
        /// NOTE: FirstOrDefault() returns a null if no value is found
        /// Use FirstOrDefault() when you DON'T know if a collection might have one element you are looking for
        /// Using FirstOrDefault() avoids throwing an exception which can hurt performance
        /// </summary>
        public Product FirstOrDefaultQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Query Syntax Here
            //value = (from prod in products
            //         select prod)
            //        .FirstOrDefault(prod => prod.Color == "Red",
            //        new Product { ProductID = -1,
            //                      Name = "NOT FOUND"});

            // Test the exception handling
            value = (from prod in products
                     select prod)
                    .FirstOrDefault(prod => prod.Color == "purple",
                        new Product
                        {
                            ProductID = -1,
                            Name = "NOT FOUND"
                        });

            return value;
        }
        #endregion

        #region FirstOrDefaultMethod
        /// <summary>
        /// Locate a specific product using FirstOrDefault(). FirstOrDefault() searches forward in the list.
        /// NOTE: FirstOrDefault() returns a null if no value is found
        /// Use FirstOrDefault() when you DON'T know if a collection might have one element you are looking for
        /// Using FirstOrDefault() avoids throwing an exception which can hurt performance
        /// </summary>
        public Product FirstOrDefaultMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Method Syntax Here
            value = products.FirstOrDefault(p => p.Color == "purple",
                 new Product
                 {
                     ProductID = -1,
                     Name = "NOT FOUND"
                 });

            return value;
        }
        #endregion



        #region LastQuery
        /// <summary>
        /// Locate a specific product using Last(). Last() searches from the end of the list backwards.
        /// NOTE: Last returns the last value from a collection, or throws an exception if no value is found
        /// </summary>
        public Product LastQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Query Syntax Here
            value = (from prod in products
                     select prod)
                     .Last(prod => prod.Color == "Red");

            // Test the exception handling
            //value = (from prod in products
            //         select prod)
            //        .Last(prod => prod.Color == "Purple");

            return value;
        }
        #endregion

        #region LastMethod
        /// <summary>
        /// Locate a specific product using Last(). Last() searches from the end of the list backwards.
        /// NOTE: Last returns the last value from a collection, or throws an exception if no value is found
        /// </summary>
        public Product LastMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Method Syntax Here
            value = products.Last(p => p.Color == "Red");

            return value;
        }
        #endregion

        #region LastOrDefaultQuery
        /// <summary>
        /// Locate a specific product using LastOrDefault(). LastOrDefault() searches from the end of the list backwards.
        /// NOTE: LastOrDefault returns the last value in a collection or a null if no values are found
        /// </summary>
        public Product LastOrDefaultQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Query Syntax Here
            //value = (from prod in products
            //         select prod)
            //        .LastOrDefault(p => p.Color == "Red");

            // Test the exception handling
            value = (from prod in products
                     select prod)
                    .LastOrDefault(p => p.Color == "purple",
                                     new Product
                                     {
                                         ProductID = -1,
                                         Name = "NOT FOUND"
                                     });

            return value;
        }
        #endregion

        #region LastOrDefaultMethod
        /// <summary>
        /// Locate a specific product using LastOrDefault(). LastOrDefault() searches from the end of the list backwards.
        /// NOTE: LastOrDefault returns the last value in a collection or a null if no values are found
        /// </summary>
        public Product LastOrDefaultMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Method Syntax Here
            value = products.LastOrDefault(p =>p.Color == "purple",
                          new Product
                          {
                              ProductID = -1,
                              Name = "NOT FOUND"
                          });


            return value;
        }
        #endregion

        #region SingleQuery
        /// <summary>
        /// Locate a specific product using Single().
        /// NOTE: Single() expects only a single element to be found in the collection, otherwise an exception is thrown
        /// Single() always searches the complete collection
        /// </summary>
        public Product SingleQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Query Syntax Here
            value = (from p in products
                     select p)
                     .Single(p => p.ProductID == 706);

            // Test the exception handling for finding multiple values
            //value = (from prod in products
            //         select prod)
            //        .Single(p => p.Color == "Red");

            // Test the exception handling for the list is null
            //products = null;
            //value = (from p in products
            //         select p)
            //         .Single(p => p.ProductID == 706);
            
            return value;
        }
        #endregion

        #region SingleMethod
        /// <summary>
        /// Locate a specific product using Single().
        /// NOTE: Single() expects only a single element to be found in the collection, otherwise an exception is thrown
        /// Single() always searches the complete collection
        /// </summary>
        public Product SingleMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Method Syntax Here
            value = products.Single(p => p.ProductID == 706);

            return value;
        }
        #endregion

        #region SingleOrDefaultQuery
        /// <summary>
        /// Locate a specific product using SingleOrDefault()
        /// NOTE: SingleOrDefault() returns a single element found in the collection, or a null value if none found in the collection, if multiple values are found an exception is thrown.
        /// SingleOrDefault() always searches the complete collection
        /// </summary>
        public Product SingleOrDefaultQuery()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Query Syntax Here
            //value = (from p in products
            //         select p)
            //          .SingleOrDefault(p => p.ProductID == 706);

            // Test the exception handling for finding multiple values
            //value = (from prod in products
            //         select prod)
            //        .SingleOrDefault(p => p.Color == "Red");



            // Test the exception handling for the list is empty
            //products.Clear();
            //value = (from p in products
            //         select p)
            //          .SingleOrDefault(p => p.ProductID == 706);

            // Test the exception handling for the list is empty and a default value is supplied
            products.Clear();
            value = (from p in products
                     select p)
                      .SingleOrDefault(p => p.ProductID == 706,
                                        new Product
                                        {
                                            ProductID = -1,
                                            Name = "NOT FOUND"
                                        });

            // Test the exception handling for the list is null


            return value;
        }
        #endregion

        #region SingleOrDefaultMethod
        /// <summary>
        /// Locate a specific product using SingleOrDefault()
        /// NOTE: SingleOrDefault() returns a single element found in the collection, or a null value if none found in the collection, if multiple values are found an exception is thrown.
        /// SingleOrDefault() always searches the complete collection
        /// </summary>
        public Product SingleOrDefaultMethod()
        {
            List<Product> products = GetProducts();
            Product value = null;

            // Write Method Syntax Here
            value = products.SingleOrDefault(p => p.ProductID == 706);

            return value;
        }
        #endregion

        #region TakeQuery
        /// <summary>
        /// Use Take() to select a specified number of items from the beginning of a collection
        /// </summary>
        public List<Product> TakeQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from p in products
                    orderby p.Name
                    select p).Take(5).ToList();

            return list;
        }
        #endregion

        #region TakeMethod
        /// <summary>
        /// Use Take() to select a specified number of items from the beginning of a collection
        /// </summary>
        public List<Product> TakeMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = products.OrderBy(p => p.Name).Take(5).ToList();


            return list;
        }
        #endregion

        #region TakeRangeQuery
        /// <summary>
        /// Use Take() to select a specified number of items from a collection using the Range operator
        /// </summary>
        public List<Product> TakeRangeQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from p in products
                    orderby p.Name
                    select p)
                    .Take(5..8).ToList();
 
            return list;
        }
        #endregion

        #region TakeRangeMethod
        /// <summary>
        /// Use Take() to select a specified number of items from the beginning of a collection
        /// </summary>
        public List<Product> TakeRangeMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = products.OrderBy(p => p.Name).Take(5..8).ToList();

            return list;
        }
        #endregion

        #region TakeWhileQuery
        /// <summary>
        /// Use TakeWhile() to select a specified number of items from the beginning of a collection based on a true condition
        /// </summary>
        public List<Product> TakeWhileQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = ( from p in products
                     orderby p.Name
                     select p)
                     .TakeWhile(p => p.Name.StartsWith("A"))
                     .ToList();

            return list;
        }
        #endregion

        #region TakeWhileMethod
        /// <summary>
        /// Use TakeWhile() to select a specified number of items from the beginning of a collection based on a true condition
        /// </summary>
        public List<Product> TakeWhileMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.OrderBy(p => p.Name).TakeWhile(p => p.Name.StartsWith("A")).ToList();


            return list;
        }
        #endregion

        #region SkipQuery
        /// <summary>
        /// Use Skip() to move past a specified number of items from the beginning of a collection
        /// </summary>
        public List<Product> SkipQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from p in products
                    orderby p.Name
                    select p)
                    .Skip(30)
                    .ToList();


            return list;
        }
        #endregion

        #region SkipMethod
        /// <summary>
        /// Use Skip() to move past a specified number of items from the beginning of a collection
        /// </summary>
        public List<Product> SkipMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            //Pagining
            list = products.OrderBy(p => p.Name).Skip(5).Take(5).ToList();


            return list;
        }
        #endregion

        #region SkipWhileQuery
        /// <summary>
        /// Use SkipWhile() to move past a specified number of items from the beginning of a collection based on a true condition
        /// </summary>
        public List<Product> SkipWhileQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from p in products
                    orderby p.Name
                    select p)
                    .SkipWhile(p => p.Name.StartsWith("A")).ToList();   

            return list;
        }
        #endregion

        #region SkipWhileMethod
        /// <summary>
        /// Use SkipWhile() to move past a specified number of items from the beginning of a collection based on a true condition
        /// </summary>
        public List<Product> SkipWhileMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.OrderBy(p => p.Name).SkipWhile(p => p.Name.StartsWith("A")).ToList();

            return list;
        }
        #endregion

        #region DistinctQuery
        /// <summary>
        /// The Distinct() operator finds all unique values within a collection.
        /// In this sample you put distinct product colors into another collection using LINQ
        /// </summary>
        public List<string> DistinctQuery()
        {
            List<Product> products = GetProducts();
            List<string> list = new();

            // Write Query Syntax Here
            list = (from p in products
                    select p.Color).Distinct().OrderBy(c => c).ToList();

            return list;
        }
        #endregion

        #region DistinctWhere
        /// <summary>
        /// The Distinct() operator finds all unique values within a collection.
        /// In this sample you put distinct product colors into another collection using LINQ
        /// </summary>
        public List<string> DistinctWhere()
        {
            List<Product> products = GetProducts();
            List<string> list = new();

            // Write Method Syntax Here
            list = products.Select(p => p.Color).Distinct().OrderBy(c => c).ToList();

            return list;
        }
        #endregion

        #region DistinctByQuery
        public List<Product> DistinctByQuery()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Query Syntax Here
            list = (from p in products
                    select p)
                    .DistinctBy(p => p.Color)
                    .OrderBy(p => p.Color)
                    .ToList();

            return list;
        }
        #endregion

        #region DistinctByMethod
        public List<Product> DistinctByMethod()
        {
            List<Product> products = GetProducts();
            List<Product> list = new();

            // Write Method Syntax Here
            list = products.DistinctBy(p => p.Color).OrderBy(p => p.Color).ToList();

            return list;
        }
        #endregion

        #region ChunkQuery
        /// <summary>
        /// Chunk() splits the elements of a larger list into a collection of arrays of a specified size where each element of the collection is an array of those items.
        /// </summary>
        public List<Product[]> ChunkQuery()
        {
            List<Product> products = GetProducts();
            List<Product[]> list = new();

            // Write Query Syntax Here
            list = (from p in products
                    select p)
                    .Chunk(5)
                    .ToList();

            return list;
        }
        #endregion

        #region ChunkMethod
        /// <summary>
        /// Chunk() splits the elements of a larger list into a collection of arrays of a specified size where each element of the collection is an array of those items.
        /// </summary>
        public List<Product[]> ChunkMethod()
        {
            List<Product> products = GetProducts();
            List<Product[]> list = new();

            // Write Method Syntax Here
            list = products.Chunk(5).ToList();

            return list;
        }
        #endregion

        #region AllQuery
        /// <summary>
        /// Use All() to see if all items in a collection meet a specified condition
        /// </summary>
        public bool AllQuery()
        {
            List<Product> products = GetProducts();
            bool value = false;

            // Write Query Syntax Here
            value = (from prod in products
                     select prod)
                     .All(prod => prod.ListPrice > prod.StandardCost);

            return value;
        }
        #endregion

        #region AllMethod
        /// <summary>
        /// Use All() to see if all items in a collection meet a specified condition
        /// </summary>
        public bool AllMethod()
        {
            List<Product> products = GetProducts();
            bool value = false;

            // Write Method Syntax Here
            value = products.All(prod => prod.ListPrice > prod.StandardCost);

            return value;
        }
        #endregion

        #region AllSalesQuery
        /// <summary>
        /// Use All() to see if all items in a collection meet a specified condition
        /// </summary>
        public bool AllSalesQuery()
        {
            List<SalesOrder> sales = GetSales();
            bool value = false;

            // Write Query Syntax Here
            value = (from s in sales
                     select s)
                     .All(s => s.OrderQty >= 1 ); 

            return value;
        }
        #endregion

        #region AllSalesMethod
        /// <summary>
        /// Use All() to see if all items in a collection meet a specified condition
        /// </summary>
        public bool AllSalesMethod()
        {
            List<SalesOrder> sales = GetSales();
            bool value = false;

            // Write Method Syntax Here
            value = sales.All(s => s.OrderQty >= 1);

            return value;
        }
        #endregion

        #region AnyQuery
        /// <summary>
        /// Use Any() to see if at least one item in a collection meets a specified condition
        /// </summary>
        public bool AnyQuery()
        {
            List<SalesOrder> sales = GetSales();
            bool value = false;

            // Write Query Syntax Here
            value = (from s in sales
                     select s)
                     .Any(s => s.LineTotal >10000);

            return value;
        }
        #endregion

        #region AnyMethod
        /// <summary>
        /// Use Any() to see if at least one item in a collection meets a specified condition
        /// </summary>
        public bool AnyMethod()
        {
            List<SalesOrder> sales = GetSales();
            bool value = false;

            // Write Method Syntax Here
            value = sales.Any(s => s.LineTotal > 10000);

            return value;
        }
        #endregion

        #region ContainsQuery
        /// <summary>
        /// Use the Contains() operator to see if a collection contains a specific value
        /// </summary>
        public bool ContainsQuery()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            bool value = false;

            // Write Query Syntax Here
            value = (from num in numbers
                     select num)
                     .Contains(3);

            return value;
        }
        #endregion

        #region ContainsMethod
        /// <summary>
        /// Use the Contains() operator to see if a collection contains a specific value
        /// </summary>
        public bool ContainsMethod()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5 };
            bool value = false;

            // Write Method Syntax Here
            value = numbers.Contains(3);

            return value;
        }
        #endregion

        #region ContainsComparerQuery
        /// <summary>
        /// Use the Contains() operator to see if a collection contains a specific value
        /// </summary>
        public bool ContainsComparerQuery()
        {
            List<Product> products = GetProducts();
            ProductIdComparer pc = new();
            bool value = false;

            // Write Query Syntax Here
            value = (from prod in products
                     select prod)
                    .Contains(new Product { ProductID = 744 }, pc);

            return value;
        }
        #endregion

        #region ContainsComparerMethod
        /// <summary>
        /// Use the Contains() operator to see if a collection contains a specific value.
        /// When comparing classes, you need to write a EqualityComparer class.
        /// </summary>
        public bool ContainsComparerMethod()
        {
            List<Product> products = GetProducts();
            ProductIdComparer pc = new();
            bool value = false;

            // Write Method Syntax Here
            value = products.Contains(new Product { ProductID = 744 }, pc);

            return value;
        }
        #endregion

        #region SequenceEqualIntegersQuery
        /// <summary>
        /// SequenceEqual() compares two different collections to see if they are equal
        /// When using simple data types such as int, string, a direct comparison between values is performed
        /// </summary>
        public bool SequenceEqualIntegersQuery()
        {
            bool value = false;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 1, 2, 3, 4, 5 };

            // Write Query Syntax Here
            value = (from num in list1
                     select num).SequenceEqual(list2);

            return value;
        }
        #endregion

        #region SequenceEqualIntegersMethod
        /// <summary>
        /// SequenceEqual() compares two different collections to see if they are equal
        /// When using simple data types such as int, string, a direct comparison between values is performed
        /// </summary>
        public bool SequenceEqualIntegersMethod()
        {
            bool value = false;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 1, 2, 3, 4, 5 };

            // Write Method Syntax Here
            value = list1.SequenceEqual(list2);

            return value;
        }
        #endregion

        #region SequenceEqualObjectsQuery
        /// <summary>
        /// When using a collection of objects, SequenceEqual() performs a comparison to see if the two object references point to the same object
        /// </summary>
        public bool SequenceEqualObjectsQuery()
        {
            bool value = false;
            // Create a list of products
                    List<Product> list1 = new()
              {
                new Product { ProductID = 1, Name = "Product 1" },
                new Product { ProductID = 2, Name = "Product 2" },
              };
                    // Create a list of products
                    List<Product> list2 = new()
              {
                new Product { ProductID = 1, Name = "Product 1" },
                new Product { ProductID = 2, Name = "Product 2" },
              };

            // Make Collections the Same
            list2 = list1;

            // Write Query Syntax Here
            value = (from prod in list1
                     select prod).SequenceEqual(list2); 


            return value;
        }
        #endregion

        #region SequenceEqualObjectsMethod
        /// <summary>
        /// When using a collection of objects, SequenceEqual() performs a comparison to see if the two object references point to the same object
        /// </summary>
        public bool SequenceEqualObjectsMethod()
        {
            bool value = false;
            // Create a list of products
               List<Product> list1 = new()
              {
                new Product { ProductID = 1, Name = "Product 1" },
                new Product { ProductID = 2, Name = "Product 2" },
              };
                    // Create a list of products
                    List<Product> list2 = new()
              {
                new Product { ProductID = 1, Name = "Product 1" },
                new Product { ProductID = 2, Name = "Product 2" },
              };

            // Make Collections the Same
             list2 = list1;

            // Write Method Syntax Here
            value = list1.SequenceEqual(list2);

            return value;
        }
        #endregion

        #region SequenceEqualUsingComparerQuery
        /// <summary>
        /// Use an EqualityComparer class to determine if the objects are the same based on the values in properties
        /// </summary>
        public bool SequenceEqualUsingComparerQuery()
        {
            bool value = false;
            ProductComparer pc = new ProductComparer();

            // Load all Product Data From Data Source 1
            List<Product> list1 = ProductRepository.GetAll();

            // Load all Product Data From Data Source 2
            List<Product> list2 = ProductRepository.GetAll();

            // Remove an element from 'list1' to make the collections different
            list1.RemoveAt(0);

            // Write Query Syntax Here
            value = (from prod in list1 
                     select prod)
                     .SequenceEqual(list2, pc);

            return value;
        }
        #endregion

        #region SequenceEqualUsingComparerMethod
        /// <summary>
        /// Use an EqualityComparer class to determine if the objects are the same based on the values in properties
        /// </summary>
        public bool SequenceEqualUsingComparerMethod()
        {
            bool value = false;
            ProductComparer pc = new ProductComparer();
            // Load all Product Data From Data Source 1
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data From Data Source 2
            List<Product> list2 = ProductRepository.GetAll();

            // Remove an element from 'list1' to make the collections different
            //list1.RemoveAt(0);

            // Write Method Syntax Here
            value = list1.SequenceEqual(list2, pc);


            return value;
        }
        #endregion

        #region ExceptIntegersQuery
        /// <summary>
        /// Find all values in one list that are not in the other list
        /// </summary>
        public List<int> ExceptIntegersQuery()
        {
            List<int> list = null;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 3, 4, 5 };

            // Write Query Syntax Here
            list = (from prod in list1
                    select prod)
                    .Except(list2).ToList();

            return list;
        }
        #endregion

        #region ExceptIntegersMethod
        /// <summary>
        /// Find all values in one list that are not in the other list
        /// </summary>
        public List<int> ExceptIntegersMethod()
        {
            List<int> list = null;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 3, 4, 5 };

            // Write Method Syntax Here
            list = list1.Except(list2).ToList();

            return list;
        }
        #endregion

        #region ExceptProductSalesQuery
        /// <summary>
        /// Find all products that do not have sales
        /// </summary>
        public List<int> ExceptProductSalesQuery()
        {
            List<int> list = null;
            List<Product> products = ProductRepository.GetAll();
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    select prod.ProductID)
                    .Except(from sale in sales
                            select sale.ProductID).ToList();

            return list;
        }
        #endregion

        #region ExceptProductSalesMethod
        /// <summary>
        /// Find all products that do not have sales
        /// </summary>
        public List<int> ExceptProductSalesMethod()
        {
            List<int> list = null;
            List<Product> products = ProductRepository.GetAll();
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.Select(p => p.ProductID)
                         .Except(sales.Select(sale => sale.ProductID)).ToList();

            return list;
        }
        #endregion

        #region ExceptUsingComparerQuery
        /// <summary>
        /// Find all products that are in one list but not the other using a comparer class
        /// </summary>
        public List<Product> ExceptUsingComparerQuery()
        {
            List<Product> list = null;
            ProductComparer pc = new();
            // Load all Product Data From Data Source 1
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data From Data Source 2
            List<Product> list2 = ProductRepository.GetAll();

            // Remove all products with color = "Black" from 'list2'
            // to give us a difference in the two lists
            list2.RemoveAll(prod => prod.Color == "Black");

            // Write Query Syntax Here
            list = (from prod in list1
                    select prod)
                    .Except(list2, pc).ToList();

            return list;
        }
        #endregion

        #region ExceptUsingComparerMethod
        /// <summary>
        /// Find all products that are in one list but not the other using a comparer class
        /// </summary>
        public List<Product> ExceptUsingComparerMethod()
        {
            List<Product> list = null;
            ProductComparer pc = new();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Remove all products with color = "Black" from 'list2'
            // to give us a difference in the two lists
            list2.RemoveAll(prod => prod.Color == "Black");

            // Write Method Syntax Here
            list = list1.Except(list2, pc).ToList();

            return list;
        }
        #endregion

        #region ExceptByQuery
        /// <summary>
        /// ExceptBy() finds products within a collection that DO NOT compare to a List<string> against a specified property in the collection.
        /// The default comparer for ExceptBy() is 'string'
        /// </summary>
        public List<Product> ExceptByQuery()
        {
            List<Product> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // The list of colors to exclude from the list
            List<string> colors = new() { "Red", "Black" };

            // Write Query Syntax Here
            list = (from p in products
                    select p)
                    .ExceptBy(colors, p => p.Color).ToList();

            return list;
        }
        #endregion

        #region ExceptByMethod
        /// <summary>
        /// ExceptBy() finds products within a collection that DO NOT compare to a List<string> against a specified property in the collection.
        /// The default comparer for ExceptBy() is 'string'
        /// </summary>
        public List<Product> ExceptByMethod()
        {
            List<Product> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // The list of colors to exclude from the list
            List<string> colors = new() { "Red", "Black" };

            // Write Method Syntax Here
            list = products.ExceptBy(colors, products => products.Color).ToList();

            return list;
        }
        #endregion

        #region ExceptByProductSalesQuery
        /// <summary>
        /// Find all products that do not have sales
        /// Change the default comparer for ExceptBy()
        /// </summary>
        public List<Product> ExceptByProductSalesQuery()
        {
            List<Product> list = null;
            List<Product> products = ProductRepository.GetAll();
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from p in products
                    select p)
                    .ExceptBy<Product, int>(
                        from sale in sales
                        select sale.ProductID,
                        p => p.ProductID).ToList();

            return list;
        }
        #endregion

        #region ExceptByProductSalesMethod
        /// <summary>
        /// Find all products that do not have sales
        /// Change the default comparer for ExceptBy()
        /// </summary>
        public List<Product> ExceptByProductSalesMethod()
        {
            List<Product> list = null;
            List<Product> products = ProductRepository.GetAll();
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.ExceptBy<Product, int>(
                sales.Select(s => s.ProductID), prod => prod.ProductID).ToList();

            return list;
        }
        #endregion

        #region IntersectIntegersQuery
        /// <summary>
        /// Intersect() finds all values in one list that are also in the other list
        /// </summary>
        public List<int> IntersectIntegersQuery()
        {
            List<int> list = null;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 3, 4, 5 };

            // Write Query Syntax Here
            list = (from num in list1
                    select num)
                    .Intersect(list2).ToList();

            return list;
        }
        #endregion

        #region IntersectIntegersMethod
        /// <summary>
        /// Intersect() finds all values in one list that are also in the other list
        /// </summary>
        public List<int> IntersectIntegersMethod()
        {
            List<int> list = null;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 3, 4, 5 };

            // Write Method Syntax Here
            list = list1.Intersect(list2).ToList();

            return list;
        }
        #endregion

        #region IntersectProductSalesQuery
        /// <summary>
        /// Find all products that have sales
        /// </summary>
        public List<int> IntersectProductSalesQuery()
        {
            List<int> list = null;
            List<Product> products = ProductRepository.GetAll();
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    select prod.ProductID)
                    .Intersect(from sale in sales select sale.ProductID)
                    .ToList();
              

            return list;
        }
        #endregion

        #region IntersectProductSalesMethod
        /// <summary>
        /// Find all products that have sales
        /// </summary>
        public List<int> IntersectProductSalesMethod()
        {
            List<int> list = null;
            List<Product> products = ProductRepository.GetAll();
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.Select(p => p.ProductID).Intersect(sales.Select(sale => sale.ProductID)).ToList();

            return list;
        }
        #endregion

        #region IntersectUsingComparerQuery
        /// <summary>
        /// Intersect() finds all products that are in common between two collections using a comparer class
        /// </summary>
        public List<Product> IntersectUsingComparerQuery()
        {
            List<Product> list = null;
            ProductComparer pc = new();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Remove 'black' products from 'list1'
            list1.RemoveAll(prod => prod.Color == "Black");
            // Remove 'red' products from 'list2'
            list2.RemoveAll(prod => prod.Color == "Red");

            // Write Query Syntax Here
            list = (from prod in list1
                    select prod)
                    .Intersect(list2, pc)
                    .ToList();

            return list;
        }
        #endregion

        #region IntersectUsingComparerMethod
        /// <summary>
        /// Intersect() finds all products that are in common between two collections using a comparer class
        /// </summary>
        public List<Product> IntersectUsingComparerMethod()
        {
            List<Product> list = null;
            ProductComparer pc = new();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Remove 'black' products from 'list1'
            list1.RemoveAll(prod => prod.Color == "Black");
            // Remove 'red' products from 'list2'
            list2.RemoveAll(prod => prod.Color == "Red");

            // Write Method Syntax Here
            list = list1.Intersect(list2, pc).ToList();

            return list;
        }
        #endregion

        #region IntersectByQuery
        /// <summary>
        /// Find products within a collection by comparing a List<string> against a specified property in the collection.
        /// </summary>
        public List<Product> IntersectByQuery()
        {
            List<Product> list = null;
            List<Product> products = ProductRepository.GetAll();

            // The list of colors to locate in the list
            List<string> colors = new() { "Red", "Black" };

            // Write Query Syntax Here
            list = (from p in products
                    select p)
                    .IntersectBy(colors, p => p.Color).ToList();

            return list;
        }
        #endregion

        #region IntersectByMethod
        /// <summary>
        /// IntersectBy() finds DISTINCT products within a collection by comparing a List<string> against a specified property in the collection.
        /// </summary>
        public List<Product> IntersectByMethod()
        {
            List<Product> list = null;
            List<Product> products = ProductRepository.GetAll();

            // The list of colors to locate in the list
            List<string> colors = new() { "Red", "Black" };

            // Write Method Syntax Here
            list = products.IntersectBy(colors, p => p.Color).ToList();

            return list;
        }
        #endregion

        #region IntersectByProductSalesQuery
        /// <summary>
        /// Find all products that have sales using a 'int' key selector
        /// Change the default comparer for IntersectBy()
        /// </summary>
        public List<Product> IntersectByProductSalesQuery()
        {
            List<Product> list = null;
            List<Product> products = ProductRepository.GetAll();
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from p in products
                    select p)
                      .IntersectBy<Product, int>(
                          from sale in sales
                          select sale.ProductID,
                          p => p.ProductID).ToList();

            return list;
        }
        #endregion

        #region IntersectByProductSalesMethod
        /// <summary>
        /// Find all products that have sales using a 'int' key selector
        /// Change the default comparer for IntersectBy()
        /// </summary>
        public List<Product> IntersectByProductSalesMethod()
        {
            List<Product> list = null;
            List<Product> products = ProductRepository.GetAll();
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.IntersectBy<Product,int>(
                sales.Select(s => s.ProductID),
                p => p.ProductID)
                .ToList();

            return list;
        }
        #endregion

        #region UnionIntegersQuery
        /// <summary>
        /// Union() combines two lists together, but skips duplicates
        /// This is like the UNION SQL operator
        /// </summary>
        public List<int> UnionIntegersQuery()
        {
            List<int> list = null;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 1, 2, 3, 4, 5 };

            // Write Query Syntax Here
            list = (from  num in list1
                    select num)
                    .Union(list2)
                    .OrderBy(num => num)
                    .ToList();

            return list;
        }
        #endregion

        #region UnionIntegersMethod
        /// <summary>
        /// Union() combines two lists together, but skips duplicates
        /// This is like the UNION SQL operator
        /// </summary>
        public List<int> UnionIntegersMethod()
        {
            List<int> list = null;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 1, 2, 3, 4, 5 };

            // Write Query Syntax Here
            list = list1.Union(list2)
                .OrderBy(num => num)
                .ToList();

            return list;
        }
        #endregion

        #region UnionQuery
        /// <summary>
        /// Union() combines two lists together, but skips duplicates by using a comparer class
        /// This is like the UNION SQL operator
        /// </summary>
        public List<Product> UnionQuery()
        {
            List<Product> list = null;
            ProductComparer pc = new();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in list1
                    select prod)
                    .Union(list2, pc)
                    .OrderBy(p => p.Name)
                    .ToList();

            return list;
        }
        #endregion

        #region UnionMethod
        /// <summary>
        /// Union() combines two lists together, but skips duplicates by using a comparer class
        /// This is like the UNION SQL operator
        /// </summary>
        public List<Product> UnionMethod()
        {
            List<Product> list = null;
            ProductComparer pc = new();
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Write Method Syntax Here
            list = list1.Union(list2,pc)
                .OrderBy(p => p.Name)
                .ToList();

            return list;
        }
        #endregion

        #region UnionByQuery
        /// <summary>
        /// UnionBy() combines two lists together using DISTINCT on the property specified. 
        /// </summary>
        public List<Product> UnionByQuery()
        {
            List<Product> list = null;
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Write Query Syntax Here
            list =  (from prod in list1
                     select prod)
                     .UnionBy(list2, p => p.Color) 
                     .OrderBy(p => p.Name) 
                     .ToList();

            return list;
        }
        #endregion

        #region UnionByMethod
        /// <summary>
        /// UnionBy() combines two lists together using DISTINCT on the property specified. 
        /// </summary>
        public List<Product> UnionByMethod()
        {
            List<Product> list = null;
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Write Method Syntax Here
            list = list1.UnionBy(list2, p => p.Color)
                .OrderBy(p => p.Name)
                .ToList();

            return list;
        }
        #endregion

        #region ConcatIntegersQuery
        /// <summary>
        /// The Concat() operator combines two lists together and does NOT check for duplicates
        /// This is like the UNION ALL SQL operator
        /// </summary>
        public List<int> ConcatIntegersQuery()
        {
            List<int> list = null;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 1, 2, 3, 4, 5 };

            // Write Query Syntax Here
            list = (from num in list1
                    select num)
                    .Concat(list2)
                    .OrderBy(num => num)
                    .ToList() ;

            return list;
        }
        #endregion

        #region ConcatIntegersMethod
        /// <summary>
        /// The Concat() operator combines two lists together and does NOT check for duplicates
        /// This is like the UNION ALL SQL operator
        /// </summary>
        public List<int> ConcatIntegersMethod()
        {
            List<int> list = null;
            // Create a list of numbers
            List<int> list1 = new() { 5, 2, 3, 4, 5 };
            // Create a list of numbers
            List<int> list2 = new() { 1, 2, 3, 4, 5 };

            // Write Query Syntax Here
            list = list1.Concat(list2)
                .OrderBy(num => num)
                .ToList() ;

            return list;
        }
        #endregion

        #region ConcatQuery
        /// <summary>
        /// The Concat() operator combines two lists together and does NOT check for duplicates
        /// This is like the UNION ALL SQL operator
        /// </summary>
        public List<Product> ConcatQuery()
        {
            List<Product> list = null;
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in list1
                    select prod)
                    .Concat(list2)
                    .OrderBy(p => p.Name)
                    .ToList() ;

            return list;
        }
        #endregion

        #region ConcatMethod
        /// <summary>
        /// The Concat() operator combines two lists together and does NOT check for duplicates
        /// This is like the UNION ALL SQL operator
        /// </summary>
        public List<Product> ConcatMethod()
        {
            List<Product> list = null;
            // Load all Product Data
            List<Product> list1 = ProductRepository.GetAll();
            // Load all Product Data
            List<Product> list2 = ProductRepository.GetAll();

            // Write Method Syntax Here
            list = list1.Concat(list2)
                .OrderBy(p => p.Name)
                .ToList() ;

            return list;
        }
        #endregion

        #region InnerJoinQuery
        /// <summary>
        /// Join a Sales Order collection with Products into anonymous class
        /// NOTE: This is an equijoin or an inner join
        /// </summary>
        public List<ProductOrder> InnerJoinQuery()
        {
            List<ProductOrder> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Order Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in  products
                    join sale in sales
                    on prod.ProductID equals sale.ProductID
                    select new ProductOrder
                    {
                        ProductID = prod.ProductID,
                        Name = prod.Name,
                        Color = prod.Color,
                        StandardCost = prod.StandardCost,
                        ListPrice = prod.ListPrice,
                        Size = prod.Size,
                        SalesOrderID = sale.SalesOrderID,
                        OrderQty = sale.OrderQty,
                        UnitPrice = sale.UnitPrice,
                        LineTotal   = sale.LineTotal
                    })
                    .OrderBy(p => p.Name).ToList() ;
                    

            return list;
        }
        #endregion

        #region InnerJoinMethod
        /// <summary>
        /// Join a Sales Order collection with Products into anonymous class
        /// NOTE: This is an equijoin or an inner join
        /// </summary>
        public List<ProductOrder> InnerJoinMethod()
        {
            List<ProductOrder> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Order Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.Join(sales, 
                prod => prod.ProductID,
                sale => sale.ProductID,
                (prod,sale) => new ProductOrder
                {
                    ProductID = prod.ProductID,
                    Name = prod.Name,
                    Color = prod.Color,
                    StandardCost = prod.StandardCost,
                    ListPrice = prod.ListPrice,
                    Size = prod.Size,
                    SalesOrderID = sale.SalesOrderID,
                    OrderQty = sale.OrderQty,
                    UnitPrice = sale.UnitPrice,
                    LineTotal = sale.LineTotal
                })
                .OrderBy (p => p.Name).ToList() ;

            return list;
        }
        #endregion

        #region InnerJoinTwoFieldsQuery
        /// <summary>
        /// Join a Sales Order collection with Products collection using two fields
        /// </summary>
        public List<ProductOrder> InnerJoinTwoFieldsQuery()
        {
            List<ProductOrder> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Order Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    join sale in sales
                    on 
                    new { prod.ProductID , Qty = (short)6}
                    equals
                    new {sale.ProductID, Qty = sale.OrderQty}
                    select new ProductOrder
                    { 
                        ProductID = prod.ProductID,
                        Name = prod.Name,
                        Color = prod.Color,
                        StandardCost = prod.StandardCost,
                        ListPrice = prod.ListPrice,
                        Size = prod.Size,
                        SalesOrderID= sale.SalesOrderID,
                        OrderQty = sale.OrderQty,
                        UnitPrice = sale.UnitPrice,
                        LineTotal = sale.LineTotal
                    })
                    .OrderBy(p => p.Name).ToList() ;

            return list;
        }
        #endregion

        #region InnerJoinTwoFieldsMethod
        /// <summary>
        /// Join a Sales Order collection with Products collection using two fields
        /// </summary>
        public List<ProductOrder> InnerJoinTwoFieldsMethod()
        {
            List<ProductOrder> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Order Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.Join(sales,
                prod => new { prod.ProductID , Qty = (short)6},
                sale => new { sale.ProductID, Qty = sale.OrderQty},
                (prod,sale) => new ProductOrder
                {
                    ProductID = prod.ProductID,
                    Name = prod.Name,
                    Color = prod.Color,
                    StandardCost = prod.StandardCost,
                    ListPrice = prod.ListPrice,
                    Size = prod.Size,
                    SalesOrderID = sale.SalesOrderID,
                    OrderQty = sale.OrderQty,
                    UnitPrice = sale.UnitPrice,
                    LineTotal = sale.LineTotal
                })
                .OrderBy(p => p.Name).ToList();

            return list;
        }
        #endregion

        #region JoinIntoQuery
        /// <summary>
        /// Use 'into' to create a new object with a Sales collection for each Product
        /// This is like a combination of an inner join and left outer join
        /// The 'into' keyword allows you to put the sales into a 'sales' variable 
        /// that can be used to retrieve all sales for a specific product
        /// </summary>
        public List<ProductSales> JoinIntoQuery()
        {
            List<ProductSales> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Order Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    orderby prod.ProductID
                    join sale in sales
                    on prod.ProductID equals sale.ProductID
                    into newSales
                    select new ProductSales
                    {
                        Product = prod,
                        Sales = newSales.OrderBy(s => s.SalesOrderID).ToList()
                    }).ToList();

            return list;
        }
        #endregion

        #region JoinIntoMethod
        /// <summary>
        /// Use GroupJoin() to create a new object with a Sales collection for each Product
        /// This is like a combination of an inner join and left outer join
        /// The GroupJoin() method replaces the into keyword
        /// </summary>
        public List<ProductSales> JoinIntoMethod()
        {
            List<ProductSales> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Order Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.OrderBy(p => p.ProductID)
                .GroupJoin(sales,
                    prod => prod.ProductID,
                    sale => sale.ProductID,
                    (prod, newSales) => new ProductSales
                    {
                        Product = prod,
                        Sales = newSales.OrderBy(s => s.SalesOrderID).ToList()
                    })
                    .ToList();


            return list;
        }
        #endregion

        #region LeftOuterJoinQuery
        /// <summary>
        /// Perform a left join between Products and Sales using DefaultIfEmpty() and SelectMany()
        /// </summary>
        public List<ProductOrder> LeftOuterJoinQuery()
        {
            List<ProductOrder> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Order Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    join sale in sales
                    on prod.ProductID equals sale.ProductID
                    into newSales
                    from sale in newSales.DefaultIfEmpty()
                    select new ProductOrder
                    {
                        ProductID = prod.ProductID,
                        Name = prod.Name,
                        Color = prod.Color,
                        StandardCost = prod.StandardCost,
                        ListPrice = prod.ListPrice,
                        Size = prod.Size,
                        SalesOrderID = sale?.SalesOrderID, //use the null-conditional operator
                        OrderQty = sale?.OrderQty,
                        UnitPrice = sale?.UnitPrice,
                        LineTotal = sale?.LineTotal
                    })
                    .OrderBy(p => p.Name).ToList();

            return list;
        }
        #endregion

        #region LeftOuterJoinMethod
        /// <summary>
        /// Perform a left join between Products and Sales using DefaultIfEmpty() and SelectMany()
        /// </summary>
        public List<ProductOrder> LeftOuterJoinMethod()
        {
            List<ProductOrder> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Order Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = products.SelectMany(
                prod => sales.Where(s => s.ProductID == prod.ProductID).DefaultIfEmpty(),
                (prod, sale) => new ProductOrder
                {
                    ProductID = prod.ProductID,
                    Name = prod.Name,
                    Color = prod.Color,
                    StandardCost = prod.StandardCost,
                    ListPrice = prod.ListPrice,
                    Size = prod.Size,
                    SalesOrderID = sale?.SalesOrderID, //use the null-conditional operator
                    OrderQty = sale?.OrderQty,
                    UnitPrice = sale?.UnitPrice,
                    LineTotal = sale?.LineTotal
                })
                .OrderBy(p => p.Name).ToList();

            return list;
        }
        #endregion

        #region GroupByQuery
        /// <summary>
        /// Group products by Size property. orderby is optional, but generally used
        /// </summary>
        public List<IGrouping<string, Product>> GroupByQuery()
        {
            List<IGrouping<string, Product>> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    orderby prod.Size
                    group prod by prod.Size).ToList();  

            return list;
        }
        #endregion

        #region GroupByMethod
        /// <summary>
        /// Group products by Size property. orderby is optional, but generally used
        /// </summary>
        public List<IGrouping<string, Product>> GroupByMethod()
        {
            List<IGrouping<string, Product>> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            list = products
                .OrderBy(p => p.Size)
                .GroupBy(p => p.Size)
                .ToList();

            return list;
        }
        #endregion

        #region GroupByIntoQuery
        /// <summary>
        /// Group products by Size property. 'into' is optional.
        /// </summary>
        public List<IGrouping<string, Product>> GroupByIntoQuery()
        {
            List<IGrouping<string, Product>> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    group prod by prod.Size into sizes
                    orderby sizes.Key
                    select sizes).ToList();

            return list;
        }
        #endregion

        #region GroupByUsingKeyQuery
        /// <summary>
        /// After selecting 'into' new variable, can sort on the 'Key' property. Key property has the value of what you grouped on.
        /// </summary>
        public List<IGrouping<string, Product>> GroupByUsingKeyQuery()
        {
            List<IGrouping<string, Product>> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            list = products.GroupBy(prod => prod.Size)
                            .OrderBy(sizes => sizes.Key) 
                            .Select(sizes => sizes)
                            .ToList();

            return list;
        }
        #endregion

        #region GroupByUsingKeyMethod
        /// <summary>
        /// After selecting 'into' new variable, can sort on the 'Key' property. Key property has the value of what you grouped on.
        /// </summary>
        public List<IGrouping<string, Product>> GroupByUsingKeyMethod()
        {
            List<IGrouping<string, Product>> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here


            return list;
        }
        #endregion

        #region GroupByWhereQuery
        /// <summary>
        /// Group products by Size property and where the group has more than 2 members
        /// This simulates a HAVING clause in SQL
        /// </summary>
        public List<IGrouping<string, Product>> GroupByWhereQuery()
        {
            List<IGrouping<string, Product>> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    orderby prod.Size
                    group prod by prod.Size into sizes
                    where sizes.Count() >2
                    select sizes).ToList();

            return list;
        }
        #endregion

        #region GroupByWhereMethod
        /// <summary>
        /// Group products by Size property and where the group has more than 2 members
        /// This simulates a HAVING clause in SQL
        /// </summary>
        public List<IGrouping<string, Product>> GroupByWhereMethod()
        {
            List<IGrouping<string, Product>> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            list = products.OrderBy(p => p.Size)
                            .GroupBy(prod => prod.Size)
                            .Where(sizes => sizes.Count() >2)
                            .Select(sizes => sizes)
                           .ToList();

            return list;
        }
        #endregion

        #region GroupBySubQueryQuery
        /// <summary>
        /// Group Sales by SalesOrderID, add Products into new Sales Order object using a subquery
        /// </summary>
        public List<SaleProducts> GroupBySubQueryQuery()
        {
            List<SaleProducts> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            list = (from sale in sales
                    orderby sale.SalesOrderID
                    group sale by sale.SalesOrderID into newSales
                    select new SaleProducts
                    {
                        SalesOrderID = newSales.Key,
                        Products = (from p in products
                                    orderby p.ProductID
                                    join sale in sales
                                    on p.ProductID equals sale.ProductID
                                    where sale.SalesOrderID == newSales.Key
                                    select p).ToList()
                    }).ToList();


            return list;
        }
        #endregion

        #region GroupBySubQueryMethod
        /// <summary>
        /// Group Sales by SalesOrderID, add Products into new Sales Order object using a subquery
        /// </summary>
        public List<SaleProducts> GroupBySubQueryMethod()
        {
            List<SaleProducts> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Load all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            list = sales.OrderBy(s => s.SalesOrderID)
                        .GroupBy(sale => sale.SalesOrderID)
                        .Select(newSales => new SaleProducts
                        {
                            SalesOrderID = newSales.Key,
                            Products = products.OrderBy(p => p.ProductID)
                                                .Join(newSales,
                                                prod => prod.ProductID,
                                                sale => sale.ProductID,
                                                (prod, sale) => prod).ToList()
                        }).ToList();

            return list;
        }
        #endregion

        #region GroupByDistinctQuery
        /// <summary>
        /// The Distinct() operator can be simulated using the GroupBy() and FirstOrDefault() operators
        /// In this sample you put distinct product colors into another collection using LINQ
        /// </summary>
        public List<string> GroupByDistinctQuery()
        {
            List<string> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            list = (from prod in products
                    orderby prod.Color
                    group prod by prod.Color into groupedColors
                    select groupedColors.FirstOrDefault().Color).ToList();
                   

            return list;
        }
        #endregion

        #region GroupByDistinctMethod
        /// <summary>
        /// The Distinct() operator can be simulated using the GroupBy() and FirstOrDefault() operators
        /// In this sample you put distinct product colors into another collection using LINQ
        /// </summary>
        public List<string> GroupByDistinctMethod()
        {
            List<string> list = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            list = products.GroupBy(p => p.Color)
                            .Select(groupedColors => groupedColors.FirstOrDefault().Color) 
                            .OrderBy(c => c)
                            .ToList();

            return list;
        }
        #endregion
        #region CountQuery
        /// <summary>
        /// Gets the total number of products in a collection
        /// </summary>
        public int CountQuery()
        {
            int value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            value = (from prod in products
                     select prod)
                     .Count();

            return value;
        }
        #endregion

        #region CountMethod
        /// <summary>
        /// Gets the total number of products in a collection
        /// </summary>
        public int CountMethod()
        {
            int value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            value = products.Count();

            return value;
        }
        #endregion

        #region CountFilteredQuery
        /// <summary>
        /// Can either add a where clause or a predicate in the Count() method
        /// </summary>
        public int CountFilteredQuery()
        {
            int value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here
            value = (from prod in products
                     select prod)
                     .Count(p => p.Color=="Red");


            // Write Query Syntax #2 Here
            value = (from prod in products
                     where prod.Color == "Red"
                     select prod)
                     .Count();

            return value;
        }
        #endregion

        #region CountFilteredMethod
        /// <summary>
        /// Gets the total number of products in a collection
        /// </summary>
        public int CountFilteredMethod()
        {
            int value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
            value = products.Count(p => p.Color == "Red");

            // Write Method Syntax #2 Here
            value = products.Where(p => p.Color == "Red").Count();

            return value;
        }
        #endregion

        #region MinQuery
        /// <summary>
        /// Get the minimum value of a single property in a collection
        /// </summary>
        public decimal MinQuery()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here
            value = (from prod in products
                     select prod.ListPrice)
                     .Min();

            // Write Query Syntax #2 Here
            value = (from prod in products
                     select prod)
                     .Min(prod => prod.ListPrice);

            return value;
        }
        #endregion

        #region MinMethod
        /// <summary>
        /// Get the minimum value of a single property in a collection
        /// </summary>
        public decimal MinMethod()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
            value = products.Select(p => p.ListPrice).Min();

            // Write Method Syntax #2 Here
            value = products.Min(prod => prod.ListPrice);

            return value;
        }
        #endregion

        #region MaxQuery
        /// <summary>
        /// Get the maximum value of a single property in a collection
        /// </summary>
        public decimal MaxQuery()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here
            value = (from prod in products
                     select prod.ListPrice) .Max();

            // Write Query Syntax #2 Here
            value = (from prod in products
                     select prod)
                     .Max(prod => prod.ListPrice);

            return value;
        }
        #endregion

        #region MaxMethod
        /// <summary>
        /// Get the maximum value of a single property in a collection
        /// </summary>
        public decimal MaxMethod()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
            value = products.Select(p => p.ListPrice).Max();

            // Write Method Syntax #2 Here
            value = products.Max(p => p.ListPrice);

            return value;
        }
        #endregion

        #region MinByQuery
        /// <summary>
        /// Get the minimum value of a single property in a collection, but return the object
        /// </summary>
        public Product MinByQuery()
        {
            Product product = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            product = (from prod in products
                       select prod)
                       .MinBy(prod => prod.ListPrice);

            return product;
        }
        #endregion

        #region MinByMethod
        /// <summary>
        /// Get the minimum value of a single property in a collection, but return the object
        /// </summary>
        public Product MinByMethod()
        {
            Product product = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            product = products.MinBy(prod => prod.ListPrice);

            return product;
        }
        #endregion

        #region MaxByQuery
        /// <summary>
        /// Get the maximum value of a single property in a collection, but return the object
        /// </summary>
        public Product MaxByQuery()
        {
            Product product = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            product = (from prod in products
                       select prod).MaxBy(p => p.ListPrice);

            return product;
        }
        #endregion

        #region MaxByMethod
        /// <summary>
        /// Get the maximum value of a single property in a collection, but return the object
        /// </summary>
        public Product MaxByMethod()
        {
            Product product = null;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            product = products.MaxBy(p => p.ListPrice);

            return product;
        }
        #endregion

        #region AverageQuery
        /// <summary>
        /// Get the average of all values within a single property in a collection
        /// </summary>
        public decimal AverageQuery()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here
            value = (from prod in products
                     select prod.ListPrice)
                     .Average();

            // Write Query Syntax #2 Here
            value = (from prod in products
                     select prod) 
                     .Average(p => p.ListPrice);

            return value;
        }
        #endregion

        #region AverageMethod
        /// <summary>
        /// Get the average of all values within a single property in a collection
        /// </summary>
        public decimal AverageMethod()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
            value = products.Select(p => p.ListPrice).Average();

            // Write Method Syntax #2 Here
            value = products.Average(p => p.ListPrice);

            return value;
        }
        #endregion

        #region SumQuery
        /// <summary>
        /// Gets the sum of the values of a single property in a collection
        /// </summary>
        public decimal SumQuery()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax #1 Here
            value = (from prod in products
                     select prod)
                     .Sum(p => p.ListPrice);

            // Write Query Syntax #2 Here
            value = (from prod in products
                     select prod.ListPrice).Sum();

            return value;
        }
        #endregion

        #region SumMethod
        /// <summary>
        /// Gets the sum of the values of a single property in a collection
        /// </summary>
        public decimal SumMethod()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax #1 Here
            value  = products.Sum(p => p.ListPrice);

            // Write Method Syntax #1 Here
            value = products.Select(p => p.ListPrice).Sum();

            return value;
        }
        #endregion

        #region AggregateQuery
        /// <summary>
        /// Aggregate allows you to iterate over a collection and perform an accumulation of values. With this operator you can simulate count, sum, etc.
        /// </summary>
        public decimal AggregateQuery()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here
            value = (from prod in products
                     select prod)
                     .Aggregate(0M, (sum, prod) =>
                          sum + prod.ListPrice);

            return value;
        }
        #endregion

        #region AggregateMethod
        /// <summary>
        /// Aggregate allows you to iterate over a collection and perform an accumulation of values. With this operator you can simulate count, sum, etc.
        /// </summary>
        public decimal AggregateMethod()
        {
            decimal value = 0;
            // Load all Product Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here
            value = products.Aggregate(0M, (sum, prod) => sum += prod.ListPrice);

            return value;
        }
        #endregion

        #region AggregateCustomQuery
        /// <summary>
        /// Use Sales Orders and calculate the total Sales by multiplying OrderQty * UnitPrice for each order
        /// </summary>
        public decimal AggregateCustomQuery()
        {
            decimal value = 0;
            // Load all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here
            value = (from sale in sales
                     select sale)
                     .Aggregate(0M, (sum, sale) =>
                         sum += (sale.OrderQty * sale.UnitPrice));

            return value;
        }
        #endregion

        #region AggregateCustomMethod
        /// <summary>
        /// Use Sales Orders and calculate the total Sales by multiplying OrderQty * UnitPrice for each order
        /// </summary>
        public decimal AggregateCustomMethod()
        {
            decimal value = 0;
            // Load all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here
            value = sales.Aggregate(0M, (sum, sale) =>
                sum += (sale.OrderQty * sale.UnitPrice));

            return value;
        }
        #endregion

        #region AggregateUsingGroupByQuery
        /// <summary>
        /// Group products by Size property and calculate min/max/average prices
        /// </summary>
        public List<ProductStats> AggregateUsingGroupByQuery()
        {
            List<ProductStats> list = null;
            // Load all Sales Data
            List<Product> products = ProductRepository.GetAll();

            // Write Query Syntax Here


            return list;
        }
        #endregion

        #region AggregateUsingGroupByMethod
        /// <summary>
        /// Group products by Size property and calculate min/max/average prices
        /// </summary>
        public List<ProductStats> AggregateUsingGroupByMethod()
        {
            List<ProductStats> list = null;
            // Load all Sales Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here


            return list;
        }
        #endregion

        #region AggregateMoreEfficientMethod
        /// <summary>
        /// Use Aggregate with some custom methods to gather the data in one pass 
        /// </summary>
        public List<ProductStats> AggregateMoreEfficientMethod()
        {
            List<ProductStats> list = null;
            // Load all Sales Data
            List<Product> products = ProductRepository.GetAll();

            // Write Method Syntax Here


            return list;
        }
        #endregion

        #region ForEachQuery
        /// <summary>
        /// ForEach allows you to iterate over a collection to perform assignments within each object.
        /// Assign the LineTotal from the OrderQty * UnitPrice
        /// When using the Query syntax, assign the result to a temporary variable.
        /// </summary>
        public List<SalesOrder> ForEachQuery()
        {
            // Get all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here


            return sales;
        }
        #endregion

        #region ForEachMethod
        /// <summary>
        /// ForEach allows you to iterate over a collection to perform assignments within each object.
        /// Assign the LineTotal from the OrderQty * UnitPrice
        /// </summary>
        public List<SalesOrder> ForEachMethod()
        {
            // Get all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here


            return sales;
        }
        #endregion

        #region ForEachSubQueryQuery
        /// <summary>
        /// Iterate over each object in the collection and call a sub query to calculate total sales
        /// </summary>
        public List<Product> ForEachSubQueryQuery()
        {
            // Get all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Get all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here


            return products;
        }
        #endregion

        #region ForEachSubQueryMethod
        /// <summary>
        /// Iterate over each object in the collection and call a sub query to calculate total sales
        /// </summary>
        public List<Product> ForEachSubQueryMethod()
        {
            // Get all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Get all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here


            return products;
        }
        #endregion

        #region ForEachQueryCallingMethodQuery
        /// <summary>
        /// Iterate over each object in the collection and call a method to set a property.
        /// This method passes in each Product object into the SalesForProduct() method.
        /// In the CalculateTotalSalesForProduct() method, the total sales for each Product is calculated.
        /// The total is placed into each Product objects' TotalSales property.
        /// </summary>
        public List<Product> ForEachQueryCallingMethodQuery()
        {
            // Get all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Get all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Query Syntax Here




            return null;
        }
        #endregion

        #region CalculateTotalSalesForProduct Method
        /// <summary>
        /// Helper method called by LINQ to sum sales for a product
        /// </summary>
        /// <param name="prod">A product</param>
        /// <returns>Total Sales for Product</returns>
        private decimal CalculateTotalSalesForProduct(Product prod, List<SalesOrder> sales)
        {
            return sales.Where(sale => sale.ProductID == prod.ProductID)
                        .Sum(sale => sale.LineTotal);
        }
        #endregion

        #region ForEachQueryCallingMethod
        /// <summary>
        /// Iterate over each object in the collection and call a method to set a property.
        /// This method passes in each Product object into the SalesForProduct() method.
        /// In the CalculateTotalSalesForProduct() method, the total sales for each Product is calculated.
        /// The total is placed into each Product objects' TotalSales property.
        /// </summary>
        public List<Product> ForEachQueryCallingMethod()
        {
            // Get all Product Data
            List<Product> products = ProductRepository.GetAll();
            // Get all Sales Data
            List<SalesOrder> sales = SalesOrderRepository.GetAll();

            // Write Method Syntax Here


            return products;
        }
        #endregion







        #region Extra Example
        public List<Product> ForEachQueryCalculateNameLength()
        {
            List<Product> products = GetProducts();
            List<Product> list;

            // Write Query Syntax Here
            list = (from prod in products
                    let tmp = prod.NameLength = prod.Name.Length
                    select prod).ToList();

            return list;
        }
        #endregion
    }
}
