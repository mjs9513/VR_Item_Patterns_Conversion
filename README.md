# VR_Item_Patterns_Conversion
This project demonstrates an improved version of the item system that is present in my VR survival game, featured on my portfolio www.michaelschek.com.
This item system was designed with the goal of utilizing as many design patterns as possible, design patterns detailed here: https://www.geeksforgeeks.org/software-design-patterns/
Program.cs demonstrates the main test cases for the program and shows off many of the design-pattern related functionalities.
The main tests that were run for this system were for:
* Item creation using the factory systems
* Testing the Flyweight design pattern implementation
* Testing the decorator design pattern implementation
* Testing the resource system and stacking behaviors
* Testing the item storage system

Behaviors:
Behavior classes were built with the Strategy design pattern in mind such that different behaviors/sets of game logic could be applied to different objects at runtime. The Behavior classes are meant to contain the main logic the drivers item interactions and behaviors,
for instance the ToolBehavior containing the necessary code for dealing damage and the storage behavior handling storing items like in a chest for a game.

Blueprints:
Blueprints are structs that can be thought of as "Crafting Recipies" for items. They are objects that are created to hold the information that will make up items created in Factories (detialed below). 

Factories:
The ItemFactory class is purposed with creating and returning items when called upon. There is room for further expansion of this system as detailed in the comments, as object pooling could be built in for better resource management, but for now it serves to decouple the
object creation process from the class itself.

Interfaces:
In this folder is a variety of interfaces I created to assist in the setup of the system.

Items:
This folder contains the class definitions for the main object types that can be created in this system. 
Currently it contains the class definitions for:
* Base Items
* Resources
* Tools
* Enchanted Tools
These classes hold different behaviors that can be swapped in and out as necessary at run time, and are used to drive interactions with the objects.

Program Data:
In this folder is a file for the various enums that I used and a static class called ItemAtlas that contains definitions for the different items that can be created in the system (i.e. Iron Pickaxe, Enchantments, Stack Behaviors, and so on).
