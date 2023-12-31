using UnityEngine;
using Utils;

namespace GhostNirvana {

public partial class ApplianceMass : PossessableAgent<StandardMovementInput> {

    [SerializeField] MovableAgentRuntimeSet allEnemies;
    [SerializeField] float acceleration;
    [SerializeField] float movementSpeed;

    protected override void Awake() {
        base.Awake();
    }

    protected override void OnEnable() {
        base.OnEnable();
        allEnemies.Add(this);
    }

    protected void OnDisable() {
        allEnemies.Remove(this);
    }

    protected void Update() => PerformUpdate(InnerUpdate);

    void InnerUpdate() {
        Vector3 desiredVelocity = input.desiredMovement * movementSpeed;

        Velocity = Mathx.AccelerateTowards(
            currentVelocity: Velocity,
            desiredVelocity,
            acceleration,
            movementSpeed,
            Time.deltaTime
        );
    }
}

}
