using UnityEngine;
using TMPro;
using UnityEditor;
using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class CombatDebugMenuManager : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField _searchField;

	[SerializeField]
	private TMP_Dropdown _fileDropdown;

	[SerializeField]
	private Button _playButton;

	[SerializeField]
	private Button _stopButton;

	[SerializeField]
	private Button _refreshButton;

	[SerializeField]
	private CombatManager _combatManager;

	[SerializeField]
	private TextMeshProUGUI _label;

	[SerializeField]
	private TextMeshProUGUI _fileDisplay;

	private string[] _xmlPatterns = new string[0];

	private string[] _sortedPatterns = new string[0];

	private string _selectedFile = "";

	private void OnEnable()
	{
		_fileDropdown.Hide();

		_playButton.onClick.AddListener(PlayClicked);
		_stopButton.onClick.AddListener(StopClicked);
		_refreshButton.onClick.AddListener(RefreshClicked);
	}

	// buttons
	private void PlayClicked()
	{
		if (_selectedFile == "") return;

		_combatManager.StartPattern(_selectedFile);
	}

	private void StopClicked()
	{
		_combatManager.StopPattern();
	}

	private void RefreshClicked()
	{
		AssetDatabase.Refresh();

		_combatManager.StopPattern();
	}

	// begin search
	public void OnInputSelected(string value)
	{
		_searchField.text = "";

		AssetDatabase.Refresh();

		string[] files = Directory.GetFiles("Assets/BattleData/Patterns");

		_xmlPatterns = files.Where(s => s.Substring(s.Length - 3) == "xml").ToArray();
		_sortedPatterns = _xmlPatterns;

		UpdateDropdown();
	}

	// sort
	public void OnInputUpdated(string value)
	{
		_sortedPatterns = _xmlPatterns.Where(x => x.Contains(value)).OrderBy(x => x.IndexOf(value)).ToArray();

		UpdateDropdown();

		_selectedFile = "Assets/BattleData/Patterns/" + _label.text;
		_fileDisplay.text = $"Loaded File: {_selectedFile}";
	}

	// dropdown clicked
	public void OnFileSelected(Int32 choice)
	{
		_fileDropdown.Hide();

		
	}

	// display sorted files
	private void UpdateDropdown()
	{
		List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();

		foreach(string xml in  _sortedPatterns)
		{
			TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData(xml.Substring(27));
			newOptions.Add(data);
		}

		_fileDropdown.options = newOptions;
		_fileDropdown.RefreshShownValue();
		_fileDropdown.Show();
	}
}
