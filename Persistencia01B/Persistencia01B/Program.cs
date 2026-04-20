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

namespace TallerIUJO_Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TALLER: INGENIERÍA DE CADENAS Y ARCHIVOS ===");

            // --- Prueba del Desafío 1 ---
            // Simulación de entrada: usuario y clave separada por punto y coma
            ValidarSeguridad("estudiante_iujo;acceso123_temp");

            // --- Prueba del Desafío 2 ---
            // Se requiere que el archivo 'avatar.jpg' exista en la carpeta del ejecutable
            ClonarImagen();

            // --- Prueba del Desafío 3 ---
            // Escaneo de archivos en el directorio actual del programa
            string rutaActual = AppDomain.CurrentDomain.BaseDirectory;
            GestionarArchivosPesados(rutaActual);

            Console.WriteLine("\nOperaciones finalizadas. Presione una tecla para cerrar.");
            Console.ReadKey();
        }

// Desafío 1: El Validador de Seguridad
        static void ValidarSeguridad(string registro)
        {
        // Uso de .Split para separar los campos de la cadena
            string[] campos = registro.Split(';');
            string usuario = campos[0];
            string clave = campos[1];

   // Verificación de clave débil usando .Contains
            if (clave.Contains("123"))
            {
           // Se utiliza StreamWriter con el mandato 'using' para asegurar el cierre del archivo
                using (StreamWriter sw = new StreamWriter("seguridad.txt", true))
                {
                    sw.WriteLine("ALERTA: Clave Débil detectada para el usuario: " + usuario);
                }
                Console.WriteLine("1. Registro de seguridad generado exitosamente.");
            }
        }

     // Desafío 2: El Clonador de Imágenes (FileStream) 
        static void ClonarImagen()
        {
            string origen = "avatar.jpg";
            string destino = "respaldo.jpg";

       if (File.Exists(origen)) // Verificación previa para evitar excepciones 
            {
           // Implementación de Nivel 5: Ingeniería Atómica con FileStream 
                using (FileStream fsLectura = new FileStream(origen, FileMode.Open, FileAccess.Read))
                using (FileStream fsEscritura = new FileStream(destino, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024]; // Buffer sugerido de 1024 bytes 
                    int cantidadLeida;

               // Lectura y escritura secuencial byte a byte mediante el buffer 
                    while ((cantidadLeida = fsLectura.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsEscritura.Write(buffer, 0, cantidadLeida);
                    }
                }
                Console.WriteLine("2. Imagen clonada correctamente: " + destino);
            }
            else
            {
                Console.WriteLine("3. Error: El archivo origen 'avatar.jpg' no fue localizado.");
            }
        }

        // Desafío 3: El Buscador de Archivos Pesados 
        static void GestionarArchivosPesados(string directorio)
        {
          // Obtención de todos los archivos en la ruta especificada
            string[] archivos = Directory.GetFiles(directorio);

            foreach (string rutaArchivo in archivos)
            {
             // Uso de la clase FileInfo para inspeccionar metadatos (Nivel 3)
                FileInfo info = new FileInfo(rutaArchivo);
                
         // Filtro para archivos mayores a 5KB (5000 bytes aprox.)
                if (info.Length > 5000)
                {
                    // La instrucción File.Delete(rutaArchivo) se mantiene comentada para 
                    // prevenir el borrado accidental de archivos del sistema durante la prueba.
                    Console.WriteLine("4. Archivo pesado detectado (>5KB): " + info.Name);
                }
            }
        }
    }
}