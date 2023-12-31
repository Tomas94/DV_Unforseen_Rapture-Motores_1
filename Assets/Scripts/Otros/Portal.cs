using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public Sprite portalOpen;
    SpriteRenderer _sRenderer;
    
    public string scene;

    public int buttonsNeeded;
    public int buttonCount;
    public bool activated;

    void Start()
    {
        _sRenderer = GetComponent<SpriteRenderer>();
        activated = false;
    }

    void Update()
    {
        ActivatePortal();

        if (Input.GetKeyDown(KeyCode.K)) buttonCount++;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (activated && Input.GetKeyDown(KeyCode.W))
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
    void ActivatePortal()
    {
        if (buttonCount >= buttonsNeeded)
        {
            activated = true;
            _sRenderer.sprite = portalOpen;
        }
    }
}
