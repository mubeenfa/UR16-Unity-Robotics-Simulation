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

The hierarchy is mapped to the six robot joints as follow:

```text
Base       → J1
Shoulder   → J2
Elbow      → J3
Wrist 1    → J4
Wrist 2    → J5
Wrist 3    → J6
```

Because the imported model uses its own local coordinate orientations, the joint rotations were adjusted to match the model's axes.

For example, the shoulder uses a rotational offset:

```csharp
shoulderJoint.localRotation =
    Quaternion.Euler(-90f, shoulderAngle, 0f);
```

### Joint Control

The controller maintains an angle for each of the six joints:

```text
j1Angle
j2Angle
j3Angle
j4Angle
j5Angle
j6Angle
```

These angles are applied to the corresponding UR16 transforms.

Joint limits are enforced using `Mathf.Clamp()`.

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
* Basic joint control

The UR16 can now be manipulated through its individual joint angles inside Unity.

---

# Phase 2 — Joint Control UI

### Objective

Add a graphical user interface that allows the UR16 joints to be controlled using Unity UI sliders.

### Slider Control

Six sliders were added to control the six UR16 joints:

```text
J1Slider
J2Slider
J3Slider
J4Slider
J5Slider
J6Slider
```

Each slider uses the configured joint limits:

```text
J1: -180° → 180°
J2:    0° → 180°
J3: -135° → 135°
J4: -180° → 180°
J5: -180° → 180°
J6: -180° → 180°
```

The slider values are connected to the corresponding joint-angle variables in `UR16Controller`.

The control flow is:

```text
UI Slider
    ↓
UR16UIController
    ↓
Joint Angle
    ↓
UR16Controller
    ↓
UR16 Model
```

### Joint Angle Display

A TextMeshPro label was added for each joint to display its current angle.

The UI displays:

```text
J1 → current angle
J2 → current angle
J3 → current angle
J4 → current angle
J5 → current angle
J6 → current angle
```

The values are updated as the sliders are moved.

### Home Button

A `HOME` button was added to return all joints to their zero position.

Home position:

```text
J1 = 0°
J2 = 0°
J3 = 0°
J4 = 0°
J5 = 0°
J6 = 0°
```

Pressing the button resets:

* Robot joint angles
* Slider positions
* Displayed angle values

### Phase 2 Result

Phase 2 successfully established:

* Unity-based control panel
* Six joint sliders
* Joint-limit-aware slider ranges
* Live joint-angle display
* HOME/RESET functionality
* Slider-based control of the UR16

The UR16 can now be controlled entirely through the Unity UI.

### Current Project Structure

```text
Assets
├── Scripts
│   ├── UR16Controller.cs
│   └── UR16UIController.cs
└── ...
```
