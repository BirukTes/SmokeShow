using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reduce : MonoBehaviour {

    private Material m_Material;    // Used to store material reference.
    private Color m_Color;
    private TriggerableElement element;
    [SerializeField]
    private Color unityColor = new Color( 0, 0, 0, 0 );
    [SerializeField]
    private float reduceAmp = 100;

    // Use this for initialization
    void Start () {
        element = GetComponent<TriggerableElement>();
        // Get reference to object's material.
        m_Material = GetComponent<Renderer>().material;

        // Get material's starting color value.
        m_Color = m_Material.color;
    }

    void Update() {
        if ( element.state == States.ACTIVE ) {
            m_Material.color = new Color( unityColor.r, unityColor.g, unityColor.b, (1 - (MessageBus.calcedAlpha * reduceAmp ) ) );
        }
    }

}
