using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10;
    public float turnSpeed = 3;

    [Header("Projectile")]
    public GameObject projectilePrefab;
    [SerializeField]
    private GameObject spawnPoint = null;

    //Reference to player components
    private Rigidbody playerRb;
    private PlayerStats myStats;
    private AnimationController animController;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        myStats = GetComponent<PlayerStats>();
        animController = GetComponent<AnimationController>();
    }

    void Update()
    {
        //If alive then Move() and Look()
        if (myStats.isDead == false)
        {
            Move();
            Look();

            //Attack if cooldown has reset and mana is sufficient
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                int spellCost = projectilePrefab.GetComponent<ProjectileController>().manaCost;

                if (myStats.attackCooldown <= 0f && myStats.currentMana > spellCost)
                {
                    Shoot();
                }
            }
        }
    }

    //Bind movement to vertical and horizontal inputs
    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        playerRb.MovePosition(playerRb.position + movement * speed * Time.deltaTime);
         
        if (movement != Vector3.zero)
        {
            animController.MoveAnimationStart();
        }

        if (movement == Vector3.zero)
        {
            animController.MoveAnimationStop();
        }
    }

    //Smooth look at cursor position
    private void Look()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
       
        if (Physics.Raycast(camRay, out hit))
        {
            Vector3 cursorPos = hit.point;
            cursorPos.y = 0.1f;

            Quaternion cursorAngle = Quaternion.LookRotation(cursorPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, cursorAngle, turnSpeed * Time.deltaTime);
        }
    }

    //Instantiate projectile
    private void Shoot()
    {
        animController.AttackAnimation();
        
        Instantiate(projectilePrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        myStats.ReduceMana(projectilePrefab.GetComponent<ProjectileController>().manaCost);
        myStats.ResetCooldown();
    }
}
