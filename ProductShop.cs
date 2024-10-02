using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LexWeek02MiniProject
{
    public class ProductShop
    {
        bool running = true;
        ProductList prodList = new ProductList();

        public ProductShop() { }

        public void Run()
        {

            while (running)
            {
                Console.WriteLine(new string('-', 50));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("'P' to enter a new product | 'S' to searh for a product  | 'Q' to quit the program!");
                Console.ForegroundColor = ConsoleColor.White;
                char userInput = char.ToUpper(Console.ReadKey().KeyChar);
                //Console.ReadLine(); //Optional if i want to make sure the user has to press "Enter" to make their choice.
                                    //Although this makes it impossible for the user to erase their input. Erasing input can be achieved by using a string with "Trim()", make the switch case string to char.
                                    //The char is then plucked out as a substring where only the first character counts for their choice(substring[0]).
                Console.WriteLine();
                switch(userInput)
                {
                    case 'P': prodList.CreateItem();                        
                        break;
                    case 'S':
                        prodList.ShowSearchedProduct();
                        break;
                    case 'Q':
                        prodList.PrintInfo();
                        Console.WriteLine("Exiting program");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                };


    
            

            }
        }
    }
}
