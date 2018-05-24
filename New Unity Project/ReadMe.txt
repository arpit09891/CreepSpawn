Overview:

I am trying to create small Moba game or atleast incorporate some of its feature. It is right now more like tower defence game. Stop minions from reaching castle.

Assignment 4

Why you selected the topic?

I wanted to implement MOBA game features in my game. I want to make it as similar as I can to MOBA. In MOBA games or tower defense, minions go to a certain lane till the core. 
So, I selected the navigation system and pluggable AI for my AI. It give my minions intelligence to follow player if they see him. They will keep on chasing him untill he is in their line of sight and alive. If player dies or evade their line of sight the AI will go into search state. If they dont find him they will go back to their lane system. Pretty much like in MOBA games. The difference is player to evade their line of sight has to hide.

I also learned delegate pattern in implmenting of navigation system which improved my knowledge on power of scriptable object. Their importance in saving the memory.

Your knowledge of the topic prior to doing the research?

I am new in Unity. So, I never even baked navigation system. Although navigation is small part of this tutorial. Its more of state pluggin in an AI through delegate pattern. I didn't know anything about this pattern until Gene, Gameplay programming professor, introduce in one od his lecture. I got interested in it so I want to learn it more.In process, I learn ower of delegate patter, using states and scriptable object. Now, I got creep system fairly like MOBA games.

Your approach to researching the topic?

It got introduced to me in one of my gameplay programming class. I wanted to implement it to achieve navigation system of MOBA games so I selected this topic.
I read the topic and search about scriptable objects. I watched the tutorial on Unity twice. I did create the game exactly as tutorial illustrated. I listened to tutorial atleast 3 times to learn it and understand its concepts. It took significant amount of time but I learned a lot. In process, I came across new concepts for navigation system. After learning tutorial and practising it. I implement it to my game. In order to make it compatible with my game I have to change my movement script to StateController and this incorporate it to control my creep movements smoothly. It was little bit buggy but then it worked good in an end without any errors.

What you learned through the research?

I learned how to iplement navigation system like MOBA games. I learned scriptable objects. I learned pluggable AI.
I learned how to create a finite state machine based on AI system.
I learned how to author actions, decisions, and transitions for our state machine.
I learned how to  modify agent behavior by plugging in ScriptableObject assets.

I made two types of Agent 
Chaser - Patrols, once they see an enemy they chase untill enemy is dead.
Scanner - Patrols, once they see an enemy they chase untill losing line of sight, then scan in a circle for new targets and either chase or patrol.

Further more, to better game play designer can control line of sight of enemy to their wish by changing the values in DefaultEnemyStats, which is scriptable object.

links to any research sources:

https://unity3d.com/learn/tutorials/topics/navigation/intro-and-session-goals?playlist=17105

Link to my video
https://drive.google.com/open?id=0Bz_PY_IX2MkBR1M5WXVKd0J4OWs

I showed gameplay first in which AI follow a path untill they find player after finding player they hunt him, If player evades their line of sight, they start looking for it.
There are sphere in scene view to show state of AI:
Green sphere: Follow Path.
Yellow Sphere: Looking for player
Red Sphere: chase and attack player

