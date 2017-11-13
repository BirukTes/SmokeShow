using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;

public class TriggerElements : MonoBehaviour {

    private List<TriggerableElement> musicReactiveElements = new List<TriggerableElement>();
    private List<TriggerableElement> backgroundElements = new List<TriggerableElement>();
    private TriggerableElement lastTriggeredElement;

    protected virtual void Awake() {
        foreach ( GameObject obj in GameObject.FindGameObjectsWithTag( "MusicReactive" ) ) {
            musicReactiveElements.Add( obj.GetComponent<TriggerableElement>() );
        }
        foreach ( GameObject obj in GameObject.FindGameObjectsWithTag( "Background" ) ) {
            backgroundElements.Add( obj.GetComponent<TriggerableElement>() );
        }
    }

    void Update() {
        foreach ( char c in Input.inputString ) {
            var index = KeyToIndexDictionary.GetIndex( c.ToString() );

            try {
                if ( index <= 14 ) {
                    lastTriggeredElement = TriggerElement( index, musicReactiveElements );
                }
                else if ( index <= 29 ) {
                    lastTriggeredElement = TriggerElement( index, backgroundElements );
                }
                else if ( index == 9999 ) {
                    Debug.Log( "Could not find a value for keystroke of " + c.ToString() );
                }
                else {
                    Debug.Log( "Got a very unexpected outcome using keystroke of " + c.ToString() );
                }
            }
            catch ( NoElementWithIndexException e ) {
                Debug.Log( "Could not find an element with index position of " + e.index );
            }

        }

        if ( Input.GetButtonDown( "Up" ) ) {
            if ( lastTriggeredElement && !lastTriggeredElement.audioInsensitive ) {
                lastTriggeredElement.gameObject.GetComponent<TransparentMaterial>().DecrementSensitivityDivision();
            }
        }
        else if ( Input.GetButtonDown( "Down" ) ) {
            if ( lastTriggeredElement && !lastTriggeredElement.audioInsensitive ) {
                lastTriggeredElement.gameObject.GetComponent<TransparentMaterial>().IncrementSensitivityDivision();
            }
        }
        else if ( Input.GetButtonDown( "FlipBuffer" ) ) {
            if ( lastTriggeredElement && !lastTriggeredElement.audioInsensitive ) {
                lastTriggeredElement.gameObject.GetComponent<TransparentMaterial>().FlipBuffer();
            }
        }
        else if ( Input.GetButtonDown( "DriveTreble" ) ) {
            if ( lastTriggeredElement && !lastTriggeredElement.audioInsensitive ) {
                lastTriggeredElement.gameObject.GetComponent<TransparentMaterial>().FlipTreble();
            }
        }
        else if ( Input.GetButtonDown( "DriveMids" ) ) {
            if ( lastTriggeredElement && !lastTriggeredElement.audioInsensitive ) {
                lastTriggeredElement.gameObject.GetComponent<TransparentMaterial>().FlipMids();
            }
        }
        else if ( Input.GetButtonDown( "DriveBass" ) ) {
            if ( lastTriggeredElement && !lastTriggeredElement.audioInsensitive ) {
                lastTriggeredElement.gameObject.GetComponent<TransparentMaterial>().FlipBass();
            }
        }
        else if ( Input.GetKey( KeyCode.LeftShift ) && Input.GetKey( KeyCode.Escape ) ) {
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
    }

    TriggerableElement TriggerElement( int index, List<TriggerableElement> elements ) {

        var fadingIn = elements.FirstOrDefault( element => element.state == States.FADING_IN );

        var selectedElement = elements.FirstOrDefault( element => element.indexOfElement == index );

        if (!selectedElement ) {
            throw new NoElementWithIndexException(index);
        }

        if ( !fadingIn && selectedElement.state == States.INACTIVE ) {

            var elementToTurnOff = elements.FirstOrDefault(
                element => element.state == States.ACTIVE
                && element.indexOfElement != index );

            if ( elementToTurnOff ) {
                elementToTurnOff.TurnOff();
            }
            selectedElement.TurnOn();
        }
        return selectedElement;
    }

    class NoElementWithIndexException : System.Exception {
        public int index;

        public NoElementWithIndexException( int index ) {
            this.index = index;
        }
    }

}
