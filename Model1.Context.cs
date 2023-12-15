﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace УП
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UCHEEntities2 : DbContext
    {
        public UCHEEntities2()
            : base("name=UCHEEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<apteka> apteka { get; set; }
        public virtual DbSet<aptekapost> aptekapost { get; set; }
        public virtual DbSet<aptekasklad> aptekasklad { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    
        public virtual ObjectResult<GetSupplyDetails_Result> GetSupplyDetails(Nullable<int> minSupplyCode)
        {
            var minSupplyCodeParameter = minSupplyCode.HasValue ?
                new ObjectParameter("minSupplyCode", minSupplyCode) :
                new ObjectParameter("minSupplyCode", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSupplyDetails_Result>("GetSupplyDetails", minSupplyCodeParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Вывести_Даты_Поставок_С_Большим_Продажами_Result> Вывести_Даты_Поставок_С_Большим_Продажами(Nullable<int> код_лекарства, Nullable<int> количество_проданного)
        {
            var код_лекарстваParameter = код_лекарства.HasValue ?
                new ObjectParameter("Код_лекарства", код_лекарства) :
                new ObjectParameter("Код_лекарства", typeof(int));
    
            var количество_проданногоParameter = количество_проданного.HasValue ?
                new ObjectParameter("Количество_проданного", количество_проданного) :
                new ObjectParameter("Количество_проданного", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Вывести_Даты_Поставок_С_Большим_Продажами_Result>("Вывести_Даты_Поставок_С_Большим_Продажами", код_лекарстваParameter, количество_проданногоParameter);
        }
    
        public virtual ObjectResult<Вывести_Лекарства_ПоПоказанию_Result> Вывести_Лекарства_ПоПоказанию(string показание)
        {
            var показаниеParameter = показание != null ?
                new ObjectParameter("Показание", показание) :
                new ObjectParameter("Показание", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Вывести_Лекарства_ПоПоказанию_Result>("Вывести_Лекарства_ПоПоказанию", показаниеParameter);
        }
    
        public virtual ObjectResult<Вывести_Лекарства_С_Условием_Result> Вывести_Лекарства_С_Условием(Nullable<int> количество_в_упаковке, Nullable<int> минимальный_Код_лекарства)
        {
            var количество_в_упаковкеParameter = количество_в_упаковке.HasValue ?
                new ObjectParameter("Количество_в_упаковке", количество_в_упаковке) :
                new ObjectParameter("Количество_в_упаковке", typeof(int));
    
            var минимальный_Код_лекарстваParameter = минимальный_Код_лекарства.HasValue ?
                new ObjectParameter("Минимальный_Код_лекарства", минимальный_Код_лекарства) :
                new ObjectParameter("Минимальный_Код_лекарства", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Вывести_Лекарства_С_Условием_Result>("Вывести_Лекарства_С_Условием", количество_в_упаковкеParameter, минимальный_Код_лекарстваParameter);
        }
    }
}
