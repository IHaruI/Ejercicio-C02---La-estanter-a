/*

Generar la clase Estante.

https://codeutnfra.github.io/programacion_2_laboratorio_2_apuntes/assets/images/estante-diagram-92964e4b26abc3145cc9d7366cad5bab.png

1. Posee dos atributos privados. Uno será un entero que indicará la ubicación del estante y el otro es un array de tipo "Producto".
2. El constructor de instancia privado será el único que incializará el array. La sobrecarga pública del constructor inicializará la ubicación del estante, recibiendo como parámetros la capacidad y la ubicación. Reutilizar código.
3. El método público "GetProductos", retornará el array de productos.
4. El método público de clase (estático) "MostrarEstante", retornará una cadena con toda la información del estante incluyendo el detalle de cada uno de sus productos. Reutilizar código.
5. Posee las siguientes sobrecargas de operadores:
    i. "==": Retornará "true" si es que el producto ya se encuentra en el estante, "false" caso contrario.
    ii. "+": Retornará "true" y agregará el producto si el estante posee capacidad de almacenar al menos un producto más y dicho producto no se encuentra en el estante, "false" caso contrario. Reutilizar código.
    iii. "-": Retornará un estante sin el producto, siempre y cuando el producto se encuentre en el listado. Reutilizar código.

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Estante
    {
        private Producto[] productos;
        private int ubicacionEstante;
        private Estante(int capacidad)
        {
            this.productos = new Producto[capacidad];
        }

        public Estante(int capacidad, int ubicacion) : this (capacidad)
        {
            this.ubicacionEstante = ubicacion;
        }

        public Producto[] GetProductos()
        {
            return this.productos;
        }

        public static string MostrarEstante(Estante e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Ubicacion del estante: {e.ubicacionEstante}");

            foreach (Producto producto in e.productos)
            {
                sb.AppendLine(Producto.MostrarProducto(producto));
            }

            return sb.ToString();
        }

        public static bool operator +(Estante e, Producto p)
        {
            if (e != p)
            {
                for (int i = 0; i < e.productos.Length; i++)
                {
                    if (e.productos[i] is null)
                    {
                        e.productos[i] = p;
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator ==(Estante e, Producto p)
        {
            foreach (Producto producto in e.productos)
            {
                if (producto == p)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Estante e, Producto p)
        {
            return !(e == p);
        }

        public static Estante operator -(Estante e, Producto p)
        {
            if (e == p)
            {
                for (int i = 0; i < e.productos.Length; i++)
                {
                    if (e.productos[i] == p)
                    {
                        e.productos[i] = null;
                    }
                }
            }
            return e;
        }
    }
}
