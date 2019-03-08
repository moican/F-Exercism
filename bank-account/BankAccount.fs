module BankAccount

type Account = { mutable TotalAccount : Option<decimal> } with
    member self.AlterAccount (change : decimal)  =         
        match self.TotalAccount with
        | Some i -> self.TotalAccount <- Some (self.TotalAccount.Value + change)
        | None -> self.TotalAccount <- Some change 
        self
        
let mkBankAccount() = { TotalAccount = None }

let openAccount (account : Account) : Ref<Account> = 
    account.TotalAccount <- Some 0.0m
    ref account

let closeAccount account = 
    (!account).TotalAccount <- None
    account

let getBalance (account : Ref<Account>) = (!account).TotalAccount

let updateBalanceSafe (account : Ref<Account>) change =
    (!account).AlterAccount change |> ignore
    account

let updateBalance (change : decimal) (account : Ref<Account>)  = 
    lock account (fun() -> updateBalanceSafe account change) |> ignore
    account





