/*
Crear un proyecto de tipo biblioteca de clases que contenga la clase Producto.

https://codeutnfra.github.io/programacion_2_laboratorio_2_apuntes/assets/images/producto-diagram-765be2d7770aabd572e603a495bef7a2.png

1. Todos sus atributos son privados.
2. Posee sólo un constructor de instancia.
3. El método "GetMarca", retornará el valor correspondiente al atributo "marca".
4. También poseerá el atributo "codigoDeBarras", el cual se publicará sólo a través de la conversión explícita nombrada más adelante.
5. El método de clase (estático) "MostrarProducto" es público y retornará una cadena detallando los atributos de la clase.
6. Posee las siguientes sobrecargas de operadores:
    i. "explicit": Realizará la conversión de un objeto "Producto" a "string". Sólo retornará el atributo "codigoDeBarras" del producto.
    ii. "== (Producto, Producto)": Retornará "true" si las marcas y códigos de barra son iguales, "false" caso contrario.
    iii. "== (Producto, string)": Retornará "true" si la marca del producto coincide con la cadena pasada como argumento, "false" caso contrario.

 */

using System;

namespace Biblioteca
{
    public class Producto
    {
        private string codigoDeBarra;
        private string marca;
        private float precio;

        public Producto(string marca, string codigoDeBarra, float precio)
        {
            this.marca = marca;
            this.codigoDeBarra = codigoDeBarra;
            this.precio = precio;
        }

        public string GetMarca()
        {
            return this.marca;
        }

        public float GetPrecio()
        {
            return this.precio;
        }

        public static string MostrarProducto (Producto p)
        {
            return $"Marca {p.marca} - Codigo {p.codigoDeBarra} - Precio {p.precio}";
        }

        public static explicit operator string(Producto p)
        {
            return p.codigoDeBarra;
        }

        public static bool operator == (Producto p1, Producto p2)
        {
            if (p1 is not null && p2 is not null)
            {
                return p1.marca == p2.marca && p1.codigoDeBarra == p2.codigoDeBarra;
            }
            return false;
        }

        public static bool operator !=(Producto p1, Producto p2)
        {
            return !(p1 == p2);
        }

        public static bool operator ==(Producto p1, string marca)
        {
            return p1.marca == marca;
        }

        public static bool operator !=(Producto p1, string marca)
        {
            return !(p1.marca == marca);
        }
    }
}
