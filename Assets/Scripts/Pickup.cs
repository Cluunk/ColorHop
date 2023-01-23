using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pickup : MonoBehaviour
{
    [SerializeField] private float timerIncreaseAmount;
    [SerializeField] private AudioObject audioObj;
    [SerializeField] private ColorObject colorObject;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != GameManager.Instance.CurrentLevel.Player.gameObject)
            return;
        
        GameManager.Instance.CurrentLevel.Clock.IncreaseTimer(timerIncreaseAmount);
        if (colorObject)
            GameManager.Instance.CurrentLevel.ColorObjectManager.RemoveObject(colorObject);
        if (audioObj)
            Instantiate(audioObj, transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}