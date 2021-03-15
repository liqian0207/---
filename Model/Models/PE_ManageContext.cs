using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Model.Models
{
    public partial class PE_ManageContext : DbContext
    {
        public PE_ManageContext()
        {
        }

        public PE_ManageContext(DbContextOptions<PE_ManageContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PE_Customer> PeCustomers { get; set; }
        public virtual DbSet<PeExChestXRay> PeExChestXRays { get; set; }
        public virtual DbSet<PE_EX_Electrocardiogram> PeExElectrocardiograms { get; set; }
        public virtual DbSet<PE_EX_InterMedicine> PeExInterMedicines { get; set; }
        public virtual DbSet<PE_EX_LiverFunction> PeExLiverFunctions { get; set; }
        public virtual DbSet<PE_EX_Ordinary> PeExOrdinaries { get; set; }
        public virtual DbSet<PE_EX_RoutineBlood> PeExRoutineBloods { get; set; }
        public virtual DbSet<PE_EX_Surgery> PeExSurgeries { get; set; }
        public virtual DbSet<PE_EX_Urinalysis> PeExUrinalyses { get; set; }
        public virtual DbSet<PE_Item> PeItems { get; set; }
        public virtual DbSet<PE_Sheet> PeSheets { get; set; }
        public virtual DbSet<PE_Type> PeTypes { get; set; }
        public virtual DbSet<View_PE_Sheep> ViewPeSheeps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PE_Manage;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<PE_Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("PE_Customer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerAddress).HasColumnType("text");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CustomerPhone)
                    .HasMaxLength(11)
                    .IsFixedLength(true)
                    .HasComment("电话");

                entity.Property(e => e.CustomerSex)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.CustomerType).HasComment("用户类型（来自Item表）");
            });

            modelBuilder.Entity<PeExChestXRay>(entity =>
            {
                entity.ToTable("PE_EX_ChestX-ray");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("胸透");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RepresentationTypeId)
                    .HasColumnName("RepresentationTypeID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PE_EX_Electrocardiogram>(entity =>
            {
                entity.ToTable("PE_EX_Electrocardiogram");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("心电图");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RepresentationTypeId)
                    .HasColumnName("RepresentationTypeID")
                    .HasDefaultValueSql("((0))")
                    .HasComment("发现有无心率失常，缺血性心脏病，心肌病变等。");
            });

            modelBuilder.Entity<PE_EX_InterMedicine>(entity =>
            {
                entity.ToTable("PE_EX_InterMedicine");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("内科检查");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasComment("检查心肺有无杂音，杂音性质，心率是否规律，肝脾是否增大，腹部有无包块，双肾有无叩痛");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RepresentationTypeId)
                    .HasColumnName("RepresentationTypeID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PE_EX_LiverFunction>(entity =>
            {
                entity.ToTable("PE_EX_LiverFunction");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("肝功能");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasComment("了解肝脏功能，肝胆道阻塞，急性溶血性疾病及全身情况");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RepresentationTypeId)
                    .HasColumnName("RepresentationTypeID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PE_EX_Ordinary>(entity =>
            {
                entity.ToTable("PE_EX_Ordinary");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("一般检查");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasComment("检测身高体重血压，了解身体的基本信息，计算体重指数，判断是否朝中，肥胖，消瘦");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RepresentationTypeId)
                    .HasColumnName("RepresentationTypeID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PE_EX_RoutineBlood>(entity =>
            {
                entity.ToTable("PE_EX_RoutineBlood");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(15);

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasComment("了解是否贫血及凝血功能等；排除炎症感染，血癌等疾病");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RepresentationTypeId)
                    .HasColumnName("RepresentationTypeID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PE_EX_Surgery>(entity =>
            {
                entity.ToTable("PE_EX_Surgery");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("外科检查");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasComment("皮肤疾病，皮炎，湿疹，过敏性炎症等。淋巴结肿大，炎症，结核，肿瘤等。甲状腺炎症，甲亢，囊肿，肿瘤，癌等。胆囊炎症，结石，癌等。");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RepresentationTypeId)
                    .HasColumnName("RepresentationTypeID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PE_EX_Urinalysis>(entity =>
            {
                entity.ToTable("PE_EX_Urinalysis");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("尿常规");

                entity.Property(e => e.Name).HasMaxLength(10);

                entity.Property(e => e.Note)
                    .HasColumnType("text")
                    .HasComment("了解肾脏功能，初步排除肾炎，糖尿病，泌尿道炎症感染等；协助诊断黄瘟肝炎，溶血等");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.RepresentationTypeId)
                    .HasColumnName("RepresentationTypeID")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<PE_Item>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("PE_Item");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(20)
                    .HasComment("明细类型名");

                entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");

                entity.Property(e => e.ItemTypeName)
                    .HasMaxLength(20)
                    .HasComment("总类型名");
            });

            modelBuilder.Entity<PE_Sheet>(entity =>
            {
                entity.HasKey(e => e.PeId);

                entity.ToTable("PE_Sheet");

                entity.Property(e => e.PeId)
                    .HasColumnName("PE_ID")
                    .HasComment("体检单ID");

                entity.Property(e => e.CreateTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeleteTime).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDelete)
                    .HasDefaultValueSql("((0))")
                    .HasComment("0-未删除；1-已删除");

                entity.Property(e => e.PeCustomerId)
                    .HasColumnName("PE_CustomerID")
                    .HasComment("顾客ID");

                entity.Property(e => e.PeNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("PE_Number")
                    .HasComment("体检单编号");

                entity.Property(e => e.PeType)
                    .HasColumnName("PE_Type")
                    .HasComment("检查类型（PE_Type）");
            });

            modelBuilder.Entity<PE_Type>(entity =>
            {
                entity.ToTable("PE_Type");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasComment("体检类型");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<View_PE_Sheep>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_PE_Sheep");

                entity.Property(e => e.CustomerName).HasMaxLength(20);

                entity.Property(e => e.CustomerSex).HasMaxLength(1);

                entity.Property(e => e.PeId).HasColumnName("PE_ID");

                entity.Property(e => e.PeName)
                    .HasMaxLength(10)
                    .HasColumnName("PE_Name");

                entity.Property(e => e.PeNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("PE_Number");

                entity.Property(e => e.PeType).HasColumnName("PE_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
