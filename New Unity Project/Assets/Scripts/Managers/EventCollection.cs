using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCollection : MonoBehaviour {

    public UnityAction bornListener;
    public UnityAction lifeListener;
    public UnityAction deathListener;
    public UnityAction attackListener;
    public UnityAction damageListener;
    // Use this for initialization
    void Awake () {
        bornListener = new UnityAction(MinionSpawned);
        lifeListener = new UnityAction(MinionMovement);
        deathListener = new UnityAction(MinionDied);
        attackListener = new UnityAction(UnitAttacked);
        damageListener = new UnityAction(UnitDamaged);

        EventManager.StartListening("born", bornListener);
        EventManager.StartListening("life", bornListener);
        EventManager.StartListening("death", bornListener);
    }
   void MinionSpawned()
    {
    }

    void MinionDied()
    {
        
    }

    void MinionMovement()
    {
    }

    void UnitAttacked()
    {
    }

    void UnitDamaged()
    {

    }
}
