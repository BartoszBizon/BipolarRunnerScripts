using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private Transform allMenus;
	[SerializeField] private TextMeshProUGUI goldAmount;
	[SerializeField] private GameObject loadingScreen;


	private void Awake()
	{
		goldAmount.text = SaveSystem.LoadPlayer().GoldAmount.ToString();
	}

	public void PlayGame()
	{
		loadingScreen.SetActive(true);
		SceneManager.LoadSceneAsync("SampleScene");
	}
	
	public void ExitGame() {
		Application.Quit();
	}

	public void ChangeMenuPosition(float additionalYValue)
	{
		var newPosition = new Vector3(allMenus.localPosition.x, allMenus.localPosition.y + additionalYValue, allMenus.localPosition.z);
		allMenus.DOLocalMove(newPosition, 1);
	}


}
