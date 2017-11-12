# SmokeShow
Smoke Show - Live Music Visualization in Unity

An explanation of Smoke Show's functionality is available [here](https://www.youtube.com/watch?v=w9CUsIQuFV8)

Developing Beginner level skills in Unity is encouraged before using Smoke Show!

# How to Get Started with Smoke Show
1. Download and install Unity - [unity3d.com](https://unity3d.com/)
2. Download the and unzip the repository - [here](archive/master.zip)
3. Open the project in unity my double-clicking the main.scene file in /Assets/Scenes - ignore or skip any warnings about Unity versions.
4. Press Play in Unity to see Smoke Show in action - by default the application uses the bundled Busy Beds - Kangaroo Court mp3 file as the source audio.

# How Smoke Show Works
All elements in Smoke Show appear in the Hierarchy view in Unity. 

![Hierarchy](https://github.com/Vampire-Computer-People/SmokeShowScreenShots/blob/master/hierarchy.png)

They are divided into 2 categories:
1. Backgrounds - backgrounds are a collection of images that are animated statically.
2. Music Reactive - music reactive elements are collections of images that react to the music via the [AudioPeer](Assets/Scripts/Audio/AudioPeer.cs)

All elements use the [AnimateTiledTexture](Assets/Scripts/Visual/AnimateTiledTexture.cs) file to animate an array of images. Video is not currently supported.

Create a new element by duplicating an existing element in the Unity Hierarchy. Select an element and press **Control+D**.

All elements are mapped to keyboard keys via [KeyToIndexDictionary](Assets/Scripts/Dictionaries/KeyToIndexDictionary.cs). Music Reactive elements are mapped to keys 1-T from left to right on your keyboard. Backgrounds are mapped to Y-; Refer to the [Triggerable Element](Assets/Scripts/Visual/Triggerable Element.cs) component/script in the Unity inspector.

![Hierarchy](https://github.com/Vampire-Computer-People/SmokeShowScreenShots/blob/master/triggerable_element.png)

When making a new element - set **State** to INACTIVE and increment **Index Of Element** by 1.
