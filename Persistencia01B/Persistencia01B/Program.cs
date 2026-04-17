/*
 * Creado por SharpDevelop.
 * Usuario: Luis Alvarez
 * Fecha: 17/4/2026
 * Hora: 2:16 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace Persistencia01B
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Taller Sección B");
			
			// directorio
			
			string rutaRaiz  = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DATOSIUJO");
			
			string rutaReportes = Path.Combine(rutaRaiz, "REPORTES");
			Console.WriteLine(rutaRaiz);
			Console.WriteLine(rutaReportes);
			
			if(!Directory.Exists(rutaReportes)){
			//crear el directorio "reportes"
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("Directorio creado correctamente");
			   }
			
			//
				
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}