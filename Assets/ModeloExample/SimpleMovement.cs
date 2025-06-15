
using UnityEngine;
using Photon.Pun;

public class SimpleMovement : MonoBehaviourPunCallbacks
{
    public float velocidad = 5;

    void Update()
    {
        if (photonView.IsMine)
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 desplazamiento = new Vector3(movimientoHorizontal, 0, movimientoVertical) * velocidad * Time.deltaTime;

            transform.Translate(desplazamiento);
        }
    }
}
