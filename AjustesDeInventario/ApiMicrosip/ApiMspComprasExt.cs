using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ApisMicrosip
{
    public class ApiMspComprasExt
    {
        //// Chequeo de errores
        // function cmGetLastErrorCode: Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int cmGetLastErrorCode();

        // function cmGetLastErrorMessage(ErrorMessage: PChar): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int cmGetLastErrorMessage(StringBuilder ErrorMessage);

        // procedure cmSetErrorHandling(ExceptionOnError, MessageOnException: Integer); stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern void cmSetErrorHandling(int ExceptionOnError, int MessageOnException);
                
        // function SetDBCompras(DBHandle: Integer): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int SetDBCompras(int DBHandle);

        // procedure AbortaDoctoCompras; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern void AbortaDoctoCompras();

        // function DireccionProveedorEventualDocCompras(CiudadId, EstadoId, PaisId: Integer;
        // NombreProv, Calle, CodigoPostal, Telefono1, Telefono2, Fax, Email, RfcCurp, Contacto: PChar): Integer; stdcall;   
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int DireccionProveedorEventualDocCompras(int CiudadId, int EstadoId, int PaisId,
          string NombreProv, string Calle, string CodigoPostal, string Telefono1, string Telefono2, string Fax,
          string Email, string RfcCurp, string Contacto);

        // Checar Compatibilidad
        // function GetVersionApiComprasAsInteger: Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int GetVersionApiComprasAsInteger();

        // procedure GetVersionApiComprasAsString(lVersion: PChar); stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern void GetVersionApiComprasAsString(StringBuilder lVersion);

        // function ChecaCompatibilidadCompras(HdbMetadatos: Integer): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int ChecaCompatibilidadCompras(int HdbMetadatos);

        // // Ordenes de compras
        // function NuevaOrdenCompra(Fecha, Folio: PChar; ProveedorId, DirConsigId, AlmacenId: Integer;
        //   FechaEntrega, TipoDscto: Pchar; Descuento: Double; Descripcion: PChar;
        //   CondPagoId, ViaEmbarqueId, ImptoSustituidoId, ImptoSustitutoId: Integer): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int NuevaOrdenCompra(string Fecha, string Folio, int ProveedorId, int DirConsigId, int AlmacenId,
          string FechaEntrega,  string TipoDscto, Double Descuento, string Descripcion,
          int CondPagoId, int ViaEmbarqueId, int ImptoSustituidoId, int ImptoSustitutoId, int MonedaId);

        // function RenglonOrdenCompra(ArticuloId: Integer; Unidades, PrecioUnitario, PctjeDscto: Double;
        //    Notas, TipoPrecio: PChar): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int RenglonOrdenCompra(int ArticuloId, Double Unidades, Double PrecioUnitario, 
          Double PctjeDscto, string Notas, string TipoPrecio);

        // function AplicaOrdenCompra: Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int AplicaOrdenCompra();

        // // Documentos de compras
        // function NuevaCompra(Fecha, Folio: PChar; ProveedorId, AlmacenId: Integer;
        //   TipoDscto: Pchar; Descuento, TipoCambio: Double;
        //   Factura, Descripcion: PChar;
        //   Fletes, OtrosCargos, GastosAduanales: Double;
        //   CondPagoId, ImptoSustituidoId, ImptoSustitutoId: Integer): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int NuevaCompra(string Fecha,string Folio,int ProveedorId,int AlmacenId,
           string TipoDscto, Double Descuento, Double TipoCambio,
           string Factura, string Descripcion,
           Double Fletes, Double OtrosCargos, Double GastosAduanales,
           int CondPagoId, int ImptoSustituidoId, int ImptoSustitutoId);

        // function RenglonCompra(ArticuloId: Integer; Unidades, PrecioUnitario, PctjeDscto: Double;
        //    Notas, TipoPrecio: PChar): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int RenglonCompra(int ArticuloId, Double Unidades, Double PrecioUnitario, Double PctjeDscto,
          string Notas, string TipoPrecio);

        // function CompraPedimento(ClavePedimento, FechaPedimento,
        //   AduanaPedimento: PChar): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int CompraPedimento(string ClavePedimento, 
          string FechaPedimento, string AduanaPedimento);

        // function RenglonCompraLotes(ClaveLote, FechaCaducidad: PChar;
        //   Unidades: Double): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int RenglonCompraLotes(string ClaveLote, string FechaCaducidad,
          Double Unidades);

        // function RenglonCompraSeries(ClaveSerie: PChar; NumConsecutivos:
        //   Integer): Integer; stdcall;
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int RenglonCompraSeries(string ClaveSerie, int NumConsecutivos);

        // function AplicaCompra: Integer; stdcall;  
        [DllImport("ApiMspCompras.dll", SetLastError = true)]
        public static extern int AplicaCompra();

        //public ApiMspComprasExt()
        //{   
        //}
    }
}
