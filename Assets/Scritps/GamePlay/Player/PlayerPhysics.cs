using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerPhysics : MonoBehaviour
{
    private CharacterInfo playerInfo;
    private Rigidbody2D playerRB2D;
    private TrailRenderer playerTR;

    //dash

    private float timeDashing = .2f;
    private float dashPower = 5;
    // Start is called before the first frame update
    void Start()
    {
        playerInfo = GetComponentInChildren<CharacterInfo>();
        playerRB2D = GetComponent<Rigidbody2D>();
        playerTR = GetComponent<TrailRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Moving(float directionX, float directionY)
    {
        Vector2 playerDirection = new Vector2(directionX, directionY);
        playerRB2D.velocity = playerDirection * (playerInfo.Speed * Time.deltaTime) * 100;

    }

    public void Dashing(float directionX, float directionY)
    {
        StartCoroutine(DashingCoroutine(directionX, directionY));
    }

    public IEnumerator DashingCoroutine(float directionX, float directionY)
    {

        Debug.Log("thuc hien dashing");
        Vector2 dashDirection = new Vector2(directionX, directionY).normalized;
        playerRB2D.velocity = dashDirection * (dashPower) * 50;
        playerTR.emitting = true;
        yield return new WaitForSeconds(timeDashing);
        VelocityToZero();
        playerTR.emitting = false;
    }

    public void VelocityToZero()
    {
        playerRB2D.velocity = Vector2.zero;
    }
}
