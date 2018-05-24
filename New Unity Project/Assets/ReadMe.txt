Overview:

I am trying to create small Moba game or atleast incorporate some of its feature. It is right now more like tower defence game. Stop minions from reaching castle.

Assignment 3

In this minions spawn on random lane out of total 3 lanes and player aim is to kill them before reaching the castle. Player has to defend castle, for limited amount of time, without dieing to win.
Health of castle and time to defend are low for testing reasons which can easily be changed from inspector anytime. Minions can damage player too if it comes to minions range.
Castle health and time to survive can be modified from castle object in inspector.

There are two damages: ability and physical.
There are two kind of armors:
Final damage depends on type of armor, armor value, probability damage and evasion rate
There are three types of minions each having their own classification and specialities.

Minions can only do melee damage for now. I will add projectile damage.

There is one proximity based damage in the middle of game for testing purpose. It does ability damage to minions. 

This game is getting shape of "Orcs must Die".

Designer can change health, damage, range, damage type, armor type, armor value, attack speed, movement speed for both player and enemy from inspector.

Designer can also change the rate of minions spawn and can adjust different rate for different minions.

Models:

There is model is folder inside scripts folder in assets.
It contains four model classes: enemy, player, tower, castle.

enemy model contains all the value required by enemy, similarly for player. I am still iterating over castle and tower so they are not ready.

According to my understanding, Model is the bridge between controller and view.
that's why designer can add value in model, which will then be fetch by controller.

Test Cases:

Test Cases are in Scripts>TestCases>Editor

I added test cases for general check. Moreover, some checks wont let designer to give values which can broke the game. For example, giving player attack speed of 100 will break the design. Similarly, evasion more than 60 will possible make enemy dodge every attack in its lifespan, I am still testing to reduce it to 50. There are some constraints put on variables so that weird values can be avoided. However, it will change.
Moreover, I am thinking of depending my test cases more comparative to other other objects. 
For example, test enemy damage across player maximum health.
I think comparative test cases will be better but I am not sure that its better, so I need more research and your thoughts to implement it.
By comparative I mean test player model attributes against enemy attributes or tower attributes.
