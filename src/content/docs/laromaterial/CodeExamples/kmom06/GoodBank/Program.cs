using GoodBank.src;

Bank bank = new Bank("Dbwebb Bank");

BankAccount account1 = new InterestAccount("SA001", 1000, 0.05);
BankAccount account2 = new PayrollAccount("CA001", 500, 100);

bank.AddAccount(account1);
bank.AddAccount(account2);

bank.DisplayAllAccounts();
