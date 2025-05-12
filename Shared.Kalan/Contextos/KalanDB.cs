using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;
using Shared.Kalan.Entidades;

namespace Shared.Kalan.Contextos;

public partial class KalanDB : DbContext
{
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

    public virtual DbSet<aspnetreportes> aspnetreportes { get; set; }

    public virtual DbSet<aspnetroles> aspnetroles { get; set; }

    public virtual DbSet<aspnetrolreporte> aspnetrolreporte { get; set; }

    public virtual DbSet<aspnetuserclaims> aspnetuserclaims { get; set; }

    public virtual DbSet<aspnetuserlogins> aspnetuserlogins { get; set; }

    public virtual DbSet<aspnetusers> aspnetusers { get; set; }

    public virtual DbSet<aspnetusertokens> aspnetusertokens { get; set; }

    public virtual DbSet<cfdi_acuentaterceros> cfdi_acuentaterceros { get; set; }

    public virtual DbSet<cfdi_addenda> cfdi_addenda { get; set; }

    public virtual DbSet<cfdi_aerolineas> cfdi_aerolineas { get; set; }

    public virtual DbSet<cfdi_autotransporte> cfdi_autotransporte { get; set; }

    public virtual DbSet<cfdi_cancelacion_motivos> cfdi_cancelacion_motivos { get; set; }

    public virtual DbSet<cfdi_cantidadtransporta> cfdi_cantidadtransporta { get; set; }

    public virtual DbSet<cfdi_cargo> cfdi_cargo { get; set; }

    public virtual DbSet<cfdi_cartaporte> cfdi_cartaporte { get; set; }

    public virtual DbSet<cfdi_cfdiregistrofiscal> cfdi_cfdiregistrofiscal { get; set; }

    public virtual DbSet<cfdi_cfdirelacionado> cfdi_cfdirelacionado { get; set; }

    public virtual DbSet<cfdi_cfdirelacionados> cfdi_cfdirelacionados { get; set; }

    public virtual DbSet<cfdi_comercioexterior> cfdi_comercioexterior { get; set; }

    public virtual DbSet<cfdi_compensacionsaldosafavor> cfdi_compensacionsaldosafavor { get; set; }

    public virtual DbSet<cfdi_complemento> cfdi_complemento { get; set; }

    public virtual DbSet<cfdi_complementoconcepto> cfdi_complementoconcepto { get; set; }

    public virtual DbSet<cfdi_comprobante> cfdi_comprobante { get; set; }

    public virtual DbSet<cfdi_concepto> cfdi_concepto { get; set; }

    public virtual DbSet<cfdi_conceptoaddenda> cfdi_conceptoaddenda { get; set; }

    public virtual DbSet<cfdi_conceptos> cfdi_conceptos { get; set; }

    public virtual DbSet<cfdi_conceptosaddenda> cfdi_conceptosaddenda { get; set; }

    public virtual DbSet<cfdi_cuentapredial> cfdi_cuentapredial { get; set; }

    public virtual DbSet<cfdi_customized> cfdi_customized { get; set; }

    public virtual DbSet<cfdi_deduccion> cfdi_deduccion { get; set; }

    public virtual DbSet<cfdi_deducciones> cfdi_deducciones { get; set; }

    public virtual DbSet<cfdi_destinatario> cfdi_destinatario { get; set; }

    public virtual DbSet<cfdi_divisas> cfdi_divisas { get; set; }

    public virtual DbSet<cfdi_doctorelacionado> cfdi_doctorelacionado { get; set; }

    public virtual DbSet<cfdi_documentacionaduanera> cfdi_documentacionaduanera { get; set; }

    public virtual DbSet<cfdi_domicilio> cfdi_domicilio { get; set; }

    public virtual DbSet<cfdi_donatarias> cfdi_donatarias { get; set; }

    public virtual DbSet<cfdi_emisor> cfdi_emisor { get; set; }

    public virtual DbSet<cfdi_emisor_1> cfdi_emisor_1 { get; set; }

    public virtual DbSet<cfdi_encabezado> cfdi_encabezado { get; set; }

    public virtual DbSet<cfdi_error> cfdi_error { get; set; }

    public virtual DbSet<cfdi_figuratransporte> cfdi_figuratransporte { get; set; }

    public virtual DbSet<cfdi_formas_pago> cfdi_formas_pago { get; set; }

    public virtual DbSet<cfdi_horasextra> cfdi_horasextra { get; set; }

    public virtual DbSet<cfdi_identificacionvehicular> cfdi_identificacionvehicular { get; set; }

    public virtual DbSet<cfdi_impuestos> cfdi_impuestos { get; set; }

    public virtual DbSet<cfdi_impuestosdr> cfdi_impuestosdr { get; set; }

    public virtual DbSet<cfdi_impuestoslocales> cfdi_impuestoslocales { get; set; }

    public virtual DbSet<cfdi_impuestosp> cfdi_impuestosp { get; set; }

    public virtual DbSet<cfdi_incapacidad> cfdi_incapacidad { get; set; }

    public virtual DbSet<cfdi_incapacidades> cfdi_incapacidades { get; set; }

    public virtual DbSet<cfdi_informacionaduanera> cfdi_informacionaduanera { get; set; }

    public virtual DbSet<cfdi_informacionfiscaltercero> cfdi_informacionfiscaltercero { get; set; }

    public virtual DbSet<cfdi_informacionglobal> cfdi_informacionglobal { get; set; }

    public virtual DbSet<cfdi_insteducativas> cfdi_insteducativas { get; set; }

    public virtual DbSet<cfdi_mercancia> cfdi_mercancia { get; set; }

    public virtual DbSet<cfdi_mercancias> cfdi_mercancias { get; set; }

    public virtual DbSet<cfdi_nomina> cfdi_nomina { get; set; }

    public virtual DbSet<cfdi_otropago> cfdi_otropago { get; set; }

    public virtual DbSet<cfdi_otroscargos> cfdi_otroscargos { get; set; }

    public virtual DbSet<cfdi_otrospagos> cfdi_otrospagos { get; set; }

    public virtual DbSet<cfdi_pago> cfdi_pago { get; set; }

    public virtual DbSet<cfdi_pagos> cfdi_pagos { get; set; }

    public virtual DbSet<cfdi_parte> cfdi_parte { get; set; }

    public virtual DbSet<cfdi_partestransporte> cfdi_partestransporte { get; set; }

    public virtual DbSet<cfdi_pedimentos> cfdi_pedimentos { get; set; }

    public virtual DbSet<cfdi_percepcion> cfdi_percepcion { get; set; }

    public virtual DbSet<cfdi_percepciones> cfdi_percepciones { get; set; }

    public virtual DbSet<cfdi_porcuentadeterceros> cfdi_porcuentadeterceros { get; set; }

    public virtual DbSet<cfdi_receptor> cfdi_receptor { get; set; }

    public virtual DbSet<cfdi_receptor_1> cfdi_receptor_1 { get; set; }

    public virtual DbSet<cfdi_remolque> cfdi_remolque { get; set; }

    public virtual DbSet<cfdi_remolques> cfdi_remolques { get; set; }

    public virtual DbSet<cfdi_retencion> cfdi_retencion { get; set; }

    public virtual DbSet<cfdi_retencion_1> cfdi_retencion_1 { get; set; }

    public virtual DbSet<cfdi_retenciondr> cfdi_retenciondr { get; set; }

    public virtual DbSet<cfdi_retenciones> cfdi_retenciones { get; set; }

    public virtual DbSet<cfdi_retencionesdr> cfdi_retencionesdr { get; set; }

    public virtual DbSet<cfdi_retencionesp> cfdi_retencionesp { get; set; }

    public virtual DbSet<cfdi_retencionp> cfdi_retencionp { get; set; }

    public virtual DbSet<cfdi_seguros> cfdi_seguros { get; set; }

    public virtual DbSet<cfdi_separacionindemnizacion> cfdi_separacionindemnizacion { get; set; }

    public virtual DbSet<cfdi_subsidioalempleo> cfdi_subsidioalempleo { get; set; }

    public virtual DbSet<cfdi_talmaaddenda> cfdi_talmaaddenda { get; set; }

    public virtual DbSet<cfdi_terceros_impuestos> cfdi_terceros_impuestos { get; set; }

    public virtual DbSet<cfdi_terceros_retenciones> cfdi_terceros_retenciones { get; set; }

    public virtual DbSet<cfdi_terceros_traslado> cfdi_terceros_traslado { get; set; }

    public virtual DbSet<cfdi_terceros_traslados> cfdi_terceros_traslados { get; set; }

    public virtual DbSet<cfdi_timbrefiscaldigital> cfdi_timbrefiscaldigital { get; set; }

    public virtual DbSet<cfdi_tiposfigura> cfdi_tiposfigura { get; set; }

    public virtual DbSet<cfdi_totales> cfdi_totales { get; set; }

    public virtual DbSet<cfdi_traslado> cfdi_traslado { get; set; }

    public virtual DbSet<cfdi_trasladodr> cfdi_trasladodr { get; set; }

    public virtual DbSet<cfdi_trasladop> cfdi_trasladop { get; set; }

    public virtual DbSet<cfdi_traslados> cfdi_traslados { get; set; }

    public virtual DbSet<cfdi_trasladosdr> cfdi_trasladosdr { get; set; }

    public virtual DbSet<cfdi_trasladoslocales> cfdi_trasladoslocales { get; set; }

    public virtual DbSet<cfdi_trasladosp> cfdi_trasladosp { get; set; }

    public virtual DbSet<cfdi_ubicacion> cfdi_ubicacion { get; set; }

    public virtual DbSet<cfdi_ubicaciones> cfdi_ubicaciones { get; set; }

    public virtual DbSet<cfdi_usos_cfdi> cfdi_usos_cfdi { get; set; }

    public virtual DbSet<cfdi_valesdedespensa> cfdi_valesdedespensa { get; set; }

    public virtual DbSet<cfdi_valesdedespensa_concepto> cfdi_valesdedespensa_concepto { get; set; }

    public virtual DbSet<cfdi_valesdedespensa_conceptos> cfdi_valesdedespensa_conceptos { get; set; }

