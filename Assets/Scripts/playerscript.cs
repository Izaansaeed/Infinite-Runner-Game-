using UnityEngine;
using UnityEngine.UI;
public class playerscript : MonoBehaviour
{
    public float JumpForce;
    float score;
    public Text gameOverText;


    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;

    public Text ScoreTxt;
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE :" + score.ToString("F");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
            ShowGameOverText();
        }
    }

    void ShowGameOverText()
    {
        gameOverText.gameObject.SetActive(true);
        FindObjectOfType<GameManager>().ShowRestartButton();
    }


}