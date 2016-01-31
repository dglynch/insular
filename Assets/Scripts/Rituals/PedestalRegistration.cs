using UnityEngine;
using System.Collections;
using System.Linq;

public class PedestalRegistration : MonoBehaviour {

    public PedestalRitual Ritual;

    void OnTriggerEnter(Collider collider) {
        if (IsMatch(collider)) {
            Debug.Log("Cube matched.");
            Ritual.AddMatch();
        }
    }

    void OnTriggerExit(Collider collider) {
        if (IsMatch(collider)) {
            Debug.Log("Matched cube removed.");
            Ritual.RemoveMatch();
        }
    }

    private bool IsMatch(Collider collider) {
        var cubeColour = collider.gameObject.name.Split('_').Last();
        var pedestalColour = this.gameObject.name.Split('_').Last();
        return cubeColour == pedestalColour;
    }
}
