//bootleg progress switch statement 
+[!stateIntro]
    ->main
+[!stateFlamingos]
    ->AskForFlamingos
+[!stateDone]
    The Flamingos rock!!!
->DONE

=== main ==
!stateFlamingos
Ew.
Another rat.
Gross.
Did you know we’re nothing but meaningless specks in the grand cosmos of the world?
We are but just little rats roaming around,/t2 eating garbage/t4 until we die.
Then the rich aristorats steal all the money.
All I care about is music./t4 It speaks to my soul./t4 You wouldn’t understand.
My favorite band is The Flamingos,/t2 what’s yours?
@ //begin useless choice area with this symbol
What's you're favorite band?
+ [Country Town Rats]
+ [The Soul Cats]
+ [Generic Pop Bangers 2000]
- /sEWWWW!!!/d You really are just like everyone else
@ //end useless choice area with this symbol
Such a boring pick, this is why music sucks these days
Except The Flamingos
That band rocks
I wanted some merch from them but they sold out
Actually/t2 if you could find some merch for The Flamingos or some of their music/t3./t3./t3.
Then I might actually like one rat in this cruel world
Plus I’ll give you some money.
->END

=== AskForFlamingos ===
Do you have something by The Flamingos?
    +[Cool Hat]
        ->TradeCoolHat("Cool Hat")
    +[Music Disc]
        ->TradeMusicDisc("Music Disc")
    +[Invalid]
        ->InvalidOptionFlamingos() 

=== TradeCoolHat(item) ===
!stateDone
/sWait!/d
You got the limited exclusive never seen before “The Flamingos Cool Hat”
/sOMG YOU’RE AMAZING/d
I mean/t3./t3./t3./t6 ahem/t3./t3./t3.
It’s not like im a fanrat or anything
shut /sUP!!!/d
Look here’s your money
Now leave me alone
->END

=== TradeMusicDisc(item) ===
!stateDone
Wait!
You got the limited exclusive never heard before “The Flamingos” EP
OMG YOU’RE AMAZING
I mean/t3./t3./t3./t6 ahem/t3./t3./t3.
It’s not like im a fanrat or anything
shut /sUP!!!/d
Look here’s your money
Now leave me alone
->END

=== InvalidOptionFlamingos ===
This isn't by the Flamingos!
->DONE