using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infra.Data.DapperMigration
{
    [Migration(2)]
    public class CategoriaMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("Categoria");
        }

        public override void Up()
        {
            Create.Table("Categoria")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Nome").AsString(60).NotNullable()
                .WithColumn("Descricao").AsString(90).NotNullable()
                .WithColumn("DataCadastro").AsDateTime2().Nullable()
                .WithColumn("DataAtualizacao").AsDateTime2().Nullable()
                .WithColumn("DataExclusao").AsDateTime2().Nullable();
        }
    }
}
