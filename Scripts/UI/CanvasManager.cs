using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
	public TextMeshProUGUI GoldValue;
	public GameObject HealthPanel;
	public PauseMenu PauseMenu;
	public ScoreMenu ScoreMenu;
	public Image Background;
	public DistanceUI DistancePanel;
	public Slider DarkEssenceFill;
	public Image ForegroundDark;

	public void Fade(float finalAlphaValue)
	{
		Background.gameObject.SetActive(true);
		Background.canvasRenderer.SetAlpha(0);
		Background.DOFade(1, 1);
	}

}
