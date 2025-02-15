
#region Copyright (c) 2015 KEngine / Kelly <http://github.com/mr-kelly>, All rights reserved.

// KEngine - Asset Bundle framework for Unity3D
// ===================================
// 
// Author:  Kelly
// Email: 23110388@qq.com
// Github: https://github.com/mr-kelly/KEngine
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3.0 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library.

#endregion

// This file is auto generated by SettingModuleEditor.cs!
// Don't manipulate me!
// Default Template for KEngine!

using System.Collections;
using System.Collections.Generic;
using KEngine;
using KEngine.Modules;
using TableML;
namespace AppSettings
{
	/// <summary>
    /// All settings list here, so you can reload all settings manully from the list.
	/// </summary>
    public partial class SettingsManager
    {
        private static IReloadableSettings[] _settingsList;
        public static IReloadableSettings[] SettingsList
        {
            get
            {
                if (_settingsList == null)
                {
                    _settingsList = new IReloadableSettings[]
                    { 
                        BillboardSettings._instance,
                        TestSettings._instance,
                        ZslSettings._instance,
                        GameConfigSettings._instance,
                    };
                }
                return _settingsList;
            }
        }

#if UNITY_EDITOR
        [UnityEditor.MenuItem("KEngine/Settings/Try Reload All Settings Code")]
#endif
	    public static void AllSettingsReload()
	    {
	        for (var i = 0; i < SettingsList.Length; i++)
	        {
	            var settings = SettingsList[i];
                if (settings.Count > 0 // if never reload, ignore
#if UNITY_EDITOR
                    || !UnityEditor.EditorApplication.isPlaying // in editor and not playing, force load!
#endif
                    )
                {
                    settings.ReloadAll();
                }

	        }
	    }

    }


	/// <summary>
	/// Auto Generate for Tab File: "Billboard.bytes"
    /// No use of generic and reflection, for better performance,  less IL code generating
	/// </summary>>
    public partial class BillboardSettings : IReloadableSettings
    {
        /// <summary>
        /// How many reload function load?
        /// </summary>>
        public static int ReloadCount { get; private set; }

		public static readonly string[] TabFilePaths = 
        {
            "Billboard.bytes"
        };
        internal static BillboardSettings _instance = new BillboardSettings();
        Dictionary<string, BillboardSetting> _dict = new Dictionary<string, BillboardSetting>();

        /// <summary>
        /// Trigger delegate when reload the Settings
        /// </summary>>
	    public static System.Action OnReload;

        /// <summary>
        /// Constructor, just reload(init)
        /// When Unity Editor mode, will watch the file modification and auto reload
        /// </summary>
	    private BillboardSettings()
	    {
        }

        /// <summary>
        /// Get the singleton
        /// </summary>
        /// <returns></returns>
	    public static BillboardSettings GetInstance()
	    {
            if (ReloadCount == 0)
            {
                _instance._ReloadAll(true);
    #if UNITY_EDITOR
                if (SettingModule.IsFileSystemMode)
                {
                    for (var j = 0; j < TabFilePaths.Length; j++)
                    {
                        var tabFilePath = TabFilePaths[j];
                        SettingModule.WatchSetting(tabFilePath, (path) =>
                        {
                            if (path.Replace("\\", "/").EndsWith(path))
                            {
                                _instance.ReloadAll();
                                Log.LogConsole_MultiThread("File Watcher! Reload success! -> " + path);
                            }
                        });
                    }

                }
    #endif
            }

	        return _instance;
	    }
        
        public int Count
        {
            get
            {
                return _dict.Count;
            }
        }

        /// <summary>
        /// Do reload the setting file: Billboard, no exception when duplicate primary key
        /// </summary>
        public void ReloadAll()
        {
            _ReloadAll(false);
        }

        /// <summary>
        /// Do reload the setting class : Billboard, no exception when duplicate primary key, use custom string content
        /// </summary>
        public void ReloadAllWithString(string context)
        {
            _ReloadAll(false, context);
        }

