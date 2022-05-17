using FluentMigrator;
using System;

namespace Api.Infra.Data.DapperMigration
{
    [Migration(1)]
    public class ProdutoMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Produto")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Nome").AsString()
                .WithColumn("DataCadastro").AsDateTime2().Nullable()
                .WithColumn("DataAtualizacao").AsDateTime2().Nullable()
                .WithColumn("DataExclusao").AsDateTime2().Nullable()
                .WithColumn("CategoriaId").AsGuid().NotNullable().ForeignKey("Categoria", "Id");
        }
        public override void Down()
        {
            Delete.Table("Produto");
        }
    }
}
