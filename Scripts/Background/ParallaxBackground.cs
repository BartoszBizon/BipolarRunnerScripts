using System;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private List<BackgroundLayersGroup> backgroundLayersGroups;

    
    [Serializable]
    public class BackgroundLayersGroup
    {
        [SerializeField] private float speedMultiplier;
        public float SpeedMultiplier => speedMultiplier;

        [SerializeField] private List<BackgroundLayer> layers;
        public List<BackgroundLayer> Layers => layers;

    }
    private void Update()
    {
        var mainCameraPosition = CameraMovementController.Instance.CameraTransform.position;
        
        foreach (var backgroundLayersGroup in backgroundLayersGroups)
        {                
            var positionModifier = backgroundLayersGroup.SpeedMultiplier;
            foreach (var layer in backgroundLayersGroup.Layers)
            {
                var temporaryDistance = mainCameraPosition.x * (1 - positionModifier);
                var distance = mainCameraPosition.x * positionModifier;
                var layerTransform = layer.transform;

                layerTransform.position = new Vector2(layer.StartPosition + distance, layerTransform.position.y);
                
                if (temporaryDistance > layer.StartPosition + layer.SpriteLength * 1.5f)
                {
                    layer.IncreaseStartPositionByLength();
                }
                

            }
        }
    }
}
