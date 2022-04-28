using OpenClose;

BankAccount bankAccount = new BankAccount("SpecialBank", new SpecialBankAccount(300));
Console.WriteLine(  bankAccount.getAccountFee(500, 3) );
