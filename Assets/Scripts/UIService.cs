using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIService : MonoBehaviour
{

   private List<Employee> _employees;


   [SerializeField] private TextMeshProUGUI _cwZone;
   

   [SerializeField] private GameObject _startMenu;
   [SerializeField] private GameObject _createMenu;
   [SerializeField] private GameObject _deleteMenu;

   [Header("InputField")]

   [SerializeField] private InputField _organization;
   [SerializeField] private InputField _salary;
   [SerializeField] private InputField _experience;
   [SerializeField] private InputField _deleteIndex;
   

   [Header("Button")]

   [SerializeField] private Button _createButton;
   [SerializeField] private Button _enterToDeleteMenuButton;
   [SerializeField] private Button _writelineButton;
   [SerializeField] private Button _createEmployeeButton;
   [SerializeField] private Button _backToStartMenuCreateMenuButton;
   [SerializeField] private Button _deleteEmployeeButton;
   [SerializeField] private Button _deleteAllEmployeeButton;
   [SerializeField] private Button _backToStartMenuDeleteMenu;

   private void Awake()
   {
      _createButton.onClick.AddListener(CreatePersonButton);
      _enterToDeleteMenuButton.onClick.AddListener(EnterToMenuDeleteButton);
      _writelineButton.onClick.AddListener(WritelinePersonButton);
      _createEmployeeButton.onClick.AddListener(CreateEmployeeButton);
      _backToStartMenuCreateMenuButton.onClick.AddListener(BackToStartMenuButton);
      _deleteEmployeeButton.onClick.AddListener(DeleteEmployeeButton);
      _deleteAllEmployeeButton.onClick.AddListener(DeleteAllEmployeeButton);
      _backToStartMenuDeleteMenu.onClick.AddListener(BackToStartMenuDeleteMenu);
   }

   private void BackToStartMenuDeleteMenu()
   {
      _deleteMenu.SetActive(false);
      _startMenu.SetActive(true);
   }

   private void DeleteAllEmployeeButton()
   {
      _employees.Clear();
   }

   private void DeleteEmployeeButton()
   {
    
      int index = Convert.ToInt32(_deleteIndex.text);
      _employees.RemoveAt(index);
   }

   private void Start()
   {
      _deleteMenu.SetActive(false);
      _createMenu.SetActive(false);
      _startMenu.SetActive(true);
      _employees = new List<Employee>();
   }

   private void BackToStartMenuButton()
   {
      _createMenu.SetActive(false);
      _startMenu.SetActive(true);
   }

   private void CreateEmployeeButton()
   {
     _employees.Add(new Employee(_organization.text, Convert.ToInt32(_salary.text), Convert.ToInt32(_experience.text)));
   }

   private void WritelinePersonButton()
   {
      if (_employees.Count == 0)
      {
         _cwZone.text = "List empty";
      }
      
      foreach (var employee in _employees)
      {
         _cwZone.text = employee.Information();
      }
   }

   private void EnterToMenuDeleteButton()
   {
      _startMenu.SetActive(false);
      _deleteMenu.SetActive(true);
   }

   private void CreatePersonButton()
   {
      _startMenu.SetActive(false);
      _createMenu.SetActive(true);
   }
   
   
   
   //int index = Convert.ToInt32(_deleteIndex.text);
   //_employees.RemoveAt(index);
}
