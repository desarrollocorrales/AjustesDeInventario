using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ApisMicrosip
{
    public class ApiMspCxcExt
    {  
        //function ccGetLastErrorCode: Integer; stdcall;
        [DllImport("ApiMspCxc.dll", SetLastError = true)]
        public static extern int ccGetLastErrorCode();

        //function ccGetLastErrorMessage(ErrorMessage: PChar): Integer; stdcall;
        [DllImport("ApiMspCxc.dll", SetLastError = true)]
        public static extern int ccGetLastErrorMessage(StringBuilder ErrorMessage);
        
        //procedure ccSetErrorHandling(ExceptionOnError, MessageOnException: Integer); stdcall;
        [DllImport("ApiMspCxc.dll", SetLastError = true)]
        public static extern void ccSetErrorHandling(int ExceptionOnError, int MessageOnException);

		//function SetDBCxc(DBHandle: Integer): Integer; stdcall;
        [DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern int SetDBCxc(int DBHandle);

        // function GetDoctoCCId(var DoctoId: Integer): Integer;  stdcall;
        [DllImport("ApiMspCxc.dll", SetLastError = true)]
        public static extern int GetDoctoCCId(ref int DoctoId);
        
        //function NuevoCreditoCc(ConceptoCcId: Integer; Fecha, Folio: PChar;
		//    ClienteId: Integer; Descripcion: PChar; CobradorId: Integer; PLHandle: Integer): Integer; stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern int NuevoCreditoCc(int ConceptoCcId, string Fecha, string Folio,
		  int ClienteId, string Descripcion, int CobradorId, int PLHandle);

		//function AplicaCreditoCc: Integer; stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern int AplicaCreditoCc();

		//function RenglonCreditoImpuestoCc(ImpuestoId: Integer;
		//    Importe, Impuesto: Double): Integer; stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern int RenglonCreditoImpuestoCc(int ImpuestoId,
		  double Importe, double Impuesto);

		//function RenglonCreditoCc(TipoImporte: PChar; CargoId: Integer; FolioCargo: PChar;
		//    Importe, Impuesto, IvaRetenido, IsrRetenido, DsctoPpag: Double): Integer; stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern int RenglonCreditoCc(string TipoImporte, int CargoId, string FolioCargo,
		  double Importe, double Impuesto, double IvaRetenido, double IsrRetenido, double DsctoPpag);

		//procedure AbortaDoctoCxc; stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern void AbortaDoctoCxc();

		//// Checar Compatibilidad
		//function GetVersionApiCxcAsInteger: Integer; stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern int GetVersionApiCxcAsInteger();

		//procedure GetVersionApiCxcAsString(lVersion: PChar); stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern void GetVersionApiCxcAsString(StringBuilder GetVersionApiCxcAsString);

		//function ChecaCompatibilidadCxc(HdbMetadatos: Integer): Integer; stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern int ChecaCompatibilidadCxc(int HdbMetadatos);

                //function GetImporteMonedaCliente(ClienteId: Integer; FormaCobroId: Integer;
                //    ImporteCobro: Double; Fecha: PChar; var Importe: Double): Integer; stdcall;
		[DllImport("ApiMspCxc.dll", SetLastError = true)]
		public static extern int GetImporteMonedaCliente(int ClienteId, int FormaCobroId,
                  double ImporteCobro, string Fecha, ref double Importe);

    }
}


