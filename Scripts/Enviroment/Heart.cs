using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
	[SerializeField] 
	private Animator animator;
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player")) 
		{
			animator.Play("Interaction");
		}
	}

	private void DoDestroy()
	{
		Destroy(gameObject);
	}
}
