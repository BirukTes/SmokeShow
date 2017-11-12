# SmokeShow
Smoke Show - Live Music Visualization in Unity

An explanation of Smoke Show's functionality is available [here](https://www.youtube.com/watch?v=w9CUsIQuFV8)

# How to Get Started with Smoke Show
1. Download and install Unity - [unity3d.com](https://unity3d.com/)
2. Download the and unzip the repository - [here](https://github.com/Vampire-Computer-People/SmokeShow/archive/master.zip)
3. Open the project in unity my double-clicking the main.scene file in /Assets/Scenes - ignore or skip any warnings about Unity versions.
4. Press Play in Unity to see Smoke Show in action - by default the application uses the bundled Busy Beds - Kangaroo Court mp3 file as the source audio.

# About How Smoke Show Works
All elements in Smoke Show appear in the Hierarchy view in Unity. 

![Hierarchy](https://github.com/Vampire-Computer-People/SmokeShowScreenShots/blob/master/hierarchy.png)

They are divided into 2 categories:
1. Backgrounds - backgrounds are a collection of images that are animated statically.
2. Music Reactive - music reactive elements are collections of images that react to the music via the [AudioPeer](Assets/Scripts/Audio/AudioPeer.cs)

All elements use the [AnimateTiledTexture](Assets/Scripts/Visual/AnimateTiledTexture.cs) file to animate an array of images. Video is not currently supported.
