This project is your engine. You are supposed to modify/extend this
when the requirements of your project call for it (e.g. you need
extra/custom functionality).

Just like any game engine, a game engine does not need to know any specifics
about your game. A game engine just provides you with tools to create "a" game
more quickly, whatever game it may be. That is why this project cannot access
files from the YourGame project, so only "core" features go in this project.
The YourGame project makes use of this project to create features specific to
your project, typically by inheriting from GameObject.cs or simply creating
instances of classes in the engine project (e.g. Timer.cs and Sprite.cs). Look
at the demo states the YourGame project for examples I created.

A lot of thought has been put into the classes that already exist. Please, look
at them carefully. You will get a better idea of what is expected of you then!
Need inspiration? Perhaps look at how Godot Engine (a beginner friendly engine)
works. Only add features when you actually need them to save time, however ;-)!

Regarding the game tree:
When designing ways for your game objects to communicate, I really recommend
sticking to this rule of thumb: "Call down, signal up.". This means that
only parents should call methods on their children and not vice versa in general.
If children want to communicate to their parent, they typically should do so
using events (know when to break the rules).
