using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guardar en un archivo de texto en el escritorio de la computadora.
        /// </summary>
        /// <param name="texto"></param> texto a guardar.
        /// <param name="archivo"></param> nombre del archivo (sin ubicacion ni extension).
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            try
            {
                archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo + ".txt";
                
                FileStream fs = new FileStream(archivo, FileMode.Append, FileAccess.Write);

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(texto);
                    //sw.Close(); Al usar using no hace falta cerrar este archivo.
                }
                fs.Close();                
            }
            catch (ArgumentException)
            {
                string fallo = "Error en la ruta";
                throw new ArgumentException(fallo);
            }
            catch (FileNotFoundException)
            {
                string fallo = "Error en la ruta";
                throw new FileNotFoundException(fallo);
            }
            catch (DirectoryNotFoundException)
            {
                string fallo = "Error en la ruta";
                throw new DirectoryNotFoundException(fallo);
            }
            catch (IOException)
            {
                string fallo = "Archivo en uso";
                throw new IOException(fallo);
            }
            catch (NotSupportedException)
            {
                string fallo = "La ruta contiene caracteres no aceptados";
                throw new NotSupportedException(fallo);
            }
            catch (System.Security.SecurityException)
            {
                string fallo = "El usuario no tiene los permisos necesarios";
                throw new System.Security.SecurityException(fallo);
            }
            catch (InvalidOperationException)
            {
                string fallo = "Nombre no encontrado";
                throw new InvalidOperationException(fallo);
            }
            return true;
        }
    }
}
