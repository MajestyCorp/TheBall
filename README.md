# TheBall
 A ball that random moves and apply effects:<br>
 -Every second ball select a random direction with random speed between 1 and 5.<br>
 -if player press R, player ball will be cloned and clone (a smaller ball) will repeat all actions that player ball did. Player ball will be placed at center.<br>
 
 During the play Ability System tracks player ball and applies abilitites:<br>
 -ability #1: player ball will paint by random color if it will pass more than 3f distance;<br>
 -ability #2: player ball will be paint by green color if speed is higher than 3.<br>
 
 ![image](https://user-images.githubusercontent.com/101559700/170855470-ecbf3e6c-791a-4408-a636-7e752f5ef8f4.png)

## Implementation:
Each ability is a scriptable object that has  condition and action. Condition and Action also is a scriptable objects. Such implementation allows to create new conditions and new actions without coding.
All scriptable objects are stored in Profiles folder.

Context menu for abilities, conditions and actions<br>
![image](https://user-images.githubusercontent.com/101559700/170855625-2c3e9983-7e80-43a2-99f4-a6dfb57300cb.png)

ability #2 profile<br>
![image](https://user-images.githubusercontent.com/101559700/170855539-70394711-938d-49af-81c9-8a6dde3b2be8.png)

Condition profile for ability #2<br>
![image](https://user-images.githubusercontent.com/101559700/170855590-86ecf5db-a561-4776-a001-e753602ccf63.png)

Paint Action profile for ability #2<br>
![image](https://user-images.githubusercontent.com/101559700/170855577-0e5a056a-4be8-423e-a340-917146249891.png)

