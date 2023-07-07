# TestThrowMaster
Bug:
1. In EnemyScript.cs (Solved)
The EnemiesAlive variable is being calculated in Awake(). The bug is sometime EnemiesAlive is being add 1 or -1  despite being in Awake() functoin.
Solution i can think of: Is set the EnemiesAlive variable to an int. Example set it at 2, and in gamescene there are 2 enemies too. This is an easier solution, but i want to have a code to add up by itself.
