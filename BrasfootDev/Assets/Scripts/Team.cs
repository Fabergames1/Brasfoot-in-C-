using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// TESTE GITHUB agora
[System.Serializable]
public class Team : MonoBehaviour
{
    public List<Player> Players = new List<Player>(5);
    public Player player;

    public enum League { A, B, C, D };//LIMITA O MAXIMO DE STATS QUE UM TIME PODE TER
    public League league;
    public string teamName;
    public float power;//DETERMINA A CHANCE DE FAZER GOOLS
    public float defence;//DETERMINA A CHANCE DE NAO TOMAR GOOLS
    public float crowd; //BUFA OS STATUS DE DEFESA E POWER


    void Start()
    {

        defence = PlayerStregthMean();
        power = PlayerTalentMean();

    }


    float PlayerStregthMean()
    {
        float sum = 0;
        foreach (Player player in Players)
        {
            sum += player.stregth;
        }
        return sum;
    }
    float PlayerTalentMean()
    {
        float sum = 0;
        foreach (Player player in Players)
        {
            sum += player.talent;
        }
        return sum;
    }

}