        /// <summary>
        /// Do reload the setting file: Billboard
        /// </summary>
	    void _ReloadAll(bool throwWhenDuplicatePrimaryKey, string customContent = null)
        {
            for (var j = 0; j < TabFilePaths.Length; j++)
            {
                var tabFilePath = TabFilePaths[j];
                TableFile tableFile;
                if (customContent == null)
                    tableFile = SettingModule.Get(tabFilePath, false);
                else
                    tableFile = TableFile.LoadFromString(customContent);

                using (tableFile)
                {
                    foreach (var row in tableFile)
                    {
                        var pk = BillboardSetting.ParsePrimaryKey(row);
                        BillboardSetting setting;
                        if (!_dict.TryGetValue(pk, out setting))
                        {
                            setting = new BillboardSetting(row);
                            _dict[setting.Id] = setting;
                        }
                        else 
                        {
                            if (throwWhenDuplicatePrimaryKey) throw new System.Exception(string.Format("DuplicateKey, Class: {0}, File: {1}, Key: {2}", this.GetType().Name, tabFilePath, pk));
                            else setting.Reload(row);
                        }
                    }
                }
            }

	        if (OnReload != null)
	        {
	            OnReload();
	        }

            ReloadCount++;
            Log.Info("Reload settings: {0}, Row Count: {1}, Reload Count: {2}", GetType(), Count, ReloadCount);
        }

	    /// <summary>
        /// foreachable enumerable: Billboard
        /// </summary>
        public static IEnumerable GetAll()
        {
            foreach (var row in GetInstance()._dict.Values)
            {
                yield return row;
            }
        }

        /// <summary>
        /// GetEnumerator for `MoveNext`: Billboard
        /// </summary> 
	    public static IEnumerator GetEnumerator()
	    {
	        return GetInstance()._dict.Values.GetEnumerator();
	    }
         
	    /// <summary>
        /// Get class by primary key: Billboard
        /// </summary>
        public static BillboardSetting Get(string primaryKey)
        {
            BillboardSetting setting;
            if (GetInstance()._dict.TryGetValue(primaryKey, out setting)) return setting;
            return null;
        }

        // ========= CustomExtraString begin ===========
        
        // ========= CustomExtraString end ===========
    }

	/// <summary>
	/// Auto Generate for Tab File: "Billboard.bytes"
    /// Singleton class for less memory use
	/// </summary>
	public partial class BillboardSetting : TableRowFieldParser
	{
		
        /// <summary>
        /// ID Column/编号/主键
        /// </summary>
        public string Id { get; private set;}
        
        /// <summary>
        /// 公告标题
        /// </summary>
        public string Title { get; private set;}
        
        /// <summary>
        /// 公告内容
        /// </summary>
        public string Content { get; private set;}
        

        internal BillboardSetting(TableFileRow row)
        {
            Reload(row);
        }

        internal void Reload(TableFileRow row)
        { 
            Id = row.Get_string(row.Values[0], ""); 
            Title = row.Get_string(row.Values[1], ""); 
            Content = row.Get_string(row.Values[2], ""); 
        }

        /// <summary>
        /// Get PrimaryKey from a table row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string ParsePrimaryKey(TableFileRow row)
        {
            var primaryKey = row.Get_string(row.Values[0], "");
            return primaryKey;
        }
	}

	/// <summary>
	/// Auto Generate for Tab File: "Test.bytes"
    /// No use of generic and reflection, for better performance,  less IL code generating
	/// </summary>>
    public partial class TestSettings : IReloadableSettings
    {
        /// <summary>
        /// How many reload function load?
        /// </summary>>
        public static int ReloadCount { get; private set; }

		public static readonly string[] TabFilePaths = 
        {
            "Test.bytes"
        };
        internal static TestSettings _instance = new TestSettings();
        Dictionary<string, TestSetting> _dict = new Dictionary<string, TestSetting>();

