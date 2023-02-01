using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using EZCameraShake;
using DG.Tweening;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
	public int Health;
	public bool Immortal;
	
	[SerializeField] private Image[] healthArray;
	[SerializeField] private TakeHitEffect takeHitEffect;
	
	private Sequence sequence;
	private GameManager gameManager;
	private CanvasManager canvasManager;

	[Inject]
	public void Init(GameManager gameManager,CanvasManager canvasManager)
	{
		this.gameManager = gameManager;
		this.canvasManager = canvasManager;
	}
	private void Start()
	{
		for (int i=0; i<healthArray.Length; i++)
		{
			healthArray[i] = canvasManager.HealthPanel.transform.GetChild(i).GetComponent<Image>();
			if (i < Health) healthArray[i].enabled = true;
			else healthArray[i].enabled = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("DealMeleeDamage") && !Immortal)
		{
			Health--;
			Immortal = true;
			takeHitEffect.TakeHit(4);
			TurnOffImmortal();
			ChangeHealthBar();
		}

		if (col.CompareTag("HpUp") && Health < 6)
		{
			Health++;
			ChangeHealthBar();
		}

		if (col.CompareTag("DeathZone"))
		{
			Health = 0;
		}


		// THIS SECTION ALWAYS HAVE TO BE ON BOTTOM
		if (Health <= 0)
		{
			Health = 0;
			canvasManager.Fade(1);
			StartCoroutine(ShowPauseMenu());
		}
	}

	private IEnumerator ShowPauseMenu()
	{
		gameManager.IsInputDisabled = true;
		yield return new WaitForSeconds(1);
		canvasManager.ScoreMenu.gameObject.SetActive(true);
		Time.timeScale = 0;
	}

	private void TurnOffImmortal()
	{
		sequence?.Kill();
		sequence = DOTween.Sequence();
		sequence.AppendInterval(1.2f).OnComplete(() => { Immortal = false; });
	}

	private void ChangeHealthBar()
	{
		for (int i = 0; i < 6; i++)
		{
			if (i < Health)
			{
				healthArray[i].enabled = true;
			}
			else
			{			
				healthArray[i].enabled = false;
			} 
		}
	}
}
