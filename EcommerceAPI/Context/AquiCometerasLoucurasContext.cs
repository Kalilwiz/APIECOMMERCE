using System;
using System.Collections.Generic;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Context;

public partial class AquiCometerasLoucurasContext : DbContext
{
    public AquiCometerasLoucurasContext()
    {
    }

    public AquiCometerasLoucurasContext(DbContextOptions<AquiCometerasLoucurasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ItemDoPedido> Clientes { get; set; }

    public virtual DbSet<ItemDoPedido> ItemDoPedidos { get; set; }

    public virtual DbSet<ItemDoPedido> Pagamentos { get; set; }

    public virtual DbSet<ItemDoPedido> Pedidos { get; set; }

    public virtual DbSet<ItemDoPedido> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NOTE24-S28\\SQLEXPRESS;Initial Catalog=AquiCometerasLoucuras;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemDoPedido>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__D59466424BBD69C7");

            entity.ToTable("Cliente");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ItemDoPedido>(entity =>
        {
            entity.HasKey(e => e.IdItemDoPedido).HasName("PK__ItemDoPe__A2261A852B4A1E68");

            entity.ToTable("ItemDoPedido");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.ItemDoPedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__ItemDoPed__IdPed__534D60F1");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.ItemDoPedidos)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__ItemDoPed__IdPro__5441852A");
        });

        modelBuilder.Entity<ItemDoPedido>(entity =>
        {
            entity.HasKey(e => e.IdPagamento).HasName("PK__Pagament__D474651E07F34D14");

            entity.ToTable("Pagamento");

            entity.Property(e => e.FormaPagamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.Pagamentos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK__Pagamento__IdPed__4E88ABD4");
        });

        modelBuilder.Entity<ItemDoPedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PK__Pedido__9D335DC361496673");

            entity.ToTable("Pedido");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(18, 6)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Pedido__IdClient__4BAC3F29");
        });

        modelBuilder.Entity<ItemDoPedido>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produto__2E883C23BBDE593E");

            entity.ToTable("Produto");

            entity.Property(e => e.CategoriaProduto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Imagem)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Preco).HasColumnType("decimal(18, 6)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
