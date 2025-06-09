using UnityEngine;
using TMPro;
using UnityEditor;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;

public class CombatDebugMenuManager : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _searchField;

	[SerializeField]
	private TMP_Dropdown _fileDropdown;

	[SerializeField]
	private CombatManager _combatManager;

	private string[] _xmlPatterns = new string[0];

	private void OnEnable()
	{
		
	}

	public void OnInputSelected(string value)
	{
		_fileDropdown.enabled = true;

		AssetDatabase.Refresh();

		string[] files = Directory.GetFiles("Assets/Patterns");

		_xmlPatterns = files.Where(s => s.Substring(s.Length - 3) == "xml").ToArray();

		UpdateDropdown();
	}

	public void OnInputUpdated(string value)
	{

	}

	private void UpdateDropdown()
	{
		List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();

		foreach(string xml in  _xmlPatterns)
		{
			TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData(xml.Substring(16));
			newOptions.Add(data);
		}

		_fileDropdown.options = newOptions;
		_fileDropdown.Show();
	}

	private void Update()
	{
		
	}
}
