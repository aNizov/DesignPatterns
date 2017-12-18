using System;
using System.Collections.Generic;

namespace Behavioral_Visitor.Example
{
    class Client
    {
        static void Main()
        {
            var person = new Person();
            person.Assets.Add(new BankAccount { Ammount = 1000, MonthlyInterest = 0.01 });
            person.Assets.Add(new BankAccount { Ammount = 2000, MonthlyInterest = 0.02 });
            person.Assets.Add(new RealEstate { EstimatedValue = 79000, MonthlyRent = 500 });
            person.Assets.Add(new Loan { Owed = 40000, MonthlyPayment = 40 });

            var netWorthVisitor = new NetWorthVisitor();
            person.Accept(netWorthVisitor);

            Console.WriteLine(netWorthVisitor.Total);

            //Легко добавляем новую логику путем создания нового класса реализующего IVisitor
            var incomeVisitor = new IncomeVisitor();
            person.Accept(incomeVisitor);

            Console.WriteLine(incomeVisitor.Amount);
        }
    }

    public interface IVisitor
    {
        void Visit(RealEstate realEstate);
        void Visit(BankAccount bankAccount);
        void Visit(Loan loan);
    }
    public class NetWorthVisitor : IVisitor
    {
        public int Total { get; set; }
        public void Visit(RealEstate realEstate)
        {
            Total += realEstate.EstimatedValue;
        }

        public void Visit(BankAccount bankAccount)
        {
            Total += bankAccount.Ammount;
        }

        public void Visit(Loan loan)
        {
            Total -= loan.Owed;
        }
    }
    //Новая логика добавляется не путем изменения классов Loan, BankAccount и RealEstate
    //а путем добаления нового класса реализующего IVisitor
    public class IncomeVisitor : IVisitor
    {
        public double Amount;
        public void Visit(RealEstate realEstate)
        {
            Amount += realEstate.MonthlyRent;
        }

        public void Visit(BankAccount bankAccount)
        {
            Amount += bankAccount.MonthlyInterest * bankAccount.Ammount;
        }

        public void Visit(Loan loan)
        {
            Amount -= loan.MonthlyPayment;
        }
    }

    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }
    public class Person : IAsset
    {
        public IList<IAsset> Assets = new List<IAsset>();
        public void Accept(IVisitor visitor)
        {
            foreach (var asset in Assets)
                asset.Accept(visitor);
        }
    }
    public class Loan : IAsset
    {
        public int Owed { get; set; }
        public int MonthlyPayment { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class BankAccount : IAsset
    {
        public int Ammount { get; set; }
        public double MonthlyInterest { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class RealEstate : IAsset
    {
        public int EstimatedValue { get; set; }
        public int MonthlyRent { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
