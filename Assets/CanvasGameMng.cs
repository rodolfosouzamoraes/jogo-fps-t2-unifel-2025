using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameMng : MonoBehaviour
{
    public static CanvasGameMng Instance;

    void Awake(){
        if(Instance == null){
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    [Header("Conf Status Player")]
    public TextMeshProUGUI txtVida;
    public TextMeshProUGUI txtMunicao;
    public int vidaJogador;
    private int vidaMaximaJogador = 100;
    public GameObject pnlStatusPlayer;

    [Header("Conf Topo")]
    public GameObject pnlTopo;
    public GameObject [] iconesChaves;
    public TextMeshProUGUI txtTempo;
    public TextMeshProUGUI txtObjetivo;
    private float totalTempo;
    private int totalChavesColetadas;

    [Header("Conf Geral")]
    public bool fimDeJogo;

    // Start is called before the first frame update
    void Start()
    {
        vidaJogador = vidaMaximaJogador;
        txtVida.text = $"+{vidaJogador}";

        totalChavesColetadas = 0;
        totalTempo = 0;
        txtTempo.text = $"{totalTempo}";
        txtObjetivo.text = $"Colete as 7 chaves!";

        fimDeJogo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            VoltarParaMenu();
        }
        
        if(fimDeJogo == true) return;
        ContarTempo();
        AtualizarMunicaoUI();
    }

    private void AtualizarMunicaoUI(){
        int pente = PlayerMng.disparoPlayer.ArmaAtiva.Pente;
        int municao = PlayerMng.disparoPlayer.ArmaAtiva.MunicaoAtual;
        
        //Se o pente ou a munição for inferior a 10, eu vou colocar o 0 na frente do numero
        string valorPente = pente < 10 ? $"0{pente}" : $"{pente}";
        string valorMunicao = municao < 10 ? $"0{municao}" : $"{municao}";
        txtMunicao.text = $"{valorPente}/{valorMunicao}";
    }

    public void DecrementarVidaJogador(int dano){
        if(fimDeJogo == true) return;

        vidaJogador -= dano;
        if(vidaJogador <= 0){
            vidaJogador = 0;
            PlayerMng.Instance.MatarJogador();
            pnlStatusPlayer.SetActive(false);

            //Ativar tela de GameOver

            ReiniciarJogo();//Reniciar Jogo depois de um tempo
        }
        txtVida.text = $"+{vidaJogador}";
    }

    public void IncrementarVidaJogador(){
        vidaJogador += 25;
        if(vidaJogador > vidaMaximaJogador){
            vidaJogador = vidaMaximaJogador;
        }
        txtVida.text = $"+{vidaJogador}";
    }

    public void ReiniciarJogo(){
        //Exibir tela de carregamento

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DesbloquearMouse(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void VoltarParaMenu(){
        DesbloquearMouse();
        
        //Exibir a tela de carregamento

        SceneManager.LoadScene(0);
    }

    private void ContarTempo(){
        totalTempo += Time.deltaTime;
        txtTempo.text = $"{(int)totalTempo}";
    }

    public void IncrementarChave(){
        totalChavesColetadas++;
        iconesChaves[totalChavesColetadas].SetActive(true);

        //verificar se coletou todas as chaves
        if(ColetouTodasAsChaves()){
            txtObjetivo.text = "Encontre o portão final!";
        }
    }

    public bool ColetouTodasAsChaves(){
        return totalChavesColetadas == iconesChaves.Length-1 ? true : false;
    }

    public void ExibirTelaFinal(){
        fimDeJogo = true;

        // Pegar o tempo final do jogo
        // Configurar a tela final

        Debug.Log("Jogo completado!!!");
    }
}
