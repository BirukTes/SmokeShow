using UnityEngine;
using System.Collections;

class TransparentMaterial : MonoBehaviour {

    [SerializeField]
    bool buffer = false;
    [SerializeField]
    private float divisionIntensityBuffer = 10;
    [SerializeField]
    private float divisionIntensity = 10;
    [SerializeField]
    private Color unityColor = new Color( 0, 0, 0, 0 );

    private Material m_Material;    // Used to store material reference.
    private Color m_Color;            // Used to store color reference.
    [SerializeField]
    int bandX = 5;
    [SerializeField]
    int bandY = 5;
    [SerializeField]
    int bandZ = 5;
    private TriggerableElement element;

    public void IncrementSensitivityDivision() {
        if (divisionIntensityBuffer == -1) {
            divisionIntensityBuffer += 2;
            divisionIntensity += 2;
        }
        else {
            divisionIntensityBuffer += 1;
            divisionIntensity += 1;
        }
    }

    public void DecrementSensitivityDivision() {
        if ( divisionIntensityBuffer == 1 ) {
            divisionIntensityBuffer -= 2;
            divisionIntensity -= 2;
        }
        else {
            divisionIntensityBuffer -= 1;
            divisionIntensity -= 1;
        }
    }

    public void FlipBass() {
        bandX = 0;
        bandY = 1;
        bandZ = 2;
    }

    public void FlipTreble() {
        bandX = 5;
        bandY = 6;
        bandZ = 7;
    }

    public void FlipMids() {
        bandX = 3;
        bandY = 4;
        bandZ = 5;
    }

    public void FlipBuffer() {
        if ( buffer ) {
            buffer = false;
        }
        else {
            buffer = true;
        }
    }

    void Start() {
        element = GetComponent<TriggerableElement>();
        // Get reference to object's material.
        m_Material = GetComponent<Renderer>().material;

        // Get material's starting color value.
        m_Color = m_Material.color;
    }


    void Update() {
        if ( element.state == States.ACTIVE ) {
            m_Material.color = new Color( unityColor.r, unityColor.g, unityColor.b, Calc() );
        }
    }

    float Calc() {
        if ( buffer ) {
            return ( AudioPeer.bandBuffer[bandX] + AudioPeer.bandBuffer[bandY] + AudioPeer.bandBuffer[bandZ] ) / divisionIntensityBuffer;
        }
        return ( AudioPeer.frequencyBand[bandX] + AudioPeer.frequencyBand[bandY] + AudioPeer.frequencyBand[bandZ] ) / divisionIntensity;
    }
 
}
