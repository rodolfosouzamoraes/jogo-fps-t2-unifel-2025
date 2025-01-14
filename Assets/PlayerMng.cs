using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMng : MonoBehaviour
{
    public static PlayerMng Instance;
    public static VisaoCamera visaoCamera;
    public static MovimentarPlayer movimentarPlayer;
    public static DisparoPlayer disparoPlayer;

    void Awake(){
        if(Instance == null){
            visaoCamera = GetComponentInChildren<VisaoCamera>();
            movimentarPlayer = GetComponent<MovimentarPlayer>();
            disparoPlayer = GetComponent<DisparoPlayer>();
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public bool estaMorto;

    //GameObject da Lanterna

    // Update is called once per frame
    void Update()
    {
        //Ativar ou não a Lanterna
        if(Input.GetKeyDown(KeyCode.F)){
            //Ligar ou desligar Lanterna
        }
    }

    public void MatarJogador(){
        estaMorto = true;
        Destroy(GetComponent<CapsuleCollider>());
        //Habilitar fim de jogo
        //Desabilitar armas
    }
}
