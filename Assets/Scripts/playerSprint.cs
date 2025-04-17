using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSprint : MonoBehaviour
{
    private float sprintInput;
    [SerializeField] private float sprintTimer = 5f;
    [SerializeField] private float sprintCooldown = 0.5f;
    public SprintBarController sprintBarController;

    public playerMovement playermovement;
    // Start is called before the first frame update
    void Start()
    {
        sprintTimer = 5f;
        sprintBarController.SetMaxSprint(sprintTimer);
    }

    // Update is called once per frame
    void Update()
    {
        sprintInput = Input.GetAxis("Sprint");
        if(Mathf.Abs(sprintInput) > 0f && sprintTimer > 0f){
            playermovement.playerSpeed = 1.5f;
            sprintTimer -= Time.deltaTime;
            sprintBarController.SetSprint(sprintTimer);
            sprintCooldown = 0.5f;
        }
        else if(Mathf.Abs(sprintInput) > 0f && sprintTimer <= 0f){
            playermovement.playerSpeed = 1f;
        }
        else{
            playermovement.playerSpeed = 1f;
            if(sprintCooldown > 0f){
                sprintCooldown -= Time.deltaTime;
            } else if(sprintCooldown <= 0f){
                sprintTimer += Time.deltaTime * 1.5f;
                sprintBarController.SetSprint(sprintTimer);
            }
        }
        sprintTimer = Mathf.Clamp(sprintTimer,-0.05f, 5f);
    }
}
