using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour {

    public void Reset() {
        SceneManager.LoadScene("World");
    }
}
