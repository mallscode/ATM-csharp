using System;
using System.Linq;

class Program
{
    static void Main()
    {
        double balance = 1000;
        while (true)
        {
            Console.Write("ATM Menu. \n1- View Balance\n2- Deposit\n3- Withdraw\n4- Exit\n-> ");
            string[] view = { "view balance", "balance", "view", "1" };
            string[] deposit = { "deposit", "2" };
            string[] withdraw = { "withdraw", "3" };
            string[] exit = { "exit", "4" };
            string[] options = view.Concat(deposit).Concat(withdraw).Concat(exit).ToArray();

            string choice = Console.ReadLine().Trim().ToLower();
            if (options.Contains(choice))
            {
                if (view.Contains(choice))
                {
                    Console.WriteLine($"Balance: ${balance}.\n");
                }
                else if (deposit.Contains(choice))
                {
                    Console.Write("Enter the amount you want to deposit: ");
                    double amount;
                    if (double.TryParse(Console.ReadLine(), out amount))
                    {
                        balance += amount;
                        Console.WriteLine($"${amount} was deposited to your balance.\n");
                    }
                    else
                    {
                        if (!TryAgain())
                        {
                            break;
                        }
                        continue;
                    }
                }
                else if (withdraw.Contains(choice))
                {
                    Console.Write("Enter the amount you want to withdraw: ");
                    double amount;
                    if (double.TryParse(Console.ReadLine(), out amount))
                    {
                        if (balance >= amount)
                        {
                            balance -= amount;
                            Console.WriteLine($"${amount} was withdrawn from your balance.\n");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance.");
                            if (!TryAgain())
                            {
                                break;
                            }
                            continue;
                        }
                    }
                    else
                    {
                        if (!TryAgain())
                        {
                            break;
                        }
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Thank you for using our service.");
                    break;
                }
            }
            else
            {
                Console.Write("An error occurred. Please choose one of the options. Try again? Type Y for yes: ");
                string resp = Console.ReadLine().Trim().ToLower();
                if (resp != "y")
                {
                    Console.WriteLine("Thank you for using our service.");
                    break;
                }
            }
        }

        static bool TryAgain()
        {
            Console.Write("An error occurred. Try again? (Type Y for yes): ");
            return Console.ReadLine().Trim().ToLower() == "y";
        }
    }
}
