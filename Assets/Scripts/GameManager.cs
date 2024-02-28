using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // References to the camera positions or cameras for each room
    public Transform[] roomViews;
    public Camera mainCamera;

    private int currentRoomIndex = -1;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        SwitchToNextRoom();
    }

    public void SwitchToNextRoom()
    {
        currentRoomIndex++;
        if (currentRoomIndex >= roomViews.Length)
        {
            // TODO: Implement logic to show all rooms or switch to a multi-camera setup
            Time.timeScale = 0.5f; // Slow motion
            return;
        }

        mainCamera.transform.position = roomViews[currentRoomIndex].position;
        mainCamera.transform.rotation = roomViews[currentRoomIndex].rotation;

        // Freeze time while setting up the room
        Time.timeScale = 0;
    }
}
