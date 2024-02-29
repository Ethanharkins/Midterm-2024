using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Assuming you have an array or list of enemies in your scene
    // This could be populated either manually or dynamically at runtime
    public EnemyAI[] enemies;

    // Track the current camera position index for logic related to camera switching
    private int currentCameraPositionIndex = 0;
    private const int totalCameraPositions = 5; // Update this based on your game's total camera positions

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Initialize game state, e.g., freezing time if that's required at game start
        Time.timeScale = 0; // Freeze time at the start of the game
        EnableEnemyMovement(false); // Ensure enemies don't move until allowed
    }

    // Method to enable or disable enemy movement
    public void EnableEnemyMovement(bool enable)
    {
        foreach (var enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.EnableMovement(enable);
            }
        }
    }

    // Call this method to transition to the next camera view and manage game phase
    public void AdvanceCameraPosition()
    {
        currentCameraPositionIndex++;

        if (currentCameraPositionIndex >= totalCameraPositions)
        {
            // Once all camera positions have been visited, prepare for the action phase
            PrepareForActionPhase();
        }
        // Else, the CameraController would handle moving to the next camera position
    }

    void PrepareForActionPhase()
    {
        // Any preparation before the action phase begins, e.g., showing UI hints or a countdown
        StartActionPhase();
    }

    public void StartActionPhase()
    {
        Time.timeScale = 1; // Resume time for the action phase
        EnableEnemyMovement(true); // Allow enemies to move

        // Optionally, set a timer for the action phase duration before next strategy phase or game phase
        // This could involve invoking another method after a delay, e.g., using Invoke("MethodName", delayInSeconds);
    }

    // Example method to be called from UI button or elsewhere to manually trigger camera advancement
    public void OnNextCameraButtonPressed()
    {
        AdvanceCameraPosition();
    }

    // Additional methods to handle game over conditions, restarting the game, etc., can be added here
}
