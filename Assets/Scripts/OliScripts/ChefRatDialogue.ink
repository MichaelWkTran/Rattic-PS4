+[!stateIntro]
    ->main
+[!stateFruitVeg]
    ->AskForFruitVeg
+[!stateMirror]
    ->AskForMirror
+[!stateDone]
    cooking intensifies
->DONE

=== main ==
!stateFruitVeg
Bonjour rat!
As a little ratling I always wanted to be a rat chef
I’m now living my dreams
But no one trusts a rat like me with the ingredients I need
So instead/t3 I dumpster dive
If you could find me some quality fruit/t3 or vegetables/t3 I’ll make something up for you.
I promise it’ll be good.
->END

=== AskForFruitVeg ===
    Do you have some fruit or vegetables?
    +[Orange]
        ->TradeOrange("Orange")
    +[Mushroom]
        ->TradeMushroom("Mushroom")
    +[Invalid]
        ->InvalidOptionFruitVeg() 
        
=== TradeOrange(item) ===
!stateMirror
Ooo an orange
Exceptional taste young rattling
I can make up some sweet snacks with this,/t3 I just need something flat to chop on.
If you can find a flat surface I’ll cook up some tasty treats for you
->END

=== TradeMushroom(item) ===
!stateDone
Hmmm some mushrooms, I can definitely make a meal out of this
Some proper decent food
Unlike that RatDonalds stuff
It’s an insult to food
Anyways let's make this up
>m3
And voila a meal!
>e
->END

=== InvalidOptionFruitVeg ===
/sNON!/d This is not fruit or vegetables! Uncultured rat!
->DONE

=== AskForMirror ===
    Do you have a flat surface to chop this up? Or did you want me to make something different?
    +[Mirror]
        ->TradeMirror("Mirror")
    +[Mushroom]
        ->TradeMushroom("Mushroom")
    +[Invalid]
        ->InvalidOptionMirror() 
        
=== TradeMirror(item) ===
!stateDone
Bonjour yet again!
What’s this?/t7 A chopping board?
Thank you young rattling!
You could be a cook you know?
Alright let's make this up
>m3
And voila sweet snacks!
If you need anything else made come by me again!
>e
->END

=== InvalidOptionMirror ===
This will simply will not do!
Do you any flat surface to chop this up?
->DONE

->END
