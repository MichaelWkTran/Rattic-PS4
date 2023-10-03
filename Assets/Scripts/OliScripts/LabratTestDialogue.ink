//bootleg progress switch statement 
+[!stateIntro]
    ->main
+[!statePaperclip]
    ->AskForPaperclip
+[!stateTape]
    ->AskForTape
+[!stateBrokenPencil]
    ->AskForBrokenPencil
+[!stateDone]
    Thank you again
->DONE

=== main ===
!statePaperclip //set state on character to state paperclip. Must not be last (first line preferred)
I’m a failure…
I’ve tried to make a glowing machine so it’s always day, but I’ve tried a 1000 different ways.
I think I need something metal that I can bend.
But where would a rat find something like that in an attic like this?
->END

=== AskForPaperclip ===
Do you have something metal and bendable?
    +[Paperclip]
        ->TradePaperclip("Paperclip")
    +[Invalid]
        ->InvalidOptionPaperclip() 
        
=== AskForTape ===
Do you have something to fix that broken pencil?
    +[Tape]
        ->TradeTape("Tape")
    +[Invalid]
        ->InvalidOptionTape() 
        
=== AskForBrokenPencil ===
Do you still have that broken pencil?
    +[Broken Pencil]
        ->TradeBrokenPencil("Tape")
    +[Invalid]
        ->InvalidChoice

=== InvalidOptionPaperclip() ===
This doesn’t seem very /t2 metal or /t3 bendable, try again. //time delay
->DONE

=== InvalidOptionTape ===
I can't fix anything with this you /sIDIOT/d! //shout, then back to default
->DONE

==InvalidChoice===
What is this?
->DONE

=== TradePaperclip(item) ===
!stateTape //set state to state tape, see how its first line
/s Eureka! /d /t5 This {item} is exactly what I need!!!
So I can finish the calculations for my invention/t2./t2./t2. Could I possibly ask for a favor?
I have this broken pencil and I require something to put the ends back together
If you could bring that to me I would be extremely happy.
->END

===TradeTape(item)===
!stateBrokenPencil
Thanks now, wheres that broken pencil you had?
->END

===TradeBrokenPencil(item)===
!stateDone
/s Bazinga! /d /t5 The calculations are complete!
I have just invented the/t8./t8. the/t5./t5./t5.
Um/t5./t5./t5.
/sThe Lightinator/d!
Okay sorRyyYY I didn’t say I was amazing at naming things

@ //begin useless choice area with this symbol
What would you call it?
+ [Light bulb]
+ [Daylight Maker]
- Okay that’s a way better idea.
@ //end useless choice area with this symbol

What’s that? You want credit for the name and help?
HA/t2HA/t2HA/t2HA/t2HA/t2HA/t4 no way!
Here I’ll give you this pencil instead.

->END