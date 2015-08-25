# Rotary Wheel

This is a Rotary Wheel/Spinner/Knob user control built for Windows apps. 

Basic out-of-the-box looks like this:

![basic version](https://github.com/jpoon/RotaryWheel/blob/master/img/rotary_wheel_basic.png)

Stylized version:

![stylized version](https://github.com/jpoon/RotaryWheel/blob/master/img/rotary_wheel_styled.gif)


## Installation

* Download
* Add project as a reference 
* Build

## Usage

In your XAML,

```xml
   <userControl:RotaryWheel 
		x:Name="rotaryWheelDemo" 
		Size="200"
		BackgroundColor="Purple" 
		ForegroundColor="White" />
```

In your code-behind,

```c#
	rotaryWheelDemo.Slices = new[]
	{
		"Off",
		"Low",
		"Medium",
		"High",
	};
```

## Reference
http://blog.jerrynixon.com/2012/06/windows-8-animated-pie-slice.html

## License
 Copyright (c) Microsoft Corporation, licensed under [The MIT License (MIT)](https://github.com/jpoon/crunchbase/blob/master/LICENSE).