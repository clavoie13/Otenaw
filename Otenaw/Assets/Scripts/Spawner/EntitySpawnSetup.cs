using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

public class EntitySpawnSetup : Entity {

    [SerializeField]
    ToggleEvent onToggleEnabled;

    [SerializeField]
    ToggleEvent onToggleSpawn;

    public void InitializeEntity()
    {
        if(isServer)
        {
            Rewind MR = GetComponent<Rewind>();

            if (MR != null)
                MR.clearRewind();
        }

        onToggleEnabled.Invoke(true);
        isActive = true;
    }

    public void DisableEntity()
    {
        isActive = false;
        onToggleEnabled.Invoke(false);
        onToggleSpawn.Invoke(false);
        gameObject.transform.position = new Vector3(-50f, -50f, -50f);      
    }

    public void DisableTipiEntity()
    {
        isActive = false;
        onToggleEnabled.Invoke(false);
    }

    public void EnableSpawn()
    {
        onToggleSpawn.Invoke(true);
    }
}
