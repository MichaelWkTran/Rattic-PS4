+[!stateIntro]
    ->main
+[!statePoison]
    ->AskForPoison
+[!stateKeyStar]
    ->AskForKeyStar
+[!stateDone]
    Thank you again

=== main ===
!statePoison
You stupid good for nothing rat
Gosh I hope you find that rat poison and eat it up
I’d kill you myself but I’m in the middle of something
->END

=== AskForPoison ===
What are you doing back here?
    +[Rat Poison]
        ->TradePoison("Rat Poison")
    +[Invalid]
        ->InvalidOptionPoison() 

=== TradePoison(item) ===
!stateKeyStar
Wait/t4./t4./t4./t4 that’s the rat poison
And you’re giving it back to/t5 me?
Maybe you’re not so stupid after all.
Ahhh what am I doing/t2 talking to a rat.
Well if you can really understand me then I’m trying to find something for the top of my tree
Or else I’ll have to drive and get a new one
You probably don’t understand me, human holidays are probably very different to rat holidays.
Now get out before I use this poison on you.
->END

=== InvalidOptionPoison() ===
/sGet lost!/d
->DONE

=== AskForKeyStar ===
I need to find that thing for the tree, or drive and get one
    +[Christmas Star]
        ->TradeStar("Star")
    +[Key]
        ->TradeKey("Keys")
    +[Invalid]
        ->InvalidOptionKeyStar() 

=== TradeStar(item) ===
!stateDone
How’d you understand what I was talking about!?
Well that’s helpful, I guess I don’t gotta go buy a new star for our tree now
What’s that?/t6 You want a reward?
I thought the reward was that I wasn’t going to kill you.
I suppose I could spare something.
Ah/t3 I've got this string!
Awesome./t5 Well thanks young rat
->END

=== TradeKey(item) ===
!stateDone
How’d you get those!
Well that’s helpful, I guess I gotta go buy a new star for our tree now
What’s that?/t6 You want a reward?
I thought the reward was that I wasn’t going to kill you.
I suppose I could spare something.
Ah/t3 I've got this string!
Awesome./t5 Well thanks young rat
->END

=== InvalidOptionKeyStar() ===
Try again! I'm begining to think you don't understand me?!
->DONE