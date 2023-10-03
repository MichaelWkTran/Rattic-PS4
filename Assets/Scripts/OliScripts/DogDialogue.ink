+[!stateIntro]
    ->main
+[!stateChew]
    ->AskForChew
+[!stateDone]
    woof woof woof
->DONE

=== main ===
!stateChew
I’m the goodest boy. I’m the goodest boy.
Oh hello there.
May I trouble you with my woes?
Imma do it anyways
My owner stole all the shoes I chewed on, apparently it ruined them.
I don’t understand humans, but anyways I stole their car keys and hid it.
If you share something delicious I can chew on, I'll give you the car keys.
->END

=== AskForChew ===
Do you have something I can chew on?
    +[Bone]
        ->TradeBones("Bones")
    +[Cool Hat]
        ->TradeCoolHat("Cool Hat")
    +[Sweet Snack]
        This looks too sweet,/t3 and i'm not hungry,/t3 I just want to chew.
        ->DONE
    +[Meal]
        I'm not hungry,/t3 I just want to use my teeth.
        ->DONE
    +[Invalid]
        ->InvalidOptionChew() 

=== TradeBones(item) ===
!stateDone
MMMMmMM yummy bones
I don’t really want to know how you got these
But thank you very much *woof*
Now about those keys/t3./t3./t3.
Slight problem, I buried them somewhere around here
Let’s try and dig them up
>m4
Woof!
>e
->END

=== TradeCoolHat(item) ===
!stateDone
OoOOOo that’s a VERY cool hat
It’d really suck if someone chewed this up
NOM/t6 NOM/t6 NOM
Thank you very much *woof*
Now about those keys/t3./t3./t3.
Slight problem, I buried them somewhere around here
Let’s try and dig them up
>m4
Woof!
>e
->END

=== InvalidOptionChew ===
I can't chew this!
->DONE

->END