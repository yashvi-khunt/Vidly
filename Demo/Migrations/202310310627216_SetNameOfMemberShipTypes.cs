namespace Demo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name = 'Pay as You Go' Where Id=1");
            Sql("Update MembershipTypes set Name = 'Monthly' Where Id=2");
            Sql("Update MembershipTypes set Name = 'Quarterly' Where Id=3");
            Sql("Update MembershipTypes set Name = 'Annually' Where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
