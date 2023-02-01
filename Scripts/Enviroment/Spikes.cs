using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
	private Animator animator;
	private BoxCollider2D boxCollider;
	private float time;
	private int value=1;

	private void Start()
	{
		animator = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		time += Time.deltaTime;
		if(time > 5)
		{
			time = 0;
			animator.Play("ShowSpikes");
		}
	}

	private void ShowSpikes() {
		boxCollider.enabled = true;
	}

	private void HideSpikes()
	{
		boxCollider.enabled = false;
	}
}
