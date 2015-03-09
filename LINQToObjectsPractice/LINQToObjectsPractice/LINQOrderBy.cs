using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQToObjectsPractice
{
    public static class LINQGroupBy
    {
        public static void GroupByWithLINQ()
        {
            List<string> fullColorList = GetColors();

            DisplayFullList( fullColorList );

            Console.WriteLine( "\n" );

            var colorTypes = fullColorList.GroupBy( x => x )
                                          .Select( x => new
                                          {
                                              Name = x.Key,
                                              Count = x.Count()
                                          } );

            foreach (var colorType in colorTypes)
            {
                Console.WriteLine( "There are {0} {1}.", colorType.Count, colorType.Name );
            }

            Console.WriteLine( "\nPress any key to exit." );
            Console.ReadKey();
            Console.Clear();
        }

        private static void DisplayFullList( List<string> fullColorList )
        {
            Console.Write( "The list before grouping : " );
            foreach (string color in fullColorList)
            {
                Console.Write( color + " " );
            }
        }

        private static List<string> GetColors()
        {
            return new List<string> { "Yellow", "Green", "Blue", "Purple", 
                                      "Green", "Red", "Red", "Blue", "Red", 
                                      "Green", "Yellow", "Blue", "Yellow" };
        }
    }
}
