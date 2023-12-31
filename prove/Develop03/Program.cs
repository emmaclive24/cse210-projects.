using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop03 World!");
        // set a scripture here to test code.  Later, can pull these from somewhere else, like database or CSV file
        //where book, chapter and verse come from a column value and are already separated
        string scriptureString1 = "Jesus said unto him, Thou shalt love the Lord thy God with all thy heart, and with all thy soul, and with all thy mind. This is the first and great commandment. And the second is like unto it, Thou shalt love thy neighbour as thyself. On these two commandments hang all the law and the prophets.";
        string book1 = "Matthew";
        int chapter1= 22;
        int verse1= 37;
        bool isHidden = false;

        //create reference object
        Reference reference1 = new Reference(book1, chapter1, verse1);
       
        //create scripture object, passing the reference and the scripture
        //use if/else if more than one verse/range of verses
        Scripture newScripture = new Scripture(reference1, scriptureString1);
        
        Console.Clear();
        Console.WriteLine($"{reference1.GetDisplayText()} {newScripture.GetDisplayText()}");
        Console.WriteLine();
        Console.WriteLine("Press Enter to hide a word. Type quit to quit.");
        string userInput = Console.ReadLine();        
        
        while ((userInput != "quit") && (isHidden == false))  // had to change from or to and for negatives.
        // do
        {
            Console.Clear();
            // hide 3 random words
            for (int j = 0; j < 3; j++)
            {
                newScripture.HideRandomWords();
                isHidden = newScripture.IsCompletelyHidden();
                if (isHidden == true)
                {
                    break;
                }
            }
            
            Console.WriteLine($"{reference1.GetDisplayText()} {newScripture.GetDisplayText()}");
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide a word. Type quit to quit.");
            userInput = Console.ReadLine();
            isHidden = newScripture.IsCompletelyHidden();  //probably could remove this part and go back to a do/while loop.          
        } 
        
    }
}