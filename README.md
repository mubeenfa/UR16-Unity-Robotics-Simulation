# UR16-Unity-Robotics-Simulation
Unity3D simulation of a UR16 robotic arm with six-joint control

# UR16 Unity Robotics Simulation

## Phase 1 — UR16 Model Integration & Joint Control

### Objective

Build a basic robotic-arm simulation in Unity and establish individual joint control using C#.

### Initial Prototype

The project initially used Unity 3D primitives to understand the fundamentals of a robotic-arm hierarchy.

The arm was structured as a serial chain:

```text
RobotArm
└── Joint 1
    └── Link 1
        └── Joint 2
            └── Link 2
                └── Joint 3
                    └── Link 3
                        └── Joint 4
```

Each joint was represented by a Unity `Transform`. Rotating a parent joint automatically moved all child links and joints.

The prototype was controlled through C#, with joint angles applied using Unity's local rotations.

### Transition to UR16

Once the primitive-based arm and joint-control system were working, the primitives were replaced with an imported UR16 model.

The existing UR16 model provided its own link hierarchy:

```text
UR16
└── Base
    └── Shoulder
        └── Elbow
            └── Wrist 1
                └── Wrist 2
                    └── Wrist 3
```

The controller was then adapted to use these existing transforms.

The hierarchy is mapped to the six robot joints as follows:

```text
Base       → J1
Shoulder   → J2
Elbow      → J3
Wrist 1    → J4
Wrist 2    → J5
Wrist 3    → J6
```

Because the imported model uses its own local coordinate orientations, the joint rotations were adjusted to match the model's axes. For example, the shoulder uses a rotational offset:

```csharp
shoulderJoint.localRotation =
    Quaternion.Euler(-90f, shoulderAngle, 0f);
```

### Joint Control

The controller maintains an angle for each of the six joints:

```csharp
j1Angle
j2Angle
j3Angle
j4Angle
j5Angle
j6Angle
```

These angles are applied to the corresponding UR16 transforms.

Joint limits are also enforced using `Mathf.Clamp()`.

Current configured limits:

```text
J1: -180° → 180°
J2:    0° → 180°
J3: -135° → 135°
J4: -180° → 180°
J5: -180° → 180°
J6: -180° → 180°
```

### Phase 1 Result

Phase 1 successfully established:

* UR16 model integration into Unity
* Correct six-joint hierarchy
* Individual control of J1–J6
* Joint-angle variables
* Model-specific rotation mappings
* Configurable joint limits
* Basic keyboard-based joint control

The UR16 can now be manipulated through its individual joint angles inside Unity.
