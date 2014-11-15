// ----------------------------------------------------------------------------------------
// Author:                    Nguyen Van Phu
// Company:                   FTS Company
// Assembly version:          1.0.*
// Date:                      12/29/2006
// Time:                      15:50
// Project Name:              POSUI
// Project Filename:          POSUI.csproj
// Project Item Name:         Startup.cs
// Project Item Filename:     Startup.cs
// Project Item Kind:         Code
// Purpose:                   
// ----------------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using FTS.BaseBusiness.Security;
using FTS.BaseBusiness.Systems;
using FTS.BaseBusiness.Utilities;
using FTS.BaseUI.Forms;
using FTS.BaseUI.Security;
using FTS.MainUI.Systems;

#endregion

namespace FTS.MainUI {
    public class Startup {
        private FTSMain mFTSMain;
        private FTSMainForm mMainForm;
        private List<StartProcedures> mStartProcedures;
        public string oldversion = string.Empty;

        public Startup() {
            try {
                this.mFTSMain = new FTSMain();
                this.mFTSMain.PathName = Application.StartupPath + "\\";
                this.mFTSMain.RunBeforeLogin();
                FrmLogin frm = new FrmLogin(this.mFTSMain);
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK) {
                    throw (new FTSException(string.Empty));
                }
                this.mFTSMain.RunBeforeCheckVersion();
                this.CheckVersion();
                this.mFTSMain.Run();
                SkinManager.EnableFormSkins();
                BonusSkins.Register();
                OfficeSkins.Register();
                DefaultLookAndFeel lookAndFeel;
                lookAndFeel = new DefaultLookAndFeel();
                lookAndFeel.LookAndFeel.UseDefaultLookAndFeel = false;
                lookAndFeel.LookAndFeel.UseWindowsXPTheme = false;
                lookAndFeel.LookAndFeel.Style = LookAndFeelStyle.Skin;
                string skinname = this.mFTSMain.Config.AppSettings.Settings["THEME"].Value;
                if (skinname == string.Empty) {
                    lookAndFeel.LookAndFeel.SkinName = "Office 2007 Blue";
                } else {
                    lookAndFeel.LookAndFeel.SkinName = skinname;
                }
                lookAndFeel.LookAndFeel.SetSkinStyle(lookAndFeel.LookAndFeel.SkinName);
                this.mStartProcedures = new List<StartProcedures>();
                this.mFTSMain.ProjectID = new List<string>();
                string modulelist = this.mFTSMain.Config.AppSettings.Settings["MODUEL_LIST"].Value;
                string[] modules = Tools.Utilities.ParseString(modulelist);
                for (int i = 0; i < modules.Length; i++) {
                    if (modules[i] != string.Empty) {
                        this.mFTSMain.ProjectID.Add(modules[i]);
                    }
                }
                foreach (string projectid in this.mFTSMain.ProjectID) {
                    if (projectid == ProjectList.Finance) {
                        if (File.Exists(this.mFTSMain.PathName + "FTS.AccUI.dll")) {
                            Type type =
                                Assembly.LoadFile(this.mFTSMain.PathName + "FTS.AccUI.dll").GetType(
                                    "FTS.AccUI.Systems.AccStartProcedures");
                            Type[] typeArray = new Type[1] {typeof (FTSMain)};
                            ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                            if (constructorInfoObj != null) {
                                Object[] objArg = new object[1] {this.mFTSMain};
                                this.mStartProcedures.Add(((StartProcedures) constructorInfoObj.Invoke(objArg)));
                            }
                        }
                    } else {
                        if (projectid == ProjectList.Hotel) {
                            if (File.Exists(this.mFTSMain.PathName + "FTS.HotelUI.dll")) {
                                Type type =
                                    Assembly.LoadFile(this.mFTSMain.PathName + "FTS.HotelUI.dll").GetType(
                                        "FTS.HotelUI.Systems.HotelStartProcedure");
                                Type[] typeArray = new Type[1] {typeof (FTSMain)};
                                ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                                if (constructorInfoObj != null) {
                                    Object[] objArg = new object[1] {this.mFTSMain};
                                    this.mStartProcedures.Add(((StartProcedures) constructorInfoObj.Invoke(objArg)));
                                }
                            }
                        } else {
                            if (projectid == ProjectList.POS) {
                                if (File.Exists(this.mFTSMain.PathName + "FTS.POSUI.dll")) {
                                    Type type =
                                        Assembly.LoadFile(this.mFTSMain.PathName + "FTS.POSUI.dll").GetType(
                                            "FTS.POSUI.Systems.PosStartProcedure");
                                    Type[] typeArray = new Type[1] {typeof (FTSMain)};
                                    ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                                    if (constructorInfoObj != null) {
                                        Object[] objArg = new object[1] {this.mFTSMain};
                                        this.mStartProcedures.Add(((StartProcedures) constructorInfoObj.Invoke(objArg)));
                                    }
                                }
                            } else {
                                if (projectid == ProjectList.Transport) {
                                    if (File.Exists(this.mFTSMain.PathName + "FTS.TransportUI.dll")) {
                                        Type type =
                                            Assembly.LoadFile(this.mFTSMain.PathName + "FTS.TransportUI.dll").GetType(
                                                "FTS.TransportUI.Systems.TranStartProcedure");
                                        Type[] typeArray = new Type[1] {typeof (FTSMain)};
                                        ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                                        if (constructorInfoObj != null) {
                                            Object[] objArg = new object[1] {this.mFTSMain};
                                            this.mStartProcedures.Add(((StartProcedures) constructorInfoObj.Invoke(objArg)));
                                        }
                                    }
                                } else {
                                    if (projectid == ProjectList.HRM) {
                                        if (File.Exists(this.mFTSMain.PathName + "FTS.HRMUI.dll")) {
                                            Type type =
                                                Assembly.LoadFile(this.mFTSMain.PathName + "FTS.HRMUI.dll").GetType(
                                                    "FTS.HRMUI.Systems.HRMStartProcedure");
                                            Type[] typeArray = new Type[1] {typeof (FTSMain)};
                                            ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                                            if (constructorInfoObj != null) {
                                                Object[] objArg = new object[1] {this.mFTSMain};
                                                this.mStartProcedures.Add(((StartProcedures) constructorInfoObj.Invoke(objArg)));
                                            }
                                        }
                                    } else {
                                    }
                                }
                            }
                        }
                    }
                }
                try {
                    this.mFTSMain.ISDEV = this.mFTSMain.Config.AppSettings.Settings["ISDEV"].Value == "1" ? true : false;
                } catch (Exception) {
                }
                this.mMainForm = new MainFormERP(this.mFTSMain, this.mStartProcedures);
                Application.Run(this.mMainForm);
                RegManager.WriteKey("FULLPATH", this.mFTSMain.PathName);
            } catch (FTSException e) {
                if (e.SystemException != null) {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(e.SystemException.Message);
                } else {
                    FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(e.ExceptionID);
                }
            } catch (Exception e1) {
                FTS.BaseUI.Utilities.FTSMessageBox.ShowErrorMessage(e1.Message);
            }
        }

        [STAThread]
        public static void Main() {
            Startup st = new Startup();
        }

        public void CheckVersion() {
            string dbver = this.mFTSMain.SystemVars.GetSystemVars("VERSION").ToString().Trim();
            this.oldversion = dbver;
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = ",";
            provider.NumberGroupSizes = new int[] {3};
            decimal thisver = Convert.ToDecimal(FTSConstant.Version, provider);
            decimal intver = Convert.ToDecimal(dbver, provider);
            if (thisver > intver) {
                if (File.Exists(this.mFTSMain.PathName + "FTS.Update.dll")) {
                    Type type =
                        Assembly.LoadFile(this.mFTSMain.PathName + "FTS.Update.dll").GetType("FTS.Update.UpdateData");
                    Type[] typeArray = new Type[1] {typeof (FTSMain)};
                    ConstructorInfo constructorInfoObj = type.GetConstructor(typeArray);
                    if (constructorInfoObj != null) {
                        Object[] objArg = new object[1] {this.mFTSMain};
                        type.GetMethod("Update").Invoke(constructorInfoObj.Invoke(objArg), null);
                    }
                }
            } else {
                if (thisver < intver) {
                    throw new FTSException("MSG_INVALID_VERSION");
                }
            }
        }
    }
}