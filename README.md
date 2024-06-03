# StandAndShoot

A library mod for [Phantom Brigade](https://braceyourselfgames.com/phantom-brigade/) that adds an action validation function to do part checks.

It is compatible with game release version **1.3**. It works with both the Steam and Epic installs of the game. All library mods are fragile and susceptible to breakage whenever a new version is released.

This is an example of how to implement the `PhantomBrigade.Functions.ICombatActionValidationFunction` interface to do custom action validation. This example checks the part associated with the action for a specific tag. Included are example configs that use the custom function.

This can be done with the existing `DataBlockUnitCheck` functionality which is probably what you want to use if all you're doing is checking tags on parts. However, if you want to do some validation that you can't find any built-in functionality for, then this example is for you.