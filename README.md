# TestThrowMaster
There is 1 bug in EnemyScript.cs
The EnemiesAlive variable is being calculated in Awake(). The bug is sometime EnemiesAlive is being add 1 or -1  despite being in Awake() functoin.