        /// <summary>
        /// Trigger delegate when reload the Settings
        /// </summary>>
	    public static System.Action OnReload;

        /// <summary>
        /// Constructor, just reload(init)
        /// When Unity Editor mode, will watch the file modification and auto reload
        /// </summary>
	    private TestSettings()
	    {
        }

        /// <summary>
        /// Get the singleton
        /// </summary>
        /// <returns></returns>
	    public static TestSettings GetInstance()
	    {
            if (ReloadCount == 0)
            {
                _instance._ReloadAll(true);
    #if UNITY_EDITOR
                if (SettingModule.IsFileSystemMode)
                {
                    for (var j = 0; j < TabFilePaths.Length; j++)
                    {
                        var tabFilePath = TabFilePaths[j];
                        SettingModule.WatchSetting(tabFilePath, (path) =>
                        {
                            if (path.Replace("\\", "/").EndsWith(path))
                            {
                                _instance.ReloadAll();
                                Log.LogConsole_MultiThread("File Watcher! Reload success! -> " + path);
                            }
                        });
                    }

                }
    #endif
            }

	        return _instance;
	    }
        
        public int Count
        {
            get
            {
                return _dict.Count;
            }
        }

        /// <summary>
        /// Do reload the setting file: Test, no exception when duplicate primary key
        /// </summary>
        public void ReloadAll()
        {
            _ReloadAll(false);
        }

        /// <summary>
        /// Do reload the setting class : Test, no exception when duplicate primary key, use custom string content
        /// </summary>
        public void ReloadAllWithString(string context)
        {
            _ReloadAll(false, context);
        }

        /// <summary>
        /// Do reload the setting file: Test
        /// </summary>
	    void _ReloadAll(bool throwWhenDuplicatePrimaryKey, string customContent = null)
        {
            for (var j = 0; j < TabFilePaths.Length; j++)
            {
                var tabFilePath = TabFilePaths[j];
                TableFile tableFile;
                if (customContent == null)
                    tableFile = SettingModule.Get(tabFilePath, false);
                else
                    tableFile = TableFile.LoadFromString(customContent);

                using (tableFile)
                {
                    foreach (var row in tableFile)
                    {
                        var pk = TestSetting.ParsePrimaryKey(row);
                        TestSetting setting;
                        if (!_dict.TryGetValue(pk, out setting))
                        {
                            setting = new TestSetting(row);
                            _dict[setting.Id] = setting;
                        }
                        else 
                        {
                            if (throwWhenDuplicatePrimaryKey) throw new System.Exception(string.Format("DuplicateKey, Class: {0}, File: {1}, Key: {2}", this.GetType().Name, tabFilePath, pk));
                            else setting.Reload(row);
                        }
                    }
                }
            }

	        if (OnReload != null)
	        {
	            OnReload();
	        }

            ReloadCount++;
            Log.Info("Reload settings: {0}, Row Count: {1}, Reload Count: {2}", GetType(), Count, ReloadCount);
        }

	    /// <summary>
        /// foreachable enumerable: Test
        /// </summary>
        public static IEnumerable GetAll()
        {
            foreach (var row in GetInstance()._dict.Values)
            {
                yield return row;
            }
        }

        /// <summary>
        /// GetEnumerator for `MoveNext`: Test
        /// </summary> 
	    public static IEnumerator GetEnumerator()
	    {
	        return GetInstance()._dict.Values.GetEnumerator();
	    }
         
	    /// <summary>
        /// Get class by primary key: Test
        /// </summary>
        public static TestSetting Get(string primaryKey)
        {
            TestSetting setting;
            if (GetInstance()._dict.TryGetValue(primaryKey, out setting)) return setting;
            return null;
        }

        // ========= CustomExtraString begin ===========
        
        // ========= CustomExtraString end ===========
    }

	/// <summary>
	/// Auto Generate for Tab File: "Test.bytes"
    /// Singleton class for less memory use
	/// </summary>
	public partial class TestSetting : TableRowFieldParser
	{
		
