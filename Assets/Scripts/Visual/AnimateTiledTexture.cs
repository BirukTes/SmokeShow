using UnityEngine;

public class AnimateTiledTexture : MonoBehaviour {

    [SerializeField]
    Texture[] frames;
    [SerializeField]
    float framesPerSecond;
    Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
    }

    void Update() {
        mat.mainTexture = frames[(int)( Time.time * framesPerSecond ) % frames.Length];
    }
}
