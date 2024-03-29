﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace Tray
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialTray();
        }
        private System.Windows.Forms.NotifyIcon notifyIcon = null;
        private void InitialTray()
        {

            //设置托盘的各个属性
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.BalloonTipText = "程序开始运行";
            string s = "OfficeScan (Online)\r\nAntivirus \r\nDCS Eng/Ptn:7.0.1028/1268";
            notifyIcon.Text = s;
            notifyIcon.Icon = new System.Drawing.Icon("favicon2.ico");
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(1000);
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_MouseClick);

            //设置菜单项
            System.Windows.Forms.MenuItem[] menuitems = 
            {
                new System.Windows.Forms.MenuItem("OfficeScan Console"),
                new System.Windows.Forms.MenuItem("-"),
                new System.Windows.Forms.MenuItem("Component Versions"),
                new System.Windows.Forms.MenuItem("Update Now"),
                new System.Windows.Forms.MenuItem("-"),
                new System.Windows.Forms.MenuItem("Enable Roaming Mode"),
                new System.Windows.Forms.MenuItem("-"),
                new System.Windows.Forms.MenuItem("Scheduled Scan Advanced Settings"),
                new System.Windows.Forms.MenuItem("-"),
                new System.Windows.Forms.MenuItem("Plug-in Manager"),
                new System.Windows.Forms.MenuItem("-"),
                new System.Windows.Forms.MenuItem("Unload OfficeScan")
            };

            System.Windows.Forms.MenuItem menu1 = new System.Windows.Forms.MenuItem("OfficeScan Console");
            System.Windows.Forms.MenuItem menu2 = new System.Windows.Forms.MenuItem("菜单项2");
            //分隔线！！
            System.Windows.Forms.MenuItem menu3 = new System.Windows.Forms.MenuItem("-");
            ////退出菜单项
            //System.Windows.Forms.MenuItem exit = new System.Windows.Forms.MenuItem("exit");
            //exit.Click += new EventHandler(exit_Click);

            //关联托盘控件
            System.Windows.Forms.MenuItem[] childen = menuitems;
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);

            //窗体状态改变时候触发
            this.StateChanged += new EventHandler(SysTray_StateChanged);
        }
        ///
        /// 窗体状态改变时候触发
        ///
        ///

        ///

        private void SysTray_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Visibility = Visibility.Hidden;
            }
        }

        ///
        /// 退出选项
        ///
        ///

        ///

        private void exit_Click(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("确定要关闭吗?",
                                               "退出",
                                                MessageBoxButton.YesNo,
                                                MessageBoxImage.Question,
                                                MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                notifyIcon.Dispose();
                System.Windows.Application.Current.Shutdown();
            }
        }

        ///
        /// 鼠标单击
        ///
        ///

        ///

        private void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.Visibility == Visibility.Visible)
                {
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.Visibility = Visibility.Visible;
                    this.Activate();
                }
            }
        }
    }
}
