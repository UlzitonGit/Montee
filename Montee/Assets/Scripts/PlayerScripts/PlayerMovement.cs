using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Vector2 moveVector;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float jumpForce = 4f;
    private bool isGrounded;
    private bool isOnHold;
    [SerializeField] Transform holdPos;
    [SerializeField] Transform groundPos;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask holdLayer;
    public bool onZipLine = false;
    private bool canJump = true;
    private bool isJumping = false;
    [SerializeField] Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded) anim.SetInteger("State", 0);
        Walk();
        Jump();
    }

    private void FixedUpdate()
    {
        CheckGround();
        CheckHold();
    }
    void Walk()
    {
        if (onZipLine == true) return;
        moveVector.x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVector.x * moveSpeed, rb.velocity.y);
        if (moveVector.x < 0) transform.localScale = new Vector3(-1, 1, 1);
        if (moveVector.x > 0) transform.localScale = new Vector3(1, 1, 1);
        if (isGrounded && moveVector.x != 0) anim.SetInteger("State", 1);
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && (isGrounded == true || isOnHold == true || onZipLine == true) && canJump == true)
        {
            if (onZipLine == true)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                rb.isKinematic = false;
                onZipLine = false;
                transform.parent = null;
            }
            canJump = false;
            StartCoroutine(JumpReload());
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(Vector2.up * jumpForce * 10);
        }
        if(isOnHold == true && isJumping == false)
        {          
            rb.velocity = new Vector3(0,0,0);
        }
        
      
    }
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundPos.position, 0.05f, groundLayer);
        isGrounded = collider.Length > 0;
    }
    private void CheckHold()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(holdPos.position, 0.3f, holdLayer);
        isOnHold = collider.Length > 0;
    }
    IEnumerator JumpReload()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.1f);
        isJumping = false;
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }
   
}

