using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace Little_Jarvis
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] TestStrings = new string[6] //Test input
            {
                "Send mail to Jack: blabla 1",
                "Send SMS to Mike: blabla bla 1",
                "Turn on light in living room",
                "Turn off conditioner in the kitchen",
                "Send mail to Jack2: blabla 2",
                "Send SMS to Mike2: blabla bla 2",
            };

            string[] CommandNames = new string[3] { "Send", "Turn on", "Turn off" }; 
            string[] Items = new string[4] { "mail", "SMS", "light", "conditioner" };
            string[] Addressee = new string[4] { "to Jack", "to Mike", "in living room", "in the kitchen" };

            Command<string>[] commandArray = new Command<string>[4] // the size of the  history queue is 4
                         {
            new Command<string>(CommandNames, Items, Addressee),
            new Command<string>(CommandNames, Items, Addressee),
            new Command<string>(CommandNames, Items, Addressee),
            new Command<string>(CommandNames, Items, Addressee),
                         };
            MyQueue<string> QueueInst = new MyQueue<string>(commandArray); // initialize queue for history
          
            string str = " ";
            int k = 0;
            int indx = 0;
            while (str != "q")
            {
                Console.WriteLine("Please select: 1=See the list of commands, 2=See usage example of commands, 3=Ask Jarvis to execute a command, 4=History of commands or q=quit");
                Console.WriteLine("Please enter your selection: ");
                str = Console.ReadLine();
                Command<string> comm_new = new Command<string>(CommandNames, Items, Addressee);
                switch (str)
                {
                    case "1":
                        comm_new.PrintCommands(); // Print available commands
                        break;
                    case "2":
                        comm_new.ExampleCommands(); // Print examples of command execution
                        break;
                    case "3":
                        if (k > 5) { k = 0; }
                        InputSimulator.SimulateTextEntry(TestStrings[k]); // simulate keyboard input of full commands 
                        k++;
                        InputSimulator.SimulateKeyDown(VirtualKeyCode.RETURN);// simulate keyboard input of Enter
                        Console.WriteLine("Please enter the command to Jarvis: ");
                        str = Console.ReadLine();
                        if (indx > 3) { indx = 0; }
                        if (comm_new.CanExec(str)) // check if command to Jarvis is valid
                        {
                            comm_new.DoSomething(); // if command was valid execute it and report it to the user
                            commandArray[indx] = comm_new; // assign new instance of Command Class to the array of Command class
                            if (!QueueInst.IsFull())
                            {
                                QueueInst.Enqueue(commandArray[indx]); // enqueue the last command
                                indx++;  
                            }
                            else
                            {
                                if (!QueueInst.IsEmpty())
                                {
                                    QueueInst.Dequeue(); // remove first instance of Command Class from the queue
                                    QueueInst.Enqueue(commandArray[indx]); // and enqueue the last executed command to the history queue
                                    indx++;
                                }
                            }
                        }
                        break;
                    case "4":
                        Console.WriteLine("Your history is: ");
                        QueueInst.Print();// print the current history of user commands
                        break;
                    case "q":
                        Console.WriteLine("Press ENTER to quite");
                        Console.Read();
                        break;
                    default:
                        Console.WriteLine("Invalid selection. Please select 1, 2, or 3, or 4.");
                        break;
                }
            }
        }
    }
}

