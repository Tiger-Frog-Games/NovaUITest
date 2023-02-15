using System;
using System.Collections.Generic;
using Nova;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TigerFrogGames
{
    public class MouseClicker : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Camera cam;
        
        [SerializeField] private InputActionAsset playerInput;

        [SerializeField] private EventChannelBasic OnUnitNotSelected;

        [SerializeField] private LayerMask uiMask;
        
        private InputAction _mouseLeftClick, _mouseRightClick;

        #endregion

        #region Unity Methods

        private void OnEnable() {
            playerInput.Enable();
        }

        private void OnDisable() {
            playerInput.Disable();
        }
        
        private void Awake()
        {
            if (playerInput == null)
            {
                return;
            }

            _mouseLeftClick = playerInput.FindAction("LeftClick");
            _mouseLeftClick.performed += MouseLeftClickOnPerformed;
            
            _mouseRightClick = playerInput.FindAction("RightClick");
            _mouseRightClick.performed += MouseRightClickOnPerformed ;
        }
        
        private void OnDestroy()
        {
            if (_mouseLeftClick != null)
            {
                _mouseLeftClick.performed -= MouseLeftClickOnPerformed;
            }
            
            if (_mouseRightClick != null)
            {
                _mouseRightClick.performed -= MouseRightClickOnPerformed;
            }
        }

        #endregion

        #region Methods

        private void MouseLeftClickOnPerformed(InputAction.CallbackContext obj)
        {
            //print("Mouse has been left clicked");
            
            RaycastHit hit; 
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            if (Physics.Raycast(cam.ScreenPointToRay(mousePosition), out hit)) 
            {
                hit.collider.GetComponent<IClickable>()?.OnClick();

                if(IsMouseOverUi()) return;
                
                if (!hit.transform.TryGetComponent(out Unit u))
                {
                    OnUnitNotSelected.RaiseEvent();
                }
            }
            
        }
        
        private void MouseRightClickOnPerformed(InputAction.CallbackContext obj)
        {
            //print("Mouse has been right clicked");
            RaycastHit hit; 
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            if (Physics.Raycast(cam.ScreenPointToRay(mousePosition), out hit)) 
            {
                hit.collider.GetComponent<IClickable>()?.OnClick();
            }
        }
        
        public bool IsMouseOverUi()
        {
            // NameToLayer returns the index of the queried layer
            int layerIndex = LayerMask.NameToLayer("UI");
    
            // GetMask returns the layer as a bitmask
            int layerMask = LayerMask.GetMask("UI");        
    
            // Alternatively, you can convert layerIndex to a bitmask by bit-shifting.
            // layerMaskFromIndex will equal layerMask
            int layerMaskFromIndex = 1 << layerIndex;
            
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            var hits = new List<UIBlockHit>();
            
            Interaction.RaycastAll(ray, hits, Single.PositiveInfinity, layerMask);
            
            return hits.Count > 0;
        }
        
        #endregion
    }
    
}