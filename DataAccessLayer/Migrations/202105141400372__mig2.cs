﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterAbout", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterAbout");
        }
    }
}
