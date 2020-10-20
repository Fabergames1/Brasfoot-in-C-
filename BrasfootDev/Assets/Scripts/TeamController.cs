using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamController : Singleton <TeamController> {//Vai controlar os status de todos os times
	
    public List<GameObject> OnScreenTeams = new List<GameObject>();
	public List<GameObject> LeagueDteams = new List<GameObject>();//lista que recebe todos os times 
	public List<Player> Players = new List<Player>();// Lista que recebe todos os jogadores
    public Creation creation;
    public GameObject myTeam;
    public GameObject enemmyTeam;
    
	public Player playerData;//pra passar os dados de cada jogador
	//para passar os dados para criar um time
	void Awake(){
        
		foreach (Transform item in creation.gameObject.transform)
        {
            LeagueDteams.Add(item.gameObject);
        }
        LeagueDteams[0].GetComponent<Team>().teamName = "Tapetinho";
        LeagueDteams[1].GetComponent<Team>().teamName = "Na Hora";
        myTeam = LeagueDteams[0];
        

	}

	// Use this for initialization
	void Start () {
       
        //If we get here I am the one!
        GameObject.DontDestroyOnLoad(this.gameObject);//Become Immortal
       
        
	
	}
	
	// Update is called once per frame
	void Update () {
        
       
    }
	public void SelectMyTeam(){
        int index = creation.selectionIndex;
        myTeam = LeagueDteams[index];
        enemmyTeam = GameObject.FindGameObjectWithTag("OtherTeam");
	}

    public static TeamController GetInstance(){
        return Instance;
    }


	void CreatePlayer(Player data){
		
	}


}
