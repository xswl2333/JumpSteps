using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    int inputKey;
    public float jumpForce = 2.5f;
    Vector2 step;
    bool animIsPlaying = false;
    public LayerMask whatIsGoal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        step = FindObjectOfType<GameManager>().step;
    }

    // Update is called once per frame
    void Update()
    {
        if (animIsPlaying)
            return;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            inputKey = 1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            inputKey = -1;

    }

    private void FixedUpdate()
    {
        if (inputKey != 0 && !animIsPlaying)
        {
            var jumAnim = rb.DOJump(rb.position + new Vector2(step.x * inputKey, step.y), jumpForce, 1, 0.15f).SetEase(Ease.OutCubic).OnComplete(() => { animIsPlaying = false; });
            inputKey = 0;
            animIsPlaying = jumAnim.IsPlaying();
        }

        if (!animIsPlaying)
        {
            if (Physics2D.CircleCast(transform.position, 0.2f, Vector2.zero, 0, whatIsGoal))
            {
                print("You win");
            }

            if(!Physics2D.CircleCast(transform.position, 0.2f, Vector2.zero,0))
            {
                print("Game Voer");
            }
        }
    }
}
