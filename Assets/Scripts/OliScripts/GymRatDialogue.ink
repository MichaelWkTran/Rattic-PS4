//bootleg progress switch statement 
+[!stateIntro]
    ->main
+[!stateMeal]
    ->AskForMeal
+[!stateDone]
    SHREDDDINGGGG!!!!
->DONE

=== main ===
!stateMeal
DO YOU SMELL THAT!!
PURE TESTOSTERONE BABY!!!
I GET RIPPED AND GET GIRLS
I’M THE ALPHA RAT NOW!!
EVER SINCE I WAS A KID I WAS/t5 BULLIED
AND NOW MY BULLIES ARE SCARED OF ME!
IF YOU’RE NOT WAKING UP AT 5AM TO WORKOUT YOU ARE A /sLOSER RAT/d.
ALL I DO IS EXERCISE I CAN’T EVEN FEED MYSELF.
SPEAKING OF WHICH CAN YOU GET ME SOME PROPER FOOD? I NEED SUSTENANCE.
I CAN SHARE MY GYM ADVICE AND THIS MUSIC DISC FOR IT!!!
/sRAWRRRRRRRRRRRR/d *squeak squeak*
->END

=== AskForMeal ===
I NEED SUSTENANCE!!!
    +[Meal]
        ->TradeMeal("Meal")
    +[Orange]
        THIS FRUIT WOULDN'T BE ENOUGH TO SUSTAIN MY MASS.
        ->END
    +[Sweet Snack]
        ARE YOU SERIOUS?
        THIS IS COVERED IN SUGAR, IT MIGHT KILL MY MUSCLES.
        ->END
    +[Invalid]
        I CANT EAT THIS!!!!
        ->END

=== TradeMeal(item)===
!stateDone
FOODDD/t5 THAT’S WHAT I WANT!!
/q(eats the meal in one bite) /d
H/t3E/t3L/t3L/t3 YEAHHH //hell yeah
SO HERE’S MY GYM ADVICE YOU WANTED ME TO SHARE WITH YOU
NEGLECT YOUR FRIENDS,/t3 SLEEP AND FOOD AND SPEND ALL DAY GETTING RIPPED!!
I USED TO USE THIS MUSIC DISC TO PUMP IRON TO BUT SINCE YOU GOT ME THAT MEAL...
... I’M HAPPY TO SHARE IT WITH YOU WHILST YOU’RE GETTING RIPPED LIKE ME!!!
LETS DO SOME EXERCISE!!!
>m1
YEAHH!
>e
->END

->END