# Rotary Wheel User Control

This is a .NET rotary wheel/spinner/knob/wheel-of-fortune-thingy user control built using C#/XAML. 
The user control targets Windows 10 apps but can be used across all .NET applications.
Here's a stylized version that was used in [@HeavenFresh's](https://twitter.com/heavenfresh) app.

![stylized version](https://github.com/jpoon/RotaryWheel/blob/master/img/rotary_wheel_styled.gif)

Given the labels of each slice, the user control will automatically create the necessary number of slices.
Both touch and mouse events are supported, and when the user finishes manipulation of the wheel, the wheel will animate back to the center of the selected slice.

Out-of-the-box, what you'll get is something more along the lines of:

![basic version](https://github.com/jpoon/RotaryWheel/blob/master/img/rotary_wheel_basic.png)

## Installation

To install, run the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

```
PM> Install-Package RotaryWheelUserControl
```

## Usage

### Configurations:

| Property			| |
| ------------------|----------------------------------------------------------------------------|
| BackgroundColor	| color of starting slice with each subsequent slice being a lighter version |
| ForegroundColor	| color of labels |
| Size				| size of the rotary wheel |
| HideLabels		| boolean value denoting whether to show or hide the labels |
| Slices			| array of strings of the value/label for each slice |
| SelectedItemValue | read-only value denoting the currently selected slice |

| Callback | |
| ------------------|-----------------------------------------------------------|
| PropertyChanged	| event that is raised when the `SelectedItemValue` changes |


We can instantiate a rotary wheel like so:

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

## How

If you are curious of how this all works, check out the accompanying blog [post](http://jasonpoon.ca/2015/08/29/building-a-rotary-wheel-control/).

## License
 Copyright (c) Microsoft Corporation, licensed under [The MIT License (MIT)](https://raw.githubusercontent.com/jpoon/RotaryWheel/master/LICENSE).
