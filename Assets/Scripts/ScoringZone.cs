using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;
    public ParticleSystem particleSystem;
    public Ball ballEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ballEffect.SetRenderer(false);
            // ContactPoint2D contactPoint = collision.GetContact(0);
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
            // particleSystem.Play();
        }
    }
}
