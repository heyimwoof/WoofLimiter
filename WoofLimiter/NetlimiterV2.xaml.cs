
using System;
using System.Windows;
using mrousavy;
using System.Windows.Input;
using DiscordRpcDemo;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.IO;
using System.Net;

namespace WoofLimiter
{

    
    public partial class NetlimiterV2 : Window

    {

       private DiscordRpc.EventHandlers handlers;
       private DiscordRpc.RichPresence presence;

        static readonly string Rule3074 = "3074 by woof";
        static readonly string PortRange3074 = "3074";
        static readonly string Rule30K = "30K by woof";
        static readonly string PortRange30K = "30000-30009";
        static readonly string Rule27K = "27K by woof";
        static readonly string PortRange27K = "27000-27100";


        public static readonly DependencyProperty IsLimiterActive3074 =
            DependencyProperty.Register("IsLimiterActivePort1", typeof(bool), typeof(NetlimiterV2),
            new PropertyMetadata(false, OnPropertyIsLimiterActiveChanged));

        public static readonly DependencyProperty IsLimiterActive30K =
            DependencyProperty.Register("IsLimiterActivePort2", typeof(bool), typeof(NetlimiterV2),
            new PropertyMetadata(false, OnPropertyIsLimiterActiveChanged1));

        public static readonly DependencyProperty IsLimiterActive27K =
            DependencyProperty.Register("IsLimiterActivePort3", typeof(bool), typeof(NetlimiterV2),
            new PropertyMetadata(false, OnPropertyIsLimiterActiveChanged2));

     
        private bool _initializing;

        public bool IsLimiterActivePort1
        {
            get { return (bool)GetValue(IsLimiterActive3074); }
            set { SetValue(IsLimiterActive3074, value); }
        }

        public bool IsLimiterActivePort2
        {
            get { return (bool)GetValue(IsLimiterActive30K); }
            set { SetValue(IsLimiterActive30K, value); }
        }

        public bool IsLimiterActivePort3
        {
            get { return (bool)GetValue(IsLimiterActive27K); }
            set { SetValue(IsLimiterActive27K, value); }
        }

       
        private bool _enableHotkey = true;
        private HotKey _woofEnablerHotkey = null;
        private bool _enableHotkey1 = true;
        private HotKey _woofEnablerHotkey1 = null;
        private bool _enableHotkey2 = true;
        private HotKey _woofEnablerHotkey2 = null;
        

        public NetlimiterV2()
        {
            InitializeComponent();
            InitializeResources();
           
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            Computer.Content = "Welcome " + userName;
         //DiscordRPC
            DataContext = this;
            this.handlers = default(DiscordRpc.EventHandlers);
            DiscordRpc.Initialize("1043814073697050624", ref this.handlers, true, null);
            this.handlers = default(DiscordRpc.EventHandlers);
           DiscordRpc.Initialize("1043814073697050624", ref this.handlers, true, null);
            this.presence.details = "I'm a netlimiting cheater!";
            this.presence.state = "made by woof#8834";
           this.presence.largeImageKey = "woof-netlimiter";
           this.presence.smallImageKey = "woof-netlimiter";
           this.presence.largeImageText = "";
           this.presence.smallImageText = "";
            this.presence.startTimestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            DiscordRpc.UpdatePresence(ref this.presence);
            _initializing = true;
            IsLimiterActivePort1 = Limiter.DoesFWRuleExist(Rule3074);
            IsLimiterActivePort2 = Limiter.DoesFWRuleExist(Rule30K);
            IsLimiterActivePort3 = Limiter.DoesFWRuleExist(Rule27K);
            _initializing = false;

         
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            HandleHotkeyRegistration();
            HandleHotkeyRegistration1();
            HandleHotkeyRegistration2();


        }

        private void RemoveHotkey()
        {
            if(_woofEnablerHotkey != null)
            {
                _woofEnablerHotkey.Dispose();
                _woofEnablerHotkey = null;
            }
        }

        private void RemoveHotkey1()
        {
            if (_woofEnablerHotkey1 != null)
            {
                _woofEnablerHotkey1.Dispose();
                _woofEnablerHotkey1 = null;
            }
        }
        private void RemoveHotkey2()
        {
            if (_woofEnablerHotkey2 != null)
            {
                _woofEnablerHotkey2.Dispose();
                _woofEnablerHotkey2 = null;
            }
        }

      
        private void HandleHotkeyRegistration()
        {
           
            if (_enableHotkey && _woofEnablerHotkey == null)
            {
                try
                {
                    _woofEnablerHotkey = new HotKey((ModifierKeys.Control), Key.Z, this, (hotkey) =>
                    {
                        IsLimiterActivePort1 = !IsLimiterActivePort1;
                    });
                }
                catch(Exception)
                {
                    
                    MessageBox.Show("Error initializing the hotkey.");
                }
            }
            else
            {
                
                RemoveHotkey();
            }
        }

