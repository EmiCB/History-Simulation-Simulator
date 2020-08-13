// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace EmiCB.Inputs
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""39fea8f8-7f27-43d7-901b-d7234641b04b"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""9da6cfdc-37f6-47c9-b971-aff8f0479686"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""de11c2b4-a1bd-4d4f-ae3c-0fbeb4865388"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Journal"",
                    ""type"": ""Button"",
                    ""id"": ""e43106c8-4032-4536-850e-9af74a454d7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Chat"",
                    ""type"": ""Button"",
                    ""id"": ""3ada489d-6828-4b4e-994e-64e685fbdb2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ExitInfoScreen"",
                    ""type"": ""Button"",
                    ""id"": ""4323ce4d-4997-4404-aa27-da7f83a6804e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""017cec5c-bb41-4458-a88e-16ccf38c214e"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""36e4d26e-0f93-4b14-95b2-418dd03cd4bf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7eab9d90-301d-4394-a8f8-952238dfd035"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""79b9d4de-7af3-4c80-b888-4f83a014ded5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""534516b0-6987-4d49-bd79-f86820702904"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b65ca29b-9dfa-41ff-ba0b-c43d7017ef1c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""03bc07a6-d77d-4c83-a192-b5b4a483a672"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Toggle Journal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f26d64fe-cf65-41b5-b293-9b7cd099ac48"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""Toggle Chat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0a92bab-4e53-4bea-a9ba-59b8866b72a7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard & Mouse"",
                    ""action"": ""ExitInfoScreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard & Mouse"",
            ""bindingGroup"": ""Keyboard & Mouse"",
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
        }
    ]
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
            m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
            m_Player_ToggleJournal = m_Player.FindAction("Toggle Journal", throwIfNotFound: true);
            m_Player_ToggleChat = m_Player.FindAction("Toggle Chat", throwIfNotFound: true);
            m_Player_ExitInfoScreen = m_Player.FindAction("ExitInfoScreen", throwIfNotFound: true);
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
        private readonly InputAction m_Player_Look;
        private readonly InputAction m_Player_Move;
        private readonly InputAction m_Player_ToggleJournal;
        private readonly InputAction m_Player_ToggleChat;
        private readonly InputAction m_Player_ExitInfoScreen;
        public struct PlayerActions
        {
            private @Controls m_Wrapper;
            public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_Player_Look;
            public InputAction @Move => m_Wrapper.m_Player_Move;
            public InputAction @ToggleJournal => m_Wrapper.m_Player_ToggleJournal;
            public InputAction @ToggleChat => m_Wrapper.m_Player_ToggleChat;
            public InputAction @ExitInfoScreen => m_Wrapper.m_Player_ExitInfoScreen;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                    @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                    @ToggleJournal.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleJournal;
                    @ToggleJournal.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleJournal;
                    @ToggleJournal.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleJournal;
                    @ToggleChat.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleChat;
                    @ToggleChat.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleChat;
                    @ToggleChat.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleChat;
                    @ExitInfoScreen.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitInfoScreen;
                    @ExitInfoScreen.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitInfoScreen;
                    @ExitInfoScreen.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitInfoScreen;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Look.started += instance.OnLook;
                    @Look.performed += instance.OnLook;
                    @Look.canceled += instance.OnLook;
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @ToggleJournal.started += instance.OnToggleJournal;
                    @ToggleJournal.performed += instance.OnToggleJournal;
                    @ToggleJournal.canceled += instance.OnToggleJournal;
                    @ToggleChat.started += instance.OnToggleChat;
                    @ToggleChat.performed += instance.OnToggleChat;
                    @ToggleChat.canceled += instance.OnToggleChat;
                    @ExitInfoScreen.started += instance.OnExitInfoScreen;
                    @ExitInfoScreen.performed += instance.OnExitInfoScreen;
                    @ExitInfoScreen.canceled += instance.OnExitInfoScreen;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        private int m_KeyboardMouseSchemeIndex = -1;
        public InputControlScheme KeyboardMouseScheme
        {
            get
            {
                if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard & Mouse");
                return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
            }
        }
        public interface IPlayerActions
        {
            void OnLook(InputAction.CallbackContext context);
            void OnMove(InputAction.CallbackContext context);
            void OnToggleJournal(InputAction.CallbackContext context);
            void OnToggleChat(InputAction.CallbackContext context);
            void OnExitInfoScreen(InputAction.CallbackContext context);
        }
    }
}