    public virtual DbSet<th_articulos> th_articulos { get; set; }

    public virtual DbSet<th_articulos_proveedor> th_articulos_proveedor { get; set; }

    public virtual DbSet<th_articulos_tipos> th_articulos_tipos { get; set; }

    public virtual DbSet<th_articulos_unidad> th_articulos_unidad { get; set; }

    public virtual DbSet<th_bancos> th_bancos { get; set; }

    public virtual DbSet<th_catproductosat> th_catproductosat { get; set; }

    public virtual DbSet<th_cfdi_metadata> th_cfdi_metadata { get; set; }

    public virtual DbSet<th_clientes> th_clientes { get; set; }

    public virtual DbSet<th_compra_factura> th_compra_factura { get; set; }

    public virtual DbSet<th_compra_factura_detalle> th_compra_factura_detalle { get; set; }

    public virtual DbSet<th_concilacion> th_concilacion { get; set; }

    public virtual DbSet<th_conciliacion_detalle> th_conciliacion_detalle { get; set; }

    public virtual DbSet<th_condicionescredito> th_condicionescredito { get; set; }

    public virtual DbSet<th_cont_cuenta_categoria> th_cont_cuenta_categoria { get; set; }

    public virtual DbSet<th_contabilidad_configuracion> th_contabilidad_configuracion { get; set; }

    public virtual DbSet<th_contabilidad_cuenta> th_contabilidad_cuenta { get; set; }

    public virtual DbSet<th_contabilidad_cuenta_categoria> th_contabilidad_cuenta_categoria { get; set; }

    public virtual DbSet<th_contabilidad_cuenta_configuracion> th_contabilidad_cuenta_configuracion { get; set; }

    public virtual DbSet<th_contabilidad_trabajo> th_contabilidad_trabajo { get; set; }

    public virtual DbSet<th_contabilidad_trabajo_detalle> th_contabilidad_trabajo_detalle { get; set; }

    public virtual DbSet<th_cuentascobrar> th_cuentascobrar { get; set; }

    public virtual DbSet<th_cuentascobraraplicaciones> th_cuentascobraraplicaciones { get; set; }

    public virtual DbSet<th_cuentaspagar> th_cuentaspagar { get; set; }

    public virtual DbSet<th_cuentaspagaraplicaciones> th_cuentaspagaraplicaciones { get; set; }

    public virtual DbSet<th_egresos> th_egresos { get; set; }

    public virtual DbSet<th_facturacion_sellos> th_facturacion_sellos { get; set; }

    public virtual DbSet<th_facturacion_series> th_facturacion_series { get; set; }

    public virtual DbSet<th_formapago> th_formapago { get; set; }

    public virtual DbSet<th_impuestos> th_impuestos { get; set; }

    public virtual DbSet<th_ingresos> th_ingresos { get; set; }

    public virtual DbSet<th_ingresos_complemento> th_ingresos_complemento { get; set; }

    public virtual DbSet<th_ingresos_complemento_detalle> th_ingresos_complemento_detalle { get; set; }

    public virtual DbSet<th_ingresos_origen> th_ingresos_origen { get; set; }

    public virtual DbSet<th_metodopago> th_metodopago { get; set; }

    public virtual DbSet<th_monedas> th_monedas { get; set; }

    public virtual DbSet<th_paises> th_paises { get; set; }

    public virtual DbSet<th_plan_impuestos> th_plan_impuestos { get; set; }

    public virtual DbSet<th_plan_impuestos_detalle> th_plan_impuestos_detalle { get; set; }

    public virtual DbSet<th_proveedores> th_proveedores { get; set; }

    public virtual DbSet<th_regimenfiscal> th_regimenfiscal { get; set; }

    public virtual DbSet<th_sat_control> th_sat_control { get; set; }

    public virtual DbSet<th_sat_metadata> th_sat_metadata { get; set; }

    public virtual DbSet<th_satsolicitudes> th_satsolicitudes { get; set; }

    public virtual DbSet<th_satsolicitudrespuesta> th_satsolicitudrespuesta { get; set; }

    public virtual DbSet<th_tiposcambio> th_tiposcambio { get; set; }

    public virtual DbSet<th_usocfdi> th_usocfdi { get; set; }

    public virtual DbSet<th_venta_factura> th_venta_factura { get; set; }

    public virtual DbSet<th_venta_factura_comercio> th_venta_factura_comercio { get; set; }

    public virtual DbSet<th_venta_factura_comercio_emisor> th_venta_factura_comercio_emisor { get; set; }

    public virtual DbSet<th_venta_factura_comercio_mercancias> th_venta_factura_comercio_mercancias { get; set; }

    public virtual DbSet<th_venta_factura_comercio_receptor> th_venta_factura_comercio_receptor { get; set; }

