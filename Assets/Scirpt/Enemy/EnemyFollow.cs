using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform Follow;
    public FollowManager Can;

    [SerializeField] private NavMeshAgent navMesh;
    public Transform OriginalPos;
    public Transform OriginalPos1;
    public Transform OriginalPos2;

    public float maxDistance = 12f;
    public float maxDistanceFromCenter = 5f;
    public float roamingRadius; // Radius within which to select a random destination

    public LayerMask detectionLayer;
    public bool isSee;
    public bool isWalk;

    public float timer;

    public Animator animator;

    private LineRenderer lineRenderer; // LineRenderer for ray visualization


    public Collider collider1;

    private GameObject colliderOff;

    public GameObject Sign;

    public GameObject Range;
   [SerializeField] private QuestionUi Ui;
    private void Awake()
    {
        detectionLayer = LayerMask.GetMask("Player", "Building");
        navMesh = GetComponent<NavMeshAgent>();
        collider1 = GetComponent<Collider>();

        colliderOff = GameObject.FindGameObjectWithTag("Question");
        // Find Player
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (colliderOff != null)
        {
            Ui = colliderOff.GetComponent<QuestionUi>();
        }
        else
        {
            Debug.LogWarning("Question Ui Missing");
        }

        if (Ui.states == BattleStates.Start)
        {
            collider1.enabled = true;
        }
        else
        {
            collider1.enabled = false;
        }

        if (playerObject != null)
        {
            Follow = playerObject.transform;
        }
        else
        {
            Debug.LogWarning("Player GameObject not found in the scene.");
        }

        // Initialize LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>(); // Add LineRenderer if not found
        }
        lineRenderer.startWidth = 0.05f; // Line width
        lineRenderer.endWidth = 0.05f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Set default material
        lineRenderer.startColor = Color.green; // Default color
        lineRenderer.endColor = Color.green;
    }

    private void Update()
    {
        if(Ui.states == BattleStates.Start)
        {
            collider1.enabled = true;
        }
        else
        {
            collider1.enabled = false;
        }

        if (navMesh != null)
        {
            // Calculate the distance between the enemy and the player in world space
            float distanceToTarget = Vector3.Distance(transform.position, Follow.position);
            //Debug.Log($"Distance to Target: {distanceToTarget}");

            if (distanceToTarget <= maxDistance)
            {
                Debug.LogError("In sight");

                // Ray Origin in world space (slightly above the enemy to avoid hitting the ground)
                Vector3 rayOrigin = transform.position + Vector3.up * 3.0f;

                // Direction to the player in world space
                Vector3 directionToPlayer = ((Follow.position + Vector3.up * 3.0f) - rayOrigin).normalized;

                // Perform the raycast in world space
                if (Physics.Raycast(origin: rayOrigin, direction: directionToPlayer, hitInfo:out RaycastHit hit, detectionLayer))
                {
                    Debug.Log($"Raycast Hit: {hit.collider.name}");

                    // Ray hit the player
                    if (hit.collider.CompareTag("Player"))
                    {
                        Debug.Log("Player detected by raycast");
                        if (Can.canFollow)
                        {
                            Sign.gameObject.SetActive(true);
                            collider1.enabled = true;
                            navMesh.SetDestination(Follow.position);
                            anim1();
                            Debug.Log($"Moving towards Player: {Follow.position}");
                        }
                        else
                        {
                            Sign.gameObject.SetActive(false);
                            collider1.enabled = false;
                            Debug.LogWarning("Cannot follow; stopping.");
                            navMesh.destination = transform.position;
                        }

                        // Draw the ray as a line in the game view (from origin to hit point)
                        Debug.DrawRay(rayOrigin, directionToPlayer * hit.distance, Color.green);
                    }
                    else
                    {
                        Sign.gameObject.SetActive(false);

                        // Ray hit something else (not the player)
                        Debug.LogWarning($"Blocked by: {hit.collider.name}");
                        MoveBackToOriginalPos();
                        anim2();

                        // Draw the ray as a red line in the game view (up to the point of collision)
                        Debug.DrawRay(rayOrigin, directionToPlayer * hit.distance, Color.red);
                    }
                }
                else
                {
                    Debug.LogError("Raycast did not hit anything.");
                    navMesh.ResetPath();
                    anim2();

                    // Draw a yellow ray if nothing was hit (raycast distance in world space)
                    Debug.DrawRay(rayOrigin, directionToPlayer * maxDistance, Color.yellow);
                }
            }
            else
            {
                Sign.gameObject.SetActive(false);

                Debug.LogWarning("Target out of range.");
                MoveBackToOriginalPos();
                anim2();
            }

            // Ensure NavMeshAgent has a valid path
            if (navMesh.pathStatus != NavMeshPathStatus.PathComplete)
            {
                Debug.LogError("Path to target is incomplete or invalid!");
            }

            UpdateAnimationState();
        }
        else
        {
            Debug.LogError("NavMeshAgent is null!");
        }

    }

    private void DrawRay(Vector3 origin, Vector3 direction, Color color)
    {
        lineRenderer.SetPosition(0, origin); // Set the start position
        lineRenderer.SetPosition(1, origin + direction); // Set the end position
        lineRenderer.startColor = color; // Set line color
        lineRenderer.endColor = color;
    }

    private void UpdateAnimationState()
    {
        // Check if the enemy is moving
        if (navMesh.velocity.magnitude > 0.1f)
        {
            if (isSee)
            {
                animator.SetBool("IsRunning", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);
            }

            if (isWalk)
            {
                animator.SetBool("IsWalking", true);
            }
            else
            {
                animator.SetBool("IsWalking", false);
            }

            // Set walking animation
            Debug.Log("IsWalking");
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsWalking", false); // Stop walking animation
        }
    }

    void anim1()
    {
        navMesh.speed = 7;
        isSee = true;
        isWalk = false;
    }

    void anim2()
    {
        navMesh.speed = 3.5f;
        isSee = false;
        isWalk = true;
    }

    void MoveBackToOriginalPos()
    {
        timer -= Time.deltaTime;

        if (timer >= 25)
        {
            navMesh.ResetPath();
            navMesh.destination = OriginalPos2.position;
        }
        else if (timer <= 25 && timer >= 15)
        {
            navMesh.ResetPath();
            navMesh.destination = OriginalPos1.position;
        }
        else if (timer <= 15 && timer >= 5)
        {
            navMesh.ResetPath();
            navMesh.destination = OriginalPos.position;
            Invoke("delay", 10f);
        }
    }

    void delay()
    {
        timer = 35;
    }

    public float RandomFloat(float min, float max)
    {
        return Random.Range(min, max);
    }
}
