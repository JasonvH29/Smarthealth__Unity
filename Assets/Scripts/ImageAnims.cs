using UnityEngine;

public class ImageAnims : MonoBehaviour
{
    public RectTransform arrowImage1; // Assign your first arrow image in the Inspector
    public RectTransform arrowImage2; // Assign your second arrow image in the Inspector
    public float speed = 100f; // Speed of the animation
    public float distance = 200f; // Distance to move back and forth

    private Vector3 startPosition1;
    private Vector3 startPosition2;
    private bool movingRight1 = true;
    private bool movingRight2 = true;

    void Start()
    {
        startPosition1 = arrowImage1.localPosition;
        startPosition2 = arrowImage2.localPosition;
    }

    void Update()
    {
        AnimateArrow(arrowImage1, ref startPosition1, ref movingRight1);
        AnimateArrow(arrowImage2, ref startPosition2, ref movingRight2);
    }

    void AnimateArrow(RectTransform arrowImage, ref Vector3 startPosition, ref bool movingRight)
    {
        float step = speed * Time.deltaTime;
        if (movingRight)
        {
            arrowImage.localPosition += new Vector3(step, 0, 0);
            if (arrowImage.localPosition.x >= startPosition.x + distance)
            {
                movingRight = false;
            }
        }
        else
        {
            arrowImage.localPosition -= new Vector3(step, 0, 0);
            if (arrowImage.localPosition.x <= startPosition.x - distance)
            {
                movingRight = true;
            }
        }
    }
}
