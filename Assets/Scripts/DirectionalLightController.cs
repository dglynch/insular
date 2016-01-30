using UnityEngine;
using System.Collections;

public class DirectionalLightController : MonoBehaviour {

    public TimeController timeController;

    // Use this for initialization
    void Start() {
        SetSunDirection();
    }

    // Update is called once per frame
    void Update() {
        SetSunDirection();
    }

    private void SetSunDirection() {
        transform.rotation = Quaternion.Euler(timeController.GetFractionalTimeAfterDawn() * 360, -90, 0);
    }

}
