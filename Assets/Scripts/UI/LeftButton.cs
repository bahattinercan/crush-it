using UnityEngine;

public class LeftButton : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void Down()
    {
        playerController.MoveLeft();
    }

    public void Up()
    {
        playerController.MoveStraight();
    }

}