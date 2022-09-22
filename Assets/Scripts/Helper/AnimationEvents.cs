using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anim;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    private void ResetShooting()
    {
        anim.Play("idle");
    }

    private void CameraStartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}