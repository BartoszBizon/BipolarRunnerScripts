using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Material hitedWhite;
	[SerializeField] private Collider2D collider2D;
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			collider2D.enabled = false;
			Disappear();
		}
	}

	private void Disappear()
	{
		spriteRenderer.material = hitedWhite;
		
		var sequence = DOTween.Sequence();

		for (int i = 0; i < 2; i++)
		{
			sequence.Append(transform.DOScale(Vector3.one * 0.1f, 0.1f));
			sequence.Append(transform.DOScale(Vector3.one * 0.9f, 0.1f));
		}
		sequence.Append(transform.DOScale(Vector3.zero, 0.2f));
		sequence.OnComplete(() =>
		{
			Destroy(gameObject);
		});
	}
}
