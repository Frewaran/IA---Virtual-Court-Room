using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Pooling;
using Photon.Pun;

/* [MULTIPLAYER]
 * Die Funktion XRSimpleNetworkInteractable wurde mit XRSimpleInteractable erweitert, damit man die Ursprungsklasse noch hat.
 * Hier wird nur eine PhotonView-Komponente mit hinzugefügt, weil die PhotonView-Komponente wichtig ist, damit jeder alles
 * im Raum sehen kann.
 */
public class XRSimpleNetworkInteractable : XRSimpleInteractable {
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start() {
        photonView = GetComponent<PhotonView>();
    }

    /* [Multiplayer]
     * Hier wird die Ownership eines Objektes angefragt. Wenn ein Spieler ein Object nutzt, dann kann ein anderer dieses Objekt nicht nutzen,
     * bis die Ownership angefragt wird.
     */
    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor) {
        photonView.RequestOwnership();
    }
}
