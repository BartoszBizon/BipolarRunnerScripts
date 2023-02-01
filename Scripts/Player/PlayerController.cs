using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using Zenject;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private int damage;
	[SerializeField] private float jumpPower;
	[SerializeField] private PlayerHealth playerHealth;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float moveSpeedByTime;
	[SerializeField] private Rigidbody2D rbPlayer;
	[SerializeField] private PlayerDealMeleeDamage dealMeleeDamage;
	[SerializeField] private ChangeFormController changeFormController;
	[SerializeField] private int jumpMaxAmount;
	[SerializeField] private AudioClip[] jumpSounds;
	
	private Vector2 movement;
	private Vector3 velocity = Vector3.zero;
	private bool right;
	private Sequence sequence;
	private int jumpCounter;
	private bool duringDoubleJump;
	private bool isJumping;
	private float jumpTimeCounter = 0f;
	private float jumpTime = 0.35f;
	private Dictionary<string, Action> inputNamesAndActions;
	private Dictionary<KeyCode, Action> inputsNamesAndActionsKeyboard;
	private GameManager gameManager;
	private CanvasManager canvasManager;

	public bool DuringDoubleJump => duringDoubleJump;
	public int Damage => damage;
	public float JumpPower => jumpPower;
	public PlayerHealth PlayerHealth => playerHealth;
	public float MoveSpeed => moveSpeed;
	
	
	[Inject]
	public void Init(GameManager gameManager,CanvasManager canvasManager)
	{
		this.gameManager = gameManager;
		this.canvasManager = canvasManager;
	}

	private void Start()
	{
#if UNITY_ANDROID
		inputNamesAndActions = new Dictionary<string, Action>()
		{
			{"attack",InvokeInitAttack()},
			{"changeForm",InvokeChangeForm()},
			{"pause",InvokePause()}
		};
#else
		inputsNamesAndActionsKeyboard = new Dictionary<KeyCode, Action>()
		{
			{KeyCode.K,InvokeInitAttack()},
			{KeyCode.T,InvokeChangeForm()},
			{KeyCode.P,InvokePause()}
		};
#endif
	}

	private void Update()
	{

		if (gameManager.IsInputDisabled)
		{
			movement.x = 0;
			movement.y = 0;
			return;
		}

		if (changeFormController.DuringTransformation && changeFormController.CurrentForm != LightOrDark.Light)
		{
			movement.x = 0;
			return;
		}
		
#if UNITY_ANDROID
		foreach (var inputNameAndAction in inputNamesAndActions)
		{
			if (TouchController.Instance.GetBoolByName(inputNameAndAction.Key))
			{
				inputNameAndAction.Value.Invoke();
			}
		}
#else
		foreach (var inputKeyboard in inputsNamesAndActionsKeyboard)
		{
			if (Input.GetKey(inputKeyboard.Key))
			{
				inputKeyboard.Value.Invoke();
			}
		}
#endif
		JumpHandler();
	}



	private void FixedUpdate()
	{
		moveSpeed += moveSpeedByTime;
		rbPlayer.velocity = new Vector2(moveSpeed, rbPlayer.velocity.y);
	}

	private void RotatePlayer()
	{
		right = !right;
		Vector3 scaler = transform.localScale;
		scaler.x *= -1;
		transform.localScale = scaler; 
	}

	public void ResetJumpCounter()
	{
		jumpCounter = 0;
	}
	
	
	private void JumpHandler()
	{
		var getJumpDown = Input.GetKeyDown(KeyCode.Space) || TouchController.Instance.GetBoolByName("getJumpDown");
		var getJump = Input.GetKey(KeyCode.Space) || TouchController.Instance.GetBoolByName("getJump");
		var getJumpUp = Input.GetKeyUp(KeyCode.Space) || TouchController.Instance.GetBoolByName("getJumpUp");

		if (getJumpDown && jumpCounter < jumpMaxAmount)
		{
			AudioManager.Instance.EffectsAudioSource.PlayOneShot(jumpSounds[jumpCounter]);
			jumpCounter++;
			isJumping = true;
			jumpTimeCounter = jumpTime;
			rbPlayer.velocity = Vector2.up * JumpPower;
		}

		if (getJump && isJumping)
		{
			if (jumpTimeCounter > 0)
			{
				rbPlayer.velocity = Vector2.up * JumpPower;
				jumpTimeCounter -= Time.deltaTime;
			}
			else
			{
				isJumping = false;
			}
		}

		if (getJumpUp)
		{
			isJumping = false;
		}
	}

	public void AssignPlayerStats(PlayerStats playerStats)
	{
		damage = playerStats.Damage;
	}

	private Action InvokeInitAttack()
	{
		return dealMeleeDamage.InitAttack;

	}

	private Action InvokeChangeForm()
	{
		return () =>
		{
			changeFormController.ChangeFormTo(LightOrDark.Dark);
		};
	}
	
	private Action InvokePause()
	{
		return () =>
		{
			canvasManager.PauseMenu.gameObject.SetActive(true);
		};
	}
	


}


