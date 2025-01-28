using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBMng
{
    private const string VOLUME = "volume";
    private const string ZUMBI_MORTOS = "zumbi_mortos";
    private const string TEMPO_JOGO = "tempo_jogo";

    public static void SalvarDados(int totalZumbisMortos, int totalTempoJogo){
        int zumbiMortos = PlayerPrefs.GetInt(ZUMBI_MORTOS,0);
        int tempoJogo = PlayerPrefs.GetInt(TEMPO_JOGO,0);
        if(zumbiMortos < totalZumbisMortos){
            PlayerPrefs.SetInt(ZUMBI_MORTOS,zumbiMortos);
        }
        if(tempoJogo < totalTempoJogo){
            PlayerPrefs.SetInt(TEMPO_JOGO,tempoJogo);
        }
    }
}
