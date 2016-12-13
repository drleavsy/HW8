using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using InputSimulator;

namespace Little_Jarvis
{
    class Command<T> : CommandAbs<T>
    {
        public Command(T[] NewName, T[] NewItems, T[] Addressee)
        {
            commandName = NewName;
            items = NewItems;
            address = Addressee;
            ind = 0;
            message = new string[address.Length];
        }

        public override bool CanExec(T obj)
        {
            string test_obj_str = obj as string;

            if (test_obj_str == null) { return false; }

            if (CompareCommandName(test_obj_str))
            {
                if (CompareItemName(test_obj_str))
                {
                    if (CompareAddressName(test_obj_str))
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        private bool CompareCommandName(string comNameIn)
        {
            int inx = 0;
            int j = 0;
            int ItemStart = 0;
            int ItemStop = 0;
            int ItemStartNext = 0;
            int ItemStopNext = 0;

            string commandNameString = this.commandName[inx] as string;
    
            while (inx < this.commandName.Length)
            {
                if (comNameIn.ToLower().Contains(commandNameString.ToLower())) 
                {
                    ItemStart = comNameIn.ToLower().IndexOf(commandNameString.ToLower());
                    ItemStop = comNameIn.IndexOf(" ");
                    if (commandNameString.ToLower().Equals("turn off") || commandNameString.ToLower().Equals("turn on"))
                    {
                        ItemStop = comNameIn.IndexOf(" ", ItemStop+1);
                    }
                    if (ItemStop == -1 || ItemStart == -1)
                    {
                        return false;
                    }
                    ItemStartNext = ItemStop+1;
                    ItemStopNext = comNameIn.IndexOf(" ", ItemStartNext);
                    if (ItemStopNext == -1 || ItemStartNext == -1)
                    {
                        return false;
                    }
                    string substring = comNameIn.Substring(ItemStartNext, ItemStopNext- ItemStartNext);

                    string ItemString = this.items[j] as string;

                    while (j < this.items.Length)
                    {
                        if (substring.ToLower().Contains(ItemString.ToLower())) 
                        {
                            CurrentCommand = commandNameString;
                            return true;
                        }
                        j++;
                        if (j >= items.Length) { return false; }
                        ItemString = this.items[j] as string;
                    }
                }
                inx++;
                if (inx >= this.commandName.Length) { return false; }
                commandNameString = this.commandName[inx] as string;
            }
            return false;
        }

        private bool CompareItemName(string ItemNameIn)
        {
            int inx = 0;
            int j = 0;
            int ItemStart = 0;
            int ItemStop = 0;
            int ItemStartNext = 0;
            int ItemStopNext = 0;

            string ItemNameString = this.items[inx] as string;

            while (inx < this.items.Length)
            {
                if (ItemNameIn.ToLower().Contains(ItemNameString.ToLower())) // the string already contains one of the items
                {
                    //CurrentCommand = ItemNameIn;
                    ItemStart = ItemNameIn.ToLower().IndexOf(ItemNameString.ToLower());
                    ItemStop = ItemNameIn.ToLower().IndexOf(" ", ItemStart);

                    if (ItemStop == -1 || ItemStart == -1)
                    {
                        //ItemStopNext = ItemNameIn.Length - 1;
                        return false;
                    }
                    ItemStartNext = ItemStop;
                    ItemStopNext = ItemNameIn.IndexOf(" ", ItemStartNext + 1);
                    if (ItemStopNext == -1 || ItemStartNext == -1)
                    {
                        //ItemStopNext = ItemNameIn.Length - 1;
                        return false;
                    }
                    string substring = ItemNameIn.Substring(ItemStartNext, ItemStopNext - ItemStartNext);

                    if (substring.ToLower().Contains("to") && CurrentCommand.ToLower().Equals("send"))
                    {
                        int startAddr = ItemStartNext;
                        int endAddr = ItemNameIn.IndexOf(":");
                        if (startAddr == -1 || endAddr == -1)
                        {
                            //ItemStopNext = ItemNameIn.Length - 1;
                            return false;
                        }
                        substring = ItemNameIn.Substring(startAddr, endAddr - startAddr);
                    }
                    else if ((CurrentCommand.ToLower().Equals("turn off") || CurrentCommand.ToLower().Equals("turn on")) &&
                          substring.ToLower().Contains("in"))
                    {
                        int startAddr = ItemStartNext;
                        int endAddr = ItemNameIn.Length;
                        if (startAddr == -1 || endAddr == -1)
                        {
                            //ItemStopNext = ItemNameIn.Length - 1;
                            return false;
                        }
                        substring = ItemNameIn.Substring(startAddr, endAddr - startAddr);
                    }
                    else
                    {
                        return false;
                    }

                    string addressString = this.address[j] as string;
                    while (j < this.address.Length)
                    {
                        if (substring.ToLower().Contains(addressString.ToLower()))
                        {
                            CurrentItem = ItemNameString;
                            //CurrentAddr = substring;
                            return true;
                        }
                        j++;
                        if (j >= address.Length) { return false; }
                        addressString = this.address[j] as string;
                    }
                }
                inx++;
                if (inx >= this.items.Length) { return false; }
                ItemNameString = this.items[inx] as string;
            }
            return false;
        }
        private bool CompareAddressName(string AddressNameIn)
        {
            int inx = 0;
            int j = 0;
            int ItemStart = 0;
            int ItemStop = 0;
            int ItemStartNext = 0;
            int ItemStopNext = 0;

            //AddressNameIn = AddressNameIn.ToLower();
            string AddressNameString = this.address[inx] as string;

            while (inx < this.address.Length)
            {
                //CurrentCommand = AddressNameIn;
                if (AddressNameIn.ToLower().Contains(AddressNameString.ToLower()))
                {
                    ItemStart = AddressNameIn.ToLower().IndexOf(AddressNameString.ToLower());
                    ItemStop = ItemStart+ AddressNameString.Length; // (" ", ItemStart);

                    if (ItemStop == -1 || ItemStart == -1)
                    {
                        ItemStop = AddressNameIn.Length - 1;
                    }
                    string substring = AddressNameIn.Substring(ItemStart, ItemStop - ItemStart);
                    if (AddressNameIn.ToLower().Contains("sms") || AddressNameIn.ToLower().Contains("mail"))
                    {
                        ItemStartNext = ItemStop + 1; // ": "
                        ItemStopNext = AddressNameIn.Length;
                        message[ind] = AddressNameIn.Substring(ItemStartNext, ItemStopNext - ItemStartNext);
                        CurrentAddr = AddressNameString;
                        CurrentMessage = message[ind];
                        ind++;
                        return true;
                    }
                    else 
                    {
                        CurrentAddr = AddressNameString;
                        return true;
                    }
                }
                inx++;
                if (inx >= this.address.Length) { return false; }
                AddressNameString = this.address[inx] as string;
            }
            return false;
        }
        public void PrintCommands()
        {
            string temp = " ";
            Console.WriteLine(temp);
            for (int i = 0; i < commandName.Length; i++)
            {
                temp = commandName[i] as string;
                Console.WriteLine(temp);
            }
        }

        public void ExampleCommands()
        {
            Console.WriteLine("Send mail to Jack: I will call you in the night");
            Console.WriteLine("Send SMS to John: Where are you?");
            Console.WriteLine("Turn on light in living room");
            Console.WriteLine(" Turn off conditioner in the kitchen");
        }

        public override void DoSomething()
        {
            if (CurrentCommand.Contains("Send"))
            {
                Console.WriteLine("OK, I will " + CurrentCommand + " " + CurrentItem + " with text" + CurrentMessage + " " + CurrentAddr);
            }
            else if(CurrentCommand.Contains("Turn"))
            {
                Console.WriteLine("OK, I will " + CurrentCommand + " " + CurrentItem + " " + CurrentAddr);
            }
        }

        public override void Print()
        {
            if (CurrentCommand.Contains("Send"))
            {
                Console.WriteLine(CurrentCommand + " " + CurrentItem + " " + CurrentAddr + ": " + CurrentMessage);
            }
            else if (CurrentCommand.Contains("Turn"))
            {
                Console.WriteLine(CurrentCommand + " " + CurrentItem + " " + CurrentAddr);
            }
        }
    }
}
