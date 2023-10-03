+[!stateIntro]
    ->main
+[!stateCheese]
    ->AskForString
+[!stateEnding]
    ->AskForEnding
+[!stateDone]
    mewOOWwwwwieEE
->DONE

=== main ===
!stateCheese
you’re after cheese 
i might have what you want
but i want string meow meow
oh string purrr
huh... 
anyways... 
if you can share some string i could share some of my cheese with a filthy rat like yourself
it’s all about the deal in my part of town meow meow. Now go!
->END

=== AskForString ===
oh string... i need string... purrr
    +[String]
        ->TradeString("String")
    +[Invalid]
        ->InvalidOptionString() 
        
=== TradeString(item) ===
!stateEnding
/smewOOWwwwwieEE/d you got me some string!!!!
//before I give you this cheese, let’s play a game
//you didn’t think it would be that easy did you??
//>minigame
meow meow here’s your cheese rawr!
now go be a pest somewhere else i have some string to play with purrRrr
->END

=== InvalidOptionString() ===
MEOW MEOW TRY AGAIN!
->DONE

=== AskForEnding ===
What's that you want to trade again meow meow?
    +[Cheese]
        ->TradeCheese("Cheese")
    +[Invalid]
        I'm busy with my string!
        ->END

=== TradeCheese(item)===
!stateDone
what’s this?
the cheese? You’re giving it back to me
huh i see
after all your adventures you realized the rat world wasn’t all that
and now you want to join the yakuza cat family
hmmm....
well you have proven yourself to be a crafty young rat
i usually wouldn’t deal with a rodent like you
we usually chew you lot up and spit you out for breakfast
but it couldn’t hurt to have a double agent
together... we would be indestructible... purrrrrr
it’s a deal then
welcome to the family!
->END