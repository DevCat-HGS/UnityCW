using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ButtonExit : MonoBehaviourPunCallbacks {

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}