        /// <summary>
        /// ID Column/编号/主键
        /// </summary>
        public string Id { get; private set;}
        
        /// <summary>
        /// Name/名字
        /// </summary>
        public I18N Value { get; private set;}
        

        internal TestSetting(TableFileRow row)
        {
            Reload(row);
        }

        internal void Reload(TableFileRow row)
        { 
            Id = row.Get_string(row.Values[0], ""); 
            Value = row.Get_I18N(row.Values[1], ""); 
        }

        /// <summary>
        /// Get PrimaryKey from a table row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string ParsePrimaryKey(TableFileRow row)
        {
            var primaryKey = row.Get_string(row.Values[0], "");
            return primaryKey;
        }
	}

	/// <summary>
	/// Auto Generate for Tab File: "zsl.bytes"
    /// No use of generic and reflection, for better performance,  less IL code generating
	/// </summary>>
    public partial class ZslSettings : IReloadableSettings
    {
        /// <summary>
        /// How many reload function load?
        /// </summary>>
        public static int ReloadCount { get; private set; }

		public static readonly string[] TabFilePaths = 
        {
            "zsl.bytes"
        };
        internal static ZslSettings _instance = new ZslSettings();
        Dictionary<string, ZslSetting> _dict = new Dictionary<string, ZslSetting>();

        /// <summary>
        /// Trigger delegate when reload the Settings
        /// </summary>>
	    public static System.Action OnReload;

        /// <summary>
        /// Constructor, just reload(init)
        /// When Unity Editor mode, will watch the file modification and auto reload
        /// </summary>
	    private ZslSettings()
	    {
        }

        /// <summary>
        /// Get the singleton
        /// </summary>
        /// <returns></returns>
	    public static ZslSettings GetInstance()
	    {
            if (ReloadCount == 0)
            {
                _instance._ReloadAll(true);
    #if UNITY_EDITOR
                if (SettingModule.IsFileSystemMode)
                {
                    for (var j = 0; j < TabFilePaths.Length; j++)
                    {
                        var tabFilePath = TabFilePaths[j];
                        SettingModule.WatchSetting(tabFilePath, (path) =>
                        {
                            if (path.Replace("\\", "/").EndsWith(path))
                            {
                                _instance.ReloadAll();
                                Log.LogConsole_MultiThread("File Watcher! Reload success! -> " + path);
                            }
                        });
                    }

                }
    #endif
            }

	        return _instance;
	    }
        
        public int Count
        {
            get
            {
                return _dict.Count;
            }
        }

        /// <summary>
        /// Do reload the setting file: Zsl, no exception when duplicate primary key
        /// </summary>
        public void ReloadAll()
        {
            _ReloadAll(false);
        }

        /// <summary>
        /// Do reload the setting class : Zsl, no exception when duplicate primary key, use custom string content
        /// </summary>
        public void ReloadAllWithString(string context)
        {
            _ReloadAll(false, context);
        }

        /// <summary>
        /// Do reload the setting file: Zsl
        /// </summary>
	    void _ReloadAll(bool throwWhenDuplicatePrimaryKey, string customContent = null)
        {
            for (var j = 0; j < TabFilePaths.Length; j++)
            {
                var tabFilePath = TabFilePaths[j];
                TableFile tableFile;
                if (customContent == null)
                    tableFile = SettingModule.Get(tabFilePath, false);
                else
                    tableFile = TableFile.LoadFromString(customContent);

                using (tableFile)
                {
                    foreach (var row in tableFile)
                    {
                        var pk = ZslSetting.ParsePrimaryKey(row);
                        ZslSetting setting;
                        if (!_dict.TryGetValue(pk, out setting))
                        {
                            setting = new ZslSetting(row);
                            _dict[setting.Id] = setting;
                        }
                        else 
                        {
                            if (throwWhenDuplicatePrimaryKey) throw new System.Exception(string.Format("DuplicateKey, Class: {0}, File: {1}, Key: {2}", this.GetType().Name, tabFilePath, pk));
                            else setting.Reload(row);
                        }
                    }
                }
            }

	        if (OnReload != null)
	        {
	            OnReload();
	        }

            ReloadCount++;
            Log.Info("Reload settings: {0}, Row Count: {1}, Reload Count: {2}", GetType(), Count, ReloadCount);
        }

