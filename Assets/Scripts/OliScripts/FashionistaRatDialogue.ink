//bootleg progress switch statement 
+[!stateIntro]
    ->main
+[!stateFabric]
    ->AskForFabric
+[!stateMirror]
    ->AskForMirror
+[!stateDone]
    Rat vogue is calling,/t3 go away!
->DONE

=== main ===
!stateFabric
Hurry hurry darling
The red carpet at Paris Fashion Week won’t style itself
You simply must get me some fabric
This cool hat won’t make itself
->END

=== AskForFabric ===
Did you find me some fabric???
    +[Scrap Fabric]
        ->TradeFabric("Fabric")
    +[Invalid]
        This is not fabric! Goodness me!
        ->END

=== AskForMirror ===
Do you find that mirror?
    +[Mirror]
        ->TradeMirror("Mirror")
    +[Invalid]
        I can't use this as a mirror!
        ->END


=== TradeFabric(item)===
!stateMirror
Darling/t3 what took you so long?
Heavens/t3 the stress is getting to me,/t3 and where did my mirror go?
Oh no this simply won’t do.
Find me a mirror on the dot
Or else I’ll indubitably be screwed
This cool hat just won’t make itself
->END

=== TradeMirror(item)===
!stateDone
Yes yes this mirror will do
Alright/t5 just a stitch/t5 here
A dip/t5 there
And/t3./t3./t3./t3 Voila!
A cool hat
No/t5 no/t3 /sNOOOOOO!!/d
The hat is not cool
It won’t get me on the cover of rat vogue
It’s/t5./t5./t5.
It’s just a normal hat!
I have failed
What’s that?
You think it’s cool????
Well./t3./t3./t3I suppose taste is in the eye of the beholder
Here,/t3 you have it.
//But if you’re going to get a piece from the great Fashionista Rat
//Then I simply must give you a makeover
//In return for your help.
//>makeover
->END

->END