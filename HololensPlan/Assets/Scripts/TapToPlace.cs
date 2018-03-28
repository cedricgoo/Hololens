using UnityEngine;
using UnityEngine.XR.WSA;
using UnityEngine.XR.WSA.Persistence;
public class TapToPlace : MonoBehaviour
{

    [Tooltip("Supply a friendly name for the anchor as the key name for the WorldAnchorStore.")]
    public string SavedAnchorFriendlyName = "SavedAnchorFriendlyName";

    /// <summary>
    /// Keeps track of anchors stored on local device.
    /// </summary>
    WorldAnchorStore anchorStore = null;

    /// <summary>
    /// Locally saved wold anchor.
    /// </summary>
    WorldAnchor savedAnchor;

    bool placing = false;
    void Start()
    {
        WorldAnchorStore.GetAsync(AnchorStoreReady);
    }

    /// <summary>
    /// Called when the local anchor store is ready.
    /// </summary>
    /// <param name="store"></param>
    void AnchorStoreReady(WorldAnchorStore store)
    {
        anchorStore = store;

        // Try to load a previously saved world anchor.
        savedAnchor = anchorStore.Load(SavedAnchorFriendlyName, gameObject);
        if (savedAnchor == null)
        {
            // Either world anchor was not saved / does not exist or has a different name.
            Debug.Log(gameObject.name + " : " + "World anchor could not be loaded for this game object. Creating a new anchor.");

            // Create anchor since one does not exist.
            CreateAnchor();
        }
        else
        {
            Debug.Log(gameObject.name + " : " + "World anchor loaded from anchor store and updated for this game object.");
        }
    }
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        if (SpatialMapping.Instance != null)
        {
            // On each tap gesture, toggle whether the user is in placing mode.
            placing = !placing;

            // If the user is in placing mode, display the spatial mapping mesh.
            if (placing)
            {
                SpatialMapping.Instance.DrawVisualMeshes = true;

                Debug.Log(gameObject.name + " : " + "Removing existing world anchor if any.");

                // Remove existing world anchor when moving an object.
                DestroyImmediate(gameObject.GetComponent<WorldAnchor>());

                // Delete existing world anchor from anchor store when moving an object.                    
                anchorStore.Delete(SavedAnchorFriendlyName);
            }
            // If the user is not in placing mode, hide the spatial mapping mesh.
            else
            {
                SpatialMapping.Instance.DrawVisualMeshes = false;

                // Add world anchor when object placement is done.
                CreateAnchor();
            }
        }
        else
        {
            Debug.Log("TapToPlace requires spatial mapping.  Try adding SpatialMapping prefab to project.");
        }
    }

    private void CreateAnchor()
    {
        // NOTE: It's good practice to ensure your parent hierarchy or root game object does not already have a World Anchor.
        // You can handle this in a way that works best for your application.
        // For example: gameObject.transform.root.GetComponent<WorldAnchor>();

        // Add the world anchor component when done moving an object.
        WorldAnchor anchor = gameObject.AddComponent<WorldAnchor>();
        if (anchor.isLocated)
        {
            SaveAnchor(anchor);
        }
        else
        {
            anchor.OnTrackingChanged += Anchor_OnTrackingChanged;
        }
    }

    private void SaveAnchor(WorldAnchor anchor)
    {
        // Save the anchor to persist holograms across sessions.
        if (anchorStore.Save(SavedAnchorFriendlyName, anchor))
        {
            Debug.Log(gameObject.name + " : " + "World anchor saved successfully.");
        }
        else
        {
            Debug.LogError(gameObject.name + " : " + "World anchor save failed.");
        }
    }

    private void Anchor_OnTrackingChanged(WorldAnchor self, bool located)
    {
        if (located)
        {
            Debug.Log(gameObject.name + " : " + "World anchor located successfully.");

            SaveAnchor(self);
            self.OnTrackingChanged -= Anchor_OnTrackingChanged;
        }
        else
        {
            Debug.LogError(gameObject.name + " : " + "World anchor failed to locate.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (placing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                // Move this object's parent object to
                // where the raycast hit the Spatial Mapping mesh.
                //this.transform.parent.position = hitInfo.point;

                //bouge que cet objet
                this.transform.position = hitInfo.point;

                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;

                this.transform.rotation = toQuat;
                //this.transform.parent.rotation = toQuat;
            }
        }
    }
}