	    /// <summary>
        /// foreachable enumerable: Zsl
        /// </summary>
        public static IEnumerable GetAll()
        {
            foreach (var row in GetInstance()._dict.Values)
            {
                yield return row;
            }
        }

        /// <summary>
        /// GetEnumerator for `MoveNext`: Zsl
        /// </summary> 
	    public static IEnumerator GetEnumerator()
	    {
	        return GetInstance()._dict.Values.GetEnumerator();
	    }
         
	    /// <summary>
        /// Get class by primary key: Zsl
        /// </summary>
        public static ZslSetting Get(string primaryKey)
        {
            ZslSetting setting;
            if (GetInstance()._dict.TryGetValue(primaryKey, out setting)) return setting;
            return null;
        }

        // ========= CustomExtraString begin ===========
        
        // ========= CustomExtraString end ===========
    }

	/// <summary>
	/// Auto Generate for Tab File: "zsl.bytes"
    /// Singleton class for less memory use
	/// </summary>
	public partial class ZslSetting : TableRowFieldParser
	{
		
        /// <summary>
        /// ID Column/编号/主键
        /// </summary>
        public string Id { get; private set;}
        
        /// <summary>
        /// 公告标题
        /// </summary>
        public string tt { get; private set;}
        
        /// <summary>
        /// 公告内容
        /// </summary>
        public string ww { get; private set;}
        

        internal ZslSetting(TableFileRow row)
        {
            Reload(row);
        }

        internal void Reload(TableFileRow row)
        { 
            Id = row.Get_string(row.Values[0], ""); 
            tt = row.Get_string(row.Values[1], ""); 
            ww = row.Get_string(row.Values[2], ""); 
        }

        /// <summary>
        /// Get PrimaryKey from a table row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string ParsePrimaryKey(TableFileRow row)
        {
            var primaryKey = row.Get_string(row.Values[0], "");
            return primaryKey;
        }
	}

	/// <summary>
	/// Auto Generate for Tab File: "GameConfig/#Base.bytes", "GameConfig/#TSV.bytes"
    /// No use of generic and reflection, for better performance,  less IL code generating
	/// </summary>>
    public partial class GameConfigSettings : IReloadableSettings
    {
        /// <summary>
        /// How many reload function load?
        /// </summary>>
        public static int ReloadCount { get; private set; }

		public static readonly string[] TabFilePaths = 
        {
            "GameConfig/#Base.bytes", "GameConfig/#TSV.bytes"
        };
        internal static GameConfigSettings _instance = new GameConfigSettings();
        Dictionary<string, GameConfigSetting> _dict = new Dictionary<string, GameConfigSetting>();

        /// <summary>
        /// Trigger delegate when reload the Settings
        /// </summary>>
	    public static System.Action OnReload;

        /// <summary>
        /// Constructor, just reload(init)
        /// When Unity Editor mode, will watch the file modification and auto reload
        /// </summary>
	    private GameConfigSettings()
	    {
        }

        /// <summary>
        /// Get the singleton
        /// </summary>
        /// <returns></returns>
	    public static GameConfigSettings GetInstance()
	    {
            if (ReloadCount == 0)
            {
                _instance._ReloadAll(true);
    #if UNITY_EDITOR
                if (SettingModule.IsFileSystemMode)
                {
                    for (var j = 0; j < TabFilePaths.Length; j++)
                    {
                        var tabFilePath = TabFilePaths[j];
                        SettingModule.WatchSetting(tabFilePath, (path) =>
                        {
                            if (path.Replace("\\", "/").EndsWith(path))
                            {
                                _instance.ReloadAll();
                                Log.LogConsole_MultiThread("File Watcher! Reload success! -> " + path);
                            }
                        });
                    }

                }
    #endif
            }

	        return _instance;
	    }
        
