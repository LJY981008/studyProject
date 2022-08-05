using UnityEngine;

// PlayerController는 플레이어 캐릭터로서 Player 게임 오브젝트를 제어한다.
public class PlayerController : MonoBehaviour {
   public AudioClip deathClip; // 사망시 재생할 오디오 클립
   public float jumpForce = 700f; // 점프 힘

   private int jumpCount = 0; // 누적 점프 횟수
   private bool isGrounded = false; // 바닥에 닿았는지 나타냄
   private bool isDead = false; // 사망 상태

   private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
   private Animator animator; // 사용할 애니메이터 컴포넌트
   private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트

   private void Start() {
        // 초기화
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
   }

   private void Update() {
        // 사용자 입력을 감지하고 점프하는 처리
        // 죽으면 끝
        if (isDead) return;
        // 클릭(점프) 이벤트
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.velocity = Vector2.zero;    // 점프 직전의 속도를 0으로
            playerRigidbody.AddForce(new Vector2(0, jumpForce));    // 위쪽으로 힘 부여
            playerAudio.Play(); //점프 오디오 재생
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            // 클릭(점프)을 떼었을 때 속도가 상승 중 이라면 현재속도를 절반으로 줄임
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f; 
        }
        animator.SetBool("Grounded", isGrounded);
   }

   private void Die() {
        // 사망 처리
        // 사망 트리거 on
        animator.SetTrigger("Die");
        // 오디오를 사망 오디오로 변경
        playerAudio.clip = deathClip;
        // 재생
        playerAudio.Play();
        // 속도를 0으로
        playerRigidbody.velocity = Vector2.zero;
        isDead = true;
   }

   private void OnTriggerEnter2D(Collider2D other) {
       // 트리거 콜라이더를 가진 장애물과의 충돌을 감지
       // 충돌한 물체의 콜라이더가 Dead 오브젝트인지와 현재 죽지 않은 상태인지를 체크
        if(other.tag.Equals("Dead") && !isDead)
        {
            //죽음
            Die();
        }
   }

   private void OnCollisionEnter2D(Collision2D collision) {
       // 바닥에 닿았음을 감지하는 처리
       // 어떤 콜라이더와 닿았으며, 충돌 표면이 위를 보고 있으면
       if(collision.contacts[0].normal.y > 0.7f)
        {
            // 바닥에 닿은 상태로 만들고 점프횟수 초기화
            isGrounded = true;
            jumpCount = 0;
        }
   }

   private void OnCollisionExit2D(Collision2D collision) {
        // 바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
   }
}