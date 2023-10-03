+[!stateIntro]
    ->main
+[!stateTokens]
    ->tokens
+[!stateTrade]
    ->chooseItem
->DONE


=== main ===
!stateTokens
I am a spy rat
If you find some tokens lying around I can give you info on any item
What rat might want that item perhaps?
Don't worry/t4 this is all very corrupt
->END

=== tokens ===
Do you have any/t3./t3./t3./t3 tokens?
    +[Token]
    !stateTrade
    Perfect, I can now give you info on an item.
    ->END
    +[Invalid]
    That's not a token, no info for you
    ->END
=== chooseItem ===
Please choose an item you want info on.
    +[Paperclip]
    !stateTokens
    Hmmm this seems like some very bendy metal...
    Maybe ask the Lab Rat for help on this one.
    ->DONE
    +[Broken Pencil]
    !stateTokens
    Oh yeah this definitely needs to be stuck back together.
    Try find some Tape, I heard the Gym Rat might have that lying around
    ->DONE
    +[Tape]
    !stateTokens
    Very cool I love tape for when I need to keep someone quiet
    I mean, you can also use it to fix stuff I guess
    Go check in with the Lab Rat about that.
    ->DONE
    +[Pencil]
    !stateTokens
    John Wrat once killed 2 rats in a bar with a pencil.
    But I've heard you can also draw with them, ask the Artist Rat.
    ->DONE
    +[Mushroom]
    !stateTokens
    Ahh yes the mushroom
    Well that can be used for cooking but also...
    ...fortune telling stuff
    You probably shouldn't be showing me this actually
    I won't tell the RBI on you though. You're my only customer
    ->DONE
    +[Meal]
    !stateTokens
    That's a lovely meal you have there
    All I eat is RatDonalds
    That meal has a lot of sustenance actually
    Maybe the gym rat would like that, they've been training very heard
    ->DONE
    +[Mirror]
    !stateTokens
    Do I really look like that?
    You spend so much time in the dark, you lose sense of yourself
    A mirror would be very helpful for the Fashionista Rat
    But it could also be used as a flat surface for preparing food
    ->DONE
    +[Orange]
    !stateTokens
    Ooo an orange
    Very yummy
    The chef rat could definietly make something with this
    ->DONE
    +[Sweet Snack]
    !stateTokens
    Woah Sweet snacks give me pure joy
    And that doesn't happen very often
    I know those are the Mystic Rats favorite food
    ->DONE
    +[Scrap Fabric]
    !stateTokens
    What a lovely piece of Scrap fabric
    You simply must take this to the Fashionista Rat
    I can tell they'd make something amazing with it
    ->DONE
    +[Cool Hat]
    !stateTokens
    That's a really cool hat
    I would take it but I'm too self concious to wear hats
    The Dog would love to chew on this, they're such a good boy
    Emo rat might also like this, they're obsessed with all things flamingo
    Lowkey a major fanrat, dont tell them I said that
    ->DONE
    +[Music Disc]
    !stateTokens
    This a banger, way better then 3rat
    This is unreleased The Flamingos right?
    I know the Emo Rat is obsessed with all things The Flamingos
    Lowkey a major fanrat, dont tell them I said that
    ->DONE
    +[Bone]
    !stateTokens
    HAH YOU GOT SCAMMED BY THE PIRAT DIDN"T YOU!
    Yeah well the Dog would love to chew on these
    I am a little concerned what type of bones those are
    ->DONE
    +[Christmas Star]
    !stateTokens
    Is it really that time of year again?
    Christmas is one of those human holidays I think
    ->DONE
    +[Key]
    !stateTokens
    Only humans use these, anything humanlike would like this
    ->DONE
    +[Money]
    !stateTokens
    Money can be used to buy things like costumes
    ->DONE
    +[Rat Poison]
    !stateTokens
    GET THAT AWAY FROM ME
    Only an evil human would use this
    ->DONE
    +[Ring]
    !stateTokens
    This would go nicely with a costume
    ->DONE
    +[String]
    !stateTokens
    mob, murder, meow
    ->DONE
    +[Cheese]
    !stateTokens
    yum, three things want that
    2 are not rats
    1 is a collection of rats
    ->DONE
    +[Token]
    !stateTokens
    /sTHANKS FOR THE FREE TOKEN HEHE!/d
    ->END
    +[Invalid]
    I can't give info on that
    ->END
->DONE

->END