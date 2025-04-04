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

    // Variables for NaZorgInstructie1 interaction
    public GameObject naZorgInstructie1; // Reference to NaZorgInstructie1 GameObject
    public Button instructionButton1; // Reference to Instruction Button inside NaZorgInstructie1
    public GameObject instructionPanel1; // Reference to Instruction Panel inside NaZorgInstructie1
    public Button closeButton1; // Reference to Close Button inside Instruction Panel

    // Variables for NaZorgInstructie2 interaction
    public GameObject naZorgInstructie2; // Reference to NaZorgInstructie2 GameObject
    public Button instructionButton2; // Reference to Instruction Button inside NaZorgInstructie2
    public GameObject instructionPanel2; // Reference to Instruction Panel inside NaZorgInstructie2
    public Button closeButton2; // Reference to Close Button inside Instruction Panel

    void Start()
    {
        AddButtonListeners(upButton, Vector2.up);
        AddButtonListeners(downButton, Vector2.down);
        AddButtonListeners(leftButton, Vector2.left);
        AddButtonListeners(rightButton, Vector2.right);

        AddBorderToControlsBackground();

        // Initialize NaZorgInstructie1
        if (instructionPanel1 != null)
        {
            instructionPanel1.SetActive(false); // Ensure panel is initially hidden
        }

        if (instructionButton1 != null)
        {
            instructionButton1.gameObject.SetActive(false); // Ensure button is initially hidden
            instructionButton1.onClick.AddListener(ShowInstructionPanel1);
        }

        if (closeButton1 != null)
        {
            closeButton1.gameObject.SetActive(false); // Ensure close button is initially hidden
            closeButton1.onClick.AddListener(CloseInstructionPanel1);
        }

        // Initialize NaZorgInstructie2
        if (instructionPanel2 != null)
        {
            instructionPanel2.SetActive(false); // Ensure panel is initially hidden
        }

        if (instructionButton2 != null)
        {
            instructionButton2.gameObject.SetActive(false); // Ensure button is initially hidden
            instructionButton2.onClick.AddListener(ShowInstructionPanel2);
        }

        if (closeButton2 != null)
        {
            closeButton2.gameObject.SetActive(false); // Ensure close button is initially hidden
            closeButton2.onClick.AddListener(CloseInstructionPanel2);
        }
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

        if (monkeyImage.transform.position.y < 320)
        {
            movement += Vector2.up;
        }

        MoveMonkey(movement * moveSpeed * Time.deltaTime);

        CheckMonkeyProximity();
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

    void CheckMonkeyProximity()
    {
        if (naZorgInstructie1 != null && instructionButton1 != null)
        {
            float distance1 = Vector2.Distance(monkeyImage.anchoredPosition, naZorgInstructie1.GetComponent<RectTransform>().anchoredPosition);
            if (distance1 < 50f) // Adjust the distance threshold as needed
            {
                instructionButton1.gameObject.SetActive(true);
            }
            else
            {
                instructionButton1.gameObject.SetActive(false);
            }
        }

        if (naZorgInstructie2 != null && instructionButton2 != null)
        {
            float distance2 = Vector2.Distance(monkeyImage.anchoredPosition, naZorgInstructie2.GetComponent<RectTransform>().anchoredPosition);
            if (distance2 < 50f) // Adjust the distance threshold as needed
            {
                instructionButton2.gameObject.SetActive(true);
            }
            else
            {
                instructionButton2.gameObject.SetActive(false);
            }
        }
    }

    void ShowInstructionPanel1()
    {
        if (instructionPanel1 != null)
        {
            instructionPanel1.SetActive(true);
            if (closeButton1 != null)
            {
                closeButton1.gameObject.SetActive(true);
            }
        }
    }

    void CloseInstructionPanel1()
    {
        if (instructionPanel1 != null)
        {
            instructionPanel1.SetActive(false);
            if (closeButton1 != null)
            {
                closeButton1.gameObject.SetActive(false);
            }
        }
    }

    void ShowInstructionPanel2()
    {
        if (instructionPanel2 != null)
        {
            instructionPanel2.SetActive(true);
            if (closeButton2 != null)
            {
                closeButton2.gameObject.SetActive(true);
            }
        }
    }

    void CloseInstructionPanel2()
    {
        if (instructionPanel2 != null)
        {
            instructionPanel2.SetActive(false);
            if (closeButton2 != null)
            {
                closeButton2.gameObject.SetActive(false);
            }
        }
    }
}