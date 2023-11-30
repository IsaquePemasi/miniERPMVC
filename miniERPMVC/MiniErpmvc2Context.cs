using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using miniERPMVC.Models;

namespace miniERPMVC;

public partial class MiniErpmvc2Context : DbContext
{
    public MiniErpmvc2Context()
    {
    }

    public MiniErpmvc2Context(DbContextOptions<MiniErpmvc2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Fornecedore> Fornecedores { get; set; }

    public virtual DbSet<NotasFiscai> NotasFiscais { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Database=MiniERPMVC2;Trusted_Connection=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__677F38F508B9BEE5");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedNever()
                .HasColumnName("id_cliente");
            entity.Property(e => e.EnderecoCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("endereco_cliente");
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome_cliente");
            entity.Property(e => e.TelefoneCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone_cliente");
        });

        modelBuilder.Entity<Fornecedore>(entity =>
        {
            entity.HasKey(e => e.IdFornecedor).HasName("PK__Forneced__6C477092507559A3");

            entity.Property(e => e.IdFornecedor)
                .ValueGeneratedNever()
                .HasColumnName("id_fornecedor");
            entity.Property(e => e.EnderecoFornecedor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("endereco_fornecedor");
            entity.Property(e => e.NomeFornecedor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome_fornecedor");
            entity.Property(e => e.TelefoneFornecedor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone_fornecedor");
        });

        modelBuilder.Entity<NotasFiscai>(entity =>
        {
            entity.HasKey(e => e.IdNota).HasName("PK__NotasFis__26991D8C2339BA99");

            entity.Property(e => e.IdNota)
                .ValueGeneratedNever()
                .HasColumnName("id_nota");
            entity.Property(e => e.DataEmissao)
                .HasColumnType("date")
                .HasColumnName("data_emissao");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdProduto).HasColumnName("id_produto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.NotasFiscais)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__NotasFisc__id_cl__3D5E1FD2");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.NotasFiscais)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK__NotasFisc__id_pr__3E52440B");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("PK__Produtos__BA38A6B8CB118421");

            entity.Property(e => e.IdProduto)
                .ValueGeneratedNever()
                .HasColumnName("id_produto");
            entity.Property(e => e.DescricaoProduto)
                .HasColumnType("text")
                .HasColumnName("descricao_produto");
            entity.Property(e => e.IdFornecedor).HasColumnName("id_fornecedor");
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome_produto");
            entity.Property(e => e.PrecoProduto)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("preco_produto");

            entity.HasOne(d => d.IdFornecedorNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdFornecedor)
                .HasConstraintName("FK__Produtos__id_for__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
