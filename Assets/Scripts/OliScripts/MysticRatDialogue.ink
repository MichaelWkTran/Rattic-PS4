+[!stateIntro]
    ->main
+[!stateMushroom]
    ->AskForMushroom
+[!stateSweetSnacks]
    ->AskForSweetSnacks
+[!stateDone]
    I have a vision... absolute vibes
->DONE

=== main ===
!stateMushroom
Hold on! I’m getting a vision
I see/t3./t3. I see/t3./t3./t3. A young troubled rat.
A rat in need of cheese for their family
I don’t know about cheese, but I have a mirror I can part with
I need a mushroom./t3./t3./t3for./t3./t3./t3fortune telling/t5 stuff
You get it
->END

=== AskForMushroom ===
Do you have the shrooms?
    +[Mushroom]
        ->TradeMushroom("Mushroom")
    +[Invalid]
        ->InvalidOptionMushroom() 

=== TradeMushroom(item) ===
!stateSweetSnacks
/sIT’S NOT WHAT IT LOOKS LIKE!/d
Oh, nevermind it’s just you
You have the shrooms/t3./t3./t3.I mean mushroom?
Well here’s your mirror. But first...let’s share this mushroom.
I can tell you’re future with it.
>m2
Y/t3o/t3o/t3o/t3o/t3o I’m /shella/d hungry now
If you could get me something sweet and tasty that would be epic
I can give you uh/t3./t3./t3.
This one of a kind Christmas star!!
>e
->END

=== InvalidOptionMushroom ===
Hmm... this won't help me with fortune telling sorry
->DONE

=== AskForSweetSnacks ===
Do you have something sweet and tasty?
    +[Sweet Snack]
        ->TradeSweetSnacks("Sweet Snacks")
    +[Invalid]
        ->InvalidOptionSweetSnacks()
        
=== TradeSweetSnacks(item) ===
!stateDone
I envisioned you’d come back to me
Whilst you were gone the heavens spoke to me
Sucks you weren’t here to see it
I sense that you are in need of an ultimate goal
Beyond just chilling with me
Is it/t3./t3./t3.
@ //begin useless choice area with this symbol
What would you call it?
+ [Love]
+ [Conquest]
+ [Family]
- Intriguing, this was what I thought you wanted too
@ //end useless choice area with this symbol
I wish you the best in your goal.
I won’t keep you any longer, here is the Christmas Star
Thank you for the sweet snacks, this is perfect
->END

=== InvalidOptionSweetSnacks ===
I'm hungry for something sweet, got anything else?
->DONE

->END