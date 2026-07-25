using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking
{
    public class Expense
    {
        public int expenseId;
        public string category;
        public double amount;
        public string paymentMode;
        public DateTime date;

        // Constructor
        public Expense()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("      EXPENSE TRACKING SYSTEM");
            Console.WriteLine("-----------------------------------");
        }

        public void AddExpense()
        {
            Console.Write("Enter Expense ID : ");
            expenseId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Category : ");
            category = Console.ReadLine();

            Console.Write("Enter Amount : ");
            amount = Convert.ToDouble(Console.ReadLine());

            if (amount < 0)
            {
                throw new Exception("Amount cannot be negative.");
            }

            Console.Write("Enter Payment Mode : ");
            paymentMode = Console.ReadLine();

            date = DateTime.Now;
        }

        public void ShowExpense()
        {
            Console.WriteLine("\nExpense Details");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Expense ID   : " + expenseId);
            Console.WriteLine("Category     : " + category);
            Console.WriteLine("Amount       : " + amount);
            Console.WriteLine("Payment Mode : " + paymentMode);
            Console.WriteLine("Date         : " + date);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Expense> expenses = new List<Expense>();

            int choice;

            do
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Show Expenses");
                Console.WriteLine("3. Total Expense");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Expense e = new Expense();
                            e.AddExpense();
                            expenses.Add(e);

                            Console.WriteLine("\nExpense Added Successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error : " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Add Expense Operation Completed.");
                        }
                        break;

                    case 2:
                        try
                        {
                            if (expenses.Count == 0)
                            {
                                Console.WriteLine("\nNo Expenses Found.");
                            }
                            else
                            {
                                foreach (Expense e in expenses)
                                {
                                    e.ShowExpense();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error : " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Show Expense Operation Completed.");
                        }
                        break;

                    case 3:
                        try
                        {
                            double total = 0;

                            foreach (Expense e in expenses)
                            {
                                total = total + e.amount;
                            }

                            Console.WriteLine("\nTotal Expense : " + total);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error : " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Total Expense Operation Completed.");
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.WriteLine("\nExiting Program...");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error : " + ex.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Thank You!");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }

            } while (choice != 4);

            Console.ReadKey();
        }
    }
}