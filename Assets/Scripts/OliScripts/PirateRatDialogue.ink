//bootleg progress switch statement 
+[!stateIntro]
    ->main
+[!stateTreasure]
    ->AskForTreasure
+[!stateDone]
    ARRR shiver me timbers!
->DONE

=== main ===
!stateTreasure
/sARRRGHHHH/d GIMME THAT MAPPP
Yipppeeee/t3 I’m going to find the great treasure
What’s that?/t6 You need your map?
Do you know who you’re dealing with youngster???
Leave me/t4 before I hook ya!
And don’t think bout coming back without the treasure/t4 or I’ll never give you ya map back!
->END

=== AskForTreasure ===
You best be coming back to my parts with the treasure or I’ll make ya walk the plank
    +[Money]
        ->TradeTreasure("Treasure")
    +[Ring]
        ARRGHH While this IS shiny, ive already got a thousand of these.
        I'm looking for something a bit more green and gold.
        ->END
    +[Invalid]
        I WON"T GIVE YOU YA MAP BACK UNLESS YAR GET THAT TREASURE!
        ->END 

=== TradeTreasure(item) ===
!stateDone
Ayyeee/t2?/t2?/t2?/t8 You have the.../t7 treasure?
Huh/t4./t4./t4.
I was not expecting a young rattling like you to be an/t2 adventurer
@ //begin useless choice area with this symbol
Say what bout you join my team?
+ [Ay]
+ [Nay]
- Well you don't have a choice anyways!
@ //end useless choice area with this symbol
You’re first task is to rid these bones on the poop deck
Here’s ya map back
->END

->END