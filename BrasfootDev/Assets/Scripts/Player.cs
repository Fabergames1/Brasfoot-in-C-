using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player {
	public string teamName;
	public string playerName;
	public float leadership;
	public float health;
	public float agility;
	public float stregth;
	public float talent;
	public enum Rarity{
		BRONZE,
		GOLD,
		DIAMOND,
		LEGEND
	}
	public Rarity rarity;

}

