using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void mydel();
    public class bank
    {
        public event mydel Lowbalance;
        public event mydel InsufficientBalance;
        public int balance;
        public bank(int balance)
        {
            this.balance = balance;
        }
        public void Credit(int creditamount)
        {
            Console.WriteLine($"your ac is credited with{creditamount}");
            Console.WriteLine($"your total balance is {balance + creditamount}");
            balance=balance+creditamount;
        }
         
        public void Debit(int debitamount)
        {
            if(balance<debitamount)
            {
                InsufficientBalance();
                Console.WriteLine($"your balance is{balance}");
                balance=balance-debitamount;
            }
            else if(balance<5000)
            {
                Lowbalance();
                Console.WriteLine($"your Ac is debited by {debitamount}");
                Console.WriteLine($"your balance is{balance-debitamount}");
                balance=balance-debitamount;
            }
            else
            {
                Console.WriteLine($"Your AC is debitet with{debitamount}");
                Console.WriteLine($"Your balance is{balance - debitamount}");
                balance=balance - debitamount;
            }
           

           
        }
   
    }
   
    internal class Program
    {
       static void lowbal()
        {
            Console.WriteLine($"you have low balance");
        }
       static void insuf()
        {
            Console.WriteLine($"you have Insufficient balance");
        }
       
        static void Main(string[] args)
        {
            bank b = new bank(2000);
            b.Lowbalance += new mydel(lowbal);
            b.InsufficientBalance += new mydel(insuf);
            b.Credit(2000);
            b.Debit(6200);


        }
    }
}
