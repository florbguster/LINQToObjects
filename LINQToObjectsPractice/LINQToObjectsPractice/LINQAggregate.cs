using Spike_LINQ_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQToObjectsPractice
{
    public class LINQAggregate
    {
        public static void AggregateWithLINQ()
        {
            Console.WriteLine( "First Spike" );
            List<string> numberList =
                new List<string>() { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

            // Invoke the <func> "string.Format("{0}, {1}", x, y)" for every element in 
            // [List<string> bar] appending the resulting strings to delimitedBar and 
            // returning the final version to commaDelimitedBar
            string commaDelimitedBar =
                        numberList.Aggregate( ( delimitedBar, barElement ) => string.Format( "{0}, {1}",
                                                                                            delimitedBar,
                                                                                            barElement ) );

            Console.WriteLine( commaDelimitedBar + "\r\n" );


            Console.WriteLine( "\n\nSecond Spike" );
            List<ShoppingItem> shoppingItems = new List<ShoppingItem>();

            shoppingItems.Add( new ShoppingItem() { ItemName = "Steak", Price = 10.99M } );
            shoppingItems.Add( new ShoppingItem() { ItemName = "Cereal", Price = 2.99M } );
            shoppingItems.Add( new ShoppingItem() { ItemName = "Potatoes", Price = 3.99M } );
            shoppingItems.Add( new ShoppingItem() { ItemName = "Orange Juice", Price = 1.99M } );
            shoppingItems.Add( new ShoppingItem() { ItemName = "Coffee", Price = 6.99M } );
            shoppingItems.Add( new ShoppingItem() { ItemName = "Cheese", Price = 3.49M } );
            shoppingItems.Add( new ShoppingItem() { ItemName = "Frozen Pizza", Price = 5.99M } );

            string groceryList = string.Empty;

            groceryList = shoppingItems
                .Aggregate( groceryList,
                            ( receipt, foo ) =>
                                receipt + string.Format( "{0, -15} {1:c}\r\n",
                                                         foo.ItemName,
                                                         foo.Price ) );

            decimal subtotal = shoppingItems.Select( x => x.Price )
                                       .Aggregate( ( price1, price2 ) => price1 + price2 );

            decimal tax = shoppingItems.Select( x => x.Price )
                .Aggregate( 0.0M, ( runningtotal, price ) => runningtotal + price, x => x * 0.06M );

            Console.Write( groceryList );
            Console.WriteLine();
            Console.WriteLine( string.Format( "{0, 15} {1:c}", "Subtotal", subtotal ) );
            Console.WriteLine( string.Format( "{0, 15} {1:c}", "Tax", tax ) );
            Console.WriteLine( string.Format( "{0, 15} {1:c}", "Total", subtotal + tax ) );

            Console.WriteLine( "\nPress any key to proceed GroupBy operations." );
            Console.ReadKey();
            Console.Clear();
        }
    }
}
