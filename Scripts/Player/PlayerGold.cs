using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;

public class PlayerGold : MonoBehaviour
{
	public int goldAmount = 0;
	private TextMeshProUGUI goldValue;
	private CanvasManager canvasManager;

	[Inject]
	public void Init(CanvasManager canvasManager)
	{
		this.canvasManager = canvasManager;
	}
	private void Start()
	{
		goldValue = canvasManager.GoldValue;
		goldValue.SetText(string.Format("{0}", goldAmount));
	}
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Gold"))
		{
			IncrementGold();
		}
	}

	private void IncrementGold()
	{
		goldAmount += 1;
		goldValue.SetText(string.Format("{0}", goldAmount));

		SaveSystem.SavePlayer(goldAmount);
	}

	private IEnumerator LoadText()
	{
		yield return new WaitForEndOfFrame();
		goldValue.SetText(string.Format("{0}", goldAmount));
	}

}
