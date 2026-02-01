using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowAnimator : MonoBehaviour
{
    public soEvent startFireEvent;
    public soEvent stopFireEvent;
    public Animator animatorController;
    private int drawback;

    void Start()
    {
        drawback = Animator.StringToHash("pulledBack");
        startFireEvent.events.Add(() => { if (this == null) return; animatorController.SetBool(drawback, true); Debug.Log("start"); });
        stopFireEvent.events.Add(() => { if (this == null) return; animatorController.SetBool(drawback, false); Debug.Log("stop");  });
    }
}
