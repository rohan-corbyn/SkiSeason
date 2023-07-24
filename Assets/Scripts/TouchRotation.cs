using UnityEngine;

public class TouchRotation : MonoBehaviour
{
    private Vector2 lastTouchPosition;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                lastTouchPosition = touch.position;
            }
        }
    }

    private void CheckTouchedArea()
    {
        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);

        bool isTopLeft = lastTouchPosition.x < screenCenter.x && lastTouchPosition.y < screenCenter.y;
        bool isTopRight = lastTouchPosition.x >= screenCenter.x && lastTouchPosition.y < screenCenter.y;
        bool isBottomLeft = lastTouchPosition.x < screenCenter.x && lastTouchPosition.y >= screenCenter.y;
        bool isBottomRight = lastTouchPosition.x >= screenCenter.x && lastTouchPosition.y >= screenCenter.y;

        if (isTopLeft)
        {
            Debug.Log("Touched in the top left quarter of the bottom half of the screen.");
        }
        else if (isTopRight)
        {
            Debug.Log("Touched in the top right quarter of the bottom half of the screen.");
        }
        else if (isBottomLeft)
        {
            Debug.Log("Touched in the bottom left quarter of the bottom half of the screen.");
        }
        else if (isBottomRight)
        {
            Debug.Log("Touched in the bottom right quarter of the bottom half of the screen.");
        }
    }
}