        private void HandleHotkeyRegistration1()
        {
          
            if (_enableHotkey1 && _woofEnablerHotkey1 == null)
            {
                try
                {
                    _woofEnablerHotkey1 = new HotKey((ModifierKeys.Control), Key.X, this, (hotkey) =>
                    {
                        IsLimiterActivePort2 = !IsLimiterActivePort2;
                    });
                }
                catch (Exception)
                {
                    MessageBox.Show("Error initializing the hotkey.");
                }
            }
            else
            {
                RemoveHotkey1();
            }
        }
        private void HandleHotkeyRegistration2()
        {
          
            if (_enableHotkey2 && _woofEnablerHotkey2 == null)
            {
                try
                {
                    _woofEnablerHotkey2 = new HotKey((ModifierKeys.Control), Key.C, this, (hotkey) =>
                    {
                        IsLimiterActivePort3 = !IsLimiterActivePort3;
                    });
                }
                catch (Exception)
                {
                   
                    MessageBox.Show("Error initializing the hotkey.");
                }
            }
            else
            {
                RemoveHotkey2();
            }
        }

        private void InitializeResources()
        {
          
            var dict = Application.LoadComponent(new Uri("Resources/Resources.xaml", UriKind.Relative)) as ResourceDictionary;
            if (dict != null)
            {
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
        }

        /// <param name="sender"></param>
        /// <param name="e"></param>



     
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        string pauseprogram = "pause.exe";
        private void OnButtonCloseClicked(object sender, RoutedEventArgs e)
        {
            RemoveHotkey();
            RemoveHotkey1();
            RemoveHotkey2();
          
            
            Application.Current.Shutdown();

            foreach (Process process in Process.GetProcessesByName("pause"))
            {
                process.Kill();
            }
        }

        

        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            RemoveHotkey();
            RemoveHotkey1();
            RemoveHotkey2();
           

            // Remove the FW rules & Hotkeys before closing the application.
            Limiter.RemoveFirewallRule3074(Rule3074);
            Limiter.RemoveFirewallRule3074(Rule30K);
            Limiter.RemoveFirewallRule3074(Rule27K);
            base.OnClosed(e);
        }

        private static void OnPropertyIsLimiterActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NetlimiterV2 instance)
            {
                instance.OnIsLimiterActiveChanged();
            }
        }

        private static void OnPropertyIsLimiterActiveChanged1(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NetlimiterV2 instance)
            {
                instance.OnIsLimiterActiveChanged1();
            }
        }
        private static void OnPropertyIsLimiterActiveChanged2(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NetlimiterV2 instance)
            {
                instance.OnIsLimiterActiveChanged2();
            }
        }

     

        private void OnIsLimiterActiveChanged()
        {
            if(_initializing)
                return;

      
            if (IsLimiterActivePort1)
            {
                // Name. Portrange. Outbound yes/no. UDP yes/no.
                Limiter.CreateFWRule3074(ruleName: Rule3074, portValue: PortRange3074, isOut: false, isUDP: false);

                Limiter.CreateFWRule3074(ruleName: Rule3074, portValue: PortRange3074, isOut: false, isUDP: true);


            }

   
            else
            {
                Limiter.RemoveFirewallRule3074(Rule3074);
                IsLimiterActivePort1 = Limiter.DoesFWRuleExist(Rule3074);
            }
        }
        private void OnIsLimiterActiveChanged1()
        {
            if (_initializing)
                return;

           
            if (IsLimiterActivePort2)
            {
                // Name. Portrange. Outbound yes/no. UDP yes/no.
                Limiter.CreateFWRule3074(ruleName: Rule30K, portValue: PortRange30K, isOut: false, isUDP: false);

                Limiter.CreateFWRule3074(ruleName: Rule30K, portValue: PortRange30K, isOut: false, isUDP: true);


            }


            else
            {
                Limiter.RemoveFirewallRule3074(Rule30K);
                IsLimiterActivePort2 = Limiter.DoesFWRuleExist1(Rule30K);
            }
        }

        private void OnIsLimiterActiveChanged2()
        {
            if (_initializing)
                return;

            
            if (IsLimiterActivePort3)
            {
                // Name. Portrange. Outbound yes/no. UDP yes/no.
                Limiter.CreateFWRule3074(ruleName: Rule27K, portValue: PortRange27K, isOut: false, isUDP: false);

                Limiter.CreateFWRule3074(ruleName: Rule27K, portValue: PortRange27K, isOut: false, isUDP: true);

            }

            else
            {
                Limiter.RemoveFirewallRule3074(Rule27K);
                IsLimiterActivePort3 = Limiter.DoesFWRuleExist(Rule27K);
            }
        }
    

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Process.Start(pauseprogram);
            togglelabel.Content = "Press 0 to toggle.";
            inactive.Content = "Active";
            inactive.Foreground = System.Windows.Media.Brushes.LimeGreen;
        }
    }
}
