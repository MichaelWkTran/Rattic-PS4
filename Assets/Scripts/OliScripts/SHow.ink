->main

=== main ===
->trade
        ->DONE
=== chosen(Hats) ===
You shared {Hats}!!
->DONE
=== chosen2(Food) ===
You have my {Food}.
->DONE
=== InvalidOption() ===
This isnt anything to do with the flamingos.

->DONE

=== trade ===
What do you want to share with me?
    +[String]
        ->chosen2("String")
    +[Orange]
        ->chosen("Orange")
    +[Invalid]
        ->InvalidOption() 
        
        
=== knotName ===
This is the content of the knot.

-> END




-> main