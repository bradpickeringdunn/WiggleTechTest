﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wiggle.Client.Intergration.Test.ShoppingBasketService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CalculateBasketTotalRequest", Namespace="http://schemas.datacontract.org/2004/07/Wiggle.Service.Models.ShoppingBasket.Requ" +
        "est")]
    [System.SerializableAttribute()]
    public partial class CalculateBasketTotalRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Wiggle.Client.Intergration.Test.ShoppingBasketService.ShoppingBasketDto BasketField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Wiggle.Client.Intergration.Test.ShoppingBasketService.ShoppingBasketDto Basket {
            get {
                return this.BasketField;
            }
            set {
                if ((object.ReferenceEquals(this.BasketField, value) != true)) {
                    this.BasketField = value;
                    this.RaisePropertyChanged("Basket");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ShoppingBasketDto", Namespace="http://schemas.datacontract.org/2004/07/Wiggle.Service.Models.ShoppingBasket")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalResult))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.BaseDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.ProductDto[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.ProductDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.GiftVoucherDto[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.GiftVoucherDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.OfferVoucherDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.OfferVoucherType))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial class ShoppingBasketDto : Wiggle.Client.Intergration.Test.ShoppingBasketService.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Wiggle.Client.Intergration.Test.ShoppingBasketService.GiftVoucherDto[] GiftVouchersField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] NotificationsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Wiggle.Client.Intergration.Test.ShoppingBasketService.OfferVoucherDto OfferVoucherField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Wiggle.Client.Intergration.Test.ShoppingBasketService.ProductDto[] ProductsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SubTotalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TotalField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Wiggle.Client.Intergration.Test.ShoppingBasketService.GiftVoucherDto[] GiftVouchers {
            get {
                return this.GiftVouchersField;
            }
            set {
                if ((object.ReferenceEquals(this.GiftVouchersField, value) != true)) {
                    this.GiftVouchersField = value;
                    this.RaisePropertyChanged("GiftVouchers");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Notifications {
            get {
                return this.NotificationsField;
            }
            set {
                if ((object.ReferenceEquals(this.NotificationsField, value) != true)) {
                    this.NotificationsField = value;
                    this.RaisePropertyChanged("Notifications");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Wiggle.Client.Intergration.Test.ShoppingBasketService.OfferVoucherDto OfferVoucher {
            get {
                return this.OfferVoucherField;
            }
            set {
                if ((object.ReferenceEquals(this.OfferVoucherField, value) != true)) {
                    this.OfferVoucherField = value;
                    this.RaisePropertyChanged("OfferVoucher");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Wiggle.Client.Intergration.Test.ShoppingBasketService.ProductDto[] Products {
            get {
                return this.ProductsField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductsField, value) != true)) {
                    this.ProductsField = value;
                    this.RaisePropertyChanged("Products");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal SubTotal {
            get {
                return this.SubTotalField;
            }
            set {
                if ((this.SubTotalField.Equals(value) != true)) {
                    this.SubTotalField = value;
                    this.RaisePropertyChanged("SubTotal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Total {
            get {
                return this.TotalField;
            }
            set {
                if ((this.TotalField.Equals(value) != true)) {
                    this.TotalField = value;
                    this.RaisePropertyChanged("Total");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseDto", Namespace="http://schemas.datacontract.org/2004/07/Wiggle.Service.Models.Common")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.ProductDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.GiftVoucherDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.OfferVoucherDto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Wiggle.Client.Intergration.Test.ShoppingBasketService.ShoppingBasketDto))]
    public partial class BaseDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsActiveField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsActive {
            get {
                return this.IsActiveField;
            }
            set {
                if ((this.IsActiveField.Equals(value) != true)) {
                    this.IsActiveField = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductDto", Namespace="http://schemas.datacontract.org/2004/07/Wiggle.Service.Models.Products")]
    [System.SerializableAttribute()]
    public partial class ProductDto : Wiggle.Client.Intergration.Test.ShoppingBasketService.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CategoryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal PriceField;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GiftVoucherDto", Namespace="http://schemas.datacontract.org/2004/07/Wiggle.Service.Models.Products.Vouchers")]
    [System.SerializableAttribute()]
    public partial class GiftVoucherDto : Wiggle.Client.Intergration.Test.ShoppingBasketService.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal ValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string codeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string code {
            get {
                return this.codeField;
            }
            set {
                if ((object.ReferenceEquals(this.codeField, value) != true)) {
                    this.codeField = value;
                    this.RaisePropertyChanged("code");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OfferVoucherDto", Namespace="http://schemas.datacontract.org/2004/07/Wiggle.Service.Models.Products.Vouchers")]
    [System.SerializableAttribute()]
    public partial class OfferVoucherDto : Wiggle.Client.Intergration.Test.ShoppingBasketService.BaseDto {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CanBeAppliedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Wiggle.Client.Intergration.Test.ShoppingBasketService.OfferVoucherType IsApplicableToField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductCatergoyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal ThreasholdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool CanBeApplied {
            get {
                return this.CanBeAppliedField;
            }
            set {
                if ((this.CanBeAppliedField.Equals(value) != true)) {
                    this.CanBeAppliedField = value;
                    this.RaisePropertyChanged("CanBeApplied");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Wiggle.Client.Intergration.Test.ShoppingBasketService.OfferVoucherType IsApplicableTo {
            get {
                return this.IsApplicableToField;
            }
            set {
                if ((this.IsApplicableToField.Equals(value) != true)) {
                    this.IsApplicableToField = value;
                    this.RaisePropertyChanged("IsApplicableTo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductCatergoy {
            get {
                return this.ProductCatergoyField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductCatergoyField, value) != true)) {
                    this.ProductCatergoyField = value;
                    this.RaisePropertyChanged("ProductCatergoy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Threashold {
            get {
                return this.ThreasholdField;
            }
            set {
                if ((this.ThreasholdField.Equals(value) != true)) {
                    this.ThreasholdField = value;
                    this.RaisePropertyChanged("Threashold");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Value {
            get {
                return this.ValueField;
            }
            set {
                if ((this.ValueField.Equals(value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CalculateBasketTotalResult", Namespace="http://schemas.datacontract.org/2004/07/Wiggle.Service.Models.ShoppingBasket.Resu" +
        "lt")]
    [System.SerializableAttribute()]
    public partial class CalculateBasketTotalResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Wiggle.Client.Intergration.Test.ShoppingBasketService.ShoppingBasketDto BasketField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Wiggle.Client.Intergration.Test.ShoppingBasketService.ShoppingBasketDto Basket {
            get {
                return this.BasketField;
            }
            set {
                if ((object.ReferenceEquals(this.BasketField, value) != true)) {
                    this.BasketField = value;
                    this.RaisePropertyChanged("Basket");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OfferVoucherType", Namespace="http://schemas.datacontract.org/2004/07/Wiggle.Service.Models.Products.Vouchers")]
    public enum OfferVoucherType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ShoppingBasket = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Product = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ShoppingBasketService.IShoppingBasketServiceContract")]
    public interface IShoppingBasketServiceContract {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingBasketServiceContract/CalculateBasketTotal", ReplyAction="http://tempuri.org/IShoppingBasketServiceContract/CalculateBasketTotalResponse")]
        Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalResult CalculateBasketTotal(Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShoppingBasketServiceContract/CalculateBasketTotal", ReplyAction="http://tempuri.org/IShoppingBasketServiceContract/CalculateBasketTotalResponse")]
        System.Threading.Tasks.Task<Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalResult> CalculateBasketTotalAsync(Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IShoppingBasketServiceContractChannel : Wiggle.Client.Intergration.Test.ShoppingBasketService.IShoppingBasketServiceContract, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ShoppingBasketServiceContractClient : System.ServiceModel.ClientBase<Wiggle.Client.Intergration.Test.ShoppingBasketService.IShoppingBasketServiceContract>, Wiggle.Client.Intergration.Test.ShoppingBasketService.IShoppingBasketServiceContract {
        
        public ShoppingBasketServiceContractClient() {
        }
        
        public ShoppingBasketServiceContractClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ShoppingBasketServiceContractClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShoppingBasketServiceContractClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShoppingBasketServiceContractClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalResult CalculateBasketTotal(Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalRequest request) {
            return base.Channel.CalculateBasketTotal(request);
        }
        
        public System.Threading.Tasks.Task<Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalResult> CalculateBasketTotalAsync(Wiggle.Client.Intergration.Test.ShoppingBasketService.CalculateBasketTotalRequest request) {
            return base.Channel.CalculateBasketTotalAsync(request);
        }
    }
}