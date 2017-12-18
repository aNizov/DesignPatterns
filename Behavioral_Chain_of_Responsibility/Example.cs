using System;
using System.ComponentModel;

namespace Behavioral_Chain_of_Responsibility.Example
{
    public class Client
    {
        static void Main()
        {
            ExpenseHandler william = new ExpenseHandler(new Employee("William Worker", Decimal.Zero));
            ExpenseHandler mary = new ExpenseHandler(new Employee("Mary Manager", new Decimal(1000)));
            ExpenseHandler victor = new ExpenseHandler(new Employee("Victor Vicepres", new Decimal(5000)));
            ExpenseHandler paula = new ExpenseHandler(new Employee("Paula President", new Decimal(20000)));

            william.RegisterNext(mary);
            mary.RegisterNext(victor);
            victor.RegisterNext(paula);

            Console.WriteLine("Expense report amount:");

            if (Decimal.TryParse(Console.ReadLine(), out var expenseReportAmount))
            {
                IExpenseReport expense = new ExpenseReport(expenseReportAmount);
                ApprovalResponse response = william.Approve(expense);
                Console.WriteLine($"The request was {response}");
            }
        }
    }

    public enum ApprovalResponse
    {
        Denied,
        Approved,
        BeyondApprovalLimit
    }

    public interface IExpenseReport
    {
        Decimal Total { get; }
    }

    public class ExpenseReport : IExpenseReport
    {
        public ExpenseReport(Decimal total)
        {
            Total = total;
        }

        public decimal Total { get; private set; }
    }

    public interface IExpenseApprover
    {
        ApprovalResponse ApproveExpense(IExpenseReport expenseReport);
    }

    public class Employee : IExpenseApprover
    {
        public Employee(string name, Decimal approvalLimit)
        {
            Name = name;
            _approvalLimit = approvalLimit;
        }

        public string Name { get; private set; }
        private readonly Decimal _approvalLimit;

        public ApprovalResponse ApproveExpense(IExpenseReport expenseReport)
        {
            return expenseReport.Total > _approvalLimit
                ? ApprovalResponse.BeyondApprovalLimit
                : ApprovalResponse.Approved;
        }
    }

    public interface IExpenseHandler
    {
        ApprovalResponse Approve(IExpenseReport expenseReport);
        void RegisterNext(IExpenseHandler next);
    }

    class ExpenseHandler : IExpenseHandler
    {
        private readonly IExpenseApprover _approver;
        //Затычка конца списка, чтобы небыло NRE при вызове Next(), на последнем элементе
        private IExpenseHandler _next = EndOfChainExpenseHandler.Instance;

        public ExpenseHandler(IExpenseApprover expenseApprover)
        {
            _approver = expenseApprover;
        }

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            ApprovalResponse response = _approver.ApproveExpense(expenseReport);

            return response == ApprovalResponse.BeyondApprovalLimit
                ? _next.Approve(expenseReport)
                : response;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            _next = next;
        }
    }

    //Затычка конца списка, с использованием паттерна NULL-jbject
    class EndOfChainExpenseHandler : IExpenseHandler
    {
        private static readonly EndOfChainExpenseHandler _instance = new EndOfChainExpenseHandler();

        private EndOfChainExpenseHandler()
        {
        }
        public static EndOfChainExpenseHandler Instance => _instance;

        public ApprovalResponse Approve(IExpenseReport expenseReport) => ApprovalResponse.Denied;

        public void RegisterNext(IExpenseHandler next) =>
            throw new InvalidOperationException("End of chain handler must be the end of chain");
    }
}