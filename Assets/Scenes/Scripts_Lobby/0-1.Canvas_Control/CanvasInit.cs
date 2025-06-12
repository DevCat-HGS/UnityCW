using UnityEngine;
using TMPro;

public class CanvasInit : MonoBehaviour
{
    public GameObject DashboardCanvas;
    public GameObject Usercanvas;
    public GameObject GameCanvas;

    void Start()
    {
        if (DashboardCanvas != null)
        {
            DashboardCanvas.SetActive(true);
        }
        if (Usercanvas != null)
        {
            Usercanvas.SetActive(true);
        }
        if (GameCanvas != null)
        {
            GameCanvas.SetActive(true); 
        }
    }
}