        public int Count
        {
            get
            {
                return _dict.Count;
            }
        }

        /// <summary>
        /// Do reload the setting file: GameConfig, no exception when duplicate primary key
        /// </summary>
        public void ReloadAll()
        {
            _ReloadAll(false);
        }

        /// <summary>
        /// Do reload the setting class : GameConfig, no exception when duplicate primary key, use custom string content
        /// </summary>
        public void ReloadAllWithString(string context)
        {
            _ReloadAll(false, context);
        }

        /// <summary>
        /// Do reload the setting file: GameConfig
        /// </summary>
	    void _ReloadAll(bool throwWhenDuplicatePrimaryKey, string customContent = null)
        {
            for (var j = 0; j < TabFilePaths.Length; j++)
            {
                var tabFilePath = TabFilePaths[j];
                TableFile tableFile;
                if (customContent == null)
                    tableFile = SettingModule.Get(tabFilePath, false);
                else
                    tableFile = TableFile.LoadFromString(customContent);

                using (tableFile)
                {
                    foreach (var row in tableFile)
                    {
                        var pk = GameConfigSetting.ParsePrimaryKey(row);
                        GameConfigSetting setting;
                        if (!_dict.TryGetValue(pk, out setting))
                        {
                            setting = new GameConfigSetting(row);
                            _dict[setting.Id] = setting;
                        }
                        else 
                        {
                            if (throwWhenDuplicatePrimaryKey) throw new System.Exception(string.Format("DuplicateKey, Class: {0}, File: {1}, Key: {2}", this.GetType().Name, tabFilePath, pk));
                            else setting.Reload(row);
                        }
                    }
                }
            }

	        if (OnReload != null)
	        {
	            OnReload();
	        }

            ReloadCount++;
            Log.Info("Reload settings: {0}, Row Count: {1}, Reload Count: {2}", GetType(), Count, ReloadCount);
        }

	    /// <summary>
        /// foreachable enumerable: GameConfig
        /// </summary>
        public static IEnumerable GetAll()
        {
            foreach (var row in GetInstance()._dict.Values)
            {
                yield return row;
            }
        }

        /// <summary>
        /// GetEnumerator for `MoveNext`: GameConfig
        /// </summary> 
	    public static IEnumerator GetEnumerator()
	    {
	        return GetInstance()._dict.Values.GetEnumerator();
	    }
         
	    /// <summary>
        /// Get class by primary key: GameConfig
        /// </summary>
        public static GameConfigSetting Get(string primaryKey)
        {
            GameConfigSetting setting;
            if (GetInstance()._dict.TryGetValue(primaryKey, out setting)) return setting;
            return null;
        }

        // ========= CustomExtraString begin ===========
        
        // ========= CustomExtraString end ===========
    }

	/// <summary>
	/// Auto Generate for Tab File: "GameConfig/#Base.bytes", "GameConfig/#TSV.bytes"
    /// Singleton class for less memory use
	/// </summary>
	public partial class GameConfigSetting : TableRowFieldParser
	{
		
        /// <summary>
        /// ID Column/编号/主键
        /// </summary>
        public string Id { get; private set;}
        
        /// <summary>
        /// Name/名字
        /// </summary>
        public string Value { get; private set;}
        

        internal GameConfigSetting(TableFileRow row)
        {
            Reload(row);
        }

        internal void Reload(TableFileRow row)
        { 
            Id = row.Get_string(row.Values[0], ""); 
            Value = row.Get_string(row.Values[1], ""); 
        }

        /// <summary>
        /// Get PrimaryKey from a table row
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string ParsePrimaryKey(TableFileRow row)
        {
            var primaryKey = row.Get_string(row.Values[0], "");
            return primaryKey;
        }
	}
 
}
