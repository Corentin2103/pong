using UnityEngine;
using UnityEngine.EventSystems;

public class ScoringZone : MonoBehaviour
{
    public EventTrigger.TriggerEvent scoreTrigger;
    public ParticleSystem particleSystem;
    public Ball ballEffect;
    public GameObject particule;
    // Get position of the collision and add the particules to this position, rotate when it's computer's goal
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        Vector3 pos = collision.transform.position;
                    
        if (ball != null)
        {
            
            if (pos.x > 5)
            {
                particule.transform.rotation = Quaternion.identity;
                particule.transform.Rotate(0.0f, 0.0f, 180.0f);
                if (pos.y + 1 > 4)
                {
                    particule.transform.position = new Vector3(0,4,transform.position.z);
                }else if (pos.y + 1 < -4)
                {
                    particule.transform.position = new Vector3(0,-4,transform.position.z);
                }
                else
                {
                    particule.transform.position = new Vector3(0,pos.y+1,transform.position.z);
                }                
                particleSystem.Play();
                
            }
            else if (pos.x < 5)
            {
                particule.transform.rotation = Quaternion.identity;
                if (pos.y + 1 > 4)
                {
                    particule.transform.position = new Vector3(0,4,transform.position.z);
                }else if (pos.y + 1 < -4)
                {
                    particule.transform.position = new Vector3(0,-4,transform.position.z);
                }
                else
                {
                    particule.transform.position = new Vector3(0,pos.y+1,transform.position.z);
                }
                particleSystem.Play();
            }
           
            ballEffect.SetRenderer(false);
            BaseEventData eventData = new BaseEventData(EventSystem.current);
            this.scoreTrigger.Invoke(eventData);
            
        }

        
    }
}
