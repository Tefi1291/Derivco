Design process approach:

In this file you will find an explanation of the decisions I made to build the solution for QuestionTwo.

* **Support ties when the face value of the cards are the same**

  We introduced an Enum (_'PlayResultEnum'_) that represents the different result values that the game can take.
  For this point we wanted to change the interface of the game to not just return a bool, but 3 different result cases. Those are: Win, lose and Tie.
  
*  **Allow for the ties to be resolved as a win by giving the different suits precedence**

    Now we want to allow the user to introduce the ability to resolve a tie play by giving a suit precedence option. 
    
    For this point, we have introduced an optional flag to the interface of the HighCard Play method. By default suit precedence will be _off_. 
    If you call ```IHighCard.Play(true)``` you will play with suit precedence option _On_. This option will define if you win or lose in case the result has been a draw.
  And because unit tests are always necessary, there is a unit test that will cover this escenario ('Play_with_suit_precendece_never_returns_a_tie').
  
* **Support for Multiple Decks &  make the game work for a deck with 20 cards per suit**
  
    For this point, I made the decision of introduce params to the constructor of the HighCard class. You will find two constructors.
  One parameterless, which defaults the number of decks to one, and the number of cards per suit to 13. 
  Then you have a constructor that let you define the number of decks and the cards per suit as you like. 
  Also, we do validate the input and throw an exception in case the number of decks is less or equal to zero.
  
* **Support the abilty to never end in a tie, by dealing a further card to each player**
    
    To add support for this requirement, I added a loop to the main program logic, which will play another round until the game result is anything other than a tie.
    
* **Make one of the cards in the deck a wild card**
    
    Lastly, for this requirement I added a constant that defines the value of the wild card (In this case 20). 
    The algorithm will behave in such a way that if any of the cards is equal to a wild card, a win will be established immediately.
    In the event that both players get the wild card, player one takes precedence.
    
    
 
