    public string connectionString { get; set; }
    public string DatabaseName { get; set; }
    private MySQL.Extension.Extensiones.WithNoLockSqlInterceptor withNoLock = new MySQL.Extension.Extensiones.WithNoLockSqlInterceptor();
    public KalanDB(string connectionString) : base(GetOptions(connectionString))
    {
        this.connectionString = connectionString;
        OnConfiguring(new DbContextOptionsBuilder());
    }
    public KalanDB(DbContextOptions<KalanDB> options) : base(options)
    {
        var sqlServerOptionsExtension = options.FindExtension<MySql.EntityFrameworkCore.Infrastructure.Internal.MySQLOptionsExtension>();
        if (sqlServerOptionsExtension != null)
        {
            this.connectionString = sqlServerOptionsExtension.ConnectionString;
        }
    }
    private static DbContextOptions GetOptions(string connectionString)
    {
        return new DbContextOptionsBuilder().UseMySQL(connectionString).Options;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
        DatabaseName = con.Database;
        optionsBuilder.UseLazyLoadingProxies()
        .UseMySQL(connectionString);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        optionsBuilder.AddInterceptors(withNoLock);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new MySQL.Extension.Extensiones.BlankTriggerAddingConvention());
    }



Scaffold-DbContext "Server=10.20.30.1; Database=kalan_copy; user=thinks; password=thinks;" Pomelo.EntityFrameworkCore.MySql -OutputDir Entidades -ContextDir Contextos -Context KalanDB -force -UseDatabaseNames -NoPluralize
Scaffold-DbContext "Server=localhost; Database=kalan; user=thinks; password=thinks;" Pomelo.EntityFrameworkCore.MySql -OutputDir Entidades -ContextDir Contextos -Context KalanDB -force -UseDatabaseNames -NoPluralize