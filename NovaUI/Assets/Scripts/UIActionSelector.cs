using Nova;
using TigerFrogGames;
using UnityEngine;

public class UIActionSelector : MonoBehaviour
{
    
        public GestureRecognizer TriggerRegion = null;
        [SerializeField] private GameObject innerBoarder, outerBoarder, actionButton;

        [SerializeField] private UIBlock TooltipVisual;

        [SerializeField] private EventChannel OnAnotherButtonSelected;
            
            
        public void OnEnable()
        {
            OnAnotherButtonSelected.OnEvent += RemoveSelected;
            
            if (TooltipVisual != null)
            {
                // Make sure to start disabled
                TooltipVisual.gameObject.SetActive(false);
            }

            if (TriggerRegion == null)
            {
                // Can't subscribe to gesture events
                return;
            }

            // Subscribe to desired gestures
            TriggerRegion.UIBlock.AddGestureHandler<Gesture.OnClick>(ShowSelected);
            
            TriggerRegion.UIBlock.AddGestureHandler<Gesture.OnHover>(ShowTooltip);
            TriggerRegion.UIBlock.AddGestureHandler<Gesture.OnUnhover>(HideTooltip);
        }

    
        public void OnDisable()
        {
            OnAnotherButtonSelected.OnEvent -= RemoveSelected;
            
            if (TriggerRegion == null)
            {
                // Can't unsubscribe from gesture events
                return;
            }

            // Unsubscribe from gestures
            TriggerRegion.UIBlock.RemoveGestureHandler<Gesture.OnClick>(ShowSelected);
            
            TriggerRegion.UIBlock.RemoveGestureHandler<Gesture.OnHover>(ShowTooltip);
            TriggerRegion.UIBlock.RemoveGestureHandler<Gesture.OnUnhover>(HideTooltip);

        }
        
        
        private void ShowTooltip(Gesture.OnHover evt)
        {
            if (TooltipVisual == null)
            {
                // Nothing to show
                return;
            }

            TooltipVisual.gameObject.SetActive(true);

            TooltipVisual.CalculateLayout();
        }
        
        private void HideTooltip(Gesture.OnUnhover evt)
        {
            if (TooltipVisual == null)
            {
                // Nothing to hide
                return;
            }

            TooltipVisual.gameObject.SetActive(false);
        }
        
        
        private void ShowSelected(Gesture.OnClick InternalEvt)
        {
            innerBoarder.SetActive(true);
            outerBoarder.SetActive(true);
            actionButton.SetActive(true);
            
            OnAnotherButtonSelected.RaiseEvent(this.gameObject);
        }
        
        private void RemoveSelected(GameObject g)
        {
            if(this.gameObject == g) return;
            
            innerBoarder.SetActive(false);
            outerBoarder.SetActive(false);
            actionButton.SetActive(false);
        }
}
