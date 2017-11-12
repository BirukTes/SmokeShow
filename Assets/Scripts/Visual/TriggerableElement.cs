using UnityEngine;

public enum States { ACTIVE, FADING_IN, FADING_OUT, INACTIVE };

public class TriggerableElement : MonoBehaviour {

    private Material material;
    public int indexOfElement;
    public States state = States.INACTIVE;
    [SerializeField]
    private float fadePerSecond = 2.5f;
    public bool audioInsensitive = false;

    public void Start() {
        material = GetComponent<Renderer>().material;
        if ( state == States.INACTIVE ) {
            Deactivate();
        }
    }

    private void Update() {
        switch ( state ) {
            case States.FADING_IN:
                if ( material.color.a < 1 && audioInsensitive ) {
                    FadeIn();
                }
                else {
                    state = States.ACTIVE;
                }
                break;
            case States.FADING_OUT:
                if ( material.color.a > 0 ) {
                    FadeOut();
                }
                else {
                    Deactivate();
                }
                break;
        }

    }

    private void FadeOut() {
        var color = material.color;
        material.color = new Color( color.r, color.g, color.b, color.a - ( fadePerSecond * Time.deltaTime ) );
    }

    private void FadeIn() {
        var color = material.color;
        material.color = new Color( color.r, color.g, color.b, color.a + ( fadePerSecond * Time.deltaTime ) );
    }

    private void Deactivate() {
        state = States.INACTIVE;
        gameObject.SetActive( false );
    }

    public void TurnOn() {
        gameObject.SetActive( true );
        var color = material.color;
        material.color = new Color( color.r, color.g, color.b, 0 );
        if (audioInsensitive) {
            state = States.FADING_IN;
        }
        else {
            state = States.ACTIVE;
        }

    }

    public void TurnOff() {
        state = States.FADING_OUT;        
    }

}
