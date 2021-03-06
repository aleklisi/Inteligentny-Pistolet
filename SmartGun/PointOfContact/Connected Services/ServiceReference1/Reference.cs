﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PointOfContact.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICoreService")]
    public interface ICoreService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/HandleWarning", ReplyAction="http://tempuri.org/ICoreService/HandleWarningResponse")]
        void HandleWarning(MessagesLibrary.WarningMessage message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/HandleWarning", ReplyAction="http://tempuri.org/ICoreService/HandleWarningResponse")]
        System.Threading.Tasks.Task HandleWarningAsync(MessagesLibrary.WarningMessage message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/HandleShot", ReplyAction="http://tempuri.org/ICoreService/HandleShotResponse")]
        void HandleShot(MessagesLibrary.ShotMessage message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoreService/HandleShot", ReplyAction="http://tempuri.org/ICoreService/HandleShotResponse")]
        System.Threading.Tasks.Task HandleShotAsync(MessagesLibrary.ShotMessage message);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICoreServiceChannel : PointOfContact.ServiceReference1.ICoreService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CoreServiceClient : System.ServiceModel.ClientBase<PointOfContact.ServiceReference1.ICoreService>, PointOfContact.ServiceReference1.ICoreService {
        
        public CoreServiceClient() {
        }
        
        public CoreServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CoreServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoreServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoreServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void HandleWarning(MessagesLibrary.WarningMessage message) {
            base.Channel.HandleWarning(message);
        }
        
        public System.Threading.Tasks.Task HandleWarningAsync(MessagesLibrary.WarningMessage message) {
            return base.Channel.HandleWarningAsync(message);
        }
        
        public void HandleShot(MessagesLibrary.ShotMessage message) {
            base.Channel.HandleShot(message);
        }
        
        public System.Threading.Tasks.Task HandleShotAsync(MessagesLibrary.ShotMessage message) {
            return base.Channel.HandleShotAsync(message);
        }
    }
}
