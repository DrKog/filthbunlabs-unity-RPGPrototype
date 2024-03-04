
using DialogueEditor;
using UnityEngine;

public class ConversationStarter : MonoBehaviour
{
    [SerializeField] private NPCConversation myConversation;

    private bool playerInRange = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Something new");
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

}
