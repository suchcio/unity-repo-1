// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Inputs/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""268a09b0-7269-4777-ba1b-681f6c5f4459"",
            ""actions"": [
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""c38fe7a5-671e-4beb-a425-f0877158b6a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7dd9d5be-4a9e-4636-975b-f5a361e5d71a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item1"",
                    ""type"": ""Button"",
                    ""id"": ""b13bf1c6-74f2-483c-9a63-3fea1a3f498a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item2"",
                    ""type"": ""Button"",
                    ""id"": ""31a4d680-7d98-4702-873d-a1d4961296f5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item3"",
                    ""type"": ""Button"",
                    ""id"": ""3e237683-fbd9-4182-8717-4276f4ac9b8b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item4"",
                    ""type"": ""Button"",
                    ""id"": ""450919ed-dbea-4e00-8204-cbcd7f867d25"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item5"",
                    ""type"": ""Button"",
                    ""id"": ""2df31b79-5018-47b0-abaa-84f6ea15ec05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""5d18466a-5941-4314-bcbe-f96ec74e8904"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""66178e2d-79bd-44d9-8f00-05c474c76d9b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HoldWalk"",
                    ""type"": ""Button"",
                    ""id"": ""39a39e4a-0622-4e85-ba38-5e7553b95a1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PressRelease"",
                    ""type"": ""Button"",
                    ""id"": ""b1948746-8d50-43cf-b2a8-f5fdfc695f00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HoldInteract"",
                    ""type"": ""Button"",
                    ""id"": ""73fb4fd6-f4ee-4283-b0d2-0b18f5c0b2db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""85d668f0-c80a-4b96-849c-fb8d3d167be3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""93ccc32f-1c28-42a6-9dde-7e5a059b9c90"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""499e138f-deaa-4835-8f2e-13a0b0df2a8a"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ae1b9e4-5c04-4de5-af03-3c6605af396a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8469189f-0b39-4cae-80b5-eb653cfd058b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""69edc5c7-7adc-4314-95e7-1b4be4c88324"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""da9cbfc7-4bc4-4c8f-919d-49cf9c6f5467"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82d95c97-7c27-4e04-afa2-5466276b4aff"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Item1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""783a43dd-0367-4eb8-acd2-48faa48446a8"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa0ae18c-a69c-48f1-ad30-c0890bd08d1b"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""540f3128-bd08-4b13-b870-ed27b80cdf23"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c8b4de7-14fa-4e0b-a42f-8d0d6aff8224"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14c21832-8b64-4675-8275-01c04c262d94"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75c96855-0c30-4844-b625-8f94b82d4b5a"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1321e0c9-cccc-43b0-9640-2e80e1e44195"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""HoldWalk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac0e1f82-d6da-40e2-9758-2f37d11d27af"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75bfb5f3-7cd6-4e43-a9e7-f7b4d44218bc"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""HoldInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""6d7aafda-c980-4648-b425-9dbe9a93a1da"",
            ""actions"": [
                {
                    ""name"": ""CLICK"",
                    ""type"": ""Button"",
                    ""id"": ""8713b644-ab5c-46a5-90ba-a1354c5ff3f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""081ab51a-862b-4625-a88a-92ff9be6f51f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CLICK"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Walk = m_Player.FindAction("Walk", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Item1 = m_Player.FindAction("Item1", throwIfNotFound: true);
        m_Player_Item2 = m_Player.FindAction("Item2", throwIfNotFound: true);
        m_Player_Item3 = m_Player.FindAction("Item3", throwIfNotFound: true);
        m_Player_Item4 = m_Player.FindAction("Item4", throwIfNotFound: true);
        m_Player_Item5 = m_Player.FindAction("Item5", throwIfNotFound: true);
        m_Player_Cancel = m_Player.FindAction("Cancel", throwIfNotFound: true);
        m_Player_Inventory = m_Player.FindAction("Inventory", throwIfNotFound: true);
        m_Player_HoldWalk = m_Player.FindAction("HoldWalk", throwIfNotFound: true);
        m_Player_PressRelease = m_Player.FindAction("PressRelease", throwIfNotFound: true);
        m_Player_HoldInteract = m_Player.FindAction("HoldInteract", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_CLICK = m_UI.FindAction("CLICK", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Walk;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Item1;
    private readonly InputAction m_Player_Item2;
    private readonly InputAction m_Player_Item3;
    private readonly InputAction m_Player_Item4;
    private readonly InputAction m_Player_Item5;
    private readonly InputAction m_Player_Cancel;
    private readonly InputAction m_Player_Inventory;
    private readonly InputAction m_Player_HoldWalk;
    private readonly InputAction m_Player_PressRelease;
    private readonly InputAction m_Player_HoldInteract;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walk => m_Wrapper.m_Player_Walk;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Item1 => m_Wrapper.m_Player_Item1;
        public InputAction @Item2 => m_Wrapper.m_Player_Item2;
        public InputAction @Item3 => m_Wrapper.m_Player_Item3;
        public InputAction @Item4 => m_Wrapper.m_Player_Item4;
        public InputAction @Item5 => m_Wrapper.m_Player_Item5;
        public InputAction @Cancel => m_Wrapper.m_Player_Cancel;
        public InputAction @Inventory => m_Wrapper.m_Player_Inventory;
        public InputAction @HoldWalk => m_Wrapper.m_Player_HoldWalk;
        public InputAction @PressRelease => m_Wrapper.m_Player_PressRelease;
        public InputAction @HoldInteract => m_Wrapper.m_Player_HoldInteract;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Walk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnWalk;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Item1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem1;
                @Item2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem2;
                @Item3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @Item3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @Item3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem3;
                @Item4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem4;
                @Item4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem4;
                @Item4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem4;
                @Item5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem5;
                @Item5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem5;
                @Item5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItem5;
                @Cancel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancel;
                @Inventory.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventory;
                @HoldWalk.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldWalk;
                @HoldWalk.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldWalk;
                @HoldWalk.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldWalk;
                @PressRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressRelease;
                @PressRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressRelease;
                @PressRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressRelease;
                @HoldInteract.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldInteract;
                @HoldInteract.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldInteract;
                @HoldInteract.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHoldInteract;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Item1.started += instance.OnItem1;
                @Item1.performed += instance.OnItem1;
                @Item1.canceled += instance.OnItem1;
                @Item2.started += instance.OnItem2;
                @Item2.performed += instance.OnItem2;
                @Item2.canceled += instance.OnItem2;
                @Item3.started += instance.OnItem3;
                @Item3.performed += instance.OnItem3;
                @Item3.canceled += instance.OnItem3;
                @Item4.started += instance.OnItem4;
                @Item4.performed += instance.OnItem4;
                @Item4.canceled += instance.OnItem4;
                @Item5.started += instance.OnItem5;
                @Item5.performed += instance.OnItem5;
                @Item5.canceled += instance.OnItem5;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @HoldWalk.started += instance.OnHoldWalk;
                @HoldWalk.performed += instance.OnHoldWalk;
                @HoldWalk.canceled += instance.OnHoldWalk;
                @PressRelease.started += instance.OnPressRelease;
                @PressRelease.performed += instance.OnPressRelease;
                @PressRelease.canceled += instance.OnPressRelease;
                @HoldInteract.started += instance.OnHoldInteract;
                @HoldInteract.performed += instance.OnHoldInteract;
                @HoldInteract.canceled += instance.OnHoldInteract;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_CLICK;
    public struct UIActions
    {
        private @InputMaster m_Wrapper;
        public UIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @CLICK => m_Wrapper.m_UI_CLICK;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @CLICK.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCLICK;
                @CLICK.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCLICK;
                @CLICK.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCLICK;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CLICK.started += instance.OnCLICK;
                @CLICK.performed += instance.OnCLICK;
                @CLICK.canceled += instance.OnCLICK;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnWalk(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnItem1(InputAction.CallbackContext context);
        void OnItem2(InputAction.CallbackContext context);
        void OnItem3(InputAction.CallbackContext context);
        void OnItem4(InputAction.CallbackContext context);
        void OnItem5(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnHoldWalk(InputAction.CallbackContext context);
        void OnPressRelease(InputAction.CallbackContext context);
        void OnHoldInteract(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnCLICK(InputAction.CallbackContext context);
    }
}
