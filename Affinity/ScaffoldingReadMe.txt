To Create the database and tables, in the Package Manager Console type in:
update-database -verbose -Context ApplicationDbContext

If an update has been made to the ApplicationDbContext, build new migration with the command:
Add-Migration CreateUpdateApplicationSchema -Context ApplicationDbContext
Add-Migration CreateApplicationSchema -Context ApplicationDbContext