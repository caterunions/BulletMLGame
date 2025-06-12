using UnityEngine;

[CreateAssetMenu(fileName = "MaterialBank", menuName = "ScriptableObjects/MaterialBank")]
public class MaterialBank : ScriptableObject
{
	[SerializeField]
	private Material _neutralMaterial;
	[SerializeField]
	private Material _physMaterial;
	[SerializeField]
	private Material _fireMaterial;
	[SerializeField]
	private Material _iceMaterial;
	[SerializeField]
	private Material _elecMaterial;
	[SerializeField]
	private Material _windMaterial;
	[SerializeField]
	private Material _blessMaterial;
	[SerializeField]
	private Material _curseMaterial;

	public Material GetElementMaterial(ElementType elementType)
	{
		switch (elementType)
		{
			case ElementType.Neutral:
				{
					return _neutralMaterial;
				}
			case ElementType.Physical:
				{
					return _physMaterial;
				}
			case ElementType.Fire:
				{
					return _fireMaterial;
				}
			case ElementType.Ice:
				{
					return _iceMaterial;
				}
			case ElementType.Electric:
				{
					return _elecMaterial;
				}
			case ElementType.Wind:
				{
					return _windMaterial;
				}
			case ElementType.Bless:
				{
					return _blessMaterial;
				}
			case ElementType.Curse:
				{
					return _curseMaterial;
				}
		}

		return _neutralMaterial;
	}
}
