# Rotary Wheel

This is a .NET rotary wheel/spinner/knob/wheel-of-fortune-thingy user control built using C#/XAML. 
The user control targets Windows 10 apps but can be used across all .NET applications.
Here's a stylized version the user control that was used in [@HeavenFresh's](https://twitter.com/heavenfresh) application.

![stylized version](https://github.com/jpoon/RotaryWheel/blob/master/img/rotary_wheel_styled.gif)

Out-of-the-box, what you'll get is something more along the lines of:

![basic version](https://github.com/jpoon/RotaryWheel/blob/master/img/rotary_wheel_basic.png)

## Installation

* Download
* Add project as a reference 
* Build

## Usage

### Configurations:

| Property			| 
| ------------------|----------------------------------------------------------------------------|
| BackgroundColor	| color of starting slice with each subsequent slice being a lighter version |
| ForegroundColor	| color of labels |
| Size				| size of the rotary wheel |
| HideLabels		| boolean value denoting whether to show or hide the labels |
| Slices			| array of strings of the value/label for each slice |
| SelectedItemValue | read-only value denoting the currently selected slice |

| Callback |
| ------------------|-----------------------------------------------------------|
| PropertyChanged	| event that is raised when the `SelectedItemValue` changes |


With the above configurations in mind, we can instantiate a rotary wheel like so:

XAML:

```xml
   <userControl:RotaryWheel 
		x:Name="rotaryWheelDemo" 
		Size="200"
		BackgroundColor="Purple" 
		ForegroundColor="White" />
```

C# (code-behind):

```c#
	rotaryWheelDemo.Slices = new[]
	{
		"Auto",
		"Quiet",
		"Low",
		"Medium",
		"High",
	};

	rotaryWheel.PropertyChanged += <some_event_handler>;
```

Take a look at the [demo project](https://github.com/jpoon/RotaryWheel/tree/master/RotaryWheelDemo) for a closer look.


## License
 Copyright (c) Microsoft Corporation, licensed under [The MIT License (MIT)](https://github.com/jpoon/crunchbase/blob/master/LICENSE).