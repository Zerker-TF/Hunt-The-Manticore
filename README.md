# Hunt-The-Manticore 
Simple battleship game in which one player chooses how close to the city he wishes to place the manticore [0-100] and the 2nd player has to guess it's location to shoot it down with a cannon.

1- Player 1 gets to establish how far the Manticore is from the city, in the range 0 to 100.
2- Player 2 now gets to repeatedly attempt to shoot it down by picking the range to target until either the city or the Manticore is destroyed.
3- Each attempt consists of one round. In each round the console will inform player 2 if ther overshot, fell short or hit the Manticore.
4- The damage dealt on a regular round is 1 point. if the number is a multiple of 3 or 5, the damage is 3 points. if the number is a multiple of both 3 and 5, the damage is 10 points. The Manticore has an HP of 10 points.
5- If the Manticore survives a turn, it will deal 1 point of damage to the city. The City has an HP of 15 points.

Sample run of what the Console will display:

Player 1, how far away from the city do you want to station the Manticore? range: [0-100]
-----------------------------------------------------------
Player 2, it is your turn.
-----------------------------------------------------------  
STATUS: Round: 1  City: 15/15  Manticore: 10/10 
The cannon is expected to deal 1 damage this round. 
Enter desired cannon range: 50  
That round OVERSHOT the target.  
-----------------------------------------------------------
STATUS: Round: 2  City: 14/15  Manticore: 10/10  
The cannon is expected to deal 1 damage this round.  
Enter desired cannon range: 25  
That round FELL SHORT of the target.
-----------------------------------------------------------  
