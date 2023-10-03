+[!stateIntro]
    ->main
+[!AskForRing]
    ->AskForRing
+[!AskForEscape]
    ->AskForEscape
+[!stateEnding]
    ->AskForEnding
+[!stateDone]
    off we go
->DONE

=== main ===
!AskForRing
hehe hello u litle thang
@ //begin useless choice area with this symbol
aren’t you just fab. Slay rat!
+ [You’re not a real rat]
+ [You slay keep it real!]
- Ah! I’m as real as they come babes
@ //end useless choice area with this symbol
Say... 
@ //begin useless choice area with this symbol
Do you think I’m beautiful
+ [Yes]
+ [No]
- Hehe don't lie you flirt
@ //end useless choice area with this symbol
Anyways...
I need some bling for my finger
I want to complete the outfit...
I mean I...
I just wanna shine, you know?
->END

=== AskForRing ===
did you get the bling?
    +[Ring]
        ->UnlockRing
    +[Invalid]
        This isn't bling babes >_<
        ->END

=== UnlockRing ===
!AskForEscape
You got this for MEEEE!!!
Say babes, what if we get outta here
All we need is transport, I can call a taxi, or drive
So find that and we’ll go have an adventure of our own
Hehe rawr xD
->END

=== AskForEscape ===
did you get something so we can escape?
    +[Keys]
        ->TradeKeysMoney
    +[Money]
        ->TradeKeysMoney
    +[Invalid]
        This won't help us escape :/
        ->END

=== TradeKeysMoney ===
!stateEnding
Oopalie, that's perfect time to escape in to the real world
I still have to pack a few things
So in the meantime play with this string
And then we’ll go together forever
->END

=== AskForEnding ===
I'm just packing up, do you have a gift for me?
    +[Cheese]
        ->TradeCheese("Cheese")
    +[Invalid]
        Thank you, but I don't really need this hehe
        ->END

=== TradeCheese(item)===
!stateDone
Are you ready little rat
I’m glad you came back
For a second I thought you’d leave me
What’s this you bought cheese for the journey?
Why thank you very much.
I have a suspicion...
You give me all these gifts
It’s almost like you love me
@ //begin useless choice area with this symbol
Do you love me?
+ [Yes]
+ [No]
- hah...hah... *blush*
@ //end useless choice area with this symbol
AnyWAYSsss!!!
Let's talk about this later...
Well then, let's get outta here
i'm looking forward to our great adventure
->END