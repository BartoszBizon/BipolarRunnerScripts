using DG.Tweening;
using UnityEngine;
using Zenject;

// TO REFACTOR !!!
public class PlayerAnimationController : AnimationController
{
	[SerializeField] private RuntimeAnimatorController animatorControllerLight;
	[SerializeField] private RuntimeAnimatorController animatorControllerDark;
	[SerializeField] private Rigidbody2D playerRigidbody;
	[SerializeField] private PlayerController controller;
	[SerializeField] private GroundCheck groundCheck;
	[SerializeField] private SpriteRenderer playerSpriteRenderer;
	[SerializeField] private ChangeFormController changeFormController;
	private GameManager gameManager;

	[Inject]
	public void Init(GameManager gameManager)
	{
		this.gameManager = gameManager;
	}
	private void Awake()
	{
		playerSpriteRenderer.DOFade(0, 0);
	}

	private void Start()
	{
		playerSpriteRenderer.DOFade(1, 2f);
	}

	private void LateUpdate()
	{
// TO REFACTOR !!!
		if (!gameManager.IsInputDisabled)
		{
			animator.SetBool("isGrounded", groundCheck.IsGrounded);
			animator.SetBool("isGroundedVertical", groundCheck.IsGroundVertical);
			animator.SetFloat("xMove", playerRigidbody.velocity.x);
			animator.SetFloat("yMove", playerRigidbody.velocity.y);
			animator.SetBool("duringTransformation", changeFormController.DuringTransformation);
			animator.SetBool("canAttack", dealMeleeDamage.CanAttack);
			animator.SetFloat("attackCombo",((PlayerDealMeleeDamage)dealMeleeDamage).AttackCombo);
			animator.SetBool("duringDoubleJump",controller.DuringDoubleJump);
		}	
	}

	public void ChangeForm()
	{
		DOTween.To(()=>Time.timeScale,x => Time.timeScale = x, 1f,0.5f);
		animator.runtimeAnimatorController = animator.runtimeAnimatorController == animatorControllerLight ? animatorControllerDark : animatorControllerLight;
		changeFormController.DuringTransformation = false;
	}
}
