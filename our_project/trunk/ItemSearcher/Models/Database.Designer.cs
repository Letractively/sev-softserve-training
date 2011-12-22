﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region Метаданные связи EDM

[assembly: EdmRelationshipAttribute("OrderSystemModel", "FK_ItemsOrder_Items", "Items", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(ItemSearcher.Models.Items), "ItemsOrder", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(ItemSearcher.Models.ItemsOrder), true)]

#endregion

namespace ItemSearcher.Models
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class OrderSystemEntities : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект OrderSystemEntities, используя строку соединения из раздела "OrderSystemEntities" файла конфигурации приложения.
        /// </summary>
        public OrderSystemEntities() : base("name=OrderSystemEntities", "OrderSystemEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта OrderSystemEntities.
        /// </summary>
        public OrderSystemEntities(string connectionString) : base(connectionString, "OrderSystemEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта OrderSystemEntities.
        /// </summary>
        public OrderSystemEntities(EntityConnection connection) : base(connection, "OrderSystemEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Разделяемые методы
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Свойства ObjectSet
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Items> Items
        {
            get
            {
                if ((_Items == null))
                {
                    _Items = base.CreateObjectSet<Items>("Items");
                }
                return _Items;
            }
        }
        private ObjectSet<Items> _Items;
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<ItemsOrder> ItemsOrder
        {
            get
            {
                if ((_ItemsOrder == null))
                {
                    _ItemsOrder = base.CreateObjectSet<ItemsOrder>("ItemsOrder");
                }
                return _ItemsOrder;
            }
        }
        private ObjectSet<ItemsOrder> _ItemsOrder;

        #endregion
        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet Items. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToItems(Items items)
        {
            base.AddObject("Items", items);
        }
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet ItemsOrder. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToItemsOrder(ItemsOrder itemsOrder)
        {
            base.AddObject("ItemsOrder", itemsOrder);
        }

        #endregion
    }
    

    #endregion
    
    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="OrderSystemModel", Name="Items")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Items : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Items.
        /// </summary>
        /// <param name="itemID">Исходное значение свойства ItemID.</param>
        /// <param name="itemName">Исходное значение свойства ItemName.</param>
        /// <param name="itemDescriprion">Исходное значение свойства ItemDescriprion.</param>
        /// <param name="price">Исходное значение свойства Price.</param>
        /// <param name="quantity">Исходное значение свойства Quantity.</param>
        public static Items CreateItems(global::System.Int32 itemID, global::System.String itemName, global::System.String itemDescriprion, global::System.Decimal price, global::System.Int32 quantity)
        {
            Items items = new Items();
            items.ItemID = itemID;
            items.ItemName = itemName;
            items.ItemDescriprion = itemDescriprion;
            items.Price = price;
            items.Quantity = quantity;
            return items;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ItemID
        {
            get
            {
                return _ItemID;
            }
            set
            {
                if (_ItemID != value)
                {
                    OnItemIDChanging(value);
                    ReportPropertyChanging("ItemID");
                    _ItemID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ItemID");
                    OnItemIDChanged();
                }
            }
        }
        private global::System.Int32 _ItemID;
        partial void OnItemIDChanging(global::System.Int32 value);
        partial void OnItemIDChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ItemName
        {
            get
            {
                return _ItemName;
            }
            set
            {
                OnItemNameChanging(value);
                ReportPropertyChanging("ItemName");
                _ItemName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ItemName");
                OnItemNameChanged();
            }
        }
        private global::System.String _ItemName;
        partial void OnItemNameChanging(global::System.String value);
        partial void OnItemNameChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String ItemDescriprion
        {
            get
            {
                return _ItemDescriprion;
            }
            set
            {
                OnItemDescriprionChanging(value);
                ReportPropertyChanging("ItemDescriprion");
                _ItemDescriprion = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("ItemDescriprion");
                OnItemDescriprionChanged();
            }
        }
        private global::System.String _ItemDescriprion;
        partial void OnItemDescriprionChanging(global::System.String value);
        partial void OnItemDescriprionChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal Price
        {
            get
            {
                return _Price;
            }
            set
            {
                OnPriceChanging(value);
                ReportPropertyChanging("Price");
                _Price = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Price");
                OnPriceChanged();
            }
        }
        private global::System.Decimal _Price;
        partial void OnPriceChanging(global::System.Decimal value);
        partial void OnPriceChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                OnQuantityChanging(value);
                ReportPropertyChanging("Quantity");
                _Quantity = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Quantity");
                OnQuantityChanged();
            }
        }
        private global::System.Int32 _Quantity;
        partial void OnQuantityChanging(global::System.Int32 value);
        partial void OnQuantityChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Image
        {
            get
            {
                return _Image;
            }
            set
            {
                OnImageChanging(value);
                ReportPropertyChanging("Image");
                _Image = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Image");
                OnImageChanged();
            }
        }
        private global::System.String _Image;
        partial void OnImageChanging(global::System.String value);
        partial void OnImageChanged();

        #endregion
    
        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("OrderSystemModel", "FK_ItemsOrder_Items", "ItemsOrder")]
        public EntityCollection<ItemsOrder> ItemsOrder
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<ItemsOrder>("OrderSystemModel.FK_ItemsOrder_Items", "ItemsOrder");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<ItemsOrder>("OrderSystemModel.FK_ItemsOrder_Items", "ItemsOrder", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="OrderSystemModel", Name="ItemsOrder")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ItemsOrder : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта ItemsOrder.
        /// </summary>
        /// <param name="itemID">Исходное значение свойства ItemID.</param>
        /// <param name="itemInfoID">Исходное значение свойства ItemInfoID.</param>
        /// <param name="orderID">Исходное значение свойства OrderID.</param>
        /// <param name="quantity">Исходное значение свойства Quantity.</param>
        /// <param name="dimension">Исходное значение свойства Dimension.</param>
        public static ItemsOrder CreateItemsOrder(global::System.Int32 itemID, global::System.Int32 itemInfoID, global::System.Int32 orderID, global::System.Int32 quantity, global::System.String dimension)
        {
            ItemsOrder itemsOrder = new ItemsOrder();
            itemsOrder.ItemID = itemID;
            itemsOrder.ItemInfoID = itemInfoID;
            itemsOrder.OrderID = orderID;
            itemsOrder.Quantity = quantity;
            itemsOrder.Dimension = dimension;
            return itemsOrder;
        }

        #endregion
        #region Свойства-примитивы
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ItemID
        {
            get
            {
                return _ItemID;
            }
            set
            {
                if (_ItemID != value)
                {
                    OnItemIDChanging(value);
                    ReportPropertyChanging("ItemID");
                    _ItemID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ItemID");
                    OnItemIDChanged();
                }
            }
        }
        private global::System.Int32 _ItemID;
        partial void OnItemIDChanging(global::System.Int32 value);
        partial void OnItemIDChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ItemInfoID
        {
            get
            {
                return _ItemInfoID;
            }
            set
            {
                OnItemInfoIDChanging(value);
                ReportPropertyChanging("ItemInfoID");
                _ItemInfoID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ItemInfoID");
                OnItemInfoIDChanged();
            }
        }
        private global::System.Int32 _ItemInfoID;
        partial void OnItemInfoIDChanging(global::System.Int32 value);
        partial void OnItemInfoIDChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 OrderID
        {
            get
            {
                return _OrderID;
            }
            set
            {
                OnOrderIDChanging(value);
                ReportPropertyChanging("OrderID");
                _OrderID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OrderID");
                OnOrderIDChanged();
            }
        }
        private global::System.Int32 _OrderID;
        partial void OnOrderIDChanging(global::System.Int32 value);
        partial void OnOrderIDChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Quantity
        {
            get
            {
                return _Quantity;
            }
            set
            {
                OnQuantityChanging(value);
                ReportPropertyChanging("Quantity");
                _Quantity = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Quantity");
                OnQuantityChanged();
            }
        }
        private global::System.Int32 _Quantity;
        partial void OnQuantityChanging(global::System.Int32 value);
        partial void OnQuantityChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Dimension
        {
            get
            {
                return _Dimension;
            }
            set
            {
                OnDimensionChanging(value);
                ReportPropertyChanging("Dimension");
                _Dimension = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Dimension");
                OnDimensionChanged();
            }
        }
        private global::System.String _Dimension;
        partial void OnDimensionChanging(global::System.String value);
        partial void OnDimensionChanged();

        #endregion
    
        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("OrderSystemModel", "FK_ItemsOrder_Items", "Items")]
        public Items Items
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Items>("OrderSystemModel.FK_ItemsOrder_Items", "Items").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Items>("OrderSystemModel.FK_ItemsOrder_Items", "Items").Value = value;
            }
        }
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Items> ItemsReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Items>("OrderSystemModel.FK_ItemsOrder_Items", "Items");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Items>("OrderSystemModel.FK_ItemsOrder_Items", "Items", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
