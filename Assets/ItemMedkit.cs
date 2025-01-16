using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMedkit : MonoBehaviour
{
    private void OnTriggerEnter(Collider colisor){
        if(colisor.gameObject.tag == "Player"){
            CanvasGameMng.Instance.IncrementarVidaJogador();
            Destroy(gameObject);
        }
    }
}
