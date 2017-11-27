using System;
using System.Linq;
using UnityEngine;

public class AnimateTiledTexture : MonoBehaviour {

    [SerializeField]
    Texture[] frames;
    [SerializeField]
    float framesPerSecond;
    Material mat;
    [SerializeField]
    bool boomerang = false;
    Texture[] boomerangFrames;

    void Start() {
        mat = GetComponent<Renderer>().material;
        if ( boomerang ) {
            boomerangFrames = (Texture[])frames.Clone();
            Array.Reverse( boomerangFrames );
            RemoveAt( ref boomerangFrames, 0);
            RemoveAt( ref boomerangFrames, boomerangFrames.Length - 1 );
            frames = ConcatArrays( frames, boomerangFrames );
        }
    }

    void Update() {
        var frame = (int)( Time.time * framesPerSecond ) % frames.Length;
        mat.mainTexture = frames[frame];
    }

    public static void RemoveAt<T>( ref T[] arr, int index ) {
        for ( int a = index; a < arr.Length - 1; a++ ) {
            // moving elements downwards, to fill the gap at [index]
            arr[a] = arr[a + 1];
        }
        // finally, let's decrement Array's size by one
        Array.Resize( ref arr, arr.Length - 1 );
    }

    public static T[] ConcatArrays<T>( params T[][] list ) {
        var result = new T[list.Sum( a => a.Length )];
        int offset = 0;
        for ( int x = 0; x < list.Length; x++ ) {
            list[x].CopyTo( result, offset );
            offset += list[x].Length;
        }
        return result;
    }
}