    public virtual DbSet<th_venta_factura_detalle> th_venta_factura_detalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<aspnetreportes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Stored).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<aspnetroles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
            entity.Property(e => e.UsuarioModifica)
                .HasMaxLength(50)
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");
        });

        modelBuilder.Entity<aspnetrolreporte>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.IdReporte, "aspnetrolreporte_aspnetreportes_FK");

            entity.HasIndex(e => e.IdRol, "aspnetrolreporte_aspnetroles_FK");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.IdReporte).HasMaxLength(36);
            entity.Property(e => e.IdRol)
                .HasMaxLength(36)
                .UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);

            entity.HasOne(d => d.IdReporteNavigation).WithMany()
                .HasForeignKey(d => d.IdReporte)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aspnetrolreporte_aspnetreportes_FK");

            entity.HasOne(d => d.IdRolNavigation).WithMany()
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aspnetrolreporte_aspnetroles_FK");
        });

        modelBuilder.Entity<aspnetuserclaims>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.UserId, "ApplicationUser_Claims");

            entity.HasIndex(e => e.Id, "Id").IsUnique();

            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.aspnetuserclaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("ApplicationUser_Claims");
        });

        modelBuilder.Entity<aspnetuserlogins>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.HasIndex(e => e.UserId, "ApplicationUser_Logins");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.aspnetuserlogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("ApplicationUser_Logins");
        });

        modelBuilder.Entity<aspnetusers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.ConcurrencyStamp).HasMaxLength(256);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEnd).HasColumnType("datetime");
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Role).WithMany(p => p.User)
                .UsingEntity<Dictionary<string, object>>(
                    "aspnetuserroles",
                    r => r.HasOne<aspnetroles>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("aspnetuserroles_aspnetroles_FK"),
                    l => l.HasOne<aspnetusers>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("ApplicationUser_Roles"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .HasCharSet("latin1")
                            .UseCollation("latin1_swedish_ci");
                        j.HasIndex(new[] { "RoleId" }, "IdentityRole_Users");
                        j.IndexerProperty<string>("UserId").HasMaxLength(128);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                    });
        });

        modelBuilder.Entity<aspnetusertokens>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.Property(e => e.UserId).HasMaxLength(128);
            entity.Property(e => e.LoginProvider).HasMaxLength(127);
            entity.Property(e => e.Name).HasMaxLength(127);
        });

        modelBuilder.Entity<cfdi_acuentaterceros>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DomicilioFiscalACuentaTerceros).HasPrecision(19, 5);
            entity.Property(e => e.NombreACuentaTerceros)
                .HasMaxLength(60)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RegimenFiscalACuentaTerceros).HasPrecision(19, 5);
            entity.Property(e => e.RfcACuentaTerceros)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_addenda>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_aerolineas>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TUA).HasPrecision(19, 5);
            entity.Property(e => e.Version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_autotransporte>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.NumPermisoSCT)
                .HasMaxLength(40)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PermSCT)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_cancelacion_motivos>(entity =>
        {
            entity.HasKey(e => e.Clave).HasName("PRIMARY");

            entity.Property(e => e.Clave)
                .HasMaxLength(2)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(74)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_cantidadtransporta>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cantidad).HasPrecision(19, 5);
            entity.Property(e => e.IDDestino)
                .HasMaxLength(11)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IDOrigen)
                .HasMaxLength(11)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_cargo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CodigoCargo)
                .HasMaxLength(11)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Importe).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_cartaporte>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EntradaSalidaMerc)
                .HasMaxLength(9)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IdCCP)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PaisOrigenDestino)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RegimenAduanero)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TotalDistRec).HasPrecision(19, 5);
            entity.Property(e => e.TranspInternac)
                .HasMaxLength(2)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ViaEntradaSalida).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_cfdiregistrofiscal>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Folio)
                .HasMaxLength(22)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_cfdirelacionado>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.UUID)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_cfdirelacionados>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TipoRelacion)
                .HasMaxLength(2)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_comercioexterior>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CertificadoOrigen).HasMaxLength(255);
            entity.Property(e => e.ClaveDePedimento).HasMaxLength(255);
            entity.Property(e => e.Incoterm).HasMaxLength(255);
            entity.Property(e => e.Observaciones).HasMaxLength(255);
            entity.Property(e => e.TipoCambioUSD).HasMaxLength(255);
            entity.Property(e => e.TotalUSD).HasMaxLength(255);
            entity.Property(e => e.Version).HasMaxLength(255);
        });

        modelBuilder.Entity<cfdi_compensacionsaldosafavor>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Año).HasPrecision(19, 5);
            entity.Property(e => e.RemanenteSalFav).HasPrecision(19, 5);
            entity.Property(e => e.SaldoAFavor).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_complemento>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_complementoconcepto>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_comprobante>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Certificado)
                .HasMaxLength(4000)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CondicionesDePago)
                .HasMaxLength(93)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Descuento).HasPrecision(19, 5);
            entity.Property(e => e.Exportacion).HasPrecision(19, 5);
            entity.Property(e => e.Fecha).HasColumnType("datetime(3)");
            entity.Property(e => e.FormaPago).HasPrecision(19, 5);
            entity.Property(e => e.Impuestos)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.LugarExpedicion).HasMaxLength(10);
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Moneda)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NoCertificado)
                .HasMaxLength(28)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Sello)
                .HasMaxLength(481)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SubTotal).HasPrecision(19, 5);
            entity.Property(e => e.TipoCambio).HasPrecision(19, 5);
            entity.Property(e => e.TipoDeComprobante)
                .HasMaxLength(1)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Total).HasPrecision(19, 5);
            entity.Property(e => e.Version).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_concepto>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cantidad).HasPrecision(19, 5);
            entity.Property(e => e.ClaveProdServ)
                .HasMaxLength(11)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ClaveUnidad)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Concepto_Id).HasDefaultValueSql("'0'");
            entity.Property(e => e.Conceptos_Id).HasDefaultValueSql("'0'");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1166)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Descuento).HasPrecision(19, 5);
            entity.Property(e => e.Importe).HasPrecision(19, 5);
            entity.Property(e => e.NoIdentificacion)
                .HasMaxLength(138)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ObjetoImp).HasPrecision(19, 5);
            entity.Property(e => e.Unidad)
                .HasMaxLength(28)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ValorUnitario).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_conceptoaddenda>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.cantidad).HasPrecision(19, 5);
            entity.Property(e => e.importe).HasPrecision(19, 5);
            entity.Property(e => e.importeDescuento).HasPrecision(19, 5);
            entity.Property(e => e.noIdentificacion).HasPrecision(19, 5);
            entity.Property(e => e.porcenDescuento).HasPrecision(19, 5);
            entity.Property(e => e.valorUnitario).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_conceptos>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_conceptosaddenda>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_cuentapredial>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Numero)
                .HasMaxLength(22)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_customized>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_deduccion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Clave).HasPrecision(19, 5);
            entity.Property(e => e.Concepto)
                .HasMaxLength(56)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Importe).HasPrecision(19, 5);
            entity.Property(e => e.TipoDeduccion).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_deducciones>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TotalImpuestosRetenidos).HasPrecision(19, 5);
            entity.Property(e => e.TotalOtrasDeducciones).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_destinatario>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.NumRegIdTrib).HasMaxLength(255);
        });

        modelBuilder.Entity<cfdi_divisas>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.tipoOperacion)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_doctorelacionado>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EquivalenciaDR).HasPrecision(19, 5);
            entity.Property(e => e.Folio)
                .HasMaxLength(26)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IdDocumento)
                .HasMaxLength(51)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ImpPagado).HasPrecision(19, 5);
            entity.Property(e => e.ImpSaldoAnt).HasPrecision(19, 5);
            entity.Property(e => e.ImpSaldoInsoluto).HasPrecision(19, 5);
            entity.Property(e => e.MetodoDePagoDR)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.MonedaDR)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumParcialidad).HasPrecision(19, 5);
            entity.Property(e => e.ObjetoImpDR).HasPrecision(19, 5);
            entity.Property(e => e.Serie)
                .HasMaxLength(28)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoCambioDR).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_documentacionaduanera>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IdentDocAduanero)
                .HasMaxLength(25)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumPedimento)
                .HasMaxLength(29)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RFCImpo)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoDocumento).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_domicilio>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Calle)
                .HasMaxLength(130)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CodigoPostal).HasPrecision(19, 5);
            entity.Property(e => e.Colonia)
                .HasMaxLength(22)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Localidad)
                .HasMaxLength(12)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Municipio)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(30)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(19)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Pais)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Referencia)
                .HasMaxLength(53)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_donatarias>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.fechaAutorizacion)
                .HasMaxLength(14)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.leyenda)
                .HasMaxLength(534)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.noAutorizacion)
                .HasMaxLength(28)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_emisor>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ComercioExterior_Id).HasMaxLength(50);
            entity.Property(e => e.Emisor_Id).HasMaxLength(50);
            entity.Property(e => e.Nombre)
                .HasMaxLength(193)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Nomina_Id).HasMaxLength(50);
            entity.Property(e => e.RegimenFiscal)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RegistroPatronal).HasMaxLength(50);
            entity.Property(e => e.Rfc)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RfcPatronOrigen).HasMaxLength(50);
        });

        modelBuilder.Entity<cfdi_emisor_1>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.RegistroPatronal)
                .HasMaxLength(15)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RfcPatronOrigen)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_encabezado>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Almacenaje).HasPrecision(19, 5);
            entity.Property(e => e.BultosPiezas).HasPrecision(19, 5);
            entity.Property(e => e.Cajero)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaIngreso)
                .HasMaxLength(14)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaSalidaMercancia)
                .HasMaxLength(26)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Folio)
                .HasMaxLength(11)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.GuiaHouse)
                .HasMaxLength(15)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.GuiaMaster).HasPrecision(19, 5);
            entity.Property(e => e.Nombre)
                .HasMaxLength(39)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(131)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Operacion)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Patente).HasPrecision(19, 5);
            entity.Property(e => e.Pedimento)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PesoKG).HasPrecision(19, 5);
            entity.Property(e => e.RFC)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RegIngreso)
                .HasMaxLength(21)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Salida)
                .HasMaxLength(33)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Serie)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoCambio).HasPrecision(19, 5);
            entity.Property(e => e.TotalDias).HasPrecision(19, 5);
            entity.Property(e => e.ValorMerc).HasPrecision(19, 5);
            entity.Property(e => e.Volante)
                .HasMaxLength(22)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_error>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Archivo)
                .HasMaxLength(114)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaHora).HasColumnType("datetime(3)");
        });

        modelBuilder.Entity<cfdi_figuratransporte>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_formas_pago>(entity =>
        {
            entity.HasKey(e => e.Id_Forma_Pago).HasName("PRIMARY");

            entity.Property(e => e.Id_Forma_Pago)
                .HasMaxLength(5)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Activo).HasDefaultValueSql("'1'");
            entity.Property(e => e.Forma_Pago)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_horasextra>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Dias).HasPrecision(19, 5);
            entity.Property(e => e.HorasExtra).HasPrecision(19, 5);
            entity.Property(e => e.ImportePagado).HasPrecision(19, 5);
            entity.Property(e => e.TipoHoras).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_identificacionvehicular>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AnioModeloVM).HasPrecision(19, 5);
            entity.Property(e => e.ConfigVehicular)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PesoBrutoVehicular).HasPrecision(19, 5);
            entity.Property(e => e.PlacaVM)
                .HasMaxLength(9)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_impuestos>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Impuestos_Id).HasDefaultValueSql("'0'");
            entity.Property(e => e.TotalImpuestosRetenidos).HasPrecision(19, 5);
            entity.Property(e => e.TotalImpuestosTrasladados).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_impuestosdr>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_impuestoslocales>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TotaldeRetenciones).HasPrecision(19, 5);
            entity.Property(e => e.TotaldeTraslados).HasPrecision(19, 5);
            entity.Property(e => e.version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_impuestosp>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_incapacidad>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DiasIncapacidad).HasPrecision(19, 5);
            entity.Property(e => e.ImporteMonetario).HasPrecision(19, 5);
            entity.Property(e => e.TipoIncapacidad).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_incapacidades>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_informacionaduanera>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.NumeroPedimento)
                .HasMaxLength(29)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_informacionfiscaltercero>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.calle)
                .HasMaxLength(40)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.codigoPostal).HasPrecision(19, 5);
            entity.Property(e => e.colonia)
                .HasMaxLength(35)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.estado)
                .HasMaxLength(23)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.localidad)
                .HasMaxLength(7)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.municipio)
                .HasMaxLength(26)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.noExterior)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.noInterior)
                .HasMaxLength(1)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.pais)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_informacionglobal>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Año).HasMaxLength(255);
            entity.Property(e => e.Meses).HasMaxLength(255);
            entity.Property(e => e.Periodicidad).HasMaxLength(255);
        });

        modelBuilder.Entity<cfdi_insteducativas>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CURP)
                .HasMaxLength(25)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.autRVOE)
                .HasMaxLength(14)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.nivelEducativo)
                .HasMaxLength(40)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.nombreAlumno)
                .HasMaxLength(40)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.rfcPago)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_mercancia>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BienesTransp).HasPrecision(19, 5);
            entity.Property(e => e.Cantidad).HasPrecision(19, 5);
            entity.Property(e => e.ClaveUnidad)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CveMaterialPeligroso).HasPrecision(19, 5);
            entity.Property(e => e.DescripEmbalaje)
                .HasMaxLength(21)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(603)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.DescripcionMateria)
                .HasMaxLength(28)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Dimensiones)
                .HasMaxLength(9)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Embalaje)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FraccionArancelaria).HasPrecision(19, 5);
            entity.Property(e => e.MaterialPeligroso)
                .HasMaxLength(2)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Moneda)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PesoEnKg).HasPrecision(19, 5);
            entity.Property(e => e.TipoMateria).HasPrecision(19, 5);
            entity.Property(e => e.Unidad)
                .HasMaxLength(28)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UnidadAduana).HasMaxLength(255);
            entity.Property(e => e.ValorDolares).HasMaxLength(255);
            entity.Property(e => e.ValorMercancia).HasPrecision(19, 5);
            entity.Property(e => e.ValorUnitarioAduana).HasMaxLength(255);
        });

        modelBuilder.Entity<cfdi_mercancias>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.NumTotalMercancias).HasPrecision(19, 5);
            entity.Property(e => e.PesoBrutoTotal).HasPrecision(19, 5);
            entity.Property(e => e.PesoNetoTotal).HasPrecision(19, 5);
            entity.Property(e => e.UnidadPeso)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_nomina>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Emisor)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaFinalPago)
                .HasMaxLength(14)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaInicialPago)
                .HasMaxLength(14)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaPago)
                .HasMaxLength(14)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumDiasPagados).HasPrecision(19, 5);
            entity.Property(e => e.TipoNomina)
                .HasMaxLength(1)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TotalDeducciones).HasPrecision(19, 5);
            entity.Property(e => e.TotalOtrosPagos).HasPrecision(19, 5);
            entity.Property(e => e.TotalPercepciones).HasPrecision(19, 5);
            entity.Property(e => e.Version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_otropago>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Clave).HasPrecision(19, 5);
            entity.Property(e => e.Concepto)
                .HasMaxLength(53)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Importe).HasPrecision(19, 5);
            entity.Property(e => e.OtroPago_Id).HasDefaultValueSql("'0'");
            entity.Property(e => e.TipoOtroPago).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_otroscargos>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TotalCargos).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_otrospagos>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_pago>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CadPago)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CertPago)
                .HasMaxLength(67)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CtaBeneficiario)
                .HasMaxLength(25)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CtaOrdenante)
                .HasMaxLength(25)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaPago)
                .HasMaxLength(26)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FormaDePagoP).HasPrecision(19, 5);
            entity.Property(e => e.MonedaP)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Monto).HasPrecision(19, 5);
            entity.Property(e => e.NomBancoOrdExt)
                .HasMaxLength(124)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumOperacion)
                .HasMaxLength(84)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Pago_Id).HasDefaultValueSql("'0'");
            entity.Property(e => e.RfcEmisorCtaBen)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RfcEmisorCtaOrd)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SelloPago)
                .HasMaxLength(67)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoCadPago).HasPrecision(19, 5);
            entity.Property(e => e.TipoCambioP).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_pagos>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_parte>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Cantidad).HasPrecision(19, 5);
            entity.Property(e => e.ClaveProdServ)
                .HasMaxLength(11)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(56)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Importe).HasPrecision(19, 5);
            entity.Property(e => e.NoIdentificacion)
                .HasMaxLength(15)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Unidad)
                .HasMaxLength(11)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ValorUnitario).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_partestransporte>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ParteTransporte)
                .HasMaxLength(5)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_pedimentos>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Pedimento)
                .HasMaxLength(29)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_percepcion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Clave).HasPrecision(19, 5);
            entity.Property(e => e.Concepto)
                .HasMaxLength(47)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ImporteExento).HasPrecision(19, 5);
            entity.Property(e => e.ImporteGravado).HasPrecision(19, 5);
            entity.Property(e => e.TipoPercepcion).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_percepciones>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.TotalExento).HasPrecision(19, 5);
            entity.Property(e => e.TotalGravado).HasPrecision(19, 5);
            entity.Property(e => e.TotalSeparacionIndemnizacion).HasPrecision(19, 5);
            entity.Property(e => e.TotalSueldos).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_porcuentadeterceros>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.nombre)
                .HasMaxLength(137)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.rfc)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_receptor>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Antigüedad).HasMaxLength(255);
            entity.Property(e => e.ClaveEntFed).HasMaxLength(255);
            entity.Property(e => e.Curp).HasMaxLength(255);
            entity.Property(e => e.Departamento).HasMaxLength(255);
            entity.Property(e => e.DomicilioFiscalReceptor).HasPrecision(19, 5);
            entity.Property(e => e.FechaInicioRelLaboral).HasMaxLength(255);
            entity.Property(e => e.Nombre)
                .HasMaxLength(137)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumEmpleado).HasMaxLength(255);
            entity.Property(e => e.NumRegIdTrib)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumSeguridadSocial).HasMaxLength(255);
            entity.Property(e => e.PeriodicidadPago).HasMaxLength(255);
            entity.Property(e => e.Puesto).HasMaxLength(255);
            entity.Property(e => e.RegimenFiscalReceptor)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ResidenciaFiscal)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Rfc)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RiesgoPuesto).HasMaxLength(255);
            entity.Property(e => e.SalarioBaseCotApor).HasMaxLength(255);
            entity.Property(e => e.SalarioDiarioIntegrado).HasMaxLength(255);
            entity.Property(e => e.Sindicalizado).HasMaxLength(255);
            entity.Property(e => e.TipoContrato).HasMaxLength(255);
            entity.Property(e => e.TipoJornada).HasMaxLength(255);
            entity.Property(e => e.TipoRegimen).HasMaxLength(255);
            entity.Property(e => e.UsoCFDI)
                .HasMaxLength(5)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_receptor_1>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Antigüedad)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Banco).HasPrecision(19, 5);
            entity.Property(e => e.ClaveEntFed)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.CuentaBancaria)
                .HasMaxLength(25)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Curp)
                .HasMaxLength(25)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Departamento)
                .HasMaxLength(44)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaInicioRelLaboral)
                .HasMaxLength(14)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumEmpleado).HasPrecision(19, 5);
            entity.Property(e => e.NumSeguridadSocial).HasPrecision(19, 5);
            entity.Property(e => e.PeriodicidadPago).HasPrecision(19, 5);
            entity.Property(e => e.Puesto)
                .HasMaxLength(64)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RiesgoPuesto).HasPrecision(19, 5);
            entity.Property(e => e.SalarioBaseCotApor).HasPrecision(19, 5);
            entity.Property(e => e.SalarioDiarioIntegrado).HasPrecision(19, 5);
            entity.Property(e => e.Sindicalizado)
                .HasMaxLength(2)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoContrato).HasPrecision(19, 5);
            entity.Property(e => e.TipoJornada).HasPrecision(19, 5);
            entity.Property(e => e.TipoRegimen).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_remolque>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Placa)
                .HasMaxLength(9)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SubTipoRem)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_remolques>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_retencion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Base).HasPrecision(19, 5);
            entity.Property(e => e.Importe).HasPrecision(19, 5);
            entity.Property(e => e.Impuesto).HasPrecision(19, 5);
            entity.Property(e => e.TasaOCuota).HasPrecision(19, 5);
            entity.Property(e => e.TipoFactor)
                .HasMaxLength(5)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_retencion_1>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.importe).HasPrecision(19, 5);
            entity.Property(e => e.impuesto)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_retenciondr>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BaseDR).HasPrecision(19, 5);
            entity.Property(e => e.ImporteDR).HasPrecision(19, 5);
            entity.Property(e => e.ImpuestoDR).HasPrecision(19, 5);
            entity.Property(e => e.TasaOCuotaDR).HasPrecision(19, 5);
            entity.Property(e => e.TipoFactorDR)
                .HasMaxLength(5)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_retenciones>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_retencionesdr>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_retencionesp>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_retencionp>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ImporteP).HasPrecision(19, 5);
            entity.Property(e => e.ImpuestoP).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_seguros>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AseguraCarga)
                .HasMaxLength(15)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AseguraMedAmbiente)
                .HasMaxLength(39)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.AseguraRespCivil)
                .HasMaxLength(58)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PolizaCarga)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PolizaMedAmbiente).HasPrecision(19, 5);
            entity.Property(e => e.PolizaRespCivil)
                .HasMaxLength(33)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.PrimaSeguro).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_separacionindemnizacion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.IngresoAcumulable).HasPrecision(19, 5);
            entity.Property(e => e.IngresoNoAcumulable).HasPrecision(19, 5);
            entity.Property(e => e.NumAñosServicio).HasPrecision(19, 5);
            entity.Property(e => e.TotalPagado).HasPrecision(19, 5);
            entity.Property(e => e.UltimoSueldoMensOrd).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_subsidioalempleo>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.SubsidioCausado).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_talmaaddenda>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_terceros_impuestos>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_terceros_retenciones>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_terceros_traslado>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.importe).HasPrecision(19, 5);
            entity.Property(e => e.impuesto)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.tasa).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_terceros_traslados>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_timbrefiscaldigital>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FechaTimbrado)
                .HasMaxLength(26)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Leyenda)
                .HasMaxLength(32)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NoCertificadoSAT)
                .HasMaxLength(28)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RfcProvCertif)
                .HasMaxLength(16)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SelloCFD)
                .HasMaxLength(481)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.SelloSAT)
                .HasMaxLength(487)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UUID)
                .HasMaxLength(50)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_tiposfigura>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.NombreFigura)
                .HasMaxLength(53)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumLicencia)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RFCFigura)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoFigura).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_totales>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.MontoTotalPagos).HasPrecision(19, 5);
            entity.Property(e => e.TotalRetencionesIEPS).HasPrecision(19, 5);
            entity.Property(e => e.TotalRetencionesISR).HasPrecision(19, 5);
            entity.Property(e => e.TotalRetencionesIVA).HasPrecision(19, 5);
            entity.Property(e => e.TotalTrasladosBaseIVA0).HasPrecision(19, 5);
            entity.Property(e => e.TotalTrasladosBaseIVA16).HasPrecision(19, 5);
            entity.Property(e => e.TotalTrasladosBaseIVA8).HasPrecision(19, 5);
            entity.Property(e => e.TotalTrasladosBaseIVAExento).HasPrecision(19, 5);
            entity.Property(e => e.TotalTrasladosImpuestoIVA0).HasPrecision(19, 5);
            entity.Property(e => e.TotalTrasladosImpuestoIVA16).HasPrecision(19, 5);
            entity.Property(e => e.TotalTrasladosImpuestoIVA8).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_traslado>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Base).HasPrecision(19, 5);
            entity.Property(e => e.Importe).HasPrecision(19, 5);
            entity.Property(e => e.Impuesto).HasPrecision(19, 5);
            entity.Property(e => e.TasaOCuota).HasPrecision(19, 5);
            entity.Property(e => e.TipoFactor)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_trasladodr>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BaseDR).HasPrecision(19, 5);
            entity.Property(e => e.ImporteDR).HasPrecision(19, 5);
            entity.Property(e => e.ImpuestoDR).HasPrecision(19, 5);
            entity.Property(e => e.TasaOCuotaDR).HasPrecision(19, 5);
            entity.Property(e => e.TipoFactorDR)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_trasladop>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.BaseP).HasPrecision(19, 5);
            entity.Property(e => e.ImporteP).HasPrecision(19, 5);
            entity.Property(e => e.ImpuestoP).HasPrecision(19, 5);
            entity.Property(e => e.TasaOCuotaP).HasPrecision(19, 5);
            entity.Property(e => e.TipoFactorP)
                .HasMaxLength(8)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_traslados>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_trasladosdr>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_trasladoslocales>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.ImpLocTrasladado)
                .HasMaxLength(19)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Importe).HasPrecision(19, 5);
            entity.Property(e => e.TasadeTraslado).HasPrecision(19, 5);
        });

        modelBuilder.Entity<cfdi_trasladosp>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_ubicacion>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.DistanciaRecorrida).HasPrecision(19, 5);
            entity.Property(e => e.FechaHoraSalidaLlegada)
                .HasMaxLength(26)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.IDUbicacion)
                .HasMaxLength(11)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NombreRemitenteDestinatario)
                .HasMaxLength(84)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.NumRegIdTrib)
                .HasMaxLength(15)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.RFCRemitenteDestinatario)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.ResidenciaFiscal)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.TipoUbicacion)
                .HasMaxLength(9)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_ubicaciones>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<cfdi_usos_cfdi>(entity =>
        {
            entity.HasKey(e => e.Id_Uso_CFDI).HasName("PRIMARY");

            entity.Property(e => e.Id_Uso_CFDI)
                .HasMaxLength(5)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Activo).HasDefaultValueSql("'1'");
            entity.Property(e => e.Uso_CFDI)
                .HasMaxLength(119)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_valesdedespensa>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.numeroDeCuenta).HasPrecision(19, 5);
            entity.Property(e => e.registroPatronal)
                .HasMaxLength(15)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.tipoOperacion)
                .HasMaxLength(28)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.total).HasPrecision(19, 5);
            entity.Property(e => e.version)
                .HasMaxLength(4)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_valesdedespensa_concepto>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.curp)
                .HasMaxLength(25)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.fecha)
                .HasMaxLength(26)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.identificador).HasPrecision(19, 5);
            entity.Property(e => e.importe).HasPrecision(19, 5);
            entity.Property(e => e.nombre)
                .HasMaxLength(53)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.numSeguridadSocial).HasPrecision(19, 5);
            entity.Property(e => e.rfc)
                .HasMaxLength(18)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<cfdi_valesdedespensa_conceptos>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<th_articulos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.tipo_id, "th_articulos_th_articulos_tipos_FK");

            entity.HasIndex(e => e.catalogoproductosat_Id, "th_articulos_th_catproductosat_fk");

            entity.HasIndex(e => e.ImpPlanCompra_id, "th_articulos_th_plan_impuestos_FK");

            entity.HasIndex(e => e.ImpPlanVenta_id, "th_articulos_th_plan_impuestos_FK_1");

            entity.HasIndex(e => e.NombreCorto, "th_articulos_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.ImpPlanCompra_id).HasMaxLength(36);
            entity.Property(e => e.ImpPlanVenta_id).HasMaxLength(36);
            entity.Property(e => e.NombreCorto).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.catalogoproductosat_Id).HasMaxLength(10);
            entity.Property(e => e.cuentacontable_id).HasMaxLength(36);
            entity.Property(e => e.tipo_id).HasMaxLength(36);
            entity.Property(e => e.unidad_Id).HasMaxLength(36);

            entity.HasOne(d => d.ImpPlanCompra).WithMany(p => p.th_articulosImpPlanCompra)
                .HasForeignKey(d => d.ImpPlanCompra_id)
                .HasConstraintName("th_articulos_th_plan_impuestos_FK");

            entity.HasOne(d => d.ImpPlanVenta).WithMany(p => p.th_articulosImpPlanVenta)
                .HasForeignKey(d => d.ImpPlanVenta_id)
                .HasConstraintName("th_articulos_th_plan_impuestos_FK_1");

            entity.HasOne(d => d.catalogoproductosat).WithMany(p => p.th_articulos)
                .HasForeignKey(d => d.catalogoproductosat_Id)
                .HasConstraintName("th_articulos_th_catproductosat_fk");

            entity.HasOne(d => d.tipo).WithMany(p => p.th_articulos)
                .HasForeignKey(d => d.tipo_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_articulos_th_articulos_tipos_FK");
        });

        modelBuilder.Entity<th_articulos_proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => new { e.proveedor_Id, e.articulo_Id }, "th_articulos_proveedor_proveedor_Id_IDX").IsUnique();

            entity.HasIndex(e => e.articulo_Id, "th_articulos_proveedor_th_articulos_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CostoActual).HasPrecision(18, 5);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.articulo_Id).HasMaxLength(36);
            entity.Property(e => e.proveedor_Id).HasMaxLength(36);

            entity.HasOne(d => d.articulo).WithMany(p => p.th_articulos_proveedor)
                .HasForeignKey(d => d.articulo_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_articulos_proveedor_th_articulos_FK");

            entity.HasOne(d => d.proveedor).WithMany(p => p.th_articulos_proveedor)
                .HasForeignKey(d => d.proveedor_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_articulos_proveedor_th_proveedores_FK");
        });

        modelBuilder.Entity<th_articulos_tipos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NombreCorto, "th_articulos_tipos_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.NombreCorto).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_articulos_unidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.ClaveSAT)
                .HasMaxLength(15)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.NombreCorto)
                .HasMaxLength(15)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_bancos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Chequera, "th_Bancos_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Banco).HasMaxLength(100);
            entity.Property(e => e.Chequera).HasMaxLength(50);
            entity.Property(e => e.Cuenta).HasMaxLength(18);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.FechaUltimaConciliacion).HasColumnType("datetime");
            entity.Property(e => e.Saldo).HasPrecision(19, 5);
            entity.Property(e => e.SaldoUltimaConciliacion).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.cuentacontable_id).HasMaxLength(36);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
        });

        modelBuilder.Entity<th_catproductosat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(10);
            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_cfdi_metadata>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("PRIMARY");

            entity.Property(e => e.Uuid).HasMaxLength(36);
            entity.Property(e => e.EfectoComprobante).HasMaxLength(2);
            entity.Property(e => e.FechaCancelacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCertificacionSat).HasColumnType("datetime");
            entity.Property(e => e.FechaDescarga).HasColumnType("datetime");
            entity.Property(e => e.FechaEmision).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasPrecision(18, 4);
            entity.Property(e => e.NombreEmisor).HasMaxLength(150);
            entity.Property(e => e.NombreReceptor).HasMaxLength(150);
            entity.Property(e => e.RfcEmisor).HasMaxLength(18);
            entity.Property(e => e.RfcPac).HasMaxLength(18);
            entity.Property(e => e.RfcReceptor).HasMaxLength(18);
        });

        modelBuilder.Entity<th_clientes>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.planimpuestos_id, "th_clientes_th_plan_impuestos_fk");

            entity.HasIndex(e => e.regimenfiscal_Id, "th_clientes_th_regimenfiscal_FK");

            entity.HasIndex(e => e.usocfdi_Id, "th_clientes_th_usocfdi_FK");

            entity.HasIndex(e => e.NombreCorto, "th_clientes_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.Direccion).HasMaxLength(150);
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Municipio).HasMaxLength(100);
            entity.Property(e => e.NombreCorto).HasMaxLength(15);
            entity.Property(e => e.NumRegIdTrib).HasMaxLength(20);
            entity.Property(e => e.RFC).HasMaxLength(13);
            entity.Property(e => e.RazonSocial).HasMaxLength(150);
            entity.Property(e => e.ResidenciaFiscal).HasMaxLength(5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.cuentacontable_id).HasMaxLength(36);
            entity.Property(e => e.planimpuestos_id).HasMaxLength(36);
            entity.Property(e => e.regimenfiscal_Id).HasMaxLength(36);
            entity.Property(e => e.usocfdi_Id).HasMaxLength(4);

            entity.HasOne(d => d.planimpuestos).WithMany(p => p.th_clientes)
                .HasForeignKey(d => d.planimpuestos_id)
                .HasConstraintName("th_clientes_th_plan_impuestos_fk");

            entity.HasOne(d => d.regimenfiscal).WithMany(p => p.th_clientes)
                .HasForeignKey(d => d.regimenfiscal_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_clientes_th_regimenfiscal_FK_copy");

            entity.HasOne(d => d.usocfdi).WithMany(p => p.th_clientes)
                .HasForeignKey(d => d.usocfdi_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_clientes_th_usocfdi_FK_copy");
        });

        modelBuilder.Entity<th_compra_factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Factura).HasMaxLength(36);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.MontoImpuestos).HasPrecision(18, 5);
            entity.Property(e => e.Observaciones).HasMaxLength(400);
            entity.Property(e => e.SubTotal).HasPrecision(18, 5);
            entity.Property(e => e.Total).HasPrecision(18, 5);
            entity.Property(e => e.UUID).HasMaxLength(36);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.asiento_Id).HasMaxLength(36);
            entity.Property(e => e.asientocancelado_Id).HasMaxLength(36);
            entity.Property(e => e.metodopago_Id).HasMaxLength(3);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
            entity.Property(e => e.proveedor_Id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_Id).HasMaxLength(36);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.th_compra_factura)
                .HasForeignKey<th_compra_factura>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_compra_factura_th_cuentaspagar_FK");
        });

        modelBuilder.Entity<th_compra_factura_detalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.articulo_Id, "th_compra_factura_detalle_th_articulos_fk");

            entity.HasIndex(e => e.factura_Id, "th_compra_factura_detalle_th_compra_factura_fk");

            entity.HasIndex(e => e.planimpuestos_Id, "th_compra_factura_detalle_th_plan_impuestos_fk");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Cantidad).HasPrecision(18, 5);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Impuesto).HasPrecision(18, 6);
            entity.Property(e => e.SubTotal).HasPrecision(18, 6);
            entity.Property(e => e.Total).HasPrecision(18, 6);
            entity.Property(e => e.Unitario).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.articulo_Id).HasMaxLength(36);
            entity.Property(e => e.factura_Id).HasMaxLength(36);
            entity.Property(e => e.planimpuestos_Id).HasMaxLength(36);

            entity.HasOne(d => d.articulo).WithMany(p => p.th_compra_factura_detalle)
                .HasForeignKey(d => d.articulo_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_compra_factura_detalle_th_articulos_fk");

            entity.HasOne(d => d.factura).WithMany(p => p.th_compra_factura_detalle)
                .HasForeignKey(d => d.factura_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_compra_factura_detalle_th_compra_factura_fk");

            entity.HasOne(d => d.planimpuestos).WithMany(p => p.th_compra_factura_detalle)
                .HasForeignKey(d => d.planimpuestos_Id)
                .HasConstraintName("th_compra_factura_detalle_th_plan_impuestos_fk");
        });

        modelBuilder.Entity<th_concilacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.banco_Id, "th_concilacion_th_bancos_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Diferencia).HasPrecision(18, 5);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Justificacion).HasMaxLength(450);
            entity.Property(e => e.SaldoBanco).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.banco_Id).HasMaxLength(36);

            entity.HasOne(d => d.banco).WithMany(p => p.th_concilacion)
                .HasForeignKey(d => d.banco_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_concilacion_th_bancos_FK");
        });

        modelBuilder.Entity<th_conciliacion_detalle>(entity =>
        {
            entity.HasKey(e => new { e.conciliacion_Id, e.Partida })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.conciliacion_Id).HasMaxLength(36);
            entity.Property(e => e.Comentarios).HasMaxLength(400);
            entity.Property(e => e.Documento).HasMaxLength(21);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaDocumento).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);

            entity.HasOne(d => d.conciliacion).WithMany(p => p.th_conciliacion_detalle)
                .HasForeignKey(d => d.conciliacion_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_conciliacion_detalle_th_concilacion_FK");
        });

        modelBuilder.Entity<th_condicionescredito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Condicion, "th_condicionescredito_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Condicion).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_cont_cuenta_categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_contabilidad_configuracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Fiel_Password).HasMaxLength(100);
            entity.Property(e => e.Fiel_Vencimiento).HasColumnType("datetime");
            entity.Property(e => e.FormatoCC).HasMaxLength(100);
            entity.Property(e => e.RFC).HasMaxLength(13);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_contabilidad_cuenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.categoria_id, "th_contabilidad_cuenta_th_contabilidad_cuenta_categoria_FK");

            entity.HasIndex(e => e.CuentaContable, "th_contabilidad_cuenta_unique").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Segmento1).HasMaxLength(50);
            entity.Property(e => e.Segmento2).HasMaxLength(50);
            entity.Property(e => e.Segmento3).HasMaxLength(50);
            entity.Property(e => e.Segmento4).HasMaxLength(50);
            entity.Property(e => e.Segmento5).HasMaxLength(50);
            entity.Property(e => e.Segmento6).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.categoria_id).HasMaxLength(36);

            entity.HasOne(d => d.categoria).WithMany(p => p.th_contabilidad_cuenta)
                .HasForeignKey(d => d.categoria_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_contabilidad_cuenta_th_contabilidad_cuenta_categoria_FK");
        });

        modelBuilder.Entity<th_contabilidad_cuenta_categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Categoria, "th_cont_cuenta_categoria_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Segmento).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_contabilidad_cuenta_configuracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.cuentacompra_Id).HasMaxLength(36);
            entity.Property(e => e.cuentaventa_Id).HasMaxLength(36);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
        });

        modelBuilder.Entity<th_contabilidad_trabajo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.moneda_Id, "th_contabilidad_trabajo_th_monedas_FK");

            entity.HasIndex(e => e.tipocambio_Id, "th_contabilidad_trabajo_th_tiposcambio_FK");

            entity.HasIndex(e => e.Asiento, "th_contabilidad_trabajo_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Asiento).ValueGeneratedOnAdd();
            entity.Property(e => e.DocumentoOriginal).HasMaxLength(100);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Origen).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_Id).HasMaxLength(36);

            entity.HasOne(d => d.moneda).WithMany(p => p.th_contabilidad_trabajo)
                .HasForeignKey(d => d.moneda_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_contabilidad_trabajo_th_monedas_FK");

            entity.HasOne(d => d.tipocambio).WithMany(p => p.th_contabilidad_trabajo)
                .HasForeignKey(d => d.tipocambio_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_contabilidad_trabajo_th_tiposcambio_FK");
        });

        modelBuilder.Entity<th_contabilidad_trabajo_detalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.cuenta_Id, "th_contabilidad_trabajo_detalle_th_contabilidad_cuenta_FK");

            entity.HasIndex(e => e.encabezado_Id, "th_contabilidad_trabajo_detalle_th_contabilidad_trabajo_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Credito).HasPrecision(18, 5);
            entity.Property(e => e.CreditoMF).HasPrecision(18, 5);
            entity.Property(e => e.Debito).HasPrecision(18, 5);
            entity.Property(e => e.DebitoMF).HasPrecision(18, 5);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.TipoConcepto).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.cuenta_Id)
                .HasMaxLength(36)
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.encabezado_Id).HasMaxLength(36);

            entity.HasOne(d => d.cuenta).WithMany(p => p.th_contabilidad_trabajo_detalle)
                .HasForeignKey(d => d.cuenta_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_contabilidad_trabajo_detalle_th_contabilidad_cuenta_FK");

            entity.HasOne(d => d.encabezado).WithMany(p => p.th_contabilidad_trabajo_detalle)
                .HasForeignKey(d => d.encabezado_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_contabilidad_trabajo_detalle_th_contabilidad_trabajo_FK");
        });

        modelBuilder.Entity<th_cuentascobrar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UUID, "th_cuentascobrar_UUID_IDX");

            entity.HasIndex(e => new { e.cliente_Id, e.Factura }, "th_cuentascobrar_cliente_Id_IDX").IsUnique();

            entity.HasIndex(e => e.metodopago_Id, "th_cuentascobrar_th_metodopago_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Disponible).HasPrecision(18, 5);
            entity.Property(e => e.Factura).HasMaxLength(36);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(400);
            entity.Property(e => e.Original).HasPrecision(18, 5);
            entity.Property(e => e.UUID).HasMaxLength(36);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.asiento_Id).HasMaxLength(36);
            entity.Property(e => e.asientocancelado_Id).HasMaxLength(36);
            entity.Property(e => e.cliente_Id).HasMaxLength(36);
            entity.Property(e => e.metodopago_Id).HasMaxLength(3);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_Id).HasMaxLength(36);

            entity.HasOne(d => d.cliente).WithMany(p => p.th_cuentascobrar)
                .HasForeignKey(d => d.cliente_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentascobrar_th_clientees_FK");

            entity.HasOne(d => d.metodopago).WithMany(p => p.th_cuentascobrar)
                .HasForeignKey(d => d.metodopago_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentascobrar_th_metodopago_FK");
        });

        modelBuilder.Entity<th_cuentascobraraplicaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.cliente_Id, "th_cuentascobraraplicaciones_th_clientes_FK");

            entity.HasIndex(e => e.cuentascobrar_Id, "th_cuentascobraraplicaciones_th_cuentascobrar_FK");

            entity.HasIndex(e => e.ingreso_Id, "th_cuentascobraraplicaciones_th_ingresos_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FechaAplicacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoAplicado).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.cliente_Id).HasMaxLength(36);
            entity.Property(e => e.cuentascobrar_Id).HasMaxLength(36);
            entity.Property(e => e.ingreso_Id).HasMaxLength(36);

            entity.HasOne(d => d.cliente).WithMany(p => p.th_cuentascobraraplicaciones)
                .HasForeignKey(d => d.cliente_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentascobraraplicaciones_th_clientes_FK");

            entity.HasOne(d => d.cuentascobrar).WithMany(p => p.th_cuentascobraraplicaciones)
                .HasForeignKey(d => d.cuentascobrar_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentascobraraplicaciones_th_cuentascobrar_FK");

            entity.HasOne(d => d.ingreso).WithMany(p => p.th_cuentascobraraplicaciones)
                .HasForeignKey(d => d.ingreso_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentascobraraplicaciones_th_ingresos_FK");
        });

        modelBuilder.Entity<th_cuentaspagar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.UUID, "th_cuentaspagar_UUID_IDX");

            entity.HasIndex(e => new { e.proveedor_Id, e.Factura }, "th_cuentaspagar_proveedor_Id_IDX").IsUnique();

            entity.HasIndex(e => e.metodopago_Id, "th_cuentaspagar_th_metodopago_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Disponible).HasPrecision(18, 5);
            entity.Property(e => e.Factura).HasMaxLength(36);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(400);
            entity.Property(e => e.Original).HasPrecision(18, 5);
            entity.Property(e => e.UUID).HasMaxLength(36);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.asiento_Id).HasMaxLength(36);
            entity.Property(e => e.asientocancelado_Id).HasMaxLength(36);
            entity.Property(e => e.metodopago_Id).HasMaxLength(3);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
            entity.Property(e => e.proveedor_Id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_Id).HasMaxLength(36);

            entity.HasOne(d => d.metodopago).WithMany(p => p.th_cuentaspagar)
                .HasForeignKey(d => d.metodopago_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentaspagar_th_metodopago_FK");

            entity.HasOne(d => d.proveedor).WithMany(p => p.th_cuentaspagar)
                .HasForeignKey(d => d.proveedor_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentaspagar_th_proveedores_FK");
        });

        modelBuilder.Entity<th_cuentaspagaraplicaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.cuentaspagar_Id, "th_cuentaspagaraplicaciones_th_cuentaspagar_FK");

            entity.HasIndex(e => e.egreso_Id, "th_cuentaspagaraplicaciones_th_egresos_FK");

            entity.HasIndex(e => e.proveedor_Id, "th_cuentaspagaraplicaciones_th_proveedores_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FechaAplicacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoAplicado).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.cuentaspagar_Id).HasMaxLength(36);
            entity.Property(e => e.egreso_Id).HasMaxLength(36);
            entity.Property(e => e.proveedor_Id).HasMaxLength(36);

            entity.HasOne(d => d.cuentaspagar).WithMany(p => p.th_cuentaspagaraplicaciones)
                .HasForeignKey(d => d.cuentaspagar_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentaspagaraplicaciones_th_cuentaspagar_FK");

            entity.HasOne(d => d.egreso).WithMany(p => p.th_cuentaspagaraplicaciones)
                .HasForeignKey(d => d.egreso_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentaspagaraplicaciones_th_egresos_FK");

            entity.HasOne(d => d.proveedor).WithMany(p => p.th_cuentaspagaraplicaciones)
                .HasForeignKey(d => d.proveedor_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_cuentaspagaraplicaciones_th_proveedores_FK");
        });

        modelBuilder.Entity<th_egresos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Egreso, "Egreso").IsUnique();

            entity.HasIndex(e => e.bancos_id, "th_egresos_th_bancos_FK");

            entity.HasIndex(e => e.formapago_id, "th_egresos_th_formapago_FK");

            entity.HasIndex(e => e.proveedor_Id, "th_egresos_th_proveedores_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Disponible).HasPrecision(18, 5);
            entity.Property(e => e.Egreso).ValueGeneratedOnAdd();
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(400);
            entity.Property(e => e.Original).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.asiento_Id).HasMaxLength(36);
            entity.Property(e => e.asientocancelado_Id).HasMaxLength(36);
            entity.Property(e => e.bancos_id).HasMaxLength(36);
            entity.Property(e => e.formapago_id).HasMaxLength(2);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
            entity.Property(e => e.proveedor_Id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_Id).HasMaxLength(36);

            entity.HasOne(d => d.bancos).WithMany(p => p.th_egresos)
                .HasForeignKey(d => d.bancos_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_egresos_th_bancos_FK");

            entity.HasOne(d => d.formapago).WithMany(p => p.th_egresos)
                .HasForeignKey(d => d.formapago_id)
                .HasConstraintName("th_egresos_th_formapago_FK");

            entity.HasOne(d => d.proveedor).WithMany(p => p.th_egresos)
                .HasForeignKey(d => d.proveedor_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_egresos_th_proveedores_FK");
        });

        modelBuilder.Entity<th_facturacion_sellos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Sello_Password).HasMaxLength(100);
            entity.Property(e => e.Sello_Vencimiento).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_facturacion_series>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Serie, "Serie").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Serie).HasMaxLength(10);
            entity.Property(e => e.Tipo).HasMaxLength(1);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_formapago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.FormaPago, "th_formapago_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(2);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.FormaPago).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_impuestos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NombreCorto, "th_impuestos_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.IdSAT).HasMaxLength(5);
            entity.Property(e => e.NombreCorto).HasMaxLength(15);
            entity.Property(e => e.Porcentaje).HasPrecision(18, 6);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.cuentacontable_id).HasMaxLength(36);
        });

        modelBuilder.Entity<th_ingresos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Ingreso, "Ingreso").IsUnique();

            entity.HasIndex(e => e.bancos_id, "th_Ingresos_th_bancos_FK");

            entity.HasIndex(e => e.cliente_Id, "th_Ingresos_th_clientes_FK");

            entity.HasIndex(e => e.formapago_id, "th_ingresos_th_formapago_FK");

            entity.HasIndex(e => e.ingresos_origen_id, "th_ingresos_th_ingresos_origen_FK");

            entity.HasIndex(e => e.tipocambio_Id, "th_ingresos_th_tiposcambio_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Conciliado).HasDefaultValueSql("false");
            entity.Property(e => e.Disponible).HasPrecision(18, 5);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Ingreso).ValueGeneratedOnAdd();
            entity.Property(e => e.Observaciones).HasMaxLength(400);
            entity.Property(e => e.Original).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.asiento_Id).HasMaxLength(36);
            entity.Property(e => e.asientocancelado_Id).HasMaxLength(36);
            entity.Property(e => e.bancos_id).HasMaxLength(36);
            entity.Property(e => e.cliente_Id).HasMaxLength(36);
            entity.Property(e => e.formapago_id).HasMaxLength(2);
            entity.Property(e => e.ingresos_origen_id).HasMaxLength(36);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_Id).HasMaxLength(36);

            entity.HasOne(d => d.bancos).WithMany(p => p.th_ingresos)
                .HasForeignKey(d => d.bancos_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_Ingresos_th_bancos_FK");

            entity.HasOne(d => d.cliente).WithMany(p => p.th_ingresos)
                .HasForeignKey(d => d.cliente_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_Ingresos_th_clientes_FK");

            entity.HasOne(d => d.formapago).WithMany(p => p.th_ingresos)
                .HasForeignKey(d => d.formapago_id)
                .HasConstraintName("th_ingresos_th_formapago_FK");

            entity.HasOne(d => d.ingresos_origen).WithMany(p => p.th_ingresos)
                .HasForeignKey(d => d.ingresos_origen_id)
                .HasConstraintName("th_ingresos_th_ingresos_origen_FK");

            entity.HasOne(d => d.tipocambio).WithMany(p => p.th_ingresos)
                .HasForeignKey(d => d.tipocambio_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_ingresos_th_tiposcambio_FK");
        });

        modelBuilder.Entity<th_ingresos_complemento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Folio).HasMaxLength(36);
            entity.Property(e => e.Monto).HasPrecision(18, 5);
            entity.Property(e => e.UUID).HasMaxLength(36);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.ingreso_id).HasMaxLength(36);
            entity.Property(e => e.moneda_id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_id).HasMaxLength(36);
        });

        modelBuilder.Entity<th_ingresos_complemento_detalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.aplicacion_id, "th_ingresos_complemento_detalle_th_cuentaspagaraplicaciones_FK");

            entity.HasIndex(e => e.complemento_id, "th_ingresos_complemento_detalle_th_ingresos_complemento_FK");

            entity.HasIndex(e => e.moneda_id, "th_ingresos_complemento_detalle_th_monedas_FK");

            entity.HasIndex(e => e.tipocambio_id, "th_ingresos_complemento_detalle_th_tiposcambio_FK");

            entity.HasIndex(e => e.factura_id, "th_ingresos_complemento_detalle_th_venta_factura_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.MontoPago).HasPrecision(18, 5);
            entity.Property(e => e.SaldoInsoluto).HasPrecision(18, 5);
            entity.Property(e => e.aplicacion_id).HasMaxLength(36);
            entity.Property(e => e.complemento_id).HasMaxLength(36);
            entity.Property(e => e.factura_id).HasMaxLength(36);
            entity.Property(e => e.moneda_id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_id).HasMaxLength(36);

            entity.HasOne(d => d.aplicacion).WithMany(p => p.th_ingresos_complemento_detalle)
                .HasForeignKey(d => d.aplicacion_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_ingresos_complemento_detalle_th_cuentaspagaraplicaciones_FK");

            entity.HasOne(d => d.complemento).WithMany(p => p.th_ingresos_complemento_detalle)
                .HasForeignKey(d => d.complemento_id)
                .HasConstraintName("th_ingresos_complemento_detalle_th_ingresos_complemento_FK");

            entity.HasOne(d => d.factura).WithMany(p => p.th_ingresos_complemento_detalle)
                .HasForeignKey(d => d.factura_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_ingresos_complemento_detalle_th_venta_factura_FK");

            entity.HasOne(d => d.moneda).WithMany(p => p.th_ingresos_complemento_detalle)
                .HasForeignKey(d => d.moneda_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_ingresos_complemento_detalle_th_monedas_FK");

            entity.HasOne(d => d.tipocambio).WithMany(p => p.th_ingresos_complemento_detalle)
                .HasForeignKey(d => d.tipocambio_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_ingresos_complemento_detalle_th_tiposcambio_FK");
        });

        modelBuilder.Entity<th_ingresos_origen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.Origen, "th_ingresos_origen_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Observaciones).HasMaxLength(150);
            entity.Property(e => e.Origen).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_metodopago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(3);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.MetodoPago).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_monedas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NombreCorto, "th_monedas_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Descripcion).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.NombreCorto).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_paises>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.Property(e => e.Codigo).HasMaxLength(5);
            entity.Property(e => e.Pais).HasMaxLength(100);
        });

        modelBuilder.Entity<th_plan_impuestos>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.NombreCorto, "th_plan_impuestos_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.NombreCorto).HasMaxLength(15);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_plan_impuestos_detalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => new { e.impuestos_id, e.plan_impuestos_id }, "th_plan_impuestos_detalle_impuestos_id_IDX").IsUnique();

            entity.HasIndex(e => e.plan_impuestos_id, "th_plan_impuestos_detalle_th_plan_impuestos_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.impuestos_id).HasMaxLength(36);
            entity.Property(e => e.plan_impuestos_id).HasMaxLength(36);

            entity.HasOne(d => d.impuestos).WithMany(p => p.th_plan_impuestos_detalle)
                .HasForeignKey(d => d.impuestos_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_plan_impuestos_detalle_th_impuestos_FK");

            entity.HasOne(d => d.plan_impuestos).WithMany(p => p.th_plan_impuestos_detalle)
                .HasForeignKey(d => d.plan_impuestos_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_plan_impuestos_detalle_th_plan_impuestos_FK");
        });

        modelBuilder.Entity<th_proveedores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.planimpuestos_id, "th_proveedores_th_plan_impuestos_fk");

            entity.HasIndex(e => e.regimenfiscal_Id, "th_proveedores_th_regimenfiscal_FK");

            entity.HasIndex(e => e.usocfdi_Id, "th_proveedores_th_usocfdi_FK");

            entity.HasIndex(e => e.NombreCorto, "th_proveedores_unique").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.Direccion).HasMaxLength(150);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.NombreCorto).HasMaxLength(15);
            entity.Property(e => e.RFC).HasMaxLength(13);
            entity.Property(e => e.RazonSocial).HasMaxLength(150);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.cuentacontable_id).HasMaxLength(36);
            entity.Property(e => e.planimpuestos_id).HasMaxLength(36);
            entity.Property(e => e.regimenfiscal_Id).HasMaxLength(36);
            entity.Property(e => e.usocfdi_Id).HasMaxLength(3);

            entity.HasOne(d => d.planimpuestos).WithMany(p => p.th_proveedores)
                .HasForeignKey(d => d.planimpuestos_id)
                .HasConstraintName("th_proveedores_th_plan_impuestos_fk");

            entity.HasOne(d => d.regimenfiscal).WithMany(p => p.th_proveedores)
                .HasForeignKey(d => d.regimenfiscal_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_proveedores_th_regimenfiscal_FK");

            entity.HasOne(d => d.usocfdi).WithMany(p => p.th_proveedores)
                .HasForeignKey(d => d.usocfdi_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_proveedores_th_usocfdi_FK");
        });

        modelBuilder.Entity<th_regimenfiscal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(3);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Regimen).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
        });

        modelBuilder.Entity<th_sat_control>(entity =>
        {
            entity.HasKey(e => e.UUID).HasName("PRIMARY");

            entity.HasIndex(e => e.Existe, "th_sat_control_Existe_IDX");

            entity.Property(e => e.UUID).HasMaxLength(36);
            entity.Property(e => e.FechaDescarga).HasColumnType("datetime");
            entity.Property(e => e.FechaSolicitud).HasColumnType("datetime");
            entity.Property(e => e.Ruta).HasMaxLength(250);
        });

        modelBuilder.Entity<th_sat_metadata>(entity =>
        {
            entity.HasKey(e => e.uuid).HasName("PRIMARY");

            entity.Property(e => e.uuid).HasMaxLength(36);
            entity.Property(e => e.efectocomprobante).HasMaxLength(1);
            entity.Property(e => e.fechacancelacion).HasColumnType("datetime");
            entity.Property(e => e.fechacertificacionsat).HasColumnType("datetime");
            entity.Property(e => e.fechaemision).HasColumnType("datetime");
            entity.Property(e => e.monto).HasPrecision(18, 5);
            entity.Property(e => e.nombreemisor).HasMaxLength(200);
            entity.Property(e => e.nombrereceptor).HasMaxLength(200);
            entity.Property(e => e.rfcemisor).HasMaxLength(13);
            entity.Property(e => e.rfcpac).HasMaxLength(13);
            entity.Property(e => e.rfcreceptor).HasMaxLength(13);
        });

        modelBuilder.Entity<th_satsolicitudes>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PRIMARY");

            entity.Property(e => e.IdSolicitud).HasMaxLength(36);
            entity.Property(e => e.CodEstatus).HasMaxLength(10);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime");
            entity.Property(e => e.Mensaje).HasMaxLength(100);
            entity.Property(e => e.RfcEmisor).HasMaxLength(20);
            entity.Property(e => e.RfcSolicitante).HasMaxLength(20);
            entity.Property(e => e.TipoSolicitud).HasMaxLength(10);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
        });

        modelBuilder.Entity<th_satsolicitudrespuesta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.CodEstatus).HasMaxLength(10);
            entity.Property(e => e.CodigoEstatusSolicitud).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.IdPaquetes).HasMaxLength(4000);
            entity.Property(e => e.IdSolicitud).HasMaxLength(36);
            entity.Property(e => e.Mensaje).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
        });

        modelBuilder.Entity<th_tiposcambio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Origen).HasMaxLength(15);
            entity.Property(e => e.TipoCambio)
                .HasPrecision(18, 5)
                .HasDefaultValueSql("'1.00000'");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
        });

        modelBuilder.Entity<th_usocfdi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasMaxLength(4);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Id_UsoCFDi_Activo_UsuarioCreacion_)
                .HasMaxLength(128)
                .HasColumnName("Id;UsoCFDi;Activo;UsuarioCreacion;");
            entity.Property(e => e.UsoCFDi).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.c_UsoCFDI_Descripción_activo_usuario)
                .HasMaxLength(128)
                .HasColumnName("c_UsoCFDI;Descripción;activo;usuario");
        });

        modelBuilder.Entity<th_venta_factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.cliente_id, "th_venta_factura_th_clientes_fk");

            entity.HasIndex(e => e.condiciones_id, "th_venta_factura_th_condicionescredito_fk");

            entity.HasIndex(e => e.metodopago_Id, "th_venta_factura_th_metodopago_fk");

            entity.HasIndex(e => e.moneda_Id, "th_venta_factura_th_monedas_FK");

            entity.HasIndex(e => e.tipocambio_Id, "th_venta_factura_th_tiposcambio_FK");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Factura).HasMaxLength(36);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.MontoImpuestos).HasPrecision(18, 5);
            entity.Property(e => e.Observaciones).HasMaxLength(400);
            entity.Property(e => e.OrdenCompra).HasMaxLength(150);
            entity.Property(e => e.RutaAcuse).HasMaxLength(150);
            entity.Property(e => e.RutaPDF).HasMaxLength(150);
            entity.Property(e => e.RutaXML).HasMaxLength(150);
            entity.Property(e => e.SubTotal).HasPrecision(18, 5);
            entity.Property(e => e.SucursalEntrega).HasMaxLength(150);
            entity.Property(e => e.Total).HasPrecision(18, 5);
            entity.Property(e => e.UUID).HasMaxLength(36);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.asiento_Id).HasMaxLength(36);
            entity.Property(e => e.asientocancelado_Id).HasMaxLength(36);
            entity.Property(e => e.cliente_id).HasMaxLength(36);
            entity.Property(e => e.condiciones_id).HasMaxLength(36);
            entity.Property(e => e.formapago_Id)
                .HasMaxLength(2)
                .HasDefaultValueSql("'99'");
            entity.Property(e => e.metodopago_Id).HasMaxLength(3);
            entity.Property(e => e.moneda_Id).HasMaxLength(36);
            entity.Property(e => e.tipocambio_Id).HasMaxLength(36);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.th_venta_factura)
                .HasForeignKey<th_venta_factura>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_venta_factura_th_cuentascobrar_fk");

            entity.HasOne(d => d.cliente).WithMany(p => p.th_venta_factura)
                .HasForeignKey(d => d.cliente_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_venta_factura_th_clientes_fk");

            entity.HasOne(d => d.condiciones).WithMany(p => p.th_venta_factura)
                .HasForeignKey(d => d.condiciones_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_venta_factura_th_condicionescredito_fk");

            entity.HasOne(d => d.metodopago).WithMany(p => p.th_venta_factura)
                .HasForeignKey(d => d.metodopago_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_venta_factura_th_metodopago_fk");

            entity.HasOne(d => d.moneda).WithMany(p => p.th_venta_factura)
                .HasForeignKey(d => d.moneda_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_venta_factura_th_monedas_FK");

            entity.HasOne(d => d.tipocambio).WithMany(p => p.th_venta_factura)
                .HasForeignKey(d => d.tipocambio_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_venta_factura_th_tiposcambio_FK");
        });

        modelBuilder.Entity<th_venta_factura_comercio>(entity =>
        {
            entity.HasKey(e => e.factura_Id).HasName("PRIMARY");

            entity.Property(e => e.factura_Id).HasMaxLength(36);
            entity.Property(e => e.ClaveDePedimento).HasMaxLength(3);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Incoterm).HasMaxLength(3);
            entity.Property(e => e.TipoCambioUSD).HasPrecision(18, 4);
            entity.Property(e => e.TotalUSD).HasPrecision(18, 4);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.UsuarioModifica).HasMaxLength(50);
            entity.Property(e => e.Version).HasMaxLength(4);
        });

        modelBuilder.Entity<th_venta_factura_comercio_emisor>(entity =>
        {
            entity.HasKey(e => e.factura_Id).HasName("PRIMARY");

            entity.Property(e => e.factura_Id).HasMaxLength(36);
            entity.Property(e => e.Calle).HasMaxLength(250);
            entity.Property(e => e.CodigoPostal).HasMaxLength(5);
            entity.Property(e => e.Estado).HasMaxLength(5);
            entity.Property(e => e.Localidad).HasMaxLength(5);
            entity.Property(e => e.NumeroExterior).HasMaxLength(10);
            entity.Property(e => e.Pais).HasMaxLength(5);
        });

        modelBuilder.Entity<th_venta_factura_comercio_mercancias>(entity =>
        {
            entity.HasKey(e => new { e.factura_Id, e.Partida })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.factura_Id).HasMaxLength(36);
            entity.Property(e => e.CantidadAduana).HasPrecision(18, 2);
            entity.Property(e => e.FraccionArancelaria).HasMaxLength(10);
            entity.Property(e => e.NoIdentificacion).HasMaxLength(10);
            entity.Property(e => e.UnidadAduana).HasMaxLength(5);
            entity.Property(e => e.ValorDolares).HasPrecision(18, 2);
            entity.Property(e => e.ValorUnitarioAduana).HasPrecision(18, 2);
        });

        modelBuilder.Entity<th_venta_factura_comercio_receptor>(entity =>
        {
            entity.HasKey(e => e.factura_Id).HasName("PRIMARY");

            entity.Property(e => e.factura_Id).HasMaxLength(36);
            entity.Property(e => e.Calle).HasMaxLength(250);
            entity.Property(e => e.CodigoPostal).HasMaxLength(5);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Municipio).HasMaxLength(50);
            entity.Property(e => e.NumRegIdTrib).HasMaxLength(25);
            entity.Property(e => e.Pais).HasMaxLength(5);
        });

        modelBuilder.Entity<th_venta_factura_detalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.articulo_Id, "th_venta_factura_detalle_th_articulos_fk");

            entity.HasIndex(e => e.planimpuestos_Id, "th_venta_factura_detalle_th_plan_impuestos_fk");

            entity.HasIndex(e => e.factura_Id, "th_venta_factura_detalle_th_venta_factura_fk");

            entity.Property(e => e.Id).HasMaxLength(36);
            entity.Property(e => e.Cantidad).HasPrecision(18, 5);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Impuesto).HasPrecision(18, 6);
            entity.Property(e => e.SubTotal).HasPrecision(18, 6);
            entity.Property(e => e.Total).HasPrecision(18, 6);
            entity.Property(e => e.Unitario).HasPrecision(18, 5);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(50);
            entity.Property(e => e.articulo_Id).HasMaxLength(36);
            entity.Property(e => e.factura_Id).HasMaxLength(36);
            entity.Property(e => e.planimpuestos_Id).HasMaxLength(36);

            entity.HasOne(d => d.articulo).WithMany(p => p.th_venta_factura_detalle)
                .HasForeignKey(d => d.articulo_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_venta_factura_detalle_th_articulos_fk");

            entity.HasOne(d => d.factura).WithMany(p => p.th_venta_factura_detalle)
                .HasForeignKey(d => d.factura_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("th_venta_factura_detalle_th_venta_factura_fk");

            entity.HasOne(d => d.planimpuestos).WithMany(p => p.th_venta_factura_detalle)
                .HasForeignKey(d => d.planimpuestos_Id)
                .HasConstraintName("th_venta_factura_detalle_th_plan_impuestos_fk");
        });
    }
}