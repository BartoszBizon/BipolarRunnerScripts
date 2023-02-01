using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

// CLASS TO CHANGE OR REMOVE
public class AnimationEvents : MonoBehaviour
{
    [SerializeField] private Animator effectAnimator;
    [SerializeField] private UnityEvent onAttackEnd;

    public void InvokeEndAttack()
    {
        onAttackEnd.Invoke();
    }

    public void PlayAnimationEffect(string effectName)
    {
        effectAnimator.Play(effectName);
    }


}
