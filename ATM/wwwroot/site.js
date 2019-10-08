$(document).ready(function () {
    $("#check").click(function (e) {
        pinAndMenu(e);
    })

   
});

function pinAndMenu(e) {
    $.ajax({
        dataType: 'json',
        type: 'GET',
        //get all and find in success field by if statement
        url: 'api/Card',
        success: function (cards) {
            let p = document.getElementById('pin').value;


            $.each(cards, function (index, card)
            {
                //check PIN by find cards pin
                if (card.pin == p) {
                    console.log(card.pin);
                    document.getElementById('init').remove();

                    //find account by id card
                    $.ajax({
                        dataType: 'json',
                        type: 'GET',
                        url: 'api/BankAccount',
                        success: function (accounts) {
                            $.each(accounts, function (index, account) {
                                if (account.cardId == card.id) {
                                    document.getElementById('manager').style.display = "block";
                                    var i = $("manager");
                                    i.append("gdgd");
                                    $("#btns").click(function (e) {
                                        var selection = e.target.innerHTML;
                                        if (selection == 'Stan Konta') checkBalance(account);
                                        if (selection == 'Wypłata') withdraw(account);
                                        if (selection == 'Zmień PIN') changePIN(account, card);

                                    })

                                }
                            })
                        }

                    })
                }
                   
            });
        }

    });
   
}


function checkBalance(account) {
    document.getElementById("changePINForm").style.display = "none";
    document.getElementById('withdrawInfo').style.display = "none";
    document.getElementById("balanceInfo").style.display = "block";
    $.ajax({
        dataType: 'json',
        type: 'GET',
        url: 'api/BankAccount',
        success: function (accounts) {
            $.each(accounts, function (index, val) {         
                document.getElementById("setBalanceInfo").innerHTML = "Stan konta: "+ val.balance;
                })
        }
    })
}
        

function withdraw(account) {
    document.getElementById("changePINForm").style.display = "none";
    document.getElementById("balanceInfo").style.display = "none";
    document.getElementById("withdrawInfo").style.display = "block";


    $("#amountBtn").click(function (e) {
        $.ajax({
            contentType: 'application/json',
            type: "POST",
            url: "api/Transaction",
            data: JSON.stringify({
                bankAccountId: account.id,
                amount: document.getElementById('amount').value,
                
            }),
            success: function (e) {
                console.log(document.getElementById('amount').value);
                checkBalance(account);
            }
        })
    })

}

function changePIN(account, card) {
    document.getElementById("changePINForm").style.display = "block";
    document.getElementById("balanceInfo").style.display = "none";
    document.getElementById("withdrawInfo").style.display = "none";
    $("#setPINBtn").click(function (e) {
        $.ajax({
            url: "api/Card/" + card.id,
            type: "PUT",
            accepts: "application/json",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({
                id: card.id,
                // type musi być! tworze nowy obiekt ze wszystkimi polami Domain dla Command; 
                // Obiekt Command musi zawierać wszystkie prostymi pola danego Domain
                // następnie przypisuje/mapuje, ale nic nie zmieniam - i po prostu stosuje metodę Update()
                type: card.type, 
                bankAccountId: account.id,
                pin: document.getElementById('setPIN').value,
            }),
            success: function (result) {
                console.log(JSON.stringify(result));
            }
        })
    })

};






