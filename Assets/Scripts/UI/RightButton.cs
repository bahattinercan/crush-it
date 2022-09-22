using UnityEngine;

public class RightButton : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Down()
    {
        playerController.MoveRight();
    }

    public void Up()
    {
        playerController.MoveStraight();
    }
}