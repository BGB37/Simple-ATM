using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;

namespace Basic_ATM_App
{
    public class CardHolder
    {
        String CardNumber;
        int Pin;
        String FirstName;
        double Balance { get; set; }
        String LastName;
        public CardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
        {
            this.CardNumber = cardNumber;
            this.Pin = pin;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Balance = balance;
        }

        //GET METHODS
        public String getCardNumber()
        {
            return CardNumber;  
        }

        public String getFirstName()
        {
            return FirstName;
        }

        public String getLastName()
        {
            return LastName;
        }

        public double getBalance()
        {
            return Balance;
        }
        // ---------------------------------------------------------------

        // SET METHODS
        public void setCardNumber(String number)
        {
            CardNumber = number;
        }

        public void setPin(int newPin)
        {
            Pin = newPin;
        }

        public void setFirstName(String firstname)
        {
            FirstName = firstname;
        }

        public void setLastName(String lastname)
        {
            LastName = lastname;
        }

        public void setBalance(double newbalance)
        {
            Balance = newbalance;   
        }
        // ---------------------------------------------------------------

        static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please choose from one of the options.");
                Console.WriteLine("1- Deposit");
                Console.WriteLine("2- Withdraw");
                Console.WriteLine("3- Show Balance");
                Console.WriteLine("4- Exit");
            }

            void depositCash(CardHolder depositCashUser)
            {
                Console.WriteLine("How much money would you like to deposit?\n");
                double deposit = Double.Parse(Console.ReadLine());
                depositCashUser.setBalance(depositCashUser.getBalance() + deposit);
                Console.WriteLine("Thank you. Your new balance is: " + depositCashUser.Balance);
            }

            void withdraw(CardHolder currentuser)
            {
                Console.WriteLine("How much money would you like to withdraw?");
                double withdrawal = Double.Parse(Console.ReadLine());   
                if(currentuser.getBalance() < withdrawal) // Check if the user has enough balance.
                {
                    Console.WriteLine("Sorry you don't have enough balance.\n");
                } else
                {
                    currentuser.setBalance(currentuser.getBalance() - withdrawal);
                    Console.WriteLine("Thank you. Your new balance is: " + currentuser.getBalance() + ".\n");
                }
            }

            void balance(CardHolder balanceUser)
            {
                Console.WriteLine($"Current balance: {balanceUser.getBalance()}");
            }

            List<CardHolder> CardHolders = new List<CardHolder>();
            CardHolders.Add(new CardHolder("123456789", 1234, "Isiah", "Thomas", 4318.05));
            CardHolders.Add(new CardHolder("987654321", 4321, "Ashley", "Jones", 218.10));
            CardHolders.Add(new CardHolder("123412345", 5678, "Karim", "Benzema", 11990.40));
            CardHolders.Add(new CardHolder("987698765", 8765, "Lebron", "James", 48.33));

            //Promp user
            // ATM program starts here.
            Console.WriteLine("\t-- Welcome to Simple ATM --\n");
            Console.WriteLine("Please insert your debit card. ");
            String debitCardNum = "";
            CardHolder currentUser;

            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = CardHolders.FirstOrDefault(a => a.CardNumber == debitCardNum);  // Checking if current user exist in the database.
                    if(currentUser != null) 
                    { 
                        break; 
                    } else
                    {
                        Console.WriteLine("Card not recognized please try again.");
                    }

                }
                catch
                {
                    Console.Beep(2200, 3000);
                    Console.WriteLine("Card not recognized please try again.");
                }
            }
            Console.WriteLine("Please enter your pin.");

            while (true)
            {
                try
                {
                    int userPin = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                    
                    if (currentUser.Pin == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect pin. Please try again.");
                    }

                }
                catch
                {
                    Console.Beep(2200, 30);
                    Console.WriteLine("Incorrect pin. Please try again.");
                }

            }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Welcome {currentUser.getFirstName()} {currentUser.getLastName()}.\n");
                Console.ResetColor();
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch
                { }
                    if(option == 1)
                    {
                        depositCash(currentUser);
                    } else if(option == 2) 
                    {
                        withdraw(currentUser);
                    }
                    else if (option == 3)
                    {
                        balance(currentUser);
                    }
                    else if (option == 4)
                    {
                        break;
                    }
                    else 
                    {
                        option = 0;
                    }
                
            }
            while (option != 4);
            
            Console.WriteLine("Have a nice day!");
            Console.ReadLine();
            
         
            
        }    

    }
}
