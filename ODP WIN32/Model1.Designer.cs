﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace ORACLEspace
{
    #region 上下文
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    public partial class myhostsEntities : ObjectContext
    {
        #region 构造函数
    
        /// <summary>
        /// 请使用应用程序配置文件的“myhostsEntities”部分中的连接字符串初始化新 myhostsEntities 对象。
        /// </summary>
        public myhostsEntities() : base("name=myhostsEntities", "myhostsEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 myhostsEntities 对象。
        /// </summary>
        public myhostsEntities(string connectionString) : base(connectionString, "myhostsEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// 初始化新的 myhostsEntities 对象。
        /// </summary>
        public myhostsEntities(EntityConnection connection) : base(connection, "myhostsEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region 分部方法
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet 属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<HOSTS> HOSTS
        {
            get
            {
                if ((_HOSTS == null))
                {
                    _HOSTS = base.CreateObjectSet<HOSTS>("HOSTS");
                }
                return _HOSTS;
            }
        }
        private ObjectSet<HOSTS> _HOSTS;
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        public ObjectSet<TABLESPACE> TABLESPACE
        {
            get
            {
                if ((_TABLESPACE == null))
                {
                    _TABLESPACE = base.CreateObjectSet<TABLESPACE>("TABLESPACE");
                }
                return _TABLESPACE;
            }
        }
        private ObjectSet<TABLESPACE> _TABLESPACE;

        #endregion

        #region AddTo 方法
    
        /// <summary>
        /// 用于向 HOSTS EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToHOSTS(HOSTS hOSTS)
        {
            base.AddObject("HOSTS", hOSTS);
        }
    
        /// <summary>
        /// 用于向 TABLESPACE EntitySet 添加新对象的方法，已弃用。请考虑改用关联的 ObjectSet&lt;T&gt; 属性的 .Add 方法。
        /// </summary>
        public void AddToTABLESPACE(TABLESPACE tABLESPACE)
        {
            base.AddObject("TABLESPACE", tABLESPACE);
        }

        #endregion

    }

    #endregion

    #region 实体
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="myhostsModel", Name="HOSTS")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class HOSTS : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 HOSTS 对象。
        /// </summary>
        /// <param name="id">ID 属性的初始值。</param>
        /// <param name="dESCRIPTION">DESCRIPTION 属性的初始值。</param>
        public static HOSTS CreateHOSTS(global::System.Int64 id, global::System.String dESCRIPTION)
        {
            HOSTS hOSTS = new HOSTS();
            hOSTS.ID = id;
            hOSTS.DESCRIPTION = dESCRIPTION;
            return hOSTS;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int64 _ID;
        partial void OnIDChanging(global::System.Int64 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String DESCRIPTION
        {
            get
            {
                return _DESCRIPTION;
            }
            set
            {
                OnDESCRIPTIONChanging(value);
                ReportPropertyChanging("DESCRIPTION");
                _DESCRIPTION = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("DESCRIPTION");
                OnDESCRIPTIONChanged();
            }
        }
        private global::System.String _DESCRIPTION;
        partial void OnDESCRIPTIONChanging(global::System.String value);
        partial void OnDESCRIPTIONChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String IP
        {
            get
            {
                return _IP;
            }
            set
            {
                OnIPChanging(value);
                ReportPropertyChanging("IP");
                _IP = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("IP");
                OnIPChanged();
            }
        }
        private global::System.String _IP;
        partial void OnIPChanging(global::System.String value);
        partial void OnIPChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String USERNAME
        {
            get
            {
                return _USERNAME;
            }
            set
            {
                OnUSERNAMEChanging(value);
                ReportPropertyChanging("USERNAME");
                _USERNAME = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("USERNAME");
                OnUSERNAMEChanged();
            }
        }
        private global::System.String _USERNAME;
        partial void OnUSERNAMEChanging(global::System.String value);
        partial void OnUSERNAMEChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PASSWORD
        {
            get
            {
                return _PASSWORD;
            }
            set
            {
                OnPASSWORDChanging(value);
                ReportPropertyChanging("PASSWORD");
                _PASSWORD = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PASSWORD");
                OnPASSWORDChanged();
            }
        }
        private global::System.String _PASSWORD;
        partial void OnPASSWORDChanging(global::System.String value);
        partial void OnPASSWORDChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String SID
        {
            get
            {
                return _SID;
            }
            set
            {
                OnSIDChanging(value);
                ReportPropertyChanging("SID");
                _SID = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("SID");
                OnSIDChanged();
            }
        }
        private global::System.String _SID;
        partial void OnSIDChanging(global::System.String value);
        partial void OnSIDChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PORT
        {
            get
            {
                return _PORT;
            }
            set
            {
                OnPORTChanging(value);
                ReportPropertyChanging("PORT");
                _PORT = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PORT");
                OnPORTChanged();
            }
        }
        private global::System.String _PORT;
        partial void OnPORTChanging(global::System.String value);
        partial void OnPORTChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String STATE
        {
            get
            {
                return _STATE;
            }
            set
            {
                OnSTATEChanging(value);
                ReportPropertyChanging("STATE");
                _STATE = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("STATE");
                OnSTATEChanged();
            }
        }
        private global::System.String _STATE;
        partial void OnSTATEChanging(global::System.String value);
        partial void OnSTATEChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String OTHER
        {
            get
            {
                return _OTHER;
            }
            set
            {
                OnOTHERChanging(value);
                ReportPropertyChanging("OTHER");
                _OTHER = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("OTHER");
                OnOTHERChanged();
            }
        }
        private global::System.String _OTHER;
        partial void OnOTHERChanging(global::System.String value);
        partial void OnOTHERChanged();

        #endregion

    
    }
    
    /// <summary>
    /// 没有元数据文档可用。
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="myhostsModel", Name="TABLESPACE")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TABLESPACE : EntityObject
    {
        #region 工厂方法
    
        /// <summary>
        /// 创建新的 TABLESPACE 对象。
        /// </summary>
        /// <param name="id">ID 属性的初始值。</param>
        public static TABLESPACE CreateTABLESPACE(global::System.Int64 id)
        {
            TABLESPACE tABLESPACE = new TABLESPACE();
            tABLESPACE.ID = id;
            return tABLESPACE;
        }

        #endregion

        #region 基元属性
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int64 _ID;
        partial void OnIDChanging(global::System.Int64 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> HOSTID
        {
            get
            {
                return _HOSTID;
            }
            set
            {
                OnHOSTIDChanging(value);
                ReportPropertyChanging("HOSTID");
                _HOSTID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("HOSTID");
                OnHOSTIDChanged();
            }
        }
        private Nullable<global::System.Int64> _HOSTID;
        partial void OnHOSTIDChanging(Nullable<global::System.Int64> value);
        partial void OnHOSTIDChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NAME
        {
            get
            {
                return _NAME;
            }
            set
            {
                OnNAMEChanging(value);
                ReportPropertyChanging("NAME");
                _NAME = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NAME");
                OnNAMEChanged();
            }
        }
        private global::System.String _NAME;
        partial void OnNAMEChanging(global::System.String value);
        partial void OnNAMEChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> TOTAL
        {
            get
            {
                return _TOTAL;
            }
            set
            {
                OnTOTALChanging(value);
                ReportPropertyChanging("TOTAL");
                _TOTAL = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TOTAL");
                OnTOTALChanged();
            }
        }
        private Nullable<global::System.Int64> _TOTAL;
        partial void OnTOTALChanging(Nullable<global::System.Int64> value);
        partial void OnTOTALChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> USED
        {
            get
            {
                return _USED;
            }
            set
            {
                OnUSEDChanging(value);
                ReportPropertyChanging("USED");
                _USED = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("USED");
                OnUSEDChanged();
            }
        }
        private Nullable<global::System.Int64> _USED;
        partial void OnUSEDChanging(Nullable<global::System.Int64> value);
        partial void OnUSEDChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> FREE
        {
            get
            {
                return _FREE;
            }
            set
            {
                OnFREEChanging(value);
                ReportPropertyChanging("FREE");
                _FREE = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FREE");
                OnFREEChanged();
            }
        }
        private Nullable<global::System.Int64> _FREE;
        partial void OnFREEChanging(Nullable<global::System.Int64> value);
        partial void OnFREEChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> PUSER
        {
            get
            {
                return _PUSER;
            }
            set
            {
                OnPUSERChanging(value);
                ReportPropertyChanging("PUSER");
                _PUSER = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PUSER");
                OnPUSERChanged();
            }
        }
        private Nullable<global::System.Int64> _PUSER;
        partial void OnPUSERChanging(Nullable<global::System.Int64> value);
        partial void OnPUSERChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> PFREE
        {
            get
            {
                return _PFREE;
            }
            set
            {
                OnPFREEChanging(value);
                ReportPropertyChanging("PFREE");
                _PFREE = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("PFREE");
                OnPFREEChanged();
            }
        }
        private Nullable<global::System.Int64> _PFREE;
        partial void OnPFREEChanging(Nullable<global::System.Int64> value);
        partial void OnPFREEChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String AUTOEXTEND
        {
            get
            {
                return _AUTOEXTEND;
            }
            set
            {
                OnAUTOEXTENDChanging(value);
                ReportPropertyChanging("AUTOEXTEND");
                _AUTOEXTEND = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("AUTOEXTEND");
                OnAUTOEXTENDChanged();
            }
        }
        private global::System.String _AUTOEXTEND;
        partial void OnAUTOEXTENDChanging(global::System.String value);
        partial void OnAUTOEXTENDChanged();
    
        /// <summary>
        /// 没有元数据文档可用。
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> SAVETIME
        {
            get
            {
                return _SAVETIME;
            }
            set
            {
                OnSAVETIMEChanging(value);
                ReportPropertyChanging("SAVETIME");
                _SAVETIME = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SAVETIME");
                OnSAVETIMEChanged();
            }
        }
        private Nullable<global::System.DateTime> _SAVETIME;
        partial void OnSAVETIMEChanging(Nullable<global::System.DateTime> value);
        partial void OnSAVETIMEChanged();

        #endregion

    
    }

    #endregion

    
}