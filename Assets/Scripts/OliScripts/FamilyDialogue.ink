+[!stateIntro]
    ->main
+[!stateCheese]
    ->AskForCheese

+[!stateDone]
    Family is the most important thing.
->DONE

=== main ===
!stateCheese
Young rat
We have a huge favour to ask
Tomorrow is Christmas Day
And we are too poor to get our Christmas Cheese
If you could go find some we would be immensely grateful
Here, we’ll give you this paperclip to aid your journey in the attic
Good Luck young rat
->END
    
=== AskForCheese ===

Did you get the Christmas cheese young rat?
    +[Cheese]
        ->TradeCheese("Cheese")
    +[Invalid]
        ->InvalidOptionCheese() 

=== TradeCheese(item) ===
!stateDone
YOU’RE BACK
Thank goodness
We were getting worried you weren’t going to return or had lost your way
I’m sure you met a lot of quirky characters out there
But home is the most important place to be
Now come gather round children
Tell them about your great adventures beyond
And how you found the cheese
->END

=== InvalidOptionCheese ===
Please young rat. We just need cheese!
->DONE

->END