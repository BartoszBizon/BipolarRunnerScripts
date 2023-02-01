using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
	
	private int goldAmount;
	public int GoldAmount => goldAmount;

	public PlayerData(int goldAmount) {
		this.goldAmount = goldAmount;
	}

}
