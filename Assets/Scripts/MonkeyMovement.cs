using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MonkeyMovement : MonoBehaviour
{
    public RectTransform monkeyImage;
    public float moveSpeed = 10f;
    public RectTransform canvasRect;
    public Image controlsBackground; // Reference to ControlsBackground Image

    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

    private Vector2 movement;
    private Coroutine moveCoroutine;

    void Start()
    {
        AddButtonListeners(upButton, Vector2.up);
        AddButtonListeners(downButton, Vector2.down);
        AddButtonListeners(leftButton, Vector2.left);
        AddButtonListeners(rightButton, Vector2.right);

        AddBorderToControlsBackground();
    }

    void Update()
    {
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            movement += Vector2.up;
        if (Input.GetKey(KeyCode.DownArrow))
            movement += Vector2.down;
        if (Input.GetKey(KeyCode.LeftArrow))
            movement += Vector2.left;
        if (Input.GetKey(KeyCode.RightArrow))
            movement += Vector2.right;

        MoveMonkey(movement * moveSpeed * Time.deltaTime);
    }

    void AddButtonListeners(Button button, Vector2 direction)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        pointerDown.callback.AddListener((data) => StartMoving(direction));
        trigger.triggers.Add(pointerDown);

        EventTrigger.Entry pointerUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        pointerUp.callback.AddListener((data) => StopMoving());
        trigger.triggers.Add(pointerUp);
    }

    void StartMoving(Vector2 direction)
    {
        StopMoving();
        moveCoroutine = StartCoroutine(MoveContinuously(direction));
    }

    void StopMoving()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }

    IEnumerator MoveContinuously(Vector2 direction)
    {
        while (true)
        {
            MoveMonkey(direction * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    void MoveMonkey(Vector2 deltaPosition)
    {
        Vector2 newPosition = monkeyImage.anchoredPosition + deltaPosition;

        float halfWidth = monkeyImage.rect.width / 2;
        float halfHeight = monkeyImage.rect.height / 2;

        float minX = -canvasRect.rect.width / 2 + halfWidth;
        float maxX = canvasRect.rect.width / 2 - halfWidth;
        float minY = -canvasRect.rect.height / 2 + halfHeight;
        float maxY = canvasRect.rect.height / 2 - halfHeight;

        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        monkeyImage.anchoredPosition = newPosition;
    }

    void AddBorderToControlsBackground()
    {
        if (controlsBackground != null)
        {
            Outline outline = controlsBackground.gameObject.AddComponent<Outline>();
            outline.effectColor = Color.black; // Border color
            outline.effectDistance = new Vector2(5, -5);
        }
    }
}
