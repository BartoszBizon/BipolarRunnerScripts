using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
	public bool IsInputDisabled;
	public StartPlace StartPlace;
	public Camera MainCamera;
	
	private PlayerController playerController;

	[Inject]
	public void Init(PlayerController playerController)
	{
		this.playerController = playerController;
	}
	
	private void Awake()
	{		
		Application.targetFrameRate = 60;
		LoadPlayer();
	}

	public void LoadPlayer() 
	{
		PlayerData data = SaveSystem.LoadPlayer();
		playerController.GetComponentInChildren<PlayerGold>().goldAmount = data.GoldAmount;
	}
}
