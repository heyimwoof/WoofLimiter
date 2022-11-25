using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;

namespace WoofLimiter

{

    class Limiter
    {
    
        /// <param name="ruleName"
      
        public static bool DoesFWRuleExist(string ruleName)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name == ruleName)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool DoesFWRuleExist1(string ruleName1)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name == ruleName1)
                {
                    return true;
                }
            }
            return false;
        }

    
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="portValue">Single port: "222". Range: "222-444".</param>
        /// <param name="isOut">true = outbound rule. False = inbound rule.</param>
        /// <param name="isUDP">true = UDP. False = TCP.</param> 
        // Credit D2SoloEnabler Source for having this already setup.
        public static void CreateFWRule3074(string ruleName = "Firewall testing via C#", string portValue = "8000-8005", bool isOut = true, bool isUDP = true)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            
            INetFwRule2 inboundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

          
            inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;

            inboundRule.Description = "3074 UL - by woof xx.";

          
           inboundRule.Direction = isOut ? NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN : NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;

          
            inboundRule.Enabled = true;

        
            inboundRule.Name = ruleName;

          
            inboundRule.Protocol = (int)(isUDP ? NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP : NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);

            inboundRule.RemotePorts = portValue;

         
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(inboundRule);
        }

        public static void CreateFWRule30K(string ruleName = "Firewall testing via C#", string portValue = "8000-8005", bool isOut = true, bool isUDP = true)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            
            INetFwRule2 inboundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

        
            inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;

            
            inboundRule.Description = "30K - by woof xx.";

          
            inboundRule.Direction = isOut ? NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN : NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;

        
            inboundRule.Enabled = true;

        
            inboundRule.Name = ruleName;

          
            inboundRule.Protocol = (int)(isUDP ? NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP : NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);

          
            inboundRule.RemotePorts = portValue;

       
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(inboundRule);
        }
        public static void CreateFWRule27K(string ruleName = "Firewall testing via C#", string portValue = "8000-8005", bool isOut = true, bool isUDP = true)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

        
            INetFwRule2 inboundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));

          
            inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;

            inboundRule.Description = "27K - by woof xx.";

      
            inboundRule.Direction = isOut ? NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN : NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;

          
            inboundRule.Enabled = true;

            inboundRule.Name = ruleName;

        
            inboundRule.Protocol = (int)(isUDP ? NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP : NetFwTypeLib.NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);

   
            inboundRule.RemotePorts = portValue;

        
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(inboundRule);
        }


        /// <param name="ruleName">Name of firewall rule to remove.</param>

        public static void RemoveFirewallRule3074(string ruleName)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name == ruleName)
                {
                    fwPolicy2.Rules.Remove(ruleName);              
                }
            }
        }

        public static void RemoveFirewallRule30K(string ruleName1)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name == ruleName1)
                {
                    fwPolicy2.Rules.Remove(ruleName1);               
                }
            }
        }
        public static void RemoveFirewallRule27K(string ruleName2)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name == ruleName2)
                {
                    fwPolicy2.Rules.Remove(ruleName2);              
                }
            }
        }

       

    }
}
