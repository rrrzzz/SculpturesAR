
using UnityEngine;

public class DistanceFlowChanger : MonoBehaviour
{
    public Transform targetTransform;
    private Material _targetMat;
    
    private static readonly int FlowStrength = Shader.PropertyToID("_FlowStrength");
    private static readonly int HeightScale = Shader.PropertyToID("_HeightScale");

    private const float MinFlowStrength = 0f;
    private const float MaxFlowStrength = 1.5f;
    private const float MinHeightScale = 0f;
    private const float MaxHeightScale = 2f;
    private const float LargestDistance = 2f;
    private const float ClosestDistance = 0.3f;
    
    void Start()
    {
        _targetMat = targetTransform.GetComponentInChildren<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        var currentDist = Vector3.Distance(transform.position, targetTransform.position);
        var lerpValue = Mathf.InverseLerp(ClosestDistance, LargestDistance, currentDist);
        var flowStrength = Mathf.Lerp(MinFlowStrength, MaxFlowStrength, lerpValue);
        var heightScale = Mathf.Lerp(MinHeightScale, MaxHeightScale, lerpValue);

        _targetMat.SetFloat(FlowStrength, flowStrength);
        _targetMat.SetFloat(HeightScale, heightScale);
    }
}
