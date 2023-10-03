+[!stateIntro]
    ->main
+[!statePencil]
    ->AskForPencil
+[!stateDone]
    Thank you to you
->DONE
=== main ===
!statePencil
Ever just stare at the sky and wonder/t3 what’s beyond?
Or stare at a person and wonder/t3 what they’ve got going on?
Life is beautiful/t3 in a way
The poetic nature/t3 of a rainy day.
To the clear blue skies/t3 when everything is okay
All my life I’ve turned strife and pain to paint
But the life I own is in despair
I cannot illustrate/t3 with no gear
Achieve obtaining a new equipment/t6 dear
And I shall part with these/t3 mushrooms/t3 I retrieved
->END

=== AskForPencil ===
Equipment/t3 I need,/t3 mushrooms/t3 you shall recieve
    +[Pencil]
        ->TradePencil("Pencil")
    +[Invalid]
        ->InvalidOptionPen() 

=== TradePencil(item) ===
!stateDone
Oh wonderful you turned up in such a dash
The speed of which is like whiplash.
Thank you for the pencil that I require
Without it/t3 my life would have been quite dire
In return I shall share my mushroom stash.
You are an unsung hero I wish I met earlier
Alas our amity has only just begun. 
Now good day young journeyer
For I wish you well.
->END

=== InvalidOptionPen ===
Aghast!/t3 I require a drawing tool at last.
->DONE
->END