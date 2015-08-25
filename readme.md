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

Configurations:

| Property			| 
| ------------------|----------------------------------------------------------------------------|
| BackgroundColor	| color of starting slice with each subsequent slice being a lighter version |

With C#:

```c#
	var rotaryWheel = new RotaryWheel()
	{
		BackgroundColor = Colors.Purple,
		ForegroundColor = Colors.White,
		Size = 200,
		HideLabels = false,
		Slices = new[]
		{
			"Off",
			"Low",
			"Medium",
			"High",
		},
	};
	rotaryWheel.PropertyChanged += RotaryWheelDemo_PropertyChanged;
```

XAML:

```xml
   <userControl:RotaryWheel 
		x:Name="rotaryWheelDemo" 
		Size="200"
		BackgroundColor="Purple" 
		ForegroundColor="White" />
```

code-behind:

```c#
	rotaryWheelDemo.Slices = new[]
	{
		"Auto",
		"Quiet",
		"Low",
		"Medium",
		"High",
	};
```


## License
 Copyright (c) Microsoft Corporation, licensed under [The MIT License (MIT)](https://github.com/jpoon/crunchbase/blob/master/LICENSE).