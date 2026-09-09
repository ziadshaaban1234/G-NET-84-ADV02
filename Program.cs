namespace G_NET_84_ADV02
{
    internal class Program
    {
        #region All Methods

        // Func Delegate: takes a Product as input and returns a bool.
        // Used for flexible search conditions.
        public static List<Product> SearchProducts(
            List<Product> products,
            Func<Product, bool> filter)
        {
            List<Product> result = new();

            foreach (var item in products)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        // Action Delegate: takes a Product as input and does not return a value.
        // Used for printing products in different formats.
        public static void PrintReport(
            List<Product> products,
            Action<Product> action)
        {
            foreach (var item in products)
            {
                action(item);
            }
        }

        // Func Delegate: takes a Product as input and returns a string.
        // Used to transform each product into a different representation.
        public static List<string> TransformProducts(
            List<Product> products,
            Func<Product, string> transform)
        {
            List<string> result = new();

            foreach (var item in products)
            {
                result.Add(transform(item));
            }

            return result;
        }

        // Predicate Delegate: takes a Product as input and returns true or false.
        // Used for filtering products based on a condition.
        public static List<Product> FilterProducts(
            List<Product> products,
            Predicate<Product> filter)
        {
            List<Product> result = new();

            foreach (var item in products)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        #endregion

        static void Main(string[] args)
        {
            // ---------------- Product Catalog ----------------

            List<Product> catalog = new()
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Category = "Electronics",
                    Price = 1200,
                    Stock = 10
                },

                new Product
                {
                    Id = 2,
                    Name = "Phone",
                    Category = "Electronics",
                    Price = 800,
                    Stock = 25
                },

                new Product
                {
                    Id = 3,
                    Name = "T-Shirt",
                    Category = "Clothing",
                    Price = 30,
                    Stock = 100
                },

                new Product
                {
                    Id = 4,
                    Name = "Jeans",
                    Category = "Clothing",
                    Price = 60,
                    Stock = 50
                },

                new Product
                {
                    Id = 5,
                    Name = "Chocolate",
                    Category = "Food",
                    Price = 5,
                    Stock = 200
                },

                new Product
                {
                    Id = 6,
                    Name = "Coffee Beans",
                    Category = "Food",
                    Price = 15,
                    Stock = 80
                },

                new Product
                {
                    Id = 7,
                    Name = "C# Book",
                    Category = "Books",
                    Price = 45,
                    Stock = 30
                },

                new Product
                {
                    Id = 8,
                    Name = "Novel",
                    Category = "Books",
                    Price = 20,
                    Stock = 60
                },

                new Product
                {
                    Id = 9,
                    Name = "Headphones",
                    Category = "Electronics",
                    Price = 150,
                    Stock = 40
                },

                new Product
                {
                    Id = 10,
                    Name = "Jacket",
                    Category = "Clothing",
                    Price = 120,
                    Stock = 15
                }
            };


            // ==================================================
            // Task 01 : Smart Product Search
            // ==================================================

            #region SearchProducts

            Console.WriteLine("--- Electronics ---");

            List<Product> electronics =
                SearchProducts(
                    catalog,
                    p => p.Category == "Electronics"
                );

            foreach (var item in electronics)
            {
                Console.WriteLine(
                    $"{item.Name} - ${item.Price} (Stock: {item.Stock})"
                );
            }


            Console.WriteLine();
            Console.WriteLine("--- Under $50 ---");

            List<Product> under50 =
                SearchProducts(
                    catalog,
                    p => p.Price < 50
                );

            foreach (var item in under50)
            {
                Console.WriteLine(
                    $"{item.Name} - ${item.Price} (Stock: {item.Stock})"
                );
            }


            Console.WriteLine();
            Console.WriteLine("--- In Stock ---");

            List<Product> inStock =
                SearchProducts(
                    catalog,
                    p => p.Stock > 0
                );

            foreach (var item in inStock)
            {
                Console.WriteLine(
                    $"{item.Name} - ${item.Price} (Stock: {item.Stock})"
                );
            }


            Console.WriteLine();
            Console.WriteLine("--- Clothing Under $100 ---");

            List<Product> clothingUnder100 =
                SearchProducts(
                    catalog,
                    p => p.Category == "Clothing" && p.Price < 100
                );

            foreach (var item in clothingUnder100)
            {
                Console.WriteLine(
                    $"{item.Name} - ${item.Price} (Stock: {item.Stock})"
                );
            }

            #endregion


            // ==================================================
            // Task 03 : Custom Report Generator
            // ==================================================

            #region PrintReport

            Console.WriteLine();
            Console.WriteLine("--- Short Report ---");

            // Action: receives a Product and prints it.
            PrintReport(
                catalog,
                p => Console.WriteLine($"{p.Name} - ${p.Price}")
            );


            Console.WriteLine();
            Console.WriteLine("--- Detailed Report ---");

            PrintReport(
                catalog,
                p => Console.WriteLine(
                    $"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"
                )
            );

            #endregion


            #region TransformProducts

            Console.WriteLine();
            Console.WriteLine("--- Summary List ---");

            List<string> summaryList =
                TransformProducts(
                    catalog,
                    p => $"{p.Name} (${p.Price})"
                );

            foreach (var item in summaryList)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            Console.WriteLine("--- Price Labels ---");

            List<string> priceLabels =
                TransformProducts(
                    catalog,
                    p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}"
                );

            foreach (var item in priceLabels)
            {
                Console.WriteLine(item);
            }

            #endregion


            #region FilterProducts

            Console.WriteLine();
            Console.WriteLine("--- Low-Stock Alert ---");

            List<Product> lowStock =
                FilterProducts(
                    catalog,
                    p => p.Stock < 20
                );

            foreach (var item in lowStock)
            {
                Console.WriteLine(
                    $"[LOW STOCK] {item.Name}: only {item.Stock} left!"
                );
            }

            #endregion
        }
    }
}