using UnityEngine;
using SystemRandom = System.Random;

public class Onomatopoeia : MonoBehaviour
{

    public float lifetime = 1f;
    public Transform bubbleTransform;
    public SpriteRenderer bubble;
    public Sprite[] bubbleSprites;
    public Color[] bubbleColors;
    public AnimationCurve bubbleCurve;


    public Transform textTransform;
    public SpriteRenderer text;
    public Sprite[] textSprites;
    public Color[] textColors;
    public AnimationCurve textCurve;

    
    private float _timePassed = 0;

        // Start is called before the first frame update
    void Start()
    {
        //Get random color from bubbleColors
        var random = new SystemRandom();
        
        //colors
        var randomIndex = random.Next(0, bubbleColors.Length);
        bubble.color = bubbleColors[randomIndex];
        text.color = textColors[randomIndex];
        
        //sprites
        randomIndex = random.Next(0, bubbleSprites.Length);
        bubble.sprite = bubbleSprites[randomIndex];
        randomIndex = random.Next(0, textSprites.Length);
        text.sprite = textSprites[randomIndex];

        bubbleTransform.localScale = new Vector3(0, 0, 0);
        bubbleTransform.localRotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-20f, 20f));

        textTransform.localScale = new Vector3(0, 0, 0);
        textTransform.localRotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-10f, 10f));

    }

    // Update is called once per frame
    void Update()
    {
        _timePassed += Time.deltaTime;

        float bubbleSize = bubbleCurve.Evaluate(_timePassed);
        bubbleTransform.localScale = new Vector3(bubbleSize, bubbleSize, bubbleSize);

        float textSize = textCurve.Evaluate(_timePassed);
        textTransform.localScale = new Vector3(textSize, textSize, textSize);

        
        if (_timePassed > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
