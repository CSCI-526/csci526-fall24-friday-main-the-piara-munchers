using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowFlipMessageTutorial : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Image backgroundImage;
    public bool collisionOccured = false;

    void Start()
    {
        if (GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>();
        }

        if (GetComponent<Rigidbody2D>() == null)
        {
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.isKinematic = true;
        }

        // Initially, hide the message text and background image
        messageText.enabled = false;
        backgroundImage.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collisionOccured && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision detected");
            ShowMessage();
            collisionOccured = true;
        }
    }

    void ShowMessage()
    {
        messageText.text = "Guess, you should flip the world!";
        backgroundImage.enabled = true;
        messageText.enabled = true;
        StartCoroutine(HideMessageAfterDelay());
    }

    IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(3);
        messageText.enabled = false;
        backgroundImage.enabled = false;
    }
